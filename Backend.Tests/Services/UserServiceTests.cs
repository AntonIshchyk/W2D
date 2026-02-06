using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Services;

namespace Backend.Tests.Services;

public class UserServiceTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly Mock<ITokenService> _mockTokenService;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        // Setup in-memory database
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _mockTokenService = new Mock<ITokenService>();
        _mockTokenService.Setup(x => x.GenerateToken(It.IsAny<User>()))
            .Returns("fake-jwt-token");

        _userService = new UserService(_context, _mockTokenService.Object);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    #region Register Tests

    [Fact]
    public async Task RegisterUserAsync_ValidUser_ReturnsLoginResponse()
    {
        // Arrange
        string name = "John Doe";
        string email = "test@example.com";
        string password = "password123";

        // Act
        LoginResponse? result = await _userService.RegisterUserAsync(email, password, name);

        // Assert
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);
        result.Name.Should().Be(name);
        result.IsAdmin.Should().BeFalse(); // Default non-admin user
        result.UserId.Should().BeGreaterThan(0);
        result.Token.Should().Be("fake-jwt-token");

        User? userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        userInDb.Should().NotBeNull();
        userInDb!.Password.Should().NotBe(password); // Password should be hashed
        userInDb.IsAdmin.Should().BeFalse(); // Default value
    }

    [Fact]
    public async Task RegisterUserAsync_DuplicateEmail_ReturnsNull()
    {
        // Arrange
        string email = "duplicate@example.com";
        string password = "password123";
        await _userService.RegisterUserAsync(email, password, "Jane Doe");

        // Act
        LoginResponse? result = await _userService.RegisterUserAsync(email, "differentPassword", "Different User");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUserAsync_PasswordIsHashed_NotStoredInPlainText()
    {
        // Arrange
        string email = "secure@example.com";
        string password = "mySecurePassword123!";

        // Act
        await _userService.RegisterUserAsync(email, password, "Secure User");

        // Assert
        User? userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        userInDb!.Password.Should().NotBe(password);
        userInDb.Password.Should().StartWith("$2"); // BCrypt hash starts with $2
    }

    #endregion

    #region Login Tests

    [Fact]
    public async Task LoginUserAsync_ValidCredentials_ReturnsLoginResponse()
    {
        // Arrange
        string email = "login@example.com";
        string password = "password123";
        await _userService.RegisterUserAsync(email, password, "Login User");

        // Act
        LoginResponse? result = await _userService.LoginUserAsync(email, password);

        // Assert
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);
        result.Name.Should().Be("Login User");
        result.IsAdmin.Should().BeFalse();
        result.UserId.Should().BeGreaterThan(0);
        result.Token.Should().Be("fake-jwt-token");
    }

    [Fact]
    public async Task LoginUserAsync_WrongPassword_ReturnsNull()
    {
        // Arrange
        string email = "user@example.com";
        string password = "correctPassword";
        await _userService.RegisterUserAsync(email, password, "Test User");

        // Act
        LoginResponse? result = await _userService.LoginUserAsync(email, "wrongPassword");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task LoginUserAsync_UserDoesNotExist_ReturnsNull()
    {
        // Arrange
        string email = "nonexistent@example.com";
        string password = "password123";

        // Act
        LoginResponse? result = await _userService.LoginUserAsync(email, password);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region Admin Tests

    [Fact]
    public async Task RegisterUserAsync_DefaultUser_IsAdminIsFalse()
    {
        // Arrange
        string email = "regular@example.com";
        string password = "password123";

        // Act
        LoginResponse? result = await _userService.RegisterUserAsync(email, password, "Regular User");

        // Assert
        result.Should().NotBeNull();
        result!.IsAdmin.Should().BeFalse();

        User? userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        userInDb!.IsAdmin.Should().BeFalse();
    }

    [Fact]
    public async Task RegisterUserAsync_AdminUserCreatedManually_IsAdminInResponse()
    {
        // Arrange - Create admin user directly in DB
        User adminUser = new User
        {
            Email = "admin@example.com",
            Password = BCrypt.Net.BCrypt.HashPassword("adminpass"),
            Name = "Admin User",
            IsAdmin = true
        };
        _context.Users.Add(adminUser);
        await _context.SaveChangesAsync();

        // Act
        LoginResponse? result = await _userService.LoginUserAsync("admin@example.com", "adminpass");

        // Assert
        result.Should().NotBeNull();
        result!.IsAdmin.Should().BeTrue();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task RegisterAndLogin_MultipleUsers_WorksIndependently()
    {
        // Arrange
        string user1Email = "user1@example.com";
        string user1Password = "password1";
        string user2Email = "user2@example.com";
        string user2Password = "password2";

        // Act
        await _userService.RegisterUserAsync(user1Email, user1Password, "User One");
        await _userService.RegisterUserAsync(user2Email, user2Password, "User Two");

        LoginResponse? login1 = await _userService.LoginUserAsync(user1Email, user1Password);
        LoginResponse? login2 = await _userService.LoginUserAsync(user2Email, user2Password);
        LoginResponse? crossLogin = await _userService.LoginUserAsync(user1Email, user2Password);

        // Assert
        login1.Should().NotBeNull();
        login2.Should().NotBeNull();
        crossLogin.Should().BeNull(); // Wrong password for user1
        login1!.UserId.Should().NotBe(login2!.UserId);
    }

    [Fact]
    public async Task GetAllUsersAsync_ReturnsAllUsers()
    {
        // Arrange
        await _userService.RegisterUserAsync("user1@example.com", "pass1", "User One");
        await _userService.RegisterUserAsync("user2@example.com", "pass2", "User Two");
        await _userService.RegisterUserAsync("user3@example.com", "pass3", "User Three");

        // Act
        IEnumerable<User> result = await _userService.GetAllUsersAsync();

        // Assert
        result.Should().HaveCount(3);
    }

    #endregion
}
