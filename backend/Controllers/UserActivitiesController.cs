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
public class UserActivitiesController : ControllerBase
{
    private readonly IUserActivityService _userActivityService;

    public UserActivitiesController(IUserActivityService userActivityService)
    {
        _userActivityService = userActivityService;
    }

    [HttpPost]
    public async Task<ActionResult<UserActivity>> ScheduleActivity(ScheduleActivityRequest request)
    {
        int userId = User.GetUserId()!.Value;

        if (request.PlannedDate < DateTime.UtcNow.Date)
        {
            return BadRequest(new { message = "Planned date cannot be in the past" });
        }

        // Check if activity is already scheduled for this date
        UserActivity? existingUserActivity = await _userActivityService.GetExistingUserActivityAsync(userId, request.ActivityId, request.PlannedDate);
        if (existingUserActivity != null)
        {
            return BadRequest(new { message = "You have already scheduled this activity for this date" });
        }

        UserActivity userActivity = await _userActivityService.ScheduleActivityAsync(
            userId,
            request.ActivityId,
            request.PlannedDate,
            request.Notes
        );

        return CreatedAtAction(nameof(GetUserActivity), new { id = userActivity.Id }, userActivity);
    }

    [HttpGet("planned")]
    public async Task<ActionResult<IEnumerable<UserActivity>>> GetPlannedActivities()
    {
        int userId = User.GetUserId()!.Value;

        IEnumerable<UserActivity> userActivities = await _userActivityService.GetUserScheduledActivitiesAsync(userId);

        return Ok(userActivities);
    }

    [HttpGet("completed")]
    public async Task<ActionResult<IEnumerable<UserActivity>>> GetCompletedActivities()
    {
        int userId = User.GetUserId()!.Value;

        IEnumerable<UserActivity> userActivities = await _userActivityService.GetUserCompletedActivitiesAsync(userId);

        return Ok(userActivities);
    }

    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<UserActivity>>> GetHistory()
    {
        int userId = User.GetUserId()!.Value;

        IEnumerable<UserActivity> userActivities = await _userActivityService.GetUserHistoryAsync(userId);

        return Ok(userActivities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserActivity>> GetUserActivity(int id)
    {
        int userId = User.GetUserId()!.Value;

        UserActivity? userActivity = await _userActivityService.GetUserActivityByIdAsync(id, userId);

        if (userActivity == null)
        {
            return NotFound(new { message = "User activity not found" });
        }

        return Ok(userActivity);
    }

    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<UserActivity>> CompleteActivity(int id, [FromBody] CompleteActivityRequest? request = null)
    {
        int userId = User.GetUserId()!.Value;

        UserActivity? userActivity = await _userActivityService.MarkAsCompletedAsync(id, userId, request?.CompletedDate);

        if (userActivity == null)
        {
            return NotFound(new { message = "User activity not found" });
        }

        return Ok(userActivity);
    }

    [HttpPatch("{id}/cancel")]
    public async Task<ActionResult<UserActivity>> CancelActivity(int id)
    {
        int userId = User.GetUserId()!.Value;

        UserActivity? userActivity = await _userActivityService.CancelUserActivityAsync(id, userId);

        if (userActivity == null)
        {
            return NotFound(new { message = "User activity not found" });
        }

        return Ok(userActivity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserActivity(int id)
    {
        int userId = User.GetUserId()!.Value;

        bool deleted = await _userActivityService.DeleteUserActivityAsync(id, userId);

        if (!deleted)
        {
            return NotFound(new { message = "User activity not found" });
        }

        return NoContent();
    }
}
