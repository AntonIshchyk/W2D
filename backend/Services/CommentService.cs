using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Comments;
using Backend.Contracts.Common;
using Backend.Extensions;
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
            UserPhotoUrl = c.User.ProfilePhotoUrl,
            PostId = c.PostId,
            Score = c.Score,
            PhotoUrl = c.PhotoUrl,
            CurrentUserVote = currentUserId.HasValue
                ? c.Votes
                    .Where(v => v.UserId == currentUserId.Value)
                    .Select(v => (int?)v.Value)
                    .FirstOrDefault() ?? 0
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

    public async Task<Result<CommentResponse>> CreateCommentAsync(int postId, CreateCommentRequest request, int userId)
    {
        if (!PhotoUrlValidationExtensions.TryValidateOptionalPhotoUrl(request.PhotoUrl, nameof(request.PhotoUrl), out string? photoUrlError))
        {
            return Result<CommentResponse>.Invalid(photoUrlError!);
        }

        if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.PhotoUrl))
        {
            return Result<CommentResponse>.Invalid("Content or PhotoUrl is required.");
        }

        Comment comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.PostId = postId;

        bool postExists = await _context.Posts.AnyAsync(p => p.Id == postId);
        if (!postExists)
        {
            return Result<CommentResponse>.NotFound("Post not found.");
        }

        if (request.ParentCommentId.HasValue)
        {
            bool parentExists = await _context.Comments.AnyAsync(
                c => c.Id == request.ParentCommentId.Value &&
                     c.PostId == postId &&
                     !c.IsDeleted);

            if (!parentExists)
            {
                return Result<CommentResponse>.NotFound("Parent comment not found.");
            }
        }

        using var tx = await _context.Database.BeginTransactionAsync();

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

        if (response == null)
        {
            return Result<CommentResponse>.NotFound("Comment not found.");
        }

        return Result<CommentResponse>.Success(response);
    }

    public async Task<Result<bool>> DeleteCommentAsync(int postId, int commentId, int userId)
    {
        Comment? comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId && c.PostId == postId);

        if (comment == null || comment.IsDeleted)
        {
            return Result<bool>.NotFound("Comment not found.");
        }

        if (comment.UserId != userId)
        {
            return Result<bool>.Unauthorized("You do not have permission to delete this comment.");
        }

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;

        await _context.Posts
            .Where(p => p.Id == comment.PostId)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.CommentCount, x => x.CommentCount - 1));

        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> VoteCommentAsync(int postId, int commentId, int userId, int value)
    {
        if (value is not (-1 or 0 or 1))
        {
            return Result<bool>.Invalid("Vote value must be -1, 0, or 1.");
        }

        bool commentExists = await _context.Comments
            .AnyAsync(c => c.Id == commentId && c.PostId == postId && !c.IsDeleted);

        if (!commentExists)
        {
            return Result<bool>.NotFound("Comment not found.");
        }

        CommentVote? existingVote = await _context.CommentVotes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId);

        int oldValue = existingVote?.Value ?? 0;
        int delta = value - oldValue;

        if (delta == 0)
        {
            return Result<bool>.Success(true);
        }

        using var tx = await _context.Database.BeginTransactionAsync();

        if (value == 0 && existingVote != null)
        {
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

        await _context.SaveChangesAsync();

        await _context.Comments
            .Where(c => c.Id == commentId)
            .ExecuteUpdateAsync(c => c
                .SetProperty(x => x.Score, x => x.Score + delta)
                .SetProperty(x => x.UpdatedAt, DateTime.UtcNow));

        await tx.CommitAsync();

        return Result<bool>.Success(true);
    }
}
