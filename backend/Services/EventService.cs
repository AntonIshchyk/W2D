using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Events;

namespace Backend.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    private static IQueryable<Event> IncludeDetails(IQueryable<Event> query)
    {
        return query
            .Include(e => e.Organizer)
            .Include(e => e.Community);
    }

    private static EventResponse MapToResponse(Event e, int? currentUserId = null)
    {
        return new EventResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            OrganizerId = e.OrganizerId,
            OrganizerName = e.Organizer?.Username,
            SpaceId = e.SpaceId,
            CommunityName = e.Community?.Name,
            ScheduledAt = e.ScheduledAt,
            Status = e.Status.ToString(),
            Latitude = e.Latitude,
            Longitude = e.Longitude,
            LocationName = e.LocationName,
            PlaceId = e.PlaceId,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        };
    }

    public async Task<IEnumerable<EventResponse>> GetEventsAsync(
        int? topicId = null,
        EventStatus? status = null,
        double? minLat = null,
        double? maxLat = null,
        double? minLng = null,
        double? maxLng = null)
    {
        IQueryable<Event> query = IncludeDetails(_context.Events.AsNoTracking());

        if (topicId.HasValue)
            query = query.Where(e => e.SpaceId == topicId.Value);

        if (status.HasValue)
            query = query.Where(e => e.Status == status.Value);
        else
            query = query.Where(e => e.Status == EventStatus.Open);

        query = query.Where(e => e.ScheduledAt >= DateTime.UtcNow);

        if (minLat.HasValue) query = query.Where(e => e.Latitude >= minLat.Value);
        if (maxLat.HasValue) query = query.Where(e => e.Latitude <= maxLat.Value);
        if (minLng.HasValue) query = query.Where(e => e.Longitude >= minLng.Value);
        if (maxLng.HasValue) query = query.Where(e => e.Longitude <= maxLng.Value);

        query = query.OrderBy(e => e.ScheduledAt).ThenBy(e => e.Id).Take(500);

        List<Event> items = await query.ToListAsync();

        return items.Select(e => MapToResponse(e));
    }

    public async Task<EventResponse?> GetEventByIdAsync(int id)
    {
        Event? e = await IncludeDetails(_context.Events.AsNoTracking())
            .FirstOrDefaultAsync(e => e.Id == id);

        return e == null ? null : MapToResponse(e);
    }

    public async Task<EventResponse> CreateEventAsync(int organizerId, CreateEventRequest request)
    {
        Event eventEntity = new Event
        {
            Title = request.Title,
            Description = request.Description,
            OrganizerId = organizerId,
            SpaceId = request.TopicId,
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

        Event created = await IncludeDetails(_context.Events.AsNoTracking())
            .FirstAsync(e => e.Id == eventEntity.Id);

        return MapToResponse(created, organizerId);
    }

    public async Task<EventResponse?> UpdateEventAsync(int id, int organizerId, UpdateEventRequest request)
    {
        Event? eventEntity = await IncludeDetails(_context.Events)
            .FirstOrDefaultAsync(e => e.Id == id && e.OrganizerId == organizerId);

        if (eventEntity == null) return null;

        if (request.Title != null) eventEntity.Title = request.Title;
        if (request.Description != null) eventEntity.Description = request.Description;
        if (request.TopicId.HasValue) eventEntity.SpaceId = request.TopicId;
        if (request.ScheduledAt.HasValue) eventEntity.ScheduledAt = request.ScheduledAt.Value;
        if (request.Status.HasValue) eventEntity.Status = request.Status.Value;

        eventEntity.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return MapToResponse(eventEntity, organizerId);
    }

    public async Task<bool> DeleteEventAsync(int id, int organizerId)
    {
        Event? eventEntity = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id && e.OrganizerId == organizerId);

        if (eventEntity == null) return false;

        _context.Events.Remove(eventEntity);
        await _context.SaveChangesAsync();
        return true;
    }
}
