using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Posts;

public class CreatePostRequest
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000, MinimumLength = 10)]
    public string Content { get; set; } = string.Empty;

    [Required]
    [Range(1, 6)]
    public int Type { get; set; }

    [Required]
    public int ActivityId { get; set; }

    [StringLength(500)]
    public string? LocationName { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
    public double? Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
    public double? Longitude { get; set; }

    [StringLength(200)]
    public string? PlaceId { get; set; }

    [Range(1, 5)]
    public int? Rating { get; set; }

    [Range(1, 10000)]
    public int? DurationMinutes { get; set; }

    [Range(0, 1000000)]
    public decimal? Cost { get; set; }

    [StringLength(3)]
    [RegularExpression("^[A-Z]{3}$", ErrorMessage = "Currency code must be a valid 3-letter ISO 4217 code (e.g., USD, EUR)")]
    public string? CurrencyCode { get; set; }

    public DateTime? CompletedAt { get; set; }

    public List<string> PhotoUrls { get; set; } = new();
}
