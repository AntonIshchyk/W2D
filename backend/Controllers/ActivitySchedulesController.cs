using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivitySchedulesController : ControllerBase
{
    private readonly IActivityScheduleService _scheduleService;

    public ActivitySchedulesController(IActivityScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost]
    public async Task<ActionResult<ActivitySchedule>> ScheduleActivity(ScheduleActivityRequest request)
    {
        var userId = User.GetUserId()!.Value;

        if (request.PlannedDate < DateTime.UtcNow.Date)
        {
            return BadRequest(new { message = "Planned date cannot be in the past" });
        }

        // Check if activity is already scheduled for this date
        var existingSchedule = await _scheduleService.GetExistingScheduleAsync(userId, request.ActivityId, request.PlannedDate);
        if (existingSchedule != null)
        {
            return BadRequest(new { message = "You have already scheduled this activity for this date" });
        }

        var schedule = await _scheduleService.ScheduleActivityAsync(
            userId,
            request.ActivityId,
            request.PlannedDate,
            request.Notes
        );

        return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
    }

    [HttpGet("planned")]
    public async Task<ActionResult<IEnumerable<ActivitySchedule>>> GetPlannedActivities()
    {
        var userId = User.GetUserId()!.Value;

        var schedules = await _scheduleService.GetUserScheduledActivitiesAsync(userId);

        return Ok(schedules);
    }

    [HttpGet("completed")]
    public async Task<ActionResult<IEnumerable<ActivitySchedule>>> GetCompletedActivities()
    {
        var userId = User.GetUserId()!.Value;

        var schedules = await _scheduleService.GetUserCompletedActivitiesAsync(userId);

        return Ok(schedules);
    }

    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<ActivitySchedule>>> GetHistory()
    {
        var userId = User.GetUserId()!.Value;

        var schedules = await _scheduleService.GetUserHistoryAsync(userId);

        return Ok(schedules);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivitySchedule>> GetSchedule(int id)
    {
        var userId = User.GetUserId()!.Value;

        var schedule = await _scheduleService.GetScheduleByIdAsync(id, userId);

        if (schedule == null)
        {
            return NotFound(new { message = "Schedule not found" });
        }

        return Ok(schedule);
    }

    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<ActivitySchedule>> CompleteActivity(int id, [FromBody] CompleteActivityRequest? request = null)
    {
        var userId = User.GetUserId()!.Value;

        var schedule = await _scheduleService.MarkAsCompletedAsync(id, userId, request?.CompletedDate);

        if (schedule == null)
        {
            return NotFound(new { message = "Schedule not found" });
        }

        return Ok(schedule);
    }

    [HttpPatch("{id}/cancel")]
    public async Task<ActionResult<ActivitySchedule>> CancelActivity(int id)
    {
        var userId = User.GetUserId()!.Value;

        var schedule = await _scheduleService.CancelScheduleAsync(id, userId);

        if (schedule == null)
        {
            return NotFound(new { message = "Schedule not found" });
        }

        return Ok(schedule);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSchedule(int id)
    {
        var userId = User.GetUserId()!.Value;

        var deleted = await _scheduleService.DeleteScheduleAsync(id, userId);

        if (!deleted)
        {
            return NotFound(new { message = "Schedule not found" });
        }

        return NoContent();
    }
}
