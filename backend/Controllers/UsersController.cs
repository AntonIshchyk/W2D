using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Contracts.Auth;
using Backend.Contracts.Common;
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

        User? user = await _userService.GetUserByIdAsync(userId);

        if (user == null)
        {
            return Unauthorized(new { message = "User not found for the current token" });
        }

        return Ok(new
        {
            userId,
            email = user.Email,
            username = user.Username,
            bio = user.Bio,
            profilePhotoUrl = user.ProfilePhotoUrl,
            profileSetupComplete = user.ProfileSetupComplete,
        });
    }

    [HttpPut("me")]
    [Authorize]
    public async Task<ActionResult<LoginResponse>> UpdateUserProfile([FromBody] UpdateUserProfileRequest request)
    {
        int userId = User.GetUserId();

        Result<LoginResponse> result = await _userService.UpdateUserProfileAsync(userId, request);
        return result.ToActionResult(this);
    }

    [HttpDelete("me")]
    [Authorize]
    public async Task<ActionResult> DeleteUserAccount()
    {
        int userId = User.GetUserId();

        Result<bool> result = await _userService.DeleteUserAccountAsync(userId);

        if (!result.IsSuccess)
        {
            return result.Status switch
            {
                ResultStatus.NotFound => NotFound(new { message = result.Error }),
                _ => BadRequest(new { message = result.Error })
            };
        }

        return Ok(new { message = "Account deleted successfully" });
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
                Audience = [clientId]
            };

            GoogleJsonWebSignature.Payload? payload = await GoogleJsonWebSignature.ValidateAsync(request.Credential, settings);

            if (payload == null)
            {
                return Unauthorized(new { message = "Invalid Google token" });
            }

            User? existingUser = await _userService.GetUserByEmailAsync(payload.Email);

            if (existingUser != null)
            {
                LoginResponse loginResponse = _userService.GenerateTokenForUser(existingUser);
                return Ok(loginResponse);
            }

            Result<LoginResponse> result = await _userService.RegisterUserAsync(payload.Email);
            return result.ToActionResult(this);
        }
        catch (Exception)
        {
            return Unauthorized(new { message = "Google authentication failed" });
        }
    }
}
