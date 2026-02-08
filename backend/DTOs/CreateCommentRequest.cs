using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class CreateCommentRequest
{
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string Content { get; set; } = string.Empty;
}
