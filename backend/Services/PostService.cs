using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Posts;
using Backend.Contracts.Common;
using Backend.Constants;
using Backend.Extensions;

namespace Backend.Services;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PostService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ScrollResult<PostResponse>> GetPostsAsync(
        int? cursor = null,
        int limit = PaginationConstants.DefaultPageSize,
        int[]? communityIds = null,
        int? userId = null,
        int? type = null,
        string? sortBy = null,
        int? currentUserId = null)
    {
        IQueryable<Post> query = _context.Posts
            .AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.Community);

        if (communityIds != null && communityIds.Length > 0)
        {
            query = query.Where(p => p.CommunityId.HasValue && communityIds.Contains(p.CommunityId.Value));
        }

        if (userId.HasValue)
        {
            query = query.Where(p => p.UserId == userId.Value);
        }

        if (type.HasValue)
        {
            query = query.Where(p => (int)p.Type == type.Value);
        }

        int totalCount = await query.CountAsync();

        string sortMode = sortBy?.ToLower() ?? "new";

        if (cursor.HasValue)
        {
            if (sortMode == "top")
            {
                Post? cursorPost = await _context.Posts
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == cursor.Value);

                if (cursorPost != null)
                {
                    query = query.Where(p =>
                        p.Score < cursorPost.Score ||
                        (p.Score == cursorPost.Score && p.Id < cursor.Value));
                }
            }
            else
            {
                query = query.Where(p => p.Id < cursor.Value);
            }
        }

        query = sortMode switch
        {
            "top" => query.OrderByDescending(p => p.Score).ThenByDescending(p => p.Id),
            _ => query.OrderByDescending(p => p.Id)
        };

        List<Post> items = await query
            .Take(limit + 1)
            .ToListAsync();

        bool hasMore = items.Count > limit;
        if (hasMore)
        {
            items = items.Take(limit).ToList();
        }

        int? nextCursor = items.Any() ? items.Last().Id : (int?)null;

        Dictionary<int, int> userVotes = new();
        if (currentUserId.HasValue && items.Count > 0)
        {
            List<int> postIds = items.Select(p => p.Id).ToList();
            userVotes = await _context.PostVotes
                .AsNoTracking()
                .Where(v => v.UserId == currentUserId.Value && postIds.Contains(v.PostId))
                .ToDictionaryAsync(v => v.PostId, v => v.Value);
        }

        List<int> itemPostIds = items.Select(p => p.Id).ToList();
        Dictionary<int, int> commentCounts = new();
        if (itemPostIds.Count > 0)
        {
            commentCounts = await _context.Comments
                .AsNoTracking()
                .Where(c => c.PostId.HasValue && itemPostIds.Contains(c.PostId.Value))
                .GroupBy(c => c.PostId!.Value)
                .Select(g => new { PostId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.PostId, x => x.Count);
        }

        List<PostResponse> postResponses = items.Select(p =>
        {
            int? vote = currentUserId.HasValue
                ? (userVotes.TryGetValue(p.Id, out int voteValue) ? voteValue : 0)
                : null;

            PostResponse response = _mapper.Map<PostResponse>(p);
            response.CurrentUserVote = vote;
            response.CommentCount = commentCounts.TryGetValue(p.Id, out int count) ? count : 0;
            return response;
        }).ToList();

        return new ScrollResult<PostResponse>
        {
            Items = postResponses,
            NextCursor = hasMore ? nextCursor : null,
            HasMore = hasMore,
            TotalCount = totalCount
        };
    }

    public async Task<Result<PostResponse>> GetPostByIdAsync(int id, int? currentUserId = null)
    {
        Post? post = await _context.Posts
            .AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.Community)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
        {
            return Result<PostResponse>.NotFound("Post not found.");
        }

        int? currentUserVote = null;
        if (currentUserId.HasValue)
        {
            PostVote? vote = await _context.PostVotes
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.UserId == currentUserId.Value && v.PostId == id);
            currentUserVote = vote?.Value ?? 0;
        }

        PostResponse response = _mapper.Map<PostResponse>(post);
        response.CurrentUserVote = currentUserVote;
        response.CommentCount = await _context.Comments
            .AsNoTracking()
            .CountAsync(c => c.PostId == id);
        return Result<PostResponse>.Success(response);
    }

    public async Task<Result<PostResponse>> CreatePostAsync(CreatePostRequest request, int userId)
    {
        if (request.Latitude.HasValue != request.Longitude.HasValue)
        {
            return Result<PostResponse>.Invalid("Latitude and Longitude must both be provided or both be omitted.");
        }

        if (!PhotoUrlValidationExtensions.TryValidatePhotoUrls(request.PhotoUrls, nameof(request.PhotoUrls), out string? urlError))
        {
            return Result<PostResponse>.Invalid(urlError!);
        }

        if (request.CommunityId.HasValue)
        {
            bool communityExists = await _context.Communities.AnyAsync(c => c.Id == request.CommunityId.Value);
            if (!communityExists)
            {
                return Result<PostResponse>.Invalid("Community does not exist.");
            }
        }

        Post post = _mapper.Map<Post>(request);
        post.UserId = userId;
        post.Score = 0;
        post.CommentCount = 0;

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return await GetPostByIdAsync(post.Id, userId);
    }

    public async Task<Result<PostResponse>> UpdatePostAsync(int id, UpdatePostRequest request, int userId)
    {
        Post? existingPost = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == id);

        if (existingPost == null)
        {
            return Result<PostResponse>.NotFound("Post not found.");
        }

        if (existingPost.UserId != userId)
        {
            return Result<PostResponse>.Unauthorized("You do not have permission to edit this post.");
        }

        double? finalLat = request.Latitude ?? existingPost.Latitude;
        double? finalLng = request.Longitude ?? existingPost.Longitude;

        if (finalLat.HasValue != finalLng.HasValue)
        {
            return Result<PostResponse>.Invalid("Latitude and Longitude must both be provided or both be omitted.");
        }

        if (!PhotoUrlValidationExtensions.TryValidatePhotoUrls(request.PhotoUrls, nameof(request.PhotoUrls), out string? urlError))
        {
            return Result<PostResponse>.Invalid(urlError!);
        }

        _mapper.Map(request, existingPost);
        existingPost.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return await GetPostByIdAsync(id, userId);
    }

    public async Task<Result<bool>> DeletePostAsync(int id, int userId)
    {
        Post? post = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
        {
            return Result<bool>.NotFound("Post not found.");
        }

        if (post.UserId != userId)
        {
            return Result<bool>.Unauthorized("You do not have permission to delete this post.");
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> VotePostAsync(int postId, int userId, int value)
    {
        if (value is not (-1 or 0 or 1))
        {
            return Result<bool>.Invalid("Vote value must be -1, 0, or 1.");
        }

        bool postExists = await _context.Posts
            .AnyAsync(p => p.Id == postId);

        if (!postExists)
        {
            return Result<bool>.NotFound("Post not found.");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            PostVote? existingVote = await _context.PostVotes
                .FirstOrDefaultAsync(v => v.UserId == userId && v.PostId == postId);

            int scoreDelta = 0;

            if (value == 0)
            {
                if (existingVote != null)
                {
                    scoreDelta = -existingVote.Value;
                    _context.PostVotes.Remove(existingVote);
                }
            }
            else
            {
                if (existingVote != null)
                {
                    scoreDelta = value - existingVote.Value;
                    existingVote.Value = value;
                    existingVote.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    scoreDelta = value;
                    PostVote newVote = new()
                    {
                        UserId = userId,
                        PostId = postId,
                        Value = value
                    };
                    _context.PostVotes.Add(newVote);
                }
            }

            await _context.SaveChangesAsync();

            if (scoreDelta != 0)
            {
                await _context.Posts
                    .Where(p => p.Id == postId)
                    .ExecuteUpdateAsync(p => p.SetProperty(x => x.Score, x => x.Score + scoreDelta));
            }

            await transaction.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
