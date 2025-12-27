using Backend.Models;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<LoginResponse?> RegisterUserAsync(string email, string password);
    Task<LoginResponse?> LoginUserAsync(string email, string password);
}