using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Places;

public class UpdatePlaceRequest
{
    [MaxLength(120)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public int? CommunityId { get; set; }

    public List<string>? PhotoUrls { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
    public double? Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
    public double? Longitude { get; set; }

    [MaxLength(255)]
    public string? LocationName { get; set; }
}