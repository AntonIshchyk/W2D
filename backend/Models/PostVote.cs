using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class PostVote : BaseModel
{
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    [Required]
    public int Value { get; set; }
}
