using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Events;

public class CreateEventRequest
{
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = null!;

    public int? CommunityId { get; set; }

    [Required]
    public DateTime ScheduledAt { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    [MaxLength(255)]
    public string? LocationName { get; set; }

    public List<string> PhotoUrls { get; set; } = new();
}
