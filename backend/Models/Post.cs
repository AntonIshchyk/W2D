using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Post : BaseModel
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Content { get; set; } = string.Empty;

    [Required]
    public PostType Type { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;

    public int Score { get; set; }

    [StringLength(500)]
    public string? LocationName { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    [StringLength(200)]
    public string? PlaceId { get; set; }

    public int? Rating { get; set; }
    public int? DurationMinutes { get; set; }
    public decimal? Cost { get; set; }

    [StringLength(3)]
    public string? CurrencyCode { get; set; }

    public DateTime? CompletedAt { get; set; }

    public List<string> PhotoUrls { get; set; } = new();

    public int CommentCount { get; set; }

    public ICollection<PostVote> Votes { get; set; } = new List<PostVote>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
