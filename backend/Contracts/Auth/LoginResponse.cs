namespace Backend.Contracts.Auth;

public class LoginResponse
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public bool HasPassword { get; set; }
    public string Token { get; set; } = null!;
}
