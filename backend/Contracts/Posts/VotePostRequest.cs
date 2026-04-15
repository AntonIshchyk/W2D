using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Posts;

public class VotePostRequest
{
    [Required]
    [Range(-1, 1)]
    public int Value { get; set; }
}
