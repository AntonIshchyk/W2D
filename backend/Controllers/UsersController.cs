using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Auth;
using Backend.Models;
using Backend.Services;
using Backend.Extensions;
using Backend.Contracts.Users;
using Google.Apis.Auth;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("fixed")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UsersController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult> GetCurrentUser()
    {
        int userId = User.GetUserId();

        User user = (await _userService.GetUserByIdAsync(userId))!;

        return Ok(new
        {
            userId,
            email = user.Email,
            username = user.Username,
            bio = user.Bio,
            profilePhotoUrl = user.ProfilePhotoUrl,
            onboardingCompleted = user.OnboardingCompleted,
        });
    }

    [HttpPut("onboarding")]
    [Authorize]
    public async Task<ActionResult<LoginResponse>> CompleteOnboarding([FromBody] OnboardingUpdateRequest request)
    {
        int userId = User.GetUserId();

        if (await _userService.IsUsernameTakenAsync(request.Username))
        {
            return Conflict(new { message = "Username is already taken" });
        }

        User updatedUser = await _userService.CompleteOnboardingAsync(userId, request);

        LoginResponse response = _userService.GenerateTokenForUser(updatedUser);
        response.IsNewUser = false;
        return Ok(response);
    }

    [HttpPost("google-login")]
    public async Task<ActionResult<LoginResponse>> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        try
        {
            string? clientId = _configuration["Google:ClientId"];

            if (string.IsNullOrEmpty(clientId))
            {
                return StatusCode(500, new { message = "Google Client ID not configured" });
            }

            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { clientId }
            };

            GoogleJsonWebSignature.Payload? payload = await GoogleJsonWebSignature.ValidateAsync(request.Credential, settings);

            if (payload == null)
            {
                return Unauthorized(new { message = "Invalid Google token" });
            }

            // Try to find existing user by email
            User? existingUser = await _userService.GetUserByEmailAsync(payload.Email);

            if (existingUser != null)
            {
                // User exists, just login
                LoginResponse loginResponse = _userService.GenerateTokenForUser(existingUser);
                return Ok(loginResponse);
            }

            // New user, create account
            LoginResponse? result = await _userService.RegisterUserAsync(payload.Email);

            if (result == null)
            {
                return BadRequest(new { message = "Failed to create user" });
            }

            return Ok(result);
        }
        catch (Exception)
        {
            return Unauthorized(new { message = "Google authentication failed" });
        }
    }
}
