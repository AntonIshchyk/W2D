using Backend.Contracts.Events;
using Backend.Contracts.Common;
using Backend.Models;

namespace Backend.Services;

public interface IEventService
{
    Task<IEnumerable<EventResponse>> GetEventsAsync(
        int? topicId = null,
        EventStatus? status = null,
        double? minLat = null,
        double? maxLat = null,
        double? minLng = null,
        double? maxLng = null);

    Task<Result<EventResponse>> GetEventByIdAsync(int id);

    Task<Result<EventResponse>> CreateEventAsync(int organizerId, CreateEventRequest request);

    Task<Result<EventResponse>> UpdateEventAsync(int id, int organizerId, UpdateEventRequest request);

    Task<Result<bool>> DeleteEventAsync(int id, int organizerId);
}
