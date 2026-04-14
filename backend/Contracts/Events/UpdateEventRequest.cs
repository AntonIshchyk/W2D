using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Contracts.Events;

public class UpdateEventRequest
{
    [MaxLength(120)]
    public string? Title { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int? CommunityId { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public EventStatus? Status { get; set; }
}
