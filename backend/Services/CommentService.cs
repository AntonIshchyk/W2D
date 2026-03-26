using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Comments;
using System.Linq.Expressions;

namespace Backend.Services;

public class CommentService : ICommentService
{
    private static Expression<Func<Comment, CommentResponse>> ProjectComment(int? currentUserId)
    {
        return c => new CommentResponse
        {
            Id = c.Id,
            Content = c.IsDeleted ? "[deleted]" : (c.Content ?? string.Empty),
            UserId = c.UserId,
            UserName = c.User.Username,
            PostId = c.PostId,
            Score = c.Score,
            PhotoUrl = c.PhotoUrl,
            CurrentUserVote = currentUserId.HasValue
                ? c.Votes
                    .Where(v => v.UserId == currentUserId.Value)
                    .Select(v => (int?)v.Value)
                    .FirstOrDefault()
                : null,
            IsDeleted = c.IsDeleted,
            ParentCommentId = c.ParentCommentId,
            Replies = new List<CommentResponse>(),
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        };
    }

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CommentResponse>> GetCommentsAsync(int postId, int? currentUserId = null)
    {
        var allComments = await _context.Comments
            .AsNoTracking()
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .Select(ProjectComment(currentUserId))
            .ToListAsync();

        if (!allComments.Any())
            return new List<CommentResponse>();

        var lookup = allComments.ToLookup(c => c.ParentCommentId);

        List<CommentResponse> BuildTree(int? parentId)
        {
            return lookup[parentId]
                .Select(c =>
                {
                    c.Replies = BuildTree(c.Id)
                        .OrderByDescending(r => r.Score)
                        .ThenByDescending(r => r.CreatedAt)
                        .ToList();
                    return c;
                })
                .ToList();
        }

        var roots = BuildTree(null);

        CommentResponse? Prune(CommentResponse node)
        {
            node.Replies = node.Replies
                .Select(Prune)
                .OfType<CommentResponse>()
                .ToList();

            if (!node.IsDeleted) return node;
            return node.Replies.Count > 0 ? node : null;
        }

        return roots.Select(Prune).OfType<CommentResponse>().ToList();
    }

    public async Task<CommentResponse?> CreateCommentAsync(int postId, CreateCommentRequest request, int userId)
    {
        Comment comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.PostId = postId;

        using var tx = await _context.Database.BeginTransactionAsync();

        var postExists = await _context.Posts.AnyAsync(p => p.Id == postId);
        if (!postExists) return null;

        if (request.ParentCommentId.HasValue)
        {
            var parent = await _context.Comments.FirstOrDefaultAsync(
                c => c.Id == request.ParentCommentId.Value &&
                     c.PostId == postId &&
                     !c.IsDeleted);

            if (parent == null) return null;
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        await _context.Posts
            .Where(p => p.Id == postId)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + 1));

        await tx.CommitAsync();

        var response = await _context.Comments
            .AsNoTracking()
            .Where(c => c.Id == comment.Id)
            .Select(ProjectComment(userId))
            .FirstOrDefaultAsync();

        if (response == null) return null;

        response.CurrentUserVote = 0;
        return response;
    }

    public async Task<bool> DeleteCommentAsync(int postId, int commentId, int userId)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId && c.PostId == postId);

        if (comment == null || comment.UserId != userId || comment.IsDeleted)
            return false;

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;

        // Decrement CommentCount on the related post
        await _context.Posts
            .Where(p => p.Id == comment.PostId)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.CommentCount, x => x.CommentCount - 1));

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> VoteCommentAsync(int postId, int commentId, int userId, int value)
    {
        if (value < -1 || value > 1) return false;

        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId && c.PostId == postId && !c.IsDeleted);

        if (comment == null) return false;

        var existingVote = await _context.CommentVotes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId);

        int oldValue = existingVote?.Value ?? 0;
        int delta = value - oldValue;

        if (delta == 0) return true;

        if (value == 0 && existingVote != null)
            _context.CommentVotes.Remove(existingVote);
        else if (existingVote != null)
        {
            existingVote.Value = value;
            existingVote.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            _context.CommentVotes.Add(new CommentVote
            {
                UserId = userId,
                CommentId = commentId,
                Value = value
            });
        }

        comment.Score += delta;
        comment.UpdatedAt = DateTime.UtcNow;

        const int maxRetries = 3;

        for (int attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (attempt == maxRetries - 1) throw;

                await _context.Entry(comment).ReloadAsync();
                comment.Score += delta;
                comment.UpdatedAt = DateTime.UtcNow;
            }
        }

        return false;
    }
}
