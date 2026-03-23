namespace Backend.Contracts.Auth;

public class LoginResponse
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string? Username { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool IsOnboardingComplete { get; set; }
    public bool IsAdmin { get; set; }
    public string Token { get; set; } = null!;
}
