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
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    private static IQueryable<Comment> FilterByTarget(IQueryable<Comment> query, CommentTarget target, int entityId) =>
        target == CommentTarget.Post
            ? query.Where(c => c.PostId == entityId)
            : query.Where(c => c.PlaceId == entityId);

    private static async Task UpdateCommentCount(AppDbContext context, CommentTarget target, int entityId, int delta)
    {
        if (target == CommentTarget.Post)
        {
            await context.Posts
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + delta));
        }
        else
        {
            await context.Places
                .Where(p => p.Id == entityId)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + delta));
        }
    }

    private async Task<bool> EntityExistsAsync(CommentTarget target, int entityId) =>
        target == CommentTarget.Post
            ? await _context.Posts.AnyAsync(p => p.Id == entityId)
            : await _context.Places.AnyAsync(p => p.Id == entityId);

    public async Task<List<CommentResponse>> GetCommentsAsync(int entityId, CommentTarget target, int? currentUserId = null)
    {
        var query = _context.Comments.AsNoTracking().IgnoreQueryFilters();
        query = FilterByTarget(query, target, entityId);

        var allComments = await query
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .Select(ProjectComment(currentUserId))
            .ToListAsync();

        if (!allComments.Any())
            return new List<CommentResponse>();

        var lookup = allComments.ToLookup(c => c.ParentCommentId);

        List<CommentResponse> BuildTree(int? parentId) =>
            lookup[parentId]
                .Select(c =>
                {
                    c.Replies = BuildTree(c.Id)
                        .OrderByDescending(r => r.Score)
                        .ThenByDescending(r => r.CreatedAt)
                        .ToList();
                    return c;
                })
                .ToList();

        CommentResponse? Prune(CommentResponse node)
        {
            node.Replies = node.Replies.Select(Prune).OfType<CommentResponse>().ToList();
            if (!node.IsDeleted) return node;
            return node.Replies.Count > 0 ? node : null;
        }

        return BuildTree(null).Select(Prune).OfType<CommentResponse>().ToList();
    }

    public async Task<Result<CommentResponse>> CreateCommentAsync(int entityId, CommentTarget target, CreateCommentRequest request, int userId)
    {
        if (!PhotoUrlValidationExtensions.TryValidateOptionalPhotoUrl(request.PhotoUrl, nameof(request.PhotoUrl), out string? photoUrlError))
            return Result<CommentResponse>.Invalid(photoUrlError!);

        if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.PhotoUrl))
            return Result<CommentResponse>.Invalid("Content or PhotoUrl is required.");

        if (!await EntityExistsAsync(target, entityId))
            return Result<CommentResponse>.NotFound(target == CommentTarget.Post ? "Post not found." : "Place not found.");

        if (request.ParentCommentId.HasValue)
        {
            var parentQuery = _context.Comments.Where(c =>
                c.Id == request.ParentCommentId.Value && !c.IsDeleted);
            parentQuery = FilterByTarget(parentQuery, target, entityId);

            if (!await parentQuery.AnyAsync())
                return Result<CommentResponse>.NotFound("Parent comment not found.");
        }

        var comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;

        if (target == CommentTarget.Post)
            comment.PostId = entityId;
        else
            comment.PlaceId = entityId;

        using var tx = await _context.Database.BeginTransactionAsync();

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        await UpdateCommentCount(_context, target, entityId, 1);
        await tx.CommitAsync();

        var response = await _context.Comments
            .AsNoTracking()
            .Where(c => c.Id == comment.Id)
            .Select(ProjectComment(userId))
            .FirstOrDefaultAsync();

        if (response == null)
            return Result<CommentResponse>.NotFound("Comment not found.");

        return Result<CommentResponse>.Success(response);
    }

    public async Task<Result<CommentResponse>> UpdateCommentAsync(int entityId, int commentId, CommentTarget target, UpdateCommentRequest request, int userId)
    {
        if (!PhotoUrlValidationExtensions.TryValidateOptionalPhotoUrl(request.PhotoUrl, nameof(request.PhotoUrl), out string? photoUrlError))
            return Result<CommentResponse>.Invalid(photoUrlError!);

        if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.PhotoUrl))
            return Result<CommentResponse>.Invalid("Content or PhotoUrl is required.");

        var query = _context.Comments.Where(c => c.Id == commentId);
        query = FilterByTarget(query, target, entityId);

        var comment = await query.FirstOrDefaultAsync();

        if (comment == null)
            return Result<CommentResponse>.NotFound("Comment not found.");

        if (comment.UserId != userId)
            return Result<CommentResponse>.Unauthorized("You do not have permission to edit this comment.");

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
            return Result<CommentResponse>.NotFound("Comment not found.");

        return Result<CommentResponse>.Success(response);
    }

    public async Task<Result<bool>> DeleteCommentAsync(int entityId, int commentId, CommentTarget target, int userId)
    {
        var query = _context.Comments.Where(c => c.Id == commentId);
        query = FilterByTarget(query, target, entityId);

        var comment = await query.FirstOrDefaultAsync();

        if (comment == null || comment.IsDeleted)
            return Result<bool>.NotFound("Comment not found.");

        if (comment.UserId != userId)
            return Result<bool>.Unauthorized("You do not have permission to delete this comment.");

        using var tx = await _context.Database.BeginTransactionAsync();

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        await UpdateCommentCount(_context, target, entityId, -1);
        await tx.CommitAsync();

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> VoteCommentAsync(int entityId, int commentId, CommentTarget target, int userId, int value)
    {
        var existsQuery = _context.Comments.Where(c => c.Id == commentId && !c.IsDeleted);
        existsQuery = FilterByTarget(existsQuery, target, entityId);

        return await VoteHelper.VoteAsync(
            _context,
            commentId,
            userId,
            value,
            entityExists: () => existsQuery.AnyAsync(),
            getExistingVote: () => _context.CommentVotes.FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId),
            getVoteValue: v => v.Value,
            setVoteValue: (v, val) => { v.Value = val; v.UpdatedAt = DateTime.UtcNow; },
            createVote: () => new CommentVote { UserId = userId, CommentId = commentId, Value = value },
            updateScore: delta => _context.Comments
                .Where(c => c.Id == commentId)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(x => x.Score, x => x.Score + delta)
                    .SetProperty(x => x.UpdatedAt, DateTime.UtcNow)));
    }
}
