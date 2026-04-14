using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Events;
using Backend.Contracts.Common;
using System.Linq.Expressions;

namespace Backend.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    private static readonly Expression<Func<Event, EventResponse>> ProjectEvent = e => new EventResponse
    {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        OrganizerId = e.OrganizerId,
        OrganizerName = e.Organizer != null ? e.Organizer.Username : null,
        CommunityId = e.CommunityId,
        CommunityName = e.Community != null ? e.Community.Name : null,
        ScheduledAt = e.ScheduledAt,
        Status = e.Status.ToString(),
        Latitude = e.Latitude,
        Longitude = e.Longitude,
        LocationName = e.LocationName,
        PlaceId = e.PlaceId,
        CreatedAt = e.CreatedAt,
        UpdatedAt = e.UpdatedAt
    };

    public async Task<IEnumerable<EventResponse>> GetEventsAsync(
        int? communityId = null,
        EventStatus? status = null,
        double? minLat = null,
        double? maxLat = null,
        double? minLng = null,
        double? maxLng = null)
    {
        IQueryable<Event> query = _context.Events.AsNoTracking();

        if (communityId.HasValue)
            query = query.Where(e => e.CommunityId == communityId.Value);

        if (status.HasValue)
            query = query.Where(e => e.Status == status.Value);
        else
            query = query.Where(e => e.Status == EventStatus.Open);

        query = query.Where(e => e.ScheduledAt >= DateTime.UtcNow);

        if (minLat.HasValue) query = query.Where(e => e.Latitude >= minLat.Value);
        if (maxLat.HasValue) query = query.Where(e => e.Latitude <= maxLat.Value);
        if (minLng.HasValue) query = query.Where(e => e.Longitude >= minLng.Value);
        if (maxLng.HasValue) query = query.Where(e => e.Longitude <= maxLng.Value);

        return await query
            .OrderBy(e => e.ScheduledAt)
            .ThenBy(e => e.Id)
            .Take(500)
            .Select(ProjectEvent)
            .ToListAsync();
    }

    public async Task<Result<EventResponse>> GetEventByIdAsync(int id)
    {
        EventResponse? e = await _context.Events
            .AsNoTracking()
            .Select(ProjectEvent)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (e == null)
        {
            return Result<EventResponse>.NotFound("Event not found.");
        }

        return Result<EventResponse>.Success(e);
    }

    public async Task<Result<EventResponse>> CreateEventAsync(int organizerId, CreateEventRequest request)
    {
        if (request.Latitude.HasValue != request.Longitude.HasValue)
        {
            return Result<EventResponse>.Invalid("Latitude and Longitude must both be provided or both be omitted.");
        }

        if (request.CommunityId.HasValue)
        {
            bool communityExists = await _context.Communities.AnyAsync(c => c.Id == request.CommunityId.Value);
            if (!communityExists)
            {
                return Result<EventResponse>.Invalid("Community does not exist.");
            }
        }

        Event eventEntity = new Event
        {
            Title = request.Title,
            Description = request.Description,
            OrganizerId = organizerId,
            CommunityId = request.CommunityId,
            ScheduledAt = request.ScheduledAt,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            LocationName = request.LocationName,
            Status = EventStatus.Open,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();

        EventResponse created = await _context.Events
            .AsNoTracking()
            .Select(ProjectEvent)
            .FirstAsync(e => e.Id == eventEntity.Id);

        return Result<EventResponse>.Success(created);
    }

    public async Task<Result<EventResponse>> UpdateEventAsync(int id, int organizerId, UpdateEventRequest request)
    {
        Event? eventEntity = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
        {
            return Result<EventResponse>.NotFound("Event not found.");
        }

        if (eventEntity.OrganizerId != organizerId)
        {
            return Result<EventResponse>.Unauthorized("You do not have permission to edit this event.");
        }

        if (request.CommunityId.HasValue)
        {
            bool communityExists = await _context.Communities.AnyAsync(c => c.Id == request.CommunityId.Value);
            if (!communityExists)
            {
                return Result<EventResponse>.Invalid("Community does not exist.");
            }
        }

        if (request.Title != null) eventEntity.Title = request.Title;
        if (request.Description != null) eventEntity.Description = request.Description;
        if (request.CommunityId.HasValue) eventEntity.CommunityId = request.CommunityId;
        if (request.ScheduledAt.HasValue) eventEntity.ScheduledAt = request.ScheduledAt.Value;
        if (request.Status.HasValue) eventEntity.Status = request.Status.Value;

        eventEntity.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        EventResponse updated = await _context.Events
            .AsNoTracking()
            .Select(ProjectEvent)
            .FirstAsync(e => e.Id == eventEntity.Id);

        return Result<EventResponse>.Success(updated);
    }

    public async Task<Result<bool>> DeleteEventAsync(int id, int organizerId)
    {
        Event? eventEntity = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
        {
            return Result<bool>.NotFound("Event not found.");
        }

        if (eventEntity.OrganizerId != organizerId)
        {
            return Result<bool>.Unauthorized("You do not have permission to delete this event.");
        }

        _context.Events.Remove(eventEntity);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}
