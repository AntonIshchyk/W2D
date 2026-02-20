using Backend.Models;
using Backend.Contracts.Auth;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    LoginResponse GenerateTokenForUser(User user);
    Task<LoginResponse?> RegisterUserAsync(string email, string name);
}
