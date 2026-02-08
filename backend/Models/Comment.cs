using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Comment : BaseModel
{
    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    public int Score { get; set; }

    public ICollection<CommentVote> Votes { get; set; } = new List<CommentVote>();
}
