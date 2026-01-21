using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public enum Gender
{
    Male,
    Female
}

public class User
{
    public User()
    {
        IsAdmin = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = null!;

    [Range(1, 120)]
    public int Age { get; set; }

    public Gender Gender { get; set; }

    public bool IsAdmin { get; set; }

    [Required]
    [JsonIgnore]
    public string Password { get; set; } = null!;

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
}