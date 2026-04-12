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
    public async Task<ActionResult<IEnumerable<EventResponse>>> GetEvents(
        [FromQuery] int? topicId = null,
        [FromQuery] EventStatus? status = null,
        [FromQuery] double? minLat = null,
        [FromQuery] double? maxLat = null,
        [FromQuery] double? minLng = null,
        [FromQuery] double? maxLng = null)
    {
        int currentUserId = User.GetUserId();
        IEnumerable<EventResponse> result = await _eventService.GetEventsAsync(
            topicId, status, currentUserId, minLat, maxLat, minLng, maxLng);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponse>> GetEvent(int id)
    {
        int currentUserId = User.GetUserId();
        EventResponse? e = await _eventService.GetEventByIdAsync(id, currentUserId);
        if (e == null) return NotFound(new { message = "Event not found" });
        return Ok(e);
    }

    [HttpPost]
    public async Task<ActionResult<EventResponse>> CreateEvent(CreateEventRequest request)
    {
        int userId = User.GetUserId();
        EventResponse created = await _eventService.CreateEventAsync(userId, request);
        return CreatedAtAction(nameof(GetEvent), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EventResponse>> UpdateEvent(int id, UpdateEventRequest request)
    {
        int userId = User.GetUserId();
        EventResponse? updated = await _eventService.UpdateEventAsync(id, userId, request);
        if (updated == null) return NotFound(new { message = "Event not found or you are not the organizer" });
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        int userId = User.GetUserId();
        bool deleted = await _eventService.DeleteEventAsync(id, userId);
        if (!deleted) return NotFound(new { message = "Event not found or you are not the organizer" });
        return NoContent();
    }
}
