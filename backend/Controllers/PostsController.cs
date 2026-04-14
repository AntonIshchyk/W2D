using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Posts;
using Backend.Contracts.Common;
using Backend.Services;
using Backend.Extensions;
using Backend.Constants;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<ScrollResult<PostResponse>>> GetPosts(
        [FromQuery] int? cursor = null,
        [FromQuery] int limit = PaginationConstants.DefaultPageSize,
        [FromQuery] int? topicId = null,
        [FromQuery] int? userId = null,
        [FromQuery] int? type = null,
        [FromQuery] string? sortBy = null)
    {
        if (limit < PaginationConstants.MinPageSize || limit > PaginationConstants.MaxPageSize)
        {
            return BadRequest(new { message = $"Invalid limit parameter. Limit must be between {PaginationConstants.MinPageSize} and {PaginationConstants.MaxPageSize}." });
        }

        int currentUserId = User.GetUserId();

        ScrollResult<PostResponse> result = await _postService.GetPostsAsync(
            cursor,
            limit,
            topicId,
            userId,
            type,
            sortBy,
            currentUserId);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostResponse>> GetPost(int id)
    {
        int currentUserId = User.GetUserId();

        Result<PostResponse> result = await _postService.GetPostByIdAsync(id, currentUserId);
        return result.ToActionResult(this);
    }

    [HttpPost]
    public async Task<ActionResult<PostResponse>> CreatePost(CreatePostRequest request)
    {
        int userId = User.GetUserId();
        Result<PostResponse> result = await _postService.CreatePostAsync(request, userId);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return CreatedAtAction(nameof(GetPost), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PostResponse>> UpdatePost(int id, UpdatePostRequest request)
    {
        int userId = User.GetUserId();
        Result<PostResponse> result = await _postService.UpdatePostAsync(id, request, userId);
        return result.ToActionResult(this);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        int userId = User.GetUserId();

        Result<bool> result = await _postService.DeletePostAsync(id, userId);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return NoContent();
    }

    [HttpPost("{id}/vote")]
    public async Task<ActionResult> VotePost(int id, VotePostRequest request)
    {
        int userId = User.GetUserId();

        Result<bool> result = await _postService.VotePostAsync(id, userId, request.Value);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return Ok(new { message = "Vote recorded." });
    }
}
