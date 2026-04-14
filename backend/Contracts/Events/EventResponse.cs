using Backend.Models;

namespace Backend.Contracts.Events;

public class EventResponse : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OrganizerId { get; set; }
    public string? OrganizerName { get; set; }
    public int? CommunityId { get; set; }
    public string? CommunityName { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? LocationName { get; set; }
    public string? PlaceId { get; set; }
}
