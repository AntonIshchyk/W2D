using Backend.Contracts.Comments;
using Backend.Contracts.Common;
using Backend.Models;

namespace Backend.Services;

public interface ICommentService
{
    Task<List<CommentResponse>> GetCommentsAsync(int entityId, CommentTarget target, int? currentUserId = null);
    Task<Result<CommentResponse>> CreateCommentAsync(int entityId, CommentTarget target, CreateCommentRequest request, int userId);
    Task<Result<CommentResponse>> UpdateCommentAsync(int entityId, int commentId, CommentTarget target, UpdateCommentRequest request, int userId);
    Task<Result<bool>> DeleteCommentAsync(int entityId, int commentId, CommentTarget target, int userId);
    Task<Result<bool>> VoteCommentAsync(int entityId, int commentId, CommentTarget target, int userId, int value);
}