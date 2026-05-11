using Backend.Controllers;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Backend.Tests.Controllers;

public class UploadsControllerTests
{
    private UploadsController CreateController(Mock<IR2UploadService> mock, int userId = 1)
    {
        var controller = new UploadsController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task Presign_ReturnsBadRequest_WhenMissingFields()
    {
        var mock = new Mock<IR2UploadService>();
        var controller = CreateController(mock);
        var req = new PresignRequest { FileName = "", ContentType = "" };

        var result = await controller.Presign(req);

        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task Presign_ReturnsBadRequest_WhenInvalidContentType()
    {
        var mock = new Mock<IR2UploadService>();
        var controller = CreateController(mock);
        var req = new PresignRequest { FileName = "a.png", ContentType = "application/pdf" };

        var result = await controller.Presign(req);

        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task Presign_ReturnsOk_OnSuccess()
    {
        var mock = new Mock<IR2UploadService>();
        mock.Setup(s => s.GetPresignedUploadUrlAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new PresignedUploadResult { UploadUrl = "u", PublicUrl = "p", Key = "k" });

        var controller = CreateController(mock, 7);
        var req = new PresignRequest { FileName = "photo.png", ContentType = "image/png" };

        var result = await controller.Presign(req);

        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Presign_ReturnsBadRequest_OnInvalidFileName()
    {
        var mock = new Mock<IR2UploadService>();
        var controller = CreateController(mock, 1);
        var req = new PresignRequest { FileName = "../evil.png", ContentType = "image/png" };

        var result = await controller.Presign(req);

        result.Should().BeOfType<BadRequestObjectResult>();
    }
}
