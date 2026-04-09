using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Event : BaseModel
{
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [Required]
    public int OrganizerId { get; set; }

    [JsonIgnore]
    public User? Organizer { get; set; }

    public int? SpaceId { get; set; }
    public Community? Community { get; set; }

    [Required]
    public DateTime ScheduledAt { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    [MaxLength(255)]
    public string? LocationName { get; set; }

    [MaxLength(255)]
    public string? PlaceId { get; set; }

    public EventStatus Status { get; set; } = EventStatus.Open;
}
