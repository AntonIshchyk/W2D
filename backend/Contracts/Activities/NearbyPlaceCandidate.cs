namespace Backend.Contracts.Activities;

public sealed class NearbyPlaceCandidate
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? CommunityName { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Score { get; set; }
    public string? LocationName { get; set; }
}
