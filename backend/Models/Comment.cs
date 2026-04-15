using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Comment : BaseModel
{
    [StringLength(1000)]
    public string? Content { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int Score { get; set; }
    public bool IsDeleted { get; set; } = false;

    public string? PhotoUrl { get; set; }

    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    public ICollection<CommentVote> Votes { get; set; } = new List<CommentVote>();
}
