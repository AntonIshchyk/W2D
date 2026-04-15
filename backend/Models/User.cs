using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class User : BaseModel
{
    [Required]
    [MaxLength(30)]
    public string Username { get; set; } = null!;

    [MaxLength(160)]
    public string? Bio { get; set; }

    [MaxLength(500)]
    public string? ProfilePhotoUrl { get; set; }

    public bool ProfileSetupComplete { get; set; } = false;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = null!;
}
