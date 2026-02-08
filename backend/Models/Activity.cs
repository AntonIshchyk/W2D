using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Activity : BaseModel
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(5000)]
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
}
