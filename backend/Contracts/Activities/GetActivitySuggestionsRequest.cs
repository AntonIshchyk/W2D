using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Activities;

public class GetActivitySuggestionsRequest
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(30)]
    public string Social { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Mood { get; set; } = string.Empty;

    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
    public double Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
    public double Longitude { get; set; }

    [MaxLength(255)]
    public string? LocationName { get; set; }

    [MaxLength(500)]
    public string? ExtraNotes { get; set; }
}
