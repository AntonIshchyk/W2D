using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Comments;

public class UpdateCommentRequest
{
    [StringLength(300)]
    public string? Content { get; set; }

    public string? PhotoUrl { get; set; }
}