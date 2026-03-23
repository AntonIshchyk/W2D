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
        string normalizedUsername = username.Trim().ToLowerInvariant();

        return await _context.Users
            .AnyAsync(u => u.Username.ToLower() == normalizedUsername);
    }

    public async Task<LoginResponse?> RegisterUserAsync(string email, string usernameSeed)
    {
        string baseUsername = usernameSeed
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "_");

        baseUsername = System.Text.RegularExpressions.Regex
            .Replace(baseUsername, "[^a-z0-9_]", string.Empty);

        if (string.IsNullOrWhiteSpace(baseUsername))
        {
            baseUsername = email.Split('@')[0].ToLowerInvariant();
            baseUsername = System.Text.RegularExpressions.Regex
                .Replace(baseUsername, "[^a-z0-9_]", string.Empty);
        }

        if (baseUsername.Length < 3)
        {
            baseUsername = (baseUsername + "user").PadRight(3, '0');
        }

        if (baseUsername.Length > 20)
        {
            baseUsername = baseUsername[..20];
        }

        string candidate = baseUsername;
        int suffix = 1;
        while (await IsUsernameTakenAsync(candidate))
        {
            string suffixText = suffix.ToString();
            int maxBaseLength = Math.Max(3, 20 - suffixText.Length);
            string trimmedBase = baseUsername[..Math.Min(baseUsername.Length, maxBaseLength)];
            candidate = $"{trimmedBase}{suffixText}";
            suffix++;
        }

        var user = new User
        {
            Email = email,
            Username = candidate,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return GenerateTokenForUser(user);
    }

    public async Task<User> CompleteOnboardingAsync(int userId, OnboardingUpdateRequest request)
    {
        User user = await _context.Users.FirstAsync(u => u.Id == userId);

        string normalizedUsername = request.Username.Trim().ToLowerInvariant();

        user.Username = normalizedUsername;
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