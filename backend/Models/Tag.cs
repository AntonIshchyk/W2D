using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Tag : BaseModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public List<Activity> Activities { get; set; } = new List<Activity>();
}
