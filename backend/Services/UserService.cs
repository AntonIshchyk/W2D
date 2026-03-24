using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Auth;
using Backend.Contracts.Users;

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

    public async Task<bool> IsUsernameTakenAsync(string username)
    {
        return await _context.Users
            .AnyAsync(u => u.Username == username.Trim());
    }

    public async Task<LoginResponse?> RegisterUserAsync(string email)
    {
        string username = email.Split('@')[0].ToLowerInvariant();

        var user = new User
        {
            Email = email,
            Username = username,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return GenerateTokenForUser(user);
    }

    public async Task<User> CompleteOnboardingAsync(int userId, OnboardingUpdateRequest request)
    {
        User user = await _context.Users.FirstAsync(u => u.Id == userId);

        string trimmedUsername = request.Username.Trim();

        user.Username = trimmedUsername;
        user.Bio = string.IsNullOrWhiteSpace(request.Bio) ? null : request.Bio.Trim();
        user.ProfilePhotoUrl = string.IsNullOrWhiteSpace(request.ProfilePhotoUrl) ? null : request.ProfilePhotoUrl.Trim();
        user.OnboardingCompleted = true;

        await _context.SaveChangesAsync();
        return user;
    }

    public LoginResponse GenerateTokenForUser(User user)
    {
        string token = _tokenService.GenerateToken(user);
        LoginResponse response = _mapper.Map<LoginResponse>(user);
        response.Token = token;
        return response;
    }
}