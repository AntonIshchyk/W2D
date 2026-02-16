using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Comments;

public class CreateCommentRequest
{
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string Content { get; set; } = string.Empty;

    // Optional: for replies
    public int? ParentCommentId { get; set; }
}
