using Backend.Contracts.Events;
using Backend.Contracts.Common;
using Backend.Models;

namespace Backend.Services;

public interface IEventService
{
    Task<ScrollResult<EventResponse>> GetEventsAsync(
        int? cursor = null,
        int limit = 20,
        int? topicId = null,
        EventStatus? status = null,
        bool upcomingOnly = true,
        int? currentUserId = null);

    Task<EventResponse?> GetEventByIdAsync(int id, int? currentUserId = null);

    Task<EventResponse> CreateEventAsync(int organizerId, CreateEventRequest request);

    Task<EventResponse?> UpdateEventAsync(int id, int organizerId, UpdateEventRequest request);

    Task<bool> DeleteEventAsync(int id, int organizerId);

    Task<(bool success, string message, EventAttendeeResponse? attendee)> RsvpAsync(int eventId, int userId);

    Task<bool> CancelRsvpAsync(int eventId, int userId);

    Task<IEnumerable<EventAttendeeResponse>> GetAttendeesAsync(int eventId);
}
