using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Comments;
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
    public async Task<ActionResult<List<CommentResponse>>> GetComments(int postId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        int? currentUserId = User.GetUserId();
        List<CommentResponse> comments = await _commentService.GetCommentsAsync(postId, page, pageSize, currentUserId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentResponse>> CreateComment(int postId, CreateCommentRequest request)
    {
        int userId = User.GetUserId()!.Value;
        CommentResponse? comment = await _commentService.CreateCommentAsync(postId, request, userId);

        if (comment == null)
            return NotFound(new { message = "Post not found" });

        return Created($"api/posts/{postId}/comments/{comment.Id}", comment);
    }

    [HttpDelete("{commentId}")]
    public async Task<ActionResult> DeleteComment(int postId, int commentId)
    {
        int userId = User.GetUserId()!.Value;
        bool deleted = await _commentService.DeleteCommentAsync(commentId, userId);

        if (!deleted)
            return NotFound(new { message = "Comment not found or unauthorized" });

        return NoContent();
    }

    [HttpPost("{commentId}/vote")]
    public async Task<ActionResult> VoteComment(int postId, int commentId, VoteCommentRequest request)
    {
        int userId = User.GetUserId()!.Value;
        bool success = await _commentService.VoteCommentAsync(commentId, userId, request.Value);

        if (!success)
            return NotFound(new { message = "Comment not found" });

        return Ok(new { message = "Vote recorded successfully" });
    }

    [HttpGet("{parentCommentId}/replies")]
    public async Task<ActionResult<List<CommentResponse>>> GetReplies(int postId, int parentCommentId, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        int? currentUserId = User.GetUserId();
        var replies = await _commentService.GetRepliesAsync(parentCommentId, page, pageSize, currentUserId);
        return Ok(replies);
    }

}
