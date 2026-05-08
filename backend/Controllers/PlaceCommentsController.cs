using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Comments;
using Backend.Contracts.Common;
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
        int currentUserId = User.GetUserId();
        var comments = await _commentService.GetPlaceCommentsAsync(placeId, currentUserId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentResponse>> CreateComment(int placeId, CreateCommentRequest request)
    {
        int userId = User.GetUserId();
        Result<CommentResponse> result = await _commentService.CreatePlaceCommentAsync(placeId, request, userId);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return Created($"api/places/{placeId}/comments/{result.Value.Id}", result.Value);
    }

    [HttpPut("{commentId}")]
    public async Task<ActionResult<CommentResponse>> UpdateComment(int placeId, int commentId, UpdateCommentRequest request)
    {
        int userId = User.GetUserId();
        Result<CommentResponse> result = await _commentService.UpdatePlaceCommentAsync(placeId, commentId, request, userId);

        if (!result.IsSuccess || result.Value == null)
        {
            return result.ToActionResult(this);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{commentId}")]
    public async Task<ActionResult> DeleteComment(int placeId, int commentId)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _commentService.DeletePlaceCommentAsync(placeId, commentId, userId);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return NoContent();
    }

    [HttpPost("{commentId}/vote")]
    public async Task<ActionResult> VoteComment(int placeId, int commentId, VoteCommentRequest request)
    {
        int userId = User.GetUserId();
        Result<bool> result = await _commentService.VotePlaceCommentAsync(placeId, commentId, userId, request.Value);

        if (!result.IsSuccess)
        {
            return result.ToActionResult(this);
        }

        return Ok(new { message = "Vote recorded." });
    }
}