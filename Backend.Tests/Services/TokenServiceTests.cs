using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
using Backend.Models;
using Backend.Services;

namespace Backend.Tests.Services;

public class TokenServiceTests
{
    private readonly IConfiguration _configuration;
    private readonly TokenService _tokenService;

    public TokenServiceTests()
    {
        var configDict = new Dictionary<string, string>
        {
            { "Jwt:Key", "placeHolderSecretKeyThatIsAtLeast32CharactersLong!" },
            { "Jwt:Issuer", "Backend" },
            { "Jwt:Audience", "Frontend" }
        };

        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configDict!)
            .Build();

        _tokenService = new TokenService(_configuration);
    }

    [Fact]
    public void GenerateToken_ValidUser_ReturnsValidJwtToken()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "Test User",
            Email = "test@example.com",
            Age = 25,
            Gender = Gender.Male
        };

        // Act
        var token = _tokenService.GenerateToken(user);

        // Assert
        token.Should().NotBeNullOrEmpty();
        token.Split('.').Should().HaveCount(3);
    }

    [Fact]
    public void GenerateToken_ValidUser_TokenContainsUserClaims()
    {
        // Arrange
        var user = new User
        {
            Id = 42,
            Name = "Claims User",
            Email = "claims@example.com",
            Age = 30,
            Gender = Gender.Female
        };

        // Act
        var token = _tokenService.GenerateToken(user);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        jwtToken.Claims.Should().Contain(c =>
            c.Type == ClaimTypes.NameIdentifier && c.Value == "42");
        jwtToken.Claims.Should().Contain(c =>
            c.Type == ClaimTypes.Email && c.Value == "claims@example.com");
    }

    [Fact]
    public void GenerateToken_ValidUser_TokenHasCorrectIssuerAndAudience()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "Test User",
            Email = "test@example.com",
            Age = 25,
            Gender = Gender.Male
        };

        // Act
        var token = _tokenService.GenerateToken(user);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        jwtToken.Issuer.Should().Be("Backend");
        jwtToken.Audiences.Should().Contain("Frontend");
    }

    [Fact]
    public void GenerateToken_ValidUser_TokenHasExpirationTime()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "Test User",
            Email = "test@example.com",
            Age = 25,
            Gender = Gender.Male
        };

        // Act
        var token = _tokenService.GenerateToken(user);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        jwtToken.ValidTo.Should().BeAfter(DateTime.UtcNow);
        jwtToken.ValidTo.Should().BeCloseTo(DateTime.UtcNow.AddHours(24), TimeSpan.FromMinutes(1));
    }

    [Fact]
    public void GenerateToken_DifferentUsers_GenerateDifferentTokens()
    {
        // Arrange
        var user1 = new User { Id = 1, Email = "user1@example.com" };
        var user2 = new User { Id = 2, Email = "user2@example.com" };

        // Act
        var token1 = _tokenService.GenerateToken(user1);
        var token2 = _tokenService.GenerateToken(user2);

        // Assert
        token1.Should().NotBe(token2);
    }

    [Fact]
    public void GenerateToken_MissingJwtKey_ThrowsException()
    {
        // Arrange
        var configDict = new Dictionary<string, string>
        {
            { "Jwt:Issuer", "Backend" },
            { "Jwt:Audience", "Frontend" }
        };
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(configDict!)
            .Build();
        var service = new TokenService(config);
        var user = new User { Id = 1, Email = "test@example.com" };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => service.GenerateToken(user));
    }
}
