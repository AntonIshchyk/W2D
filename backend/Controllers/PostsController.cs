using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Models;
using Backend.DTOs;
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
        [FromQuery] int? activityId = null,
        [FromQuery] int? userId = null,
        [FromQuery] int? type = null,
        [FromQuery] string? sortBy = null)
    {
        if (limit < PaginationConstants.MinPageSize || limit > PaginationConstants.MaxPageSize)
        {
            return BadRequest(new { message = $"Invalid limit parameter. Limit must be between {PaginationConstants.MinPageSize} and {PaginationConstants.MaxPageSize}." });
        }

        int? currentUserId = User.GetUserId();

        ScrollResult<PostResponse> result = await _postService.GetPostsAsync(
            cursor,
            limit,
            activityId,
            userId,
            type,
            sortBy,
            currentUserId);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostResponse>> GetPost(int id)
    {
        int? currentUserId = User.GetUserId();

        PostResponse? post = await _postService.GetPostByIdAsync(id, currentUserId);

        if (post == null)
        {
            return NotFound(new { message = "Post not found" });
        }

        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(CreatePostRequest request)
    {
        int userId = User.GetUserId()!.Value;

        try
        {
            Post createdPost = await _postService.CreatePostAsync(request, userId);
            return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> UpdatePost(int id, UpdatePostRequest request)
    {
        int userId = User.GetUserId()!.Value;

        try
        {
            Post? updatedPost = await _postService.UpdatePostAsync(id, request, userId);

            if (updatedPost == null)
            {
                return NotFound(new { message = "Post not found or unauthorized" });
            }

            return Ok(updatedPost);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        int userId = User.GetUserId()!.Value;

        bool deleted = await _postService.DeletePostAsync(id, userId);

        if (!deleted)
        {
            return NotFound(new { message = "Post not found or unauthorized" });
        }

        return NoContent();
    }

    [HttpPost("{id}/vote")]
    public async Task<ActionResult> VotePost(int id, VotePostRequest request)
    {
        int userId = User.GetUserId()!.Value;

        bool success = await _postService.VotePostAsync(id, userId, request.Value);

        if (!success)
        {
            return NotFound(new { message = "Post not found" });
        }

        return Ok(new { message = "Vote recorded successfully" });
    }
}
