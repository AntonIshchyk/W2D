using Backend.Models;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<LoginResponse?> RegisterUserAsync(string email, string password, string name, int age, Gender gender);
    Task<LoginResponse?> LoginUserAsync(string email, string password);
}