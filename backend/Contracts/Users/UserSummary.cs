namespace Backend.Contracts.Users;

public class UserSummary
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? ProfilePhotoUrl { get; set; }
}
