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

    private static readonly Expression<Func<Place, PlaceResponse>> ProjectPlace = e => new PlaceResponse
    {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        UserId = e.UserId,
        UserName = e.User != null ? e.User.Username : null,
        CommunityId = e.CommunityId,
        CommunityName = e.Community != null ? e.Community.Name : null,
        Latitude = e.Latitude,
        Longitude = e.Longitude,
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
        int? userId = null)
    {
        IQueryable<Place> query = _context.Places.AsNoTracking();

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

        return await query
            .OrderBy(e => e.Id)
            .Take(500)
            .Select(ProjectPlace)
            .ToListAsync();
    }

    public async Task<Result<PlaceResponse>> GetPlaceByIdAsync(int id)
    {
        PlaceResponse? e = await _context.Places
            .AsNoTracking()
            .Select(ProjectPlace)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (e == null)
        {
            return Result<PlaceResponse>.NotFound("Place not found.");
        }

        return Result<PlaceResponse>.Success(e);
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
            LocationName = request.LocationName,
            PhotoUrls = request.PhotoUrls,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Places.Add(eventEntity);
        await _context.SaveChangesAsync();

        PlaceResponse created = await _context.Places
            .AsNoTracking()
            .Select(ProjectPlace)
            .FirstAsync(e => e.Id == eventEntity.Id);

        return Result<PlaceResponse>.Success(created);
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

        eventEntity.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        PlaceResponse updated = await _context.Places
            .AsNoTracking()
            .Select(ProjectPlace)
            .FirstAsync(e => e.Id == eventEntity.Id);

        return Result<PlaceResponse>.Success(updated);
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
}
