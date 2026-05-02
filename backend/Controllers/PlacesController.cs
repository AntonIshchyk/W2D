using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Places;
using Backend.Contracts.Common;
using Backend.Services;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class PlacesController : ControllerBase
{
    private readonly IPlaceService _placeService;

    public PlacesController(IPlaceService placeService)
    {
        _placeService = placeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlaceResponse>>> GetPlaces(
        [FromQuery(Name = "communityId")] int[]? communityIds = null,
        [FromQuery] double? minLat = null,
        [FromQuery] double? maxLat = null,
        [FromQuery] double? minLng = null,
        [FromQuery] double? maxLng = null,
        [FromQuery] int? userId = null)
    {
        IEnumerable<PlaceResponse> result = await _placeService.GetPlacesAsync(
            communityIds, minLat, maxLat, minLng, maxLng, userId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlaceResponse>> GetPlace(int id)
    {
        Result<PlaceResponse> result = await _placeService.GetPlaceByIdAsync(id);
        return result.ToActionResult(this);
    }

    [HttpPost]
    public async Task<ActionResult<PlaceResponse>> CreatePlace(CreatePlaceRequest request)
    {
        int userId = User.GetUserId();
        Result<PlaceResponse> result = await _placeService.CreatePlaceAsync(userId, request);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return CreatedAtAction(nameof(GetPlace), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlaceResponse>> UpdatePlace(int id, UpdatePlaceRequest request)
    {
        int userId = User.GetUserId();
        Result<PlaceResponse> result = await _placeService.UpdatePlaceAsync(id, userId, request);
        return result.ToActionResult(this);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlace(int id)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _placeService.DeletePlaceAsync(id, userId);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return NoContent();
    }
}
