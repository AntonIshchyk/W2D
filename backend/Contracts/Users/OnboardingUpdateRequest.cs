using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Users;

public class UpdateUserProfileRequest
{
    [Required]
    [RegularExpression("^[A-Za-z0-9_]{3,20}$")]
    public string Username { get; set; } = string.Empty;

    [MaxLength(160)]
    public string? Bio { get; set; }
}
