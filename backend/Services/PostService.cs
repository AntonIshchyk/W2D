using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Posts;
using Backend.Contracts.Common;
using Backend.Constants;

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
        int? topicId = null,
        int? userId = null,
        int? type = null,
        string? sortBy = null,
        int? currentUserId = null)
    {
        IQueryable<Post> query = _context.Posts
            .AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.Community)
            .AsQueryable();

        // Filter by community if provided
        if (topicId.HasValue)
        {
            query = query.Where(p => p.SpaceId == topicId.Value);
        }

        // Filter by user if provided
        if (userId.HasValue)
        {
            query = query.Where(p => p.UserId == userId.Value);
        }

        // Filter by type if provided
        if (type.HasValue)
        {
            query = query.Where(p => (int)p.Type == type.Value);
        }

        // Get total count AFTER applying filters
        int totalCount = await query.CountAsync();

        string sortMode = sortBy?.ToLower() ?? "new";

        // Apply cursor based on sort mode
        if (cursor.HasValue)
        {
            if (sortMode == "hot" || sortMode == "top")
            {
                // For score-based sorting, get the cursor post's score and apply composite cursor
                Post? cursorPost = await _context.Posts
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == cursor.Value);

                if (cursorPost != null)
                {
                    // Filter: Score < cursorScore OR (Score == cursorScore AND Id < cursorId)
                    query = query.Where(p =>
                        p.Score < cursorPost.Score ||
                        (p.Score == cursorPost.Score && p.Id < cursor.Value));
                }
            }
            else
            {
                // For "new" mode, use simple Id-based cursor
                query = query.Where(p => p.Id < cursor.Value);
            }
        }

        // Sort based on sortBy parameter
        query = sortMode switch
        {
            "hot" => query.OrderByDescending(p => p.Score).ThenByDescending(p => p.Id),
            "top" => query.OrderByDescending(p => p.Score).ThenByDescending(p => p.Id),
            _ => query.OrderByDescending(p => p.Id) // "new" or default - newest first
        };

        // Fetch one extra item to determine if there are more results
        List<Post> items = await query
            .Take(limit + 1)
            .ToListAsync();

        bool hasMore = items.Count > limit;
        if (hasMore)
        {
            items = items.Take(limit).ToList();
        }

        int? nextCursor = items.Any() ? items.Last().Id : (int?)null;

        // Get current user votes if user is logged in
        Dictionary<int, int> userVotes = new();
        if (currentUserId.HasValue)
        {
            List<int> postIds = items.Select(p => p.Id).ToList();
            userVotes = await _context.PostVotes
                .AsNoTracking()
                .Where(v => v.UserId == currentUserId.Value && postIds.Contains(v.PostId))
                .ToDictionaryAsync(v => v.PostId, v => v.Value);
        }

        // Map to PostResponse
        List<PostResponse> postResponses = items.Select(p =>
        {
            int? vote = currentUserId.HasValue
                ? (userVotes.TryGetValue(p.Id, out int voteValue) ? voteValue : 0)
                : null;
            PostResponse response = _mapper.Map<PostResponse>(p);
            response.CurrentUserVote = vote;
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

    public async Task<PostResponse?> GetPostByIdAsync(int id, int? currentUserId = null)
    {
        Post? post = await _context.Posts
            .AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.Community)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
        {
            return null;
        }

        // Get current user vote if user is logged in
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
        return response;
    }

    private void ValidateLocationPairing(double? latitude, double? longitude)
    {
        if (latitude.HasValue != longitude.HasValue)
        {
            throw new InvalidOperationException("Latitude and Longitude must both be provided or both be omitted.");
        }
    }

    private void ValidateCostCurrencyPairing(decimal? cost, string? currencyCode)
    {
        if (cost.HasValue && string.IsNullOrWhiteSpace(currencyCode))
        {
            throw new InvalidOperationException("Currency code is required when cost is provided.");
        }

        if (!cost.HasValue && !string.IsNullOrWhiteSpace(currencyCode))
        {
            throw new InvalidOperationException("Cost is required when currency code is provided.");
        }
    }

    private void ValidatePhotoUrls(List<string>? photoUrls)
    {
        if (photoUrls != null && photoUrls.Any())
        {
            foreach (string url in photoUrls)
            {
                if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    throw new InvalidOperationException($"Invalid URL in PhotoUrls: {url}");
                }
            }
        }
    }

    public async Task<Post> CreatePostAsync(CreatePostRequest request, int userId)
    {
        // Validate business rules
        ValidateLocationPairing(request.Latitude, request.Longitude);
        ValidateCostCurrencyPairing(request.Cost, request.CurrencyCode);
        ValidatePhotoUrls(request.PhotoUrls);

        // Validate TopicId exists
        if (!await ActivityExistsAsync(request.TopicId))
        {
            throw new InvalidOperationException("Invalid TopicId. Community does not exist.");
        }

        Post post = _mapper.Map<Post>(request);
        post.UserId = userId;
        post.Score = 0;
        post.CommentCount = 0;

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return post;
    }

    public async Task<Post?> UpdatePostAsync(int id, UpdatePostRequest request, int userId)
    {
        Post? existingPost = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

        if (existingPost == null)
        {
            return null;
        }

        // Validate business rules against final entity state (merge request into existing)
        double? finalLat = request.Latitude ?? existingPost.Latitude;
        double? finalLng = request.Longitude ?? existingPost.Longitude;
        ValidateLocationPairing(finalLat, finalLng);

        decimal? finalCost = request.Cost ?? existingPost.Cost;
        string? finalCurrency = request.CurrencyCode ?? existingPost.CurrencyCode;
        ValidateCostCurrencyPairing(finalCost, finalCurrency);

        ValidatePhotoUrls(request.PhotoUrls);

        // Map only non-null properties from request to existing post
        _mapper.Map(request, existingPost);
        existingPost.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingPost;
    }

    public async Task<bool> DeletePostAsync(int id, int userId)
    {
        Post? post = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

        if (post == null)
        {
            return false;
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> VotePostAsync(int postId, int userId, int value)
    {
        // Validate vote value in service layer
        if (value is not (-1 or 0 or 1))
        {
            throw new ArgumentException("Vote value must be -1, 0, or 1");
        }

        // Verify post exists
        bool postExists = await _context.Posts
            .AnyAsync(p => p.Id == postId);

        if (!postExists)
        {
            return false;
        }

        // Wrap in transaction to prevent score corruption
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            PostVote? existingVote = await _context.PostVotes
                .FirstOrDefaultAsync(v => v.UserId == userId && v.PostId == postId);

            int scoreDelta = 0;

            if (value == 0)
            {
                // Remove vote
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
                    // Update existing vote
                    scoreDelta = value - existingVote.Value;
                    existingVote.Value = value;
                    existingVote.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    // Create new vote
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

            // Save vote record first
            await _context.SaveChangesAsync();

            // Then atomically update score
            if (scoreDelta != 0)
            {
                await _context.Posts
                    .Where(p => p.Id == postId)
                    .ExecuteUpdateAsync(p => p.SetProperty(x => x.Score, x => x.Score + scoreDelta));
            }

            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> ActivityExistsAsync(int topicId)
    {
        return await _context.Communities.AnyAsync(a => a.Id == topicId);
    }
}
