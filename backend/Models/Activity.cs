using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Activity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    // An actual img in future, not an URL
    public string? ImageUrl { get; set; }

    [Required]
    public int CreatedByUserId { get; set; }
    public User? CreatedBy { get; set; }

    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;

    public int? ApprovedByUserId { get; set; }
    public User? ApprovedBy { get; set; }

    public bool IsPassive { get; set; }

    public bool IsSolo { get; set; }

    public LocationType LocationType { get; set; }

    public int? EstimatedDuration { get; set; }

    public EntryLevel? EntryLevel { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
}
