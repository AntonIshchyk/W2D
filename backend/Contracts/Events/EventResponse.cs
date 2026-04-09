namespace Backend.Contracts.Events;

public class EventResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OrganizerId { get; set; }
    public string? OrganizerName { get; set; }
    public int? SpaceId { get; set; }
    public string? CommunityName { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? LocationName { get; set; }
    public string? PlaceId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
