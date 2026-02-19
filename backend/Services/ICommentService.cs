using Backend.Contracts.Comments;

namespace Backend.Services;

public interface ICommentService
{
    Task<List<CommentResponse>> GetCommentsAsync(int postId, int? currentUserId = null);

    Task<CommentResponse?> CreateCommentAsync(int postId, CreateCommentRequest request, int userId);

    Task<bool> DeleteCommentAsync(int commentId, int userId);

    Task<bool> VoteCommentAsync(int commentId, int userId, int value);
}
