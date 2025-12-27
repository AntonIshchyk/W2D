using System.Text.Json.Serialization;

namespace Backend.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;
}