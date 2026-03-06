using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Event : BaseModel
{
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [Required]
    public int OrganizerId { get; set; }

    [JsonIgnore]
    public User? Organizer { get; set; }

    public int? ActivityId { get; set; }
    public Activity? Activity { get; set; }

    public List<Tag> Tags { get; set; } = new();

    [Required]
    public DateTime ScheduledAt { get; set; }

    public int? MaxAttendees { get; set; }

    public EventStatus Status { get; set; } = EventStatus.Open;

    public ICollection<EventAttendee> Attendees { get; set; } = new List<EventAttendee>();
}
