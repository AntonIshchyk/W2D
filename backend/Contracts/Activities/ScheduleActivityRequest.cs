using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Activities;

public class ScheduleActivityRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ActivityId must be a positive integer.")]
    public int ActivityId { get; set; }

    [Required]
    public DateTime PlannedDate { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}
