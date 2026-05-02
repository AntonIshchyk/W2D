using Backend.Models;

namespace Backend.Contracts.Comments;

public class CommentResponse : BaseModel
{
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserPhotoUrl { get; set; }
    public int PostId { get; set; }
    public int Score { get; set; }

    public int? CurrentUserVote { get; set; }

    public bool IsDeleted { get; set; }

    public string? PhotoUrl { get; set; }

    public int? ParentCommentId { get; set; }

    public List<CommentResponse> Replies { get; set; } = new();
}
