using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Common;
using Backend.Contracts.Communities;
using Backend.Extensions;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("fixed")]
[Authorize]
public class CommunitiesController : ControllerBase
{
    private readonly ICommunityService _communityService;

    public CommunitiesController(ICommunityService communityService)
    {
        _communityService = communityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommunityResponse>>> GetCommunities()
    {
        List<CommunityResponse> communities = await _communityService.GetCommunitiesAsync();
        return Ok(communities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommunityResponse>> GetCommunity(int id)
    {
        Result<CommunityResponse> result = await _communityService.GetCommunityByIdAsync(id);
        return result.ToActionResult(this);
    }
}
