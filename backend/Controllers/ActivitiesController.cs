using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Models;
using Backend.Services;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivities([FromQuery] bool approvedOnly = true)
    {
        var activities = approvedOnly
            ? await _activityService.GetApprovedActivitiesAsync()
            : await _activityService.GetAllActivitiesAsync();

        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(int id)
    {
        var activity = await _activityService.GetActivityByIdAsync(id);

        if (activity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        return Ok(activity);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Activity>> CreateActivity(Activity activity)
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        activity.CreatedByUserId = userId.Value;

        var createdActivity = await _activityService.CreateActivityAsync(activity);

        return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, createdActivity);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Activity>> UpdateActivity(int id, Activity activity)
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        var existingActivity = await _activityService.GetActivityByIdAsync(id);

        if (existingActivity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        // Only creator can update (or admin - we'll add admin check later)
        if (existingActivity.CreatedByUserId != userId.Value)
        {
            return Forbid();
        }

        var updatedActivity = await _activityService.UpdateActivityAsync(id, activity);

        return Ok(updatedActivity);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteActivity(int id)
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        var activity = await _activityService.GetActivityByIdAsync(id);

        if (activity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        // Only creator can delete (or admin - we'll add admin check later)
        if (activity.CreatedByUserId != userId.Value)
        {
            return Forbid();
        }

        var deleted = await _activityService.DeleteActivityAsync(id);

        return NoContent();
    }

    [HttpPost("{id}/approve")]
    [Authorize]
    public async Task<ActionResult<Activity>> ApproveActivity(int id)
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        if (!User.IsAdmin())
        {
            return Forbid();
        }

        var approvedActivity = await _activityService.ApproveActivityAsync(id, userId.Value);

        if (approvedActivity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        return Ok(approvedActivity);
    }

    [HttpPost("{id}/reject")]
    [Authorize]
    public async Task<ActionResult<Activity>> RejectActivity(int id)
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        if (!User.IsAdmin())
        {
            return Forbid();
        }

        var rejectedActivity = await _activityService.RejectActivityAsync(id);

        if (rejectedActivity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        return Ok(rejectedActivity);
    }
}
