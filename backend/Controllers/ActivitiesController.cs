using Backend.Contracts.Activities;
using Backend.Services;
using Backend.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivitySuggestionService _activitySuggestionService;

    public ActivitiesController(IActivitySuggestionService activitySuggestionService)
    {
        _activitySuggestionService = activitySuggestionService;
    }

    [HttpPost("suggestions")]
    public async Task<ActionResult<ActivitySuggestionResponse>> GetSuggestions(
        [FromBody] GetActivitySuggestionsRequest request,
        CancellationToken cancellationToken)
    {
        int userId = User.GetUserId();
        var result = await _activitySuggestionService.GetSuggestionsAsync(userId, request, cancellationToken);
        return result.ToActionResult(this);
    }
}
