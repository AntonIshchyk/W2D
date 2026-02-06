using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using FluentAssertions;
using Backend.Controllers;
using Backend.Models;
using Backend.Services;
using Backend.DTOs;

namespace Backend.Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IConfiguration> _mockConfiguration;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _mockConfiguration = new Mock<IConfiguration>();
        _controller = new UsersController(_mockUserService.Object, _mockConfiguration.Object);
    }

    #region Register Tests

    [Fact]
    public async Task Register_ValidUser_ReturnsOkWithLoginResponse()
    {
        // Arrange
        RegisterRequest registerRequest = new RegisterRequest
        {
            Name = "John Doe",
            Email = "test@example.com",
            Password = "password123"
        };
        LoginResponse expectedResponse = new LoginResponse
        {
            UserId = 1,
            Email = registerRequest.Email,
            Name = registerRequest.Name,
            IsAdmin = false,
            Token = "fake-token"
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(registerRequest.Email, registerRequest.Password, registerRequest.Name))
            .ReturnsAsync(expectedResponse);

        // Act
        ActionResult<LoginResponse> result = await _controller.Register(registerRequest);

        // Assert
        OkObjectResult okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        LoginResponse response = okResult.Value.Should().BeOfType<LoginResponse>().Subject;
        response.Email.Should().Be(registerRequest.Email);
        response.Token.Should().Be("fake-token");
    }

    [Fact]
    public async Task Register_DuplicateEmail_ReturnsBadRequest()
    {
        // Arrange
        RegisterRequest registerRequest = new RegisterRequest
        {
            Name = "Jane Doe",
            Email = "duplicate@example.com",
            Password = "password123"
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(registerRequest.Email, registerRequest.Password, registerRequest.Name))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        ActionResult<LoginResponse> result = await _controller.Register(registerRequest);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    #endregion

    #region Login Tests

    [Fact]
    public async Task Login_ValidCredentials_ReturnsOkWithToken()
    {
        // Arrange
        LoginRequest loginRequest = new LoginRequest
        {
            Email = "test@example.com",
            Password = "password123"
        };
        LoginResponse expectedResponse = new LoginResponse
        {
            UserId = 1,
            Email = loginRequest.Email,
            Name = "John Doe",
            IsAdmin = false,
            Token = "valid-jwt-token"
        };
        _mockUserService.Setup(x => x.LoginUserAsync(loginRequest.Email, loginRequest.Password))
            .ReturnsAsync(expectedResponse);

        // Act
        ActionResult<LoginResponse> result = await _controller.Login(loginRequest);

        // Assert
        OkObjectResult okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        LoginResponse response = okResult.Value.Should().BeOfType<LoginResponse>().Subject;
        response.Email.Should().Be(loginRequest.Email);
        response.Token.Should().Be("valid-jwt-token");
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        LoginRequest loginRequest = new LoginRequest
        {
            Email = "test@example.com",
            Password = "wrongPassword"
        };
        _mockUserService.Setup(x => x.LoginUserAsync(loginRequest.Email, loginRequest.Password))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        ActionResult<LoginResponse> result = await _controller.Login(loginRequest);

        // Assert
        UnauthorizedObjectResult unauthorizedResult = result.Result.Should().BeOfType<UnauthorizedObjectResult>().Subject;
        unauthorizedResult.StatusCode.Should().Be(401);
    }

    [Fact]
    public async Task Login_UserDoesNotExist_ReturnsUnauthorized()
    {
        // Arrange
        LoginRequest loginRequest = new LoginRequest
        {
            Email = "nonexistent@example.com",
            Password = "password123"
        };
        _mockUserService.Setup(x => x.LoginUserAsync(loginRequest.Email, loginRequest.Password))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        ActionResult<LoginResponse> result = await _controller.Login(loginRequest);

        // Assert
        result.Result.Should().BeOfType<UnauthorizedObjectResult>();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task Register_ServiceThrowsException_ExceptionPropagates()
    {
        // Arrange
        RegisterRequest registerRequest = new RegisterRequest
        {
            Name = "Test User",
            Email = "test@example.com",
            Password = "password123"
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(registerRequest.Email, registerRequest.Password, registerRequest.Name))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.Register(registerRequest));
    }

    [Fact]
    public async Task Login_ServiceThrowsException_ExceptionPropagates()
    {
        // Arrange
        LoginRequest loginRequest = new LoginRequest
        {
            Email = "test@example.com",
            Password = "password123"
        };
        _mockUserService.Setup(x => x.LoginUserAsync(loginRequest.Email, loginRequest.Password))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.Login(loginRequest));
    }

    #endregion
}
