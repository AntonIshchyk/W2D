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
}
