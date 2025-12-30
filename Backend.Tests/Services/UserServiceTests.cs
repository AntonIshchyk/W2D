using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using Backend.Data;
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
        var options = new DbContextOptionsBuilder<AppDbContext>()
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
        var name = "John Doe";
        var email = "test@example.com";
        var password = "password123";
        var age = 25;
        var gender = Gender.Male;

        // Act
        var result = await _userService.RegisterUserAsync(email, password, name, age, gender);

        // Assert
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);
        result.Name.Should().Be(name);
        result.Age.Should().Be(age);
        result.Gender.Should().Be(gender);
        result.UserId.Should().BeGreaterThan(0);
        result.Token.Should().Be("fake-jwt-token");

        var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        userInDb.Should().NotBeNull();
        userInDb!.Password.Should().NotBe(password); // Password should be hashed
    }

    [Fact]
    public async Task RegisterUserAsync_DuplicateEmail_ReturnsNull()
    {
        // Arrange
        var email = "duplicate@example.com";
        var password = "password123";
        await _userService.RegisterUserAsync(email, password, "Jane Doe", 30, Gender.Female);

        // Act
        var result = await _userService.RegisterUserAsync(email, "differentPassword", "Different User", 25, Gender.Male);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUserAsync_PasswordIsHashed_NotStoredInPlainText()
    {
        // Arrange
        var email = "secure@example.com";
        var password = "mySecurePassword123!";

        // Act
        await _userService.RegisterUserAsync(email, password, "Secure User", 28, Gender.Male);

        // Assert
        var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        userInDb!.Password.Should().NotBe(password);
        userInDb.Password.Should().StartWith("$2"); // BCrypt hash starts with $2
    }

    #endregion

    #region Login Tests

    [Fact]
    public async Task LoginUserAsync_ValidCredentials_ReturnsLoginResponse()
    {
        // Arrange
        var email = "login@example.com";
        var password = "password123";
        await _userService.RegisterUserAsync(email, password, "Login User", 27, Gender.Female);

        // Act
        var result = await _userService.LoginUserAsync(email, password);

        // Assert
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);
        result.Name.Should().Be("Login User");
        result.Age.Should().Be(27);
        result.Gender.Should().Be(Gender.Female);
        result.UserId.Should().BeGreaterThan(0);
        result.Token.Should().Be("fake-jwt-token");
    }

    [Fact]
    public async Task LoginUserAsync_WrongPassword_ReturnsNull()
    {
        // Arrange
        var email = "user@example.com";
        var password = "correctPassword";
        await _userService.RegisterUserAsync(email, password, "Test User", 26, Gender.Male);

        // Act
        var result = await _userService.LoginUserAsync(email, "wrongPassword");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task LoginUserAsync_UserDoesNotExist_ReturnsNull()
    {
        // Arrange
        var email = "nonexistent@example.com";
        var password = "password123";

        // Act
        var result = await _userService.LoginUserAsync(email, password);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task RegisterAndLogin_MultipleUsers_WorksIndependently()
    {
        // Arrange
        var user1Email = "user1@example.com";
        var user1Password = "password1";
        var user2Email = "user2@example.com";
        var user2Password = "password2";

        // Act
        await _userService.RegisterUserAsync(user1Email, user1Password, "User One", 25, Gender.Male);
        await _userService.RegisterUserAsync(user2Email, user2Password, "User Two", 30, Gender.Female);

        var login1 = await _userService.LoginUserAsync(user1Email, user1Password);
        var login2 = await _userService.LoginUserAsync(user2Email, user2Password);
        var crossLogin = await _userService.LoginUserAsync(user1Email, user2Password);

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
        await _userService.RegisterUserAsync("user1@example.com", "pass1", "User One", 25, Gender.Male);
        await _userService.RegisterUserAsync("user2@example.com", "pass2", "User Two", 30, Gender.Female);
        await _userService.RegisterUserAsync("user3@example.com", "pass3", "User Three", 28, Gender.Male);

        // Act
        var result = await _userService.GetAllUsersAsync();

        // Assert
        result.Should().HaveCount(3);
    }

    #endregion
}
