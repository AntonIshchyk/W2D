using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public UserService(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public LoginResponse GenerateTokenForUserAsync(User user)
    {
        var token = _tokenService.GenerateToken(user);

        return new LoginResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Name = user.Name,
            Age = user.Age,
            Gender = user.Gender,
            IsAdmin = user.IsAdmin,
            Token = token
        };
    }

    public async Task<LoginResponse?> RegisterUserAsync(string email, string password, string name, int age, Gender gender)
    {
        // Check if user already exists
        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            return null;
        }

        // Hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        // Create new user
        var user = new User
        {
            Email = email,
            Password = hashedPassword,
            Name = name,
            Age = age,
            Gender = gender
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return GenerateTokenForUserAsync(user);
    }

    public async Task<LoginResponse?> LoginUserAsync(string email, string password)
    {
        // Find user by email
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        // Verify password
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return GenerateTokenForUserAsync(user);
    }
}