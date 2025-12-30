using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using Backend.Controllers;
using Backend.Models;
using Backend.Services;

namespace Backend.Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new UsersController(_mockUserService.Object);
    }

    #region Register Tests

    [Fact]
    public async Task Register_ValidUser_ReturnsOkWithLoginResponse()
    {
        // Arrange
        var user = new User
        {
            Name = "John Doe",
            Email = "test@example.com",
            Password = "password123",
            Age = 25,
            Gender = Gender.Male
        };
        var expectedResponse = new LoginResponse
        {
            UserId = 1,
            Email = user.Email,
            Name = user.Name,
            Age = user.Age,
            Gender = user.Gender,
            IsAdmin = false,
            Token = "fake-token"
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(user.Email, user.Password, user.Name, user.Age, user.Gender))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Register(user);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var response = okResult.Value.Should().BeOfType<LoginResponse>().Subject;
        response.Email.Should().Be(user.Email);
        response.Token.Should().Be("fake-token");
    }

    [Fact]
    public async Task Register_DuplicateEmail_ReturnsBadRequest()
    {
        // Arrange
        var user = new User
        {
            Name = "Jane Doe",
            Email = "duplicate@example.com",
            Password = "password123",
            Age = 30,
            Gender = Gender.Female
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(user.Email, user.Password, user.Name, user.Age, user.Gender))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        var result = await _controller.Register(user);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    #endregion

    #region Login Tests

    [Fact]
    public async Task Login_ValidCredentials_ReturnsOkWithToken()
    {
        // Arrange
        var user = new User
        {
            Name = "John Doe",
            Email = "test@example.com",
            Password = "password123",
            Age = 25,
            Gender = Gender.Male
        };
        var expectedResponse = new LoginResponse
        {
            UserId = 1,
            Email = user.Email,
            Name = user.Name,
            Age = user.Age,
            Gender = user.Gender,
            IsAdmin = false,
            Token = "valid-jwt-token"
        };
        _mockUserService.Setup(x => x.LoginUserAsync(user.Email, user.Password))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Login(user);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var response = okResult.Value.Should().BeOfType<LoginResponse>().Subject;
        response.Email.Should().Be(user.Email);
        response.Token.Should().Be("valid-jwt-token");
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var user = new User
        {
            Name = "John Doe",
            Email = "test@example.com",
            Password = "wrongPassword",
            Age = 25,
            Gender = Gender.Male
        };
        _mockUserService.Setup(x => x.LoginUserAsync(user.Email, user.Password))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        var result = await _controller.Login(user);

        // Assert
        var unauthorizedResult = result.Result.Should().BeOfType<UnauthorizedObjectResult>().Subject;
        unauthorizedResult.StatusCode.Should().Be(401);
    }

    [Fact]
    public async Task Login_UserDoesNotExist_ReturnsUnauthorized()
    {
        // Arrange
        var user = new User
        {
            Name = "Nonexistent User",
            Email = "nonexistent@example.com",
            Password = "password123",
            Age = 25,
            Gender = Gender.Male
        };
        _mockUserService.Setup(x => x.LoginUserAsync(user.Email, user.Password))
            .ReturnsAsync((LoginResponse?)null);

        // Act
        var result = await _controller.Login(user);

        // Assert
        result.Result.Should().BeOfType<UnauthorizedObjectResult>();
    }

    #endregion

    #region GetUsers Tests

    [Fact]
    public async Task GetUsers_ReturnsAllUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Name = "User One", Email = "user1@example.com", Age = 25, Gender = Gender.Male },
            new User { Id = 2, Name = "User Two", Email = "user2@example.com", Age = 30, Gender = Gender.Female },
            new User { Id = 3, Name = "User Three", Email = "user3@example.com", Age = 28, Gender = Gender.Male }
        };
        _mockUserService.Setup(x => x.GetAllUsersAsync())
            .ReturnsAsync(users);

        // Act
        var result = await _controller.GetUsers();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedUsers = okResult.Value.Should().BeAssignableTo<IEnumerable<User>>().Subject;
        returnedUsers.Should().HaveCount(3);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task Register_ServiceThrowsException_ExceptionPropagates()
    {
        // Arrange
        var user = new User
        {
            Name = "Test User",
            Email = "test@example.com",
            Password = "password123",
            Age = 25,
            Gender = Gender.Male
        };
        _mockUserService.Setup(x => x.RegisterUserAsync(user.Email, user.Password, user.Name, user.Age, user.Gender))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.Register(user));
    }

    [Fact]
    public async Task Login_ServiceThrowsException_ExceptionPropagates()
    {
        // Arrange
        var user = new User
        {
            Name = "Test User",
            Email = "test@example.com",
            Password = "password123",
            Age = 25,
            Gender = Gender.Male
        };
        _mockUserService.Setup(x => x.LoginUserAsync(user.Email, user.Password))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.Login(user));
    }

    #endregion
}
