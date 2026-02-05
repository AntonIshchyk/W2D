using System.Text.Json.Serialization;

namespace Backend.Models;

public class UserActivity : BaseModel
{
    public int UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }

    public int ActivityId { get; set; }

    public Activity? Activity { get; set; }

    public DateTime PlannedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public ScheduleStatus Status { get; set; } = ScheduleStatus.Planned;

    public string? Notes { get; set; }
}
