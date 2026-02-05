using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.DTOs;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Range(1, 120)]
    public int Age { get; set; }

    public Gender Gender { get; set; }
}
