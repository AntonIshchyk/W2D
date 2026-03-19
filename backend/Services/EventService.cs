using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Events;
using Backend.Contracts.Common;
using Backend.Constants;

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
            .Include(e => e.Community)
            .Include(e => e.Tags)
            .Include(e => e.Attendees);
    }

    private static EventResponse MapToResponse(Event e, int? currentUserId = null)
    {
        EventAttendee? userAttendee = currentUserId.HasValue
            ? e.Attendees.FirstOrDefault(a => a.UserId == currentUserId.Value)
            : null;

        return new EventResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            OrganizerId = e.OrganizerId,
            OrganizerName = e.Organizer?.Name,
            TopicId = e.TopicId,
            ActivityTitle = e.Community?.Title,
            Tags = e.Tags.Select(t => new TagDto { Id = t.Id, Name = t.Name }).ToList(),
            ScheduledAt = e.ScheduledAt,
            MaxAttendees = e.MaxAttendees,
            AttendeeCount = e.Attendees.Count(a => a.Status == EventAttendeeStatus.Confirmed),
            Status = e.Status.ToString(),
            CurrentUserRsvp = userAttendee?.Status.ToString(),
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        };
    }

    public async Task<ScrollResult<EventResponse>> GetEventsAsync(
        int? cursor = null,
        int limit = PaginationConstants.DefaultPageSize,
        int? topicId = null,
        EventStatus? status = null,
        bool upcomingOnly = true,
        int? currentUserId = null)
    {
        IQueryable<Event> query = IncludeDetails(_context.Events.AsNoTracking());

        if (topicId.HasValue)
            query = query.Where(e => e.TopicId == topicId.Value);

        if (status.HasValue)
            query = query.Where(e => e.Status == status.Value);

        if (upcomingOnly)
            query = query.Where(e => e.ScheduledAt >= DateTime.UtcNow);

        int totalCount = await query.CountAsync();

        if (cursor.HasValue)
        {
            Event? cursorEvent = await _context.Events.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == cursor.Value);

            if (cursorEvent != null)
            {
                query = query.Where(e =>
                    e.ScheduledAt > cursorEvent.ScheduledAt ||
                    (e.ScheduledAt == cursorEvent.ScheduledAt && e.Id > cursor.Value));
            }
        }

        query = query.OrderBy(e => e.ScheduledAt).ThenBy(e => e.Id);

        List<Event> items = await query.Take(limit + 1).ToListAsync();

        bool hasMore = items.Count > limit;
        if (hasMore) items = items.Take(limit).ToList();

        int? nextCursor = hasMore && items.Any() ? items.Last().Id : (int?)null;

        return new ScrollResult<EventResponse>
        {
            Items = items.Select(e => MapToResponse(e, currentUserId)).ToList(),
            NextCursor = nextCursor,
            HasMore = hasMore,
            TotalCount = totalCount
        };
    }

    public async Task<EventResponse?> GetEventByIdAsync(int id, int? currentUserId = null)
    {
        Event? e = await IncludeDetails(_context.Events.AsNoTracking())
            .FirstOrDefaultAsync(e => e.Id == id);

        return e == null ? null : MapToResponse(e, currentUserId);
    }

    public async Task<EventResponse> CreateEventAsync(int organizerId, CreateEventRequest request)
    {
        Event eventEntity = new Event
        {
            Title = request.Title,
            Description = request.Description,
            OrganizerId = organizerId,
            TopicId = request.TopicId,
            ScheduledAt = request.ScheduledAt,
            MaxAttendees = request.MaxAttendees,
            Status = EventStatus.Open,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        if (request.TagIds.Count > 0)
        {
            List<Tag> tags = await _context.Tags
                .Where(t => request.TagIds.Contains(t.Id))
                .ToListAsync();
            eventEntity.Tags = tags;
        }

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
        if (request.TopicId.HasValue) eventEntity.TopicId = request.TopicId;
        if (request.ScheduledAt.HasValue) eventEntity.ScheduledAt = request.ScheduledAt.Value;
        if (request.MaxAttendees.HasValue) eventEntity.MaxAttendees = request.MaxAttendees;
        if (request.Status.HasValue) eventEntity.Status = request.Status.Value;

        if (request.TagIds != null)
        {
            List<Tag> tags = await _context.Tags
                .Where(t => request.TagIds.Contains(t.Id))
                .ToListAsync();
            eventEntity.Tags = tags;
        }

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

    public async Task<(bool success, string message, EventAttendeeResponse? attendee)> RsvpAsync(int eventId, int userId)
    {
        Event? eventEntity = await _context.Events
            .Include(e => e.Attendees)
            .FirstOrDefaultAsync(e => e.Id == eventId);

        if (eventEntity == null)
            return (false, "Event not found", null);

        if (eventEntity.Status == EventStatus.Cancelled)
            return (false, "Event is cancelled", null);

        if (eventEntity.OrganizerId == userId)
            return (false, "Organizer cannot RSVP to their own event", null);

        EventAttendee? existing = eventEntity.Attendees.FirstOrDefault(a => a.UserId == userId);

        if (existing != null && existing.Status == EventAttendeeStatus.Confirmed)
            return (false, "Already attending this event", null);

        int confirmedCount = eventEntity.Attendees.Count(a => a.Status == EventAttendeeStatus.Confirmed);
        bool isFull = eventEntity.MaxAttendees.HasValue && confirmedCount >= eventEntity.MaxAttendees.Value;
        EventAttendeeStatus newStatus = isFull ? EventAttendeeStatus.Waitlisted : EventAttendeeStatus.Confirmed;

        if (existing != null)
        {
            existing.Status = newStatus;
            existing.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            existing = new EventAttendee
            {
                EventId = eventId,
                UserId = userId,
                Status = newStatus,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.EventAttendees.Add(existing);
        }

        // Mark event Full if this fills the last spot
        if (!isFull && newStatus == EventAttendeeStatus.Confirmed && eventEntity.MaxAttendees.HasValue)
        {
            if (confirmedCount + 1 >= eventEntity.MaxAttendees.Value)
                eventEntity.Status = EventStatus.Full;
        }

        await _context.SaveChangesAsync();

        User? user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

        return (true, "RSVP successful", new EventAttendeeResponse
        {
            UserId = userId,
            UserName = user?.Name,
            Status = existing.Status.ToString(),
            JoinedAt = existing.CreatedAt
        });
    }

    public async Task<bool> CancelRsvpAsync(int eventId, int userId)
    {
        EventAttendee? attendee = await _context.EventAttendees
            .Include(a => a.Event)
            .FirstOrDefaultAsync(a => a.EventId == eventId && a.UserId == userId);

        if (attendee == null || attendee.Status == EventAttendeeStatus.Cancelled)
            return false;

        bool wasConfirmed = attendee.Status == EventAttendeeStatus.Confirmed;
        attendee.Status = EventAttendeeStatus.Cancelled;
        attendee.UpdatedAt = DateTime.UtcNow;

        if (wasConfirmed && attendee.Event != null && attendee.Event.Status == EventStatus.Full)
        {
            EventAttendee? firstWaitlisted = await _context.EventAttendees
                .Where(a => a.EventId == eventId && a.Status == EventAttendeeStatus.Waitlisted)
                .OrderBy(a => a.CreatedAt)
                .FirstOrDefaultAsync();

            if (firstWaitlisted != null)
            {
                firstWaitlisted.Status = EventAttendeeStatus.Confirmed;
                firstWaitlisted.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                attendee.Event.Status = EventStatus.Open;
                attendee.Event.UpdatedAt = DateTime.UtcNow;
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<EventAttendeeResponse>> GetAttendeesAsync(int eventId)
    {
        return await _context.EventAttendees
            .AsNoTracking()
            .Include(a => a.User)
            .Where(a => a.EventId == eventId && a.Status != EventAttendeeStatus.Cancelled)
            .OrderBy(a => a.CreatedAt)
            .Select(a => new EventAttendeeResponse
            {
                UserId = a.UserId,
                UserName = a.User != null ? a.User.Name : null,
                Status = a.Status.ToString(),
                JoinedAt = a.CreatedAt
            })
            .ToListAsync();
    }
}
