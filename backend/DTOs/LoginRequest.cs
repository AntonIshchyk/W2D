using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Password { get; set; } = null!;
}
