using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Comments;

public class CreateCommentRequest
{
    [StringLength(1000)]
    public string? Content { get; set; }

    public int? ParentCommentId { get; set; }

    public string? PhotoUrl { get; set; }
}
