using Backend.Contracts.Users;

namespace Backend.Contracts.Posts;

public class PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Type { get; set; }
    public UserSummary? Author { get; set; }
    public int TopicId { get; set; }
    public string? CommunityName { get; set; }
    public int Score { get; set; }
    public string? LocationName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? PlaceId { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<string> PhotoUrls { get; set; } = new();
    public int CommentCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? CurrentUserVote { get; set; } // -1, 0 (no vote), or +1
}
