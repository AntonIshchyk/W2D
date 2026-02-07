namespace Backend.DTOs;

public class PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Type { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public int ActivityId { get; set; }
    public string? ActivityTitle { get; set; }
    public int Score { get; set; }
    public string? LocationName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? PlaceId { get; set; }
    public int? Rating { get; set; }
    public int? DurationMinutes { get; set; }
    public decimal? Cost { get; set; }
    public string? CurrencyCode { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<string> PhotoUrls { get; set; } = new();
    public int CommentCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? CurrentUserVote { get; set; } // -1, 0 (no vote), or +1
}
