using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Models;
using Backend.Services;
using Google.Apis.Auth;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = await _userService.GetUserByIdAsync(int.Parse(userId));

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            userId = user.Id,
            email = user.Email,
            name = user.Name,
            age = user.Age,
            gender = user.Gender
        });
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> Register(RegisterRequest request)
    {
        var result = await _userService.RegisterUserAsync(request.Email, request.Password, request.Name, request.Age, request.Gender);

        if (result == null)
        {
            return BadRequest(new { message = "User with this email already exists" });
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var result = await _userService.LoginUserAsync(request.Email, request.Password);

        if (result == null)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        return Ok(result);
    }

    [HttpPost("google-login")]
    public async Task<ActionResult<LoginResponse>> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        try
        {
            var clientId = _configuration["Google:ClientId"];

            if (string.IsNullOrEmpty(clientId))
            {
                return StatusCode(500, new { message = "Google Client ID not configured" });
            }

            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { clientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Credential, settings);

            if (payload == null)
            {
                return Unauthorized(new { message = "Invalid Google token" });
            }

            // Try to find existing user by email
            var existingUser = await _userService.GetUserByEmailAsync(payload.Email);

            if (existingUser != null)
            {
                // User exists, just login
                var loginResponse = _userService.GenerateTokenForUserAsync(existingUser);
                return Ok(loginResponse);
            }

            // New user, create account
            // For Google sign-in, use a random password and set default values
            var result = await _userService.RegisterUserAsync(
                payload.Email,
                Guid.NewGuid().ToString(),
                payload.Name ?? payload.Email.Split('@')[0],
                25,
                Gender.Male
            );

            if (result == null)
            {
                return BadRequest(new { message = "Failed to create user" });
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = "Google authentication failed", error = ex.Message });
        }
    }
}