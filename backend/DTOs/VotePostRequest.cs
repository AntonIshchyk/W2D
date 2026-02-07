using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class VotePostRequest
{
    [Required]
    [Range(-1, 1)]
    public int Value { get; set; } // -1 for downvote, 0 to remove vote, +1 for upvote
}
