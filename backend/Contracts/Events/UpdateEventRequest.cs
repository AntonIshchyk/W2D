using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Events;

public class UpdateEventRequest
{
    [MaxLength(120)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public int? CommunityId { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public List<string>? PhotoUrls { get; set; }
}
