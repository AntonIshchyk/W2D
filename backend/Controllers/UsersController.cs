using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;
using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Backend.Extensions;
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
    public ActionResult GetCurrentUser()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var emailClaim = User.FindFirst(ClaimTypes.Email);
        var nameClaim = User.FindFirst(ClaimTypes.Name);

        if (userIdClaim == null || emailClaim == null || nameClaim == null)
        {
            return Unauthorized(new { message = "Invalid token claims" });
        }

        return Ok(new
        {
            userId = User.GetUserId(),
            email = emailClaim.Value,
            name = nameClaim.Value
        });
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> Register(RegisterRequest request)
    {
        LoginResponse? result = await _userService.RegisterUserAsync(request.Email, request.Password, request.Name);

        if (result == null)
        {
            return BadRequest(new { message = "User with this email already exists" });
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        LoginResponse? result = await _userService.LoginUserAsync(request.Email, request.Password);

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
            LoginResponse? result = await _userService.RegisterUserAsync(
                payload.Email,
                Guid.NewGuid().ToString(),
                payload.Name ?? payload.Email.Split('@')[0]
            );

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