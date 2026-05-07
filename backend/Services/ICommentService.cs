using Backend.Contracts.Comments;
using Backend.Contracts.Common;

namespace Backend.Services;

public interface ICommentService
{
    Task<List<CommentResponse>> GetCommentsAsync(int postId, int? currentUserId = null);

    Task<Result<CommentResponse>> CreateCommentAsync(int postId, CreateCommentRequest request, int userId);

    Task<Result<CommentResponse>> UpdateCommentAsync(int postId, int commentId, UpdateCommentRequest request, int userId);

    Task<Result<bool>> DeleteCommentAsync(int postId, int commentId, int userId);

    Task<Result<bool>> VoteCommentAsync(int postId, int commentId, int userId, int value);
}
