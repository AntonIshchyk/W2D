namespace Backend.DTOs;

public class ScheduleActivityRequest
{
    public int ActivityId { get; set; }
    public DateTime PlannedDate { get; set; }
    public string? Notes { get; set; }
}
