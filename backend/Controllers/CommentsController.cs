using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Comments;
using Backend.Contracts.Common;
using Backend.Models;
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
        var comments = await _commentService.GetCommentsAsync(postId, CommentTarget.Post, User.GetUserId());
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentResponse>> CreateComment(int postId, CreateCommentRequest request)
    {
        var result = await _commentService.CreateCommentAsync(postId, CommentTarget.Post, request, User.GetUserId());
        if (!result.IsSuccess || result.Value == null) return result.ToActionResult(this);
        return Created($"api/posts/{postId}/comments/{result.Value.Id}", result.Value);
    }

    [HttpPut("{commentId}")]
    public async Task<ActionResult<CommentResponse>> UpdateComment(int postId, int commentId, UpdateCommentRequest request)
    {
        var result = await _commentService.UpdateCommentAsync(postId, commentId, CommentTarget.Post, request, User.GetUserId());
        if (!result.IsSuccess || result.Value == null) return result.ToActionResult(this);
        return Ok(result.Value);
    }

    [HttpDelete("{commentId}")]
    public async Task<ActionResult> DeleteComment(int postId, int commentId)
    {
        var result = await _commentService.DeleteCommentAsync(postId, commentId, CommentTarget.Post, User.GetUserId());
        if (!result.IsSuccess) return result.ToActionResult(this);
        return NoContent();
    }

    [HttpPost("{commentId}/vote")]
    public async Task<ActionResult> VoteComment(int postId, int commentId, VoteCommentRequest request)
    {
        var result = await _commentService.VoteCommentAsync(postId, commentId, CommentTarget.Post, User.GetUserId(), request.Value);
        if (!result.IsSuccess) return result.ToActionResult(this);
        return Ok(new { message = "Vote recorded." });
    }
}