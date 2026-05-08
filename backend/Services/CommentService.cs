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
    private enum CommentTarget
    {
        Post,
        Place
    }

    private static Expression<Func<Comment, CommentResponse>> ProjectComment(int? currentUserId)
    {
        return c => new CommentResponse
        {
            Id = c.Id,
            Content = c.IsDeleted ? "[deleted]" : (c.Content ?? string.Empty),
            UserId = c.IsDeleted ? 0 : c.UserId,
            UserName = c.IsDeleted ? null : c.User.Username,
            UserPhotoUrl = c.IsDeleted ? null : c.User.ProfilePhotoUrl,
            PostId = c.PostId,
            PlaceId = c.PlaceId,
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
        return await GetCommentsAsync(CommentTarget.Post, postId, currentUserId);
    }

    public async Task<List<CommentResponse>> GetPlaceCommentsAsync(int placeId, int? currentUserId = null)
    {
        return await GetCommentsAsync(CommentTarget.Place, placeId, currentUserId);
    }

    private async Task<List<CommentResponse>> GetCommentsAsync(CommentTarget target, int entityId, int? currentUserId = null)
    {
        IQueryable<Comment> query = _context.Comments
            .AsNoTracking()
            .IgnoreQueryFilters();

        query = target == CommentTarget.Post
            ? query.Where(c => c.PostId == entityId)
            : query.Where(c => c.PlaceId == entityId);

        var allComments = await query
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
        return await CreateCommentAsync(CommentTarget.Post, postId, request, userId);
    }

    public async Task<Result<CommentResponse>> CreatePlaceCommentAsync(int placeId, CreateCommentRequest request, int userId)
    {
        return await CreateCommentAsync(CommentTarget.Place, placeId, request, userId);
    }

    private async Task<Result<CommentResponse>> CreateCommentAsync(CommentTarget target, int entityId, CreateCommentRequest request, int userId)
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
        if (target == CommentTarget.Post)
        {
            comment.PostId = entityId;

            bool postExists = await _context.Posts.AnyAsync(p => p.Id == entityId);
            if (!postExists)
            {
                return Result<CommentResponse>.NotFound("Post not found.");
            }
        }
        else
        {
            comment.PlaceId = entityId;

            bool placeExists = await _context.Places.AnyAsync(p => p.Id == entityId);
            if (!placeExists)
            {
                return Result<CommentResponse>.NotFound("Place not found.");
            }
        }

        if (request.ParentCommentId.HasValue)
        {
            bool parentExists = await _context.Comments.AnyAsync(c =>
                c.Id == request.ParentCommentId.Value &&
                !c.IsDeleted &&
                (target == CommentTarget.Post ? c.PostId == entityId : c.PlaceId == entityId));

            if (!parentExists)
            {
                return Result<CommentResponse>.NotFound("Parent comment not found.");
            }
        }

        using var tx = await _context.Database.BeginTransactionAsync();

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        if (target == CommentTarget.Post)
        {
            await _context.Posts
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + 1));
        }
        else
        {
            await _context.Places
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + 1));
        }

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

    public async Task<Result<CommentResponse>> UpdateCommentAsync(int postId, int commentId, UpdateCommentRequest request, int userId)
    {
        return await UpdateCommentAsync(CommentTarget.Post, postId, commentId, request, userId);
    }

    public async Task<Result<CommentResponse>> UpdatePlaceCommentAsync(int placeId, int commentId, UpdateCommentRequest request, int userId)
    {
        return await UpdateCommentAsync(CommentTarget.Place, placeId, commentId, request, userId);
    }

    private async Task<Result<CommentResponse>> UpdateCommentAsync(CommentTarget target, int entityId, int commentId, UpdateCommentRequest request, int userId)
    {
        if (!PhotoUrlValidationExtensions.TryValidateOptionalPhotoUrl(request.PhotoUrl, nameof(request.PhotoUrl), out string? photoUrlError))
        {
            return Result<CommentResponse>.Invalid(photoUrlError!);
        }

        if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.PhotoUrl))
        {
            return Result<CommentResponse>.Invalid("Content or PhotoUrl is required.");
        }

        Comment? comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId && (target == CommentTarget.Post ? c.PostId == entityId : c.PlaceId == entityId));

        if (comment == null)
        {
            return Result<CommentResponse>.NotFound("Comment not found.");
        }

        if (comment.UserId != userId)
        {
            return Result<CommentResponse>.Unauthorized("You do not have permission to edit this comment.");
        }

        comment.Content = request.Content?.Trim();
        comment.PhotoUrl = request.PhotoUrl;
        comment.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

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
        return await DeleteCommentAsync(CommentTarget.Post, postId, commentId, userId);
    }

    public async Task<Result<bool>> DeletePlaceCommentAsync(int placeId, int commentId, int userId)
    {
        return await DeleteCommentAsync(CommentTarget.Place, placeId, commentId, userId);
    }

    private async Task<Result<bool>> DeleteCommentAsync(CommentTarget target, int entityId, int commentId, int userId)
    {
        Comment? comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId && (target == CommentTarget.Post ? c.PostId == entityId : c.PlaceId == entityId));

        if (comment == null || comment.IsDeleted)
        {
            return Result<bool>.NotFound("Comment not found.");
        }

        if (comment.UserId != userId)
        {
            return Result<bool>.Unauthorized("You do not have permission to delete this comment.");
        }

        using var tx = await _context.Database.BeginTransactionAsync();

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        if (target == CommentTarget.Post)
        {
            await _context.Posts
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.CommentCount, x => x.CommentCount - 1));
        }
        else
        {
            await _context.Places
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.CommentCount, x => x.CommentCount - 1));
        }

        await tx.CommitAsync();

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> VoteCommentAsync(int postId, int commentId, int userId, int value)
    {
        return await VoteCommentAsync(CommentTarget.Post, postId, commentId, userId, value);
    }

    public async Task<Result<bool>> VotePlaceCommentAsync(int placeId, int commentId, int userId, int value)
    {
        return await VoteCommentAsync(CommentTarget.Place, placeId, commentId, userId, value);
    }

    private async Task<Result<bool>> VoteCommentAsync(CommentTarget target, int entityId, int commentId, int userId, int value)
    {
        if (value is not (-1 or 0 or 1))
        {
            return Result<bool>.Invalid("Vote value must be -1, 0, or 1.");
        }

        bool commentExists = await _context.Comments
            .AnyAsync(c => c.Id == commentId && !c.IsDeleted && (target == CommentTarget.Post ? c.PostId == entityId : c.PlaceId == entityId));

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
