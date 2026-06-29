using Backend.Contracts.Common;
using Backend.Contracts.Users;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.Tests.Services;

public class UserServiceTests
{
    [Fact]
    public async Task RegisterUserAsync_TrimsEmail_AndGeneratesUniqueUsername()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "john", Email = "john@existing.local" });
        await context.SaveChangesAsync();

        var token = new Mock<ITokenService>();
        token.Setup(t => t.GenerateToken(It.IsAny<User>())).Returns("token-1");

        var service = new UserService(context, token.Object, ServiceTestHelpers.CreateMapper());

        var result = await service.RegisterUserAsync("  john@example.com  ");

        result.Status.Should().Be(ResultStatus.Success);
        result.Value.Should().NotBeNull();
        result.Value!.Email.Should().Be("john@example.com");
        result.Value.Username.Should().Be("john1");

        var createdUser = await context.Users.AsNoTracking().SingleAsync(u => u.Email == "john@example.com");
        createdUser.Username.Should().Be("john1");
    }

    [Fact]
    public async Task RegisterUserAsync_ReturnsInvalid_WhenEmailBlank()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        var service = new UserService(
            context,
            Mock.Of<ITokenService>(),
            ServiceTestHelpers.CreateMapper());

        var result = await service.RegisterUserAsync("   ");

        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task UpdateUserProfileAsync_ReturnsInvalid_WhenUsernameTaken()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "owner", Email = "owner@test.local" },
            new User { Id = 2, Username = "taken", Email = "taken@test.local" });
        await context.SaveChangesAsync();

        var token = new Mock<ITokenService>();
        token.Setup(t => t.GenerateToken(It.IsAny<User>())).Returns("token-2");

        var service = new UserService(context, token.Object, ServiceTestHelpers.CreateMapper());

        var result = await service.UpdateUserProfileAsync(1, new UpdateUserProfileRequest
        {
            Username = "taken",
            Bio = "bio",
        });

        result.Status.Should().Be(ResultStatus.Invalid);
        var user = await context.Users.AsNoTracking().FirstAsync(u => u.Id == 1);
        user.Username.Should().Be("owner");
    }

    [Fact]
    public async Task UpdateUserProfileAsync_AsUser_UpdatesAndTrimsFields()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "owner", Email = "owner@test.local", ProfileSetupComplete = false });
        await context.SaveChangesAsync();

        var token = new Mock<ITokenService>();
        token.Setup(t => t.GenerateToken(It.IsAny<User>())).Returns("token-3");

        var service = new UserService(context, token.Object, ServiceTestHelpers.CreateMapper());

        var result = await service.UpdateUserProfileAsync(1, new UpdateUserProfileRequest
        {
            Username = "  new_name  ",
            Bio = "  hello bio  ",
        });

        result.Status.Should().Be(ResultStatus.Success);
        result.Value.Should().NotBeNull();
        result.Value!.Username.Should().Be("new_name");
        result.Value.Bio.Should().Be("hello bio");
        result.Value.ProfileSetupComplete.Should().BeTrue();
        result.Value.Token.Should().Be("token-3");

        var user = await context.Users.AsNoTracking().FirstAsync(u => u.Id == 1);
        user.Username.Should().Be("new_name");
        user.Bio.Should().Be("hello bio");
        user.ProfileSetupComplete.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteUserAccountAsync_ReturnsNotFound_WhenUserMissing()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        var service = new UserService(
            context,
            Mock.Of<ITokenService>(),
            ServiceTestHelpers.CreateMapper());

        var result = await service.DeleteUserAccountAsync(999);

        result.Status.Should().Be(ResultStatus.NotFound);
    }
}
