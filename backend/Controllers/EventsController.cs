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
        [FromQuery] int? communityId = null,
        [FromQuery] double? minLat = null,
        [FromQuery] double? maxLat = null,
        [FromQuery] double? minLng = null,
        [FromQuery] double? maxLng = null)
    {
        IEnumerable<EventResponse> result = await _eventService.GetEventsAsync(
            communityId, minLat, maxLat, minLng, maxLng);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponse>> GetEvent(int id)
    {
        Result<EventResponse> result = await _eventService.GetEventByIdAsync(id);
        return result.ToActionResult(this);
    }

    [HttpPost]
    public async Task<ActionResult<EventResponse>> CreateEvent(CreateEventRequest request)
    {
        int userId = User.GetUserId();
        Result<EventResponse> result = await _eventService.CreateEventAsync(userId, request);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return CreatedAtAction(nameof(GetEvent), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EventResponse>> UpdateEvent(int id, UpdateEventRequest request)
    {
        int userId = User.GetUserId();
        Result<EventResponse> result = await _eventService.UpdateEventAsync(id, userId, request);
        return result.ToActionResult(this);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _eventService.DeleteEventAsync(id, userId);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return NoContent();
    }
}
