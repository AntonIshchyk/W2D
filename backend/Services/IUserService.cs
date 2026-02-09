using Backend.Models;
using Backend.Contracts.Auth;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<LoginResponse?> RegisterUserAsync(string email, string password, string name, bool hasPassword = true);
    Task<LoginResponse?> LoginUserAsync(string email, string password);
    LoginResponse GenerateTokenForUser(User user);
    Task<bool> SetPasswordAsync(int userId, string newPassword);
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
}
