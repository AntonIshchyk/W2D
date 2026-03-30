using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Events;

public class CreateEventRequest
{
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    public int? TopicId { get; set; }

    public List<int> TagIds { get; set; } = new();

    [Required]
    public DateTime ScheduledAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "MaxAttendees must be a positive number.")]
    public int? MaxAttendees { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    [MaxLength(255)]
    public string? LocationName { get; set; }
}
