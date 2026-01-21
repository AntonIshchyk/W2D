namespace Backend.Models;

public class LoginResponse
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public bool IsAdmin { get; set; }
    public string Token { get; set; } = null!;
}
