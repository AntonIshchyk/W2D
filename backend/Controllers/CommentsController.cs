using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Comments;
using Backend.Contracts.Common;
using Backend.Services;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
[Authorize]
[EnableRateLimiting("fixed")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentResponse>>> GetComments(int postId)
    {
        int currentUserId = User.GetUserId();
        var comments = await _commentService.GetCommentsAsync(postId, currentUserId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentResponse>> CreateComment(int postId, CreateCommentRequest request)
    {
        int userId = User.GetUserId();
        Result<CommentResponse> result = await _commentService.CreateCommentAsync(postId, request, userId);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return Created($"api/posts/{postId}/comments/{result.Value.Id}", result.Value);
    }

    [HttpDelete("{commentId}")]
    public async Task<ActionResult> DeleteComment(int postId, int commentId)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _commentService.DeleteCommentAsync(postId, commentId, userId);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return NoContent();
    }

    [HttpPost("{commentId}/vote")]
    public async Task<ActionResult> VoteComment(int postId, int commentId, VoteCommentRequest request)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _commentService.VoteCommentAsync(postId, commentId, userId, request.Value);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return Ok(new { message = "Vote recorded." });
    }
}
