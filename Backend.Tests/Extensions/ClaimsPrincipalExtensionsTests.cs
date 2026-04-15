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
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        int userId = claimsPrincipal.GetUserId();

        // Assert
        userId.Should().Be(123);
    }

    [Fact]
    public void GetUserId_MissingClaim_ThrowsInvalidOperationException()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        Action action = () => claimsPrincipal.GetUserId();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Authenticated user ID claim is missing.");
    }

    [Fact]
    public void GetUserId_EmptyClaim_ThrowsInvalidOperationException()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, ""),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        Action action = () => claimsPrincipal.GetUserId();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Authenticated user ID claim is missing.");
    }

    [Fact]
    public void GetUserId_InvalidFormat_ThrowsInvalidOperationException()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "not-a-number"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        Action action = () => claimsPrincipal.GetUserId();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Authenticated user ID claim is invalid.");
    }

    [Fact]
    public void GetUserId_NoClaims_ThrowsInvalidOperationException()
    {
        // Arrange
        ClaimsIdentity identity = new ClaimsIdentity();
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        Action action = () => claimsPrincipal.GetUserId();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Authenticated user ID claim is missing.");
    }

    #endregion

    #region IsAdmin Tests

    [Fact]
    public void IsAdmin_AdminRole_ReturnsTrue()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Email, "admin@example.com"),
            new Claim(ClaimTypes.Role, "Admin")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        bool isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeTrue();
    }

    [Fact]
    public void IsAdmin_UserRole_ReturnsFalse()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "2"),
            new Claim(ClaimTypes.Email, "user@example.com"),
            new Claim(ClaimTypes.Role, "User")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        bool isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_NoRoleClaim_ReturnsFalse()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "3"),
            new Claim(ClaimTypes.Email, "norole@example.com")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        bool isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_EmptyRole_ReturnsFalse()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "4"),
            new Claim(ClaimTypes.Email, "empty@example.com"),
            new Claim(ClaimTypes.Role, "")
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        bool isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    [Fact]
    public void IsAdmin_CaseSensitive_ReturnsFalseForLowercase()
    {
        // Arrange
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "5"),
            new Claim(ClaimTypes.Email, "lowercase@example.com"),
            new Claim(ClaimTypes.Role, "admin") // lowercase
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        bool isAdmin = claimsPrincipal.IsAdmin();

        // Assert
        isAdmin.Should().BeFalse();
    }

    #endregion
}
