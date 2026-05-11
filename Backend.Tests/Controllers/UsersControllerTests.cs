using Backend.Contracts.Auth;
using Backend.Contracts.Common;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Backend.Controllers;

namespace Backend.Tests.Controllers;

public class UsersControllerTests
{
    [Fact]
    public async Task GoogleLogin_Returns500_WhenClientIdMissing()
    {
        var userMock = new Mock<IUserService>();
        var configMock = new Mock<IConfiguration>();
        configMock.Setup(c => c["Google:ClientId"]).Returns((string?)null);

        var controller = new UsersController(userMock.Object, configMock.Object);

        var result = await controller.GoogleLogin(new GoogleLoginRequest { Credential = "x" });

        result.Result.Should().BeOfType<ObjectResult>();
        var obj = result.Result as ObjectResult;
        obj!.StatusCode.Should().Be(500);
    }

    [Fact]
    public async Task GetCurrentUser_ReturnsUnauthorized_WhenUserNotFound()
    {
        var userMock = new Mock<IUserService>();
        userMock.Setup(u => u.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync((User?)null);

        var configMock = new Mock<IConfiguration>();
        var controller = new UsersController(userMock.Object, configMock.Object);

        // simulate user principal
        controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
        {
            HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
        };
        controller.ControllerContext.HttpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "5") }, "test"));

        var result = await controller.GetCurrentUser();

        result.Should().BeOfType<UnauthorizedObjectResult>();
    }
}
