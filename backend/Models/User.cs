using System.Text.Json.Serialization;

namespace Backend.Models;

public enum Gender
{
    Male,
    Female
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;
}