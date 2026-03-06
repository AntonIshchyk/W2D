using System.Text.Json.Serialization;

namespace Backend.Models;

public class EventAttendee : BaseModel
{
    public int EventId { get; set; }

    [JsonIgnore]
    public Event? Event { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }

    public EventAttendeeStatus Status { get; set; } = EventAttendeeStatus.Confirmed;
}
