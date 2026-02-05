using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Models;
using Backend.Services;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    private async Task<ActionResult<Activity>?> ValidateAndSetTags(Activity activity)
    {
        // Validate CategoryId exists
        if (!await _activityService.CategoryExistsAsync(activity.CategoryId))
        {
            return BadRequest(new { message = "Invalid CategoryId. Category does not exist." });
        }

        // Validate Tags exist and replace with tracked entities
        if (activity.Tags != null && activity.Tags.Any())
        {
            var tagIds = activity.Tags.Select(t => t.Id).ToList();
            var existingTags = await _activityService.GetTagsByIdsAsync(tagIds);

            if (existingTags.Count() != tagIds.Count)
            {
                return BadRequest(new { message = "One or more Tag IDs are invalid." });
            }

            activity.Tags = existingTags.ToList();
        }

        return null; // No error
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<Activity>>> GetActivities(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] int? categoryId = null,
        [FromQuery] List<int>? tagIds = null)
    {
        if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
        {
            return BadRequest(new { message = "Invalid pagination parameters. PageNumber must be >= 1 and PageSize must be between 1 and 100." });
        }

        var result = await _activityService.GetActivitiesAsync(pageNumber, pageSize, categoryId, tagIds);

        return Ok(result);
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
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Activity>> CreateActivity(Activity activity)
    {
        var validationError = await ValidateAndSetTags(activity);
        if (validationError != null)
        {
            return validationError;
        }

        var createdActivity = await _activityService.CreateActivityAsync(activity);

        return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, createdActivity);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Activity>> UpdateActivity(int id, Activity activity)
    {
        var existingActivity = await _activityService.GetActivityByIdAsync(id);

        if (existingActivity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        var validationError = await ValidateAndSetTags(activity);
        if (validationError != null)
        {
            return validationError;
        }

        var updatedActivity = await _activityService.UpdateActivityAsync(id, activity);

        return Ok(updatedActivity);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteActivity(int id)
    {
        var activity = await _activityService.GetActivityByIdAsync(id);

        if (activity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        await _activityService.DeleteActivityAsync(id);

        return NoContent();
    }
}
