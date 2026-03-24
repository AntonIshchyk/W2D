using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Users;

public class OnboardingUpdateRequest
{
    [Required]
    [RegularExpression("^[A-Za-z0-9_]{3,20}$")]
    public string Username { get; set; } = string.Empty;

    [MaxLength(160)]
    public string? Bio { get; set; }

    [MaxLength(500)]
    public string? ProfilePhotoUrl { get; set; }
}
