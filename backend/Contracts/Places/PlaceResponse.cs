namespace Backend.Contracts.Places;

public class PlaceResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserPhotoUrl { get; set; }
    public int? CommunityId { get; set; }
    public string? CommunityName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? LocationName { get; set; }
    public int Score { get; set; }
    public int CommentCount { get; set; }
    public int? CurrentUserVote { get; set; }
    public List<string> PhotoUrls { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
