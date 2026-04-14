using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Comments;

public class VoteCommentRequest
{
    [Required]
    [Range(-1, 1)]
    public int Value { get; set; }
}
