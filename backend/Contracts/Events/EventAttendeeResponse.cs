namespace Backend.Contracts.Events;

public class EventAttendeeResponse
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime JoinedAt { get; set; }
}
