using Backend.Models;
using Backend.Contracts.Auth;
using Backend.Contracts.Users;
using Backend.Contracts.Common;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<Result<LoginResponse>> UpdateUserProfileAsync(int userId, UpdateUserProfileRequest request);
    Task<Result<bool>> DeleteUserAccountAsync(int userId);
    LoginResponse GenerateTokenForUser(User user);
    Task<Result<LoginResponse>> RegisterUserAsync(string email);
}
