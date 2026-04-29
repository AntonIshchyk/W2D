using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Post : BaseModel
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public PostType Type { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? CommunityId { get; set; }
    public Community? Community { get; set; }

    public int Score { get; set; }

    [StringLength(500)]
    public string? LocationName { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public List<string> PhotoUrls { get; set; } = new();

    public int CommentCount { get; set; }

    public ICollection<PostVote> Votes { get; set; } = new List<PostVote>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
