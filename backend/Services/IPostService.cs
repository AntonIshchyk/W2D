using Backend.Models;
using Backend.DTOs;
using Backend.Constants;

namespace Backend.Services;

public interface IPostService
{
    Task<ScrollResult<PostResponse>> GetPostsAsync(
        int? cursor = null,
        int limit = PaginationConstants.DefaultPageSize,
        int? activityId = null,
        int? userId = null,
        int? type = null,
        string? sortBy = null,
        int? currentUserId = null);

    Task<PostResponse?> GetPostByIdAsync(int id, int? currentUserId = null);
    Task<Post> CreatePostAsync(CreatePostRequest request, int userId);
    Task<Post?> UpdatePostAsync(int id, UpdatePostRequest request, int userId);
    Task<bool> DeletePostAsync(int id, int userId);
    Task<bool> VotePostAsync(int postId, int userId, int value);
    Task<bool> ActivityExistsAsync(int activityId);
}
