using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Activity
{
    public Activity()
    {
        Tags = new List<Tag>();
        Status = ActivityStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public LocationType LocationType { get; set; }

    public CostLevel? CostLevel { get; set; }

    public PhysicalActivityLevel? PhysicalActivityLevel { get; set; }

    public Sociability? Sociability { get; set; }

    public EquipmentLevel? EquipmentLevel { get; set; }

    public EntryLevel? EntryLevel { get; set; }

    public List<Tag> Tags { get; set; }

    [Required]
    public int CreatedByUserId { get; set; }
    public User? CreatedBy { get; set; }

    public ActivityStatus Status { get; set; }

    public int? ApprovedByUserId { get; set; }
    public User? ApprovedBy { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
}
