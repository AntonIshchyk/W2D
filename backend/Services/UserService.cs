using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Auth;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UserService(AppDbContext context, ITokenService tokenService, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _mapper = mapper;
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

    public LoginResponse GenerateTokenForUser(User user)
    {
        string token = _tokenService.GenerateToken(user);
        LoginResponse response = _mapper.Map<LoginResponse>(user);
        response.Token = token;
        return response;
    }

    public async Task<LoginResponse?> RegisterUserAsync(string email, string password, string name, bool hasPassword = true)
    {
        // Check if user already exists
        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            return null;
        }

        // Hash the password
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        // Create new user
        User user = new User
        {
            Email = email,
            Password = hashedPassword,
            Name = name,
            HasPassword = hasPassword
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return GenerateTokenForUser(user);
    }

    public async Task<LoginResponse?> LoginUserAsync(string email, string password)
    {
        // Find user by email
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        // Verify password
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return GenerateTokenForUser(user);
    }

    public async Task<bool> SetPasswordAsync(int userId, string newPassword)
    {
        User? user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        // Only allow setting password if user doesn't have one (Google user)
        if (user.HasPassword) return false;

        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        user.HasPassword = true;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
    {
        User? user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        // Verify current password
        if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
        {
            return false;
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _context.SaveChangesAsync();
        return true;
    }
}
