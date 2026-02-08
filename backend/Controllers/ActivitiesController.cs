using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;
using Backend.Constants;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
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
            List<int> tagIds = activity.Tags.Select(t => t.Id).ToList();
            IEnumerable<Tag> existingTags = await _activityService.GetTagsByIdsAsync(tagIds);

            if (existingTags.Count() != tagIds.Count)
            {
                return BadRequest(new { message = "One or more Tag IDs are invalid." });
            }

            activity.Tags = existingTags.ToList();
        }

        return null; // No error
    }

    [HttpGet]
    public async Task<ActionResult<ScrollResult<Activity>>> GetActivities(
        [FromQuery] int? cursor = null,
        [FromQuery] int limit = PaginationConstants.DefaultPageSize,
        [FromQuery] int? categoryId = null,
        [FromQuery] List<int>? tagIds = null)
    {
        if (limit < PaginationConstants.MinPageSize || limit > PaginationConstants.MaxPageSize)
        {
            return BadRequest(new { message = $"Invalid limit parameter. Limit must be between {PaginationConstants.MinPageSize} and {PaginationConstants.MaxPageSize}." });
        }

        ScrollResult<Activity> result = await _activityService.GetActivitiesAsync(cursor, limit, categoryId, tagIds);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(int id)
    {
        Activity? activity = await _activityService.GetActivityByIdAsync(id);

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
        ActionResult<Activity>? validationError = await ValidateAndSetTags(activity);
        if (validationError != null)
        {
            return validationError;
        }

        Activity createdActivity = await _activityService.CreateActivityAsync(activity);

        return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, createdActivity);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Activity>> UpdateActivity(int id, Activity activity)
    {
        ActionResult<Activity>? validationError = await ValidateAndSetTags(activity);
        if (validationError != null)
        {
            return validationError;
        }

        Activity? updatedActivity = await _activityService.UpdateActivityAsync(id, activity);

        if (updatedActivity == null)
        {
            return NotFound(new { message = "Activity not found" });
        }

        return Ok(updatedActivity);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteActivity(int id)
    {
        bool deleted = await _activityService.DeleteActivityAsync(id);

        if (!deleted)
        {
            return NotFound(new { message = "Activity not found" });
        }

        return NoContent();
    }
}
