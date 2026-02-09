namespace Backend.Contracts.Comments;

public class CommentResponse
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public int PostId { get; set; }
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? CurrentUserVote { get; set; }
}
