using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Tag
{
    public Tag()
    {
        Activities = new List<Activity>();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public List<Activity> Activities { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
}
