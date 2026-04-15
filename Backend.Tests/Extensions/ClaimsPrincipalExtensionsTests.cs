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
}
