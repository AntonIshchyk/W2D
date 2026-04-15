using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Posts;

public class CreatePostRequest
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(1000, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, 6)]
    public int Type { get; set; }

    [Required]
    public int TopicId { get; set; }

    [StringLength(500)]
    public string? LocationName { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
    public double? Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
    public double? Longitude { get; set; }

    public DateTime? CompletedAt { get; set; }

    public List<string> PhotoUrls { get; set; } = new();
}
