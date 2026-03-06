using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Events;
using Backend.Contracts.Common;
using Backend.Models;
using Backend.Services;
using Backend.Extensions;
using Backend.Constants;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<ScrollResult<EventResponse>>> GetEvents(
        [FromQuery] int? cursor = null,
        [FromQuery] int limit = PaginationConstants.DefaultPageSize,
        [FromQuery] int? activityId = null,
        [FromQuery] EventStatus? status = null,
        [FromQuery] bool upcomingOnly = true)
    {
        if (limit < PaginationConstants.MinPageSize || limit > PaginationConstants.MaxPageSize)
            return BadRequest(new { message = $"Limit must be between {PaginationConstants.MinPageSize} and {PaginationConstants.MaxPageSize}." });

        int? currentUserId = User.GetUserId();
        ScrollResult<EventResponse> result = await _eventService.GetEventsAsync(cursor, limit, activityId, status, upcomingOnly, currentUserId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponse>> GetEvent(int id)
    {
        int? currentUserId = User.GetUserId();
        EventResponse? e = await _eventService.GetEventByIdAsync(id, currentUserId);
        if (e == null) return NotFound(new { message = "Event not found" });
        return Ok(e);
    }

    [HttpPost]
    public async Task<ActionResult<EventResponse>> CreateEvent(CreateEventRequest request)
    {
        int userId = User.GetUserId()!.Value;
        EventResponse created = await _eventService.CreateEventAsync(userId, request);
        return CreatedAtAction(nameof(GetEvent), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EventResponse>> UpdateEvent(int id, UpdateEventRequest request)
    {
        int userId = User.GetUserId()!.Value;
        EventResponse? updated = await _eventService.UpdateEventAsync(id, userId, request);
        if (updated == null) return NotFound(new { message = "Event not found or you are not the organizer" });
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        int userId = User.GetUserId()!.Value;
        bool deleted = await _eventService.DeleteEventAsync(id, userId);
        if (!deleted) return NotFound(new { message = "Event not found or you are not the organizer" });
        return NoContent();
    }

    [HttpPost("{id}/rsvp")]
    public async Task<ActionResult<EventAttendeeResponse>> Rsvp(int id)
    {
        int userId = User.GetUserId()!.Value;
        (bool success, string message, EventAttendeeResponse? attendee) = await _eventService.RsvpAsync(id, userId);
        if (!success) return BadRequest(new { message });
        return Ok(attendee);
    }

    [HttpDelete("{id}/rsvp")]
    public async Task<ActionResult> CancelRsvp(int id)
    {
        int userId = User.GetUserId()!.Value;
        bool cancelled = await _eventService.CancelRsvpAsync(id, userId);
        if (!cancelled) return NotFound(new { message = "RSVP not found or already cancelled" });
        return NoContent();
    }

    [HttpGet("{id}/attendees")]
    public async Task<ActionResult<IEnumerable<EventAttendeeResponse>>> GetAttendees(int id)
    {
        IEnumerable<EventAttendeeResponse> attendees = await _eventService.GetAttendeesAsync(id);
        return Ok(attendees);
    }
}
