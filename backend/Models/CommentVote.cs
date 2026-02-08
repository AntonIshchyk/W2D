using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class CommentVote : BaseModel
{
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int CommentId { get; set; }
    public Comment Comment { get; set; } = null!;

    [Required]
    public int Value { get; set; } // -1 for downvote, +1 for upvote
}
