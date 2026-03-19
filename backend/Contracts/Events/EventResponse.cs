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
    public List<TagDto> Tags { get; set; } = new();
    public DateTime ScheduledAt { get; set; }
    public int? MaxAttendees { get; set; }
    public int AttendeeCount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? CurrentUserRsvp { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class TagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
