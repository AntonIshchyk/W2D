using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Comments;

namespace Backend.Services;

public class CommentService : ICommentService
{
    private static CommentResponse ProjectComment(Comment c, int? currentUserId)
    {
        return new CommentResponse
        {
            Id = c.Id,
            Content = c.IsDeleted ? "[deleted]" : c.Content,
            UserId = c.UserId,
            UserName = c.User.Name,
            PostId = c.PostId,
            Score = c.Score,
            CurrentUserVote = currentUserId.HasValue ?
                c.Votes.Where(v => v.UserId == currentUserId.Value).Select(v => (int?)v.Value).FirstOrDefault()
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

    public async Task<List<CommentResponse>> GetCommentsAsync(int postId, int page = 1, int pageSize = 20, int? currentUserId = null)
    {
        var rootQuery = _context.Comments
            .AsNoTracking()
            .Where(c => c.PostId == postId && c.ParentCommentId == null);

        var rootsProjected = await rootQuery
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => ProjectComment(c, currentUserId))
            .ToListAsync();

        if (!rootsProjected.Any())
            return new List<CommentResponse>();

        var rootIds = rootsProjected.Select(r => r.Id).ToList();

        const int RepliesPerRoot = 5;
        var replies = await _context.Comments
            .AsNoTracking()
            .Where(c => c.PostId == postId && c.ParentCommentId != null && rootIds.Contains(c.ParentCommentId.Value))
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .Select(c => ProjectComment(c, currentUserId))
            .ToListAsync();

        var rootsDict = rootsProjected.ToDictionary(r => r.Id);
        var grouped = replies.GroupBy(r => r.ParentCommentId).ToDictionary(g => g.Key!.Value, g => g.Take(RepliesPerRoot).ToList());
        foreach (var kv in grouped)
        {
            var parentId = kv.Key;
            if (!rootsDict.TryGetValue(parentId, out var parent)) continue;
            foreach (var child in kv.Value)
            {
                parent.Replies.Add(child);
            }
        }

        void SortTree(CommentResponse node)
        {
            node.Replies = node.Replies
                .OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.CreatedAt)
                .ToList();

            foreach (var child in node.Replies)
                SortTree(child);
        }

        foreach (var root in rootsProjected)
            SortTree(root);

        CommentResponse? Prune(CommentResponse node)
        {
            node.Replies = node.Replies
                .Select(Prune)
                .OfType<CommentResponse>()
                .ToList();

            if (!node.IsDeleted) return node;
            return node.Replies.Count > 0 ? node : null;
        }

        var finalRoots = rootsProjected
            .Select(Prune)
            .OfType<CommentResponse>()
            .ToList();

        return finalRoots;
    }

    public async Task<CommentResponse?> CreateCommentAsync(int postId, CreateCommentRequest request, int userId)
    {
        Comment comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.PostId = postId;

        using var tx = await _context.Database.BeginTransactionAsync();

        var postExists = await _context.Posts.AnyAsync(p => p.Id == postId);
        if (!postExists)
        {
            return null;
        }

        if (request.ParentCommentId.HasValue)
        {
            var parent = await _context.Comments.FirstOrDefaultAsync(
                c => c.Id == request.ParentCommentId.Value && c.PostId == postId && !c.IsDeleted);
            if (parent == null)
            {
                return null;
            }
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var updated = await _context.Posts
            .Where(p => p.Id == postId)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + 1));

        if (updated == 0)
        {
            return null;
        }

        await tx.CommitAsync();

        var response = await _context.Comments
            .AsNoTracking()
            .Where(c => c.Id == comment.Id)
            .Select(c => ProjectComment(c, userId))
            .FirstOrDefaultAsync();

        if (response == null)
            return null;

        response.CurrentUserVote = 0;
        return response;
    }

    public async Task<List<CommentResponse>> GetRepliesAsync(int parentCommentId, int page = 1, int pageSize = 5, int? currentUserId = null)
    {
        var query = _context.Comments
            .AsNoTracking()
            .Where(c => c.ParentCommentId == parentCommentId);

        var replies = await query
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => ProjectComment(c, currentUserId))
            .ToListAsync();

        return replies;
    }

    public async Task<bool> DeleteCommentAsync(int commentId, int userId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null || comment.UserId != userId)
            return false;

        if (comment.IsDeleted)
            return false;

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> VoteCommentAsync(int commentId, int userId, int value)
    {
        if (value < -1 || value > 1)
            return false;

        Comment? comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId && !c.IsDeleted);
        if (comment == null)
            return false;

        CommentVote? existingVote = await _context.CommentVotes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId);

        int oldValue = existingVote?.Value ?? 0;

        int delta = value - oldValue;
        if (delta == 0)
            return true;

        if (value == 0)
        {
            if (existingVote != null)
                _context.CommentVotes.Remove(existingVote);
        }
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
                if (attempt == maxRetries - 1)
                    throw;

                await _context.Entry(comment).ReloadAsync();
                comment.Score += delta;
                comment.UpdatedAt = DateTime.UtcNow;
            }
        }

        return false;
    }
}
