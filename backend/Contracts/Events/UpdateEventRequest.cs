using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Contracts.Events;

public class UpdateEventRequest
{
    [MaxLength(120)]
    public string? Title { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int? ActivityId { get; set; }

    public List<int>? TagIds { get; set; }

    public DateTime? ScheduledAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "MaxAttendees must be a positive number.")]
    public int? MaxAttendees { get; set; }

    public EventStatus? Status { get; set; }
}
