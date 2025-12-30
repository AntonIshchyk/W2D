using System.Security.Claims;
using FluentAssertions;
using Backend.Extensions;

namespace Backend.Tests.Extensions;

public class ClaimsPrincipalExtensionsTests
{
    #region GetUserId Tests

    [Fact]
    public void GetUserId_ValidClaim_ReturnsUserId()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().Be(123);
    }

    [Fact]
    public void GetUserId_MissingClaim_ReturnsNull()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().BeNull();
    }

    [Fact]
    public void GetUserId_EmptyClaim_ReturnsNull()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, ""),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().BeNull();
    }

    [Fact]
    public void GetUserId_InvalidFormat_ReturnsNull()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "not-a-number"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().BeNull();
    }

    [Fact]
    public void GetUserId_NoClaims_ReturnsNull()
    {
        // Arrange
        var identity = new ClaimsIdentity();
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().BeNull();
    }

    #endregion

    #region IsAdmin Tests

    [Fact]
    public void IsAdmin_AdminRole_ReturnsTrue()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Email, "admin@example.com"),
            new Claim(ClaimTypes.Role, "Admin")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeTrue();
    }

    [Fact]
    public void IsAdmin_UserRole_ReturnsFalse()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "2"),
            new Claim(ClaimTypes.Email, "user@example.com"),
            new Claim(ClaimTypes.Role, "User")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_NoRoleClaim_ReturnsFalse()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "3"),
            new Claim(ClaimTypes.Email, "norole@example.com")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_EmptyRole_ReturnsFalse()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "4"),
            new Claim(ClaimTypes.Email, "empty@example.com"),
            new Claim(ClaimTypes.Role, "")
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_CaseSensitive_ReturnsFalseForLowercase()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "5"),
            new Claim(ClaimTypes.Email, "lowercase@example.com"),
            new Claim(ClaimTypes.Role, "admin") // lowercase
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    #endregion
}
