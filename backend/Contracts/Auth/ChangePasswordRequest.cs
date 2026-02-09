using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Auth;

public class ChangePasswordRequest
{
    [Required]
    public string CurrentPassword { get; set; } = null!;

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string NewPassword { get; set; } = null!;
}
