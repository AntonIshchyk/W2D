using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Auth;
using Backend.Contracts.Users;
using Backend.Contracts.Common;
using Backend.Extensions;

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

    public async Task<Result<LoginResponse>> RegisterUserAsync(string email)
    {
        string normalizedEmail = email.Trim();

        if (string.IsNullOrWhiteSpace(normalizedEmail))
        {
            return Result<LoginResponse>.Invalid("Email is required.");
        }

        string baseUsername = normalizedEmail.Split('@')[0].ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(baseUsername))
        {
            baseUsername = "user";
        }

        string username = baseUsername;
        int suffix = 1;
        while (await _context.Users.AnyAsync(u => u.Username == username))
        {
            username = $"{baseUsername}{suffix}";
            suffix++;
        }

        var user = new User
        {
            Email = normalizedEmail,
            Username = username,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return Result<LoginResponse>.Success(GenerateTokenForUser(user));
    }

    public async Task<Result<LoginResponse>> UpdateUserProfileAsync(int userId, UpdateUserProfileRequest request)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return Result<LoginResponse>.NotFound("User not found.");
        }

        string trimmedUsername = request.Username.Trim();

        if (string.IsNullOrWhiteSpace(trimmedUsername))
        {
            return Result<LoginResponse>.Invalid("Username is required.");
        }

        bool usernameTaken = await _context.Users
            .AnyAsync(u => u.Id != userId && u.Username == trimmedUsername);

        if (usernameTaken)
        {
            return Result<LoginResponse>.Invalid("Username is already taken.");
        }

        if (!PhotoUrlValidationExtensions.TryValidateOptionalPhotoUrl(request.ProfilePhotoUrl, nameof(request.ProfilePhotoUrl), out string? profilePhotoError))
        {
            return Result<LoginResponse>.Invalid(profilePhotoError!);
        }

        user.Username = trimmedUsername;
        user.Bio = string.IsNullOrWhiteSpace(request.Bio) ? null : request.Bio.Trim();
        user.ProfilePhotoUrl = string.IsNullOrWhiteSpace(request.ProfilePhotoUrl) ? null : request.ProfilePhotoUrl.Trim();
        user.ProfileSetupComplete = true;

        await _context.SaveChangesAsync();

        return Result<LoginResponse>.Success(GenerateTokenForUser(user));
    }

    public LoginResponse GenerateTokenForUser(User user)
    {
        string token = _tokenService.GenerateToken(user);
        LoginResponse response = _mapper.Map<LoginResponse>(user);
        response.Token = token;
        return response;
    }

    public async Task<Result<bool>> DeleteUserAccountAsync(int userId)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return Result<bool>.NotFound("User not found.");
        }
        _context.Users.Remove(user);

        try
        {
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (DbUpdateException)
        {
            return Result<bool>.Invalid("Unable to delete account due to existing related records.");
        }
    }
}