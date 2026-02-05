using Backend.Models;
using Backend.DTOs;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<LoginResponse?> RegisterUserAsync(string email, string password, string name, int age, Gender gender);
    Task<LoginResponse?> LoginUserAsync(string email, string password);
    LoginResponse GenerateTokenForUserAsync(User user);
}