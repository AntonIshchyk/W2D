using Backend.Models;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> RegisterUserAsync(string email, string password);
    Task<User?> LoginUserAsync(string email, string password);
}