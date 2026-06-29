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
[Route("api/places/{placeId}/comments")]
[Authorize]
[EnableRateLimiting("fixed")]
public class PlaceCommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public PlaceCommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentResponse>>> GetComments(int placeId)
    {
        var comments = await _commentService.GetCommentsAsync(placeId, CommentTarget.Place, User.GetUserId());
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentResponse>> CreateComment(int placeId, CreateCommentRequest request)
    {
        var result = await _commentService.CreateCommentAsync(placeId, CommentTarget.Place, request, User.GetUserId());
        if (!result.IsSuccess || result.Value == null) return result.ToActionResult(this);
        return Created($"api/places/{placeId}/comments/{result.Value.Id}", result.Value);
    }

    [HttpPut("{commentId}")]
    public async Task<ActionResult<CommentResponse>> UpdateComment(int placeId, int commentId, UpdateCommentRequest request)
    {
        var result = await _commentService.UpdateCommentAsync(placeId, commentId, CommentTarget.Place, request, User.GetUserId());
        if (!result.IsSuccess || result.Value == null) return result.ToActionResult(this);
        return Ok(result.Value);
    }

    [HttpDelete("{commentId}")]
    public async Task<ActionResult> DeleteComment(int placeId, int commentId)
    {
        var result = await _commentService.DeleteCommentAsync(placeId, commentId, CommentTarget.Place, User.GetUserId());
        if (!result.IsSuccess) return result.ToActionResult(this);
        return NoContent();
    }

    [HttpPost("{commentId}/vote")]
    public async Task<ActionResult> VoteComment(int placeId, int commentId, VoteCommentRequest request)
    {
        var result = await _commentService.VoteCommentAsync(placeId, commentId, CommentTarget.Place, User.GetUserId(), request.Value);
        if (!result.IsSuccess) return result.ToActionResult(this);
        return Ok(new { message = "Vote recorded." });
    }
}