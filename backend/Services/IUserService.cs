using Backend.Models;
using Backend.Contracts.Auth;
using Backend.Contracts.Users;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> IsUsernameTakenAsync(string username);
    Task<User> UpdateUserProfileAsync(int userId, UpdateUserProfileRequest request);
    LoginResponse GenerateTokenForUser(User user);
    Task<LoginResponse?> RegisterUserAsync(string email);
}
