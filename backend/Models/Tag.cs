using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Tag : BaseModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public List<Activity> Activities { get; set; } = new List<Activity>();
}
