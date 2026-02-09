using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Auth;

public class SetPasswordRequest
{
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string NewPassword { get; set; } = null!;
}
