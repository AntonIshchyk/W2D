using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Places;
using Backend.Contracts.Common;
using Backend.Extensions;
using System.Linq.Expressions;

namespace Backend.Services;

public class PlaceService : IPlaceService
{
    private readonly AppDbContext _context;

    public PlaceService(AppDbContext context)
    {
        _context = context;
    }

    private static readonly Func<Place, PlaceResponse> ProjectPlace = e => new PlaceResponse
    {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        UserId = e.UserId,
        UserName = e.User!.Username,
        CommunityId = e.CommunityId,
        CommunityName = e.Community != null ? e.Community.Name : null,
        Latitude = e.Latitude,
        Longitude = e.Longitude,
        Score = e.Score,
        CommentCount = e.CommentCount,
        LocationName = e.LocationName,
        PhotoUrls = e.PhotoUrls,
        CreatedAt = e.CreatedAt,
        UpdatedAt = e.UpdatedAt
    };

    public async Task<IEnumerable<PlaceResponse>> GetPlacesAsync(
        IReadOnlyCollection<int>? communityIds = null,
        double? minLat = null,
        double? maxLat = null,
        double? minLng = null,
        double? maxLng = null,
        int? userId = null,
        int? currentUserId = null)
    {
        IQueryable<Place> query = _context.Places
            .AsNoTracking()
            .Include(e => e.User)
            .Include(e => e.Community);

        if (communityIds is { Count: > 0 })
            query = query.Where(e => e.CommunityId.HasValue && communityIds.Contains(e.CommunityId.Value));

        if (minLat.HasValue) query = query.Where(e => e.Latitude >= minLat.Value);
        if (maxLat.HasValue) query = query.Where(e => e.Latitude <= maxLat.Value);
        if (minLng.HasValue) query = query.Where(e => e.Longitude >= minLng.Value);
        if (maxLng.HasValue) query = query.Where(e => e.Longitude <= maxLng.Value);

        if (userId.HasValue)
        {
            query = query.Where(e => e.UserId == userId.Value);
        }

        List<Place> items = await query
            .OrderByDescending(e => e.Score)
            .ThenByDescending(e => e.Id)
            .Take(500)
            .ToListAsync();

        Dictionary<int, int> userVotes = new();
        if (currentUserId.HasValue && items.Count > 0)
        {
            List<int> placeIds = items.Select(p => p.Id).ToList();
            userVotes = await _context.PlaceVotes
                .AsNoTracking()
                .Where(v => v.UserId == currentUserId.Value && placeIds.Contains(v.PlaceId))
                .ToDictionaryAsync(v => v.PlaceId, v => v.Value);
        }

        List<int> itemIds = items.Select(p => p.Id).ToList();
        Dictionary<int, int> commentCounts = new();
        if (itemIds.Count > 0)
        {
            commentCounts = await _context.Comments
                .AsNoTracking()
                .Where(c => c.PlaceId.HasValue && itemIds.Contains(c.PlaceId.Value))
                .GroupBy(c => c.PlaceId!.Value)
                .Select(g => new { PlaceId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.PlaceId, x => x.Count);
        }

        return items.Select(p =>
        {
            PlaceResponse response = ProjectPlace(p);
            response.CurrentUserVote = currentUserId.HasValue
                ? (userVotes.TryGetValue(p.Id, out int voteValue) ? voteValue : 0)
                : null;
            response.CommentCount = commentCounts.TryGetValue(p.Id, out int count) ? count : 0;
            return response;
        }).ToList();
    }

    public async Task<Result<PlaceResponse>> GetPlaceByIdAsync(int id, int? currentUserId = null)
    {
        Place? place = await _context.Places
            .AsNoTracking()
            .Include(e => e.User)
            .Include(e => e.Community)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (place == null)
        {
            return Result<PlaceResponse>.NotFound("Place not found.");
        }

        int? currentUserVote = null;
        if (currentUserId.HasValue)
        {
            PlaceVote? vote = await _context.PlaceVotes
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.UserId == currentUserId.Value && v.PlaceId == id);
            currentUserVote = vote?.Value ?? 0;
        }

        int commentCount = await _context.Comments
            .AsNoTracking()
            .CountAsync(c => c.PlaceId == id);

        PlaceResponse response = ProjectPlace(place);
        response.CurrentUserVote = currentUserVote;
        response.CommentCount = commentCount;
        return Result<PlaceResponse>.Success(response);
    }

    public async Task<Result<PlaceResponse>> CreatePlaceAsync(int userId, CreatePlaceRequest request)
    {
        if (request.Latitude.HasValue != request.Longitude.HasValue)
        {
            return Result<PlaceResponse>.Invalid("Latitude and Longitude must both be provided or both be omitted.");
        }

        if (request.CommunityId.HasValue)
        {
            bool communityExists = await _context.Communities.AnyAsync(c => c.Id == request.CommunityId.Value);
            if (!communityExists)
            {
                return Result<PlaceResponse>.Invalid("Community does not exist.");
            }
        }

        if (!PhotoUrlValidationExtensions.TryValidatePhotoUrls(request.PhotoUrls, nameof(request.PhotoUrls), out string? photoUrlError))
        {
            return Result<PlaceResponse>.Invalid(photoUrlError!);
        }

        Place eventEntity = new Place
        {
            Title = request.Title,
            Description = request.Description,
            UserId = userId,
            CommunityId = request.CommunityId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Score = 0,
            CommentCount = 0,
            LocationName = request.LocationName,
            PhotoUrls = request.PhotoUrls,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Places.Add(eventEntity);
        await _context.SaveChangesAsync();

        return await GetPlaceByIdAsync(eventEntity.Id, userId);
    }

    public async Task<Result<PlaceResponse>> UpdatePlaceAsync(int id, int userId, UpdatePlaceRequest request)
    {
        Place? eventEntity = await _context.Places
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
        {
            return Result<PlaceResponse>.NotFound("Place not found.");
        }

        if (eventEntity.UserId != userId)
        {
            return Result<PlaceResponse>.Unauthorized("You do not have permission to edit this place.");
        }

        if (request.CommunityId.HasValue)
        {
            bool communityExists = await _context.Communities.AnyAsync(c => c.Id == request.CommunityId.Value);
            if (!communityExists)
            {
                return Result<PlaceResponse>.Invalid("Community does not exist.");
            }
        }

        if (!PhotoUrlValidationExtensions.TryValidatePhotoUrls(request.PhotoUrls, nameof(request.PhotoUrls), out string? photoUrlError))
        {
            return Result<PlaceResponse>.Invalid(photoUrlError!);
        }

        if (request.Title != null) eventEntity.Title = request.Title;
        if (request.Description != null) eventEntity.Description = request.Description;
        if (request.CommunityId.HasValue) eventEntity.CommunityId = request.CommunityId;
        if (request.PhotoUrls != null) eventEntity.PhotoUrls = request.PhotoUrls;
        if (request.Latitude.HasValue) eventEntity.Latitude = request.Latitude;
        if (request.Longitude.HasValue) eventEntity.Longitude = request.Longitude;
        if (request.LocationName != null) eventEntity.LocationName = request.LocationName;

        eventEntity.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return await GetPlaceByIdAsync(eventEntity.Id, userId);
    }

    public async Task<Result<bool>> DeletePlaceAsync(int id, int userId)
    {
        Place? eventEntity = await _context.Places
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
        {
            return Result<bool>.NotFound("Place not found.");
        }

        if (eventEntity.UserId != userId)
        {
            return Result<bool>.Unauthorized("You do not have permission to delete this place.");
        }

        _context.Places.Remove(eventEntity);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }

    public Task<Result<bool>> VotePlaceAsync(int placeId, int userId, int value) => VoteHelper.VoteAsync(
        _context,
        placeId,
        userId,
        value,
        entityExists: () => _context.Places.AnyAsync(p => p.Id == placeId),
        getExistingVote: () => _context.PlaceVotes.FirstOrDefaultAsync(v => v.UserId == userId && v.PlaceId == placeId),
        getVoteValue: v => v.Value,
        setVoteValue: (v, val) => { v.Value = val; v.UpdatedAt = DateTime.UtcNow; },
        createVote: () => new PlaceVote { UserId = userId, PlaceId = placeId, Value = value },
        updateScore: delta => _context.Places
            .Where(p => p.Id == placeId)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.Score, x => x.Score + delta))
    );
}
