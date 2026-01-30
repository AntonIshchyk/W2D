using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Activity : BaseModel
{
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

    public List<Tag> Tags { get; set; } = new List<Tag>();

    public int? CreatedByUserId { get; set; }
    public User? CreatedBy { get; set; }

    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;

    public int? ApprovedByUserId { get; set; }
    public User? ApprovedBy { get; set; }
}
