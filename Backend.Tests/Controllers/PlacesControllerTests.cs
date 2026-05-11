using Backend.Contracts.Common;
using Backend.Contracts.Places;
using Backend.Controllers;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Backend.Tests.Controllers;

public class PlacesControllerTests
{
    private PlacesController CreateController(Mock<IPlaceService> mock, int userId = 1)
    {
        var controller = new PlacesController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task GetPlace_ReturnsOk_OnSuccess()
    {
        var mock = new Mock<IPlaceService>();
        var resp = new PlaceResponse { Id = 2 };
        mock.Setup(s => s.GetPlaceByIdAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<PlaceResponse>.Success(resp));

        var controller = CreateController(mock);

        var result = await controller.GetPlace(2);

        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task DeletePlace_ReturnsForbidden_WhenNotOwner()
    {
        var mock = new Mock<IPlaceService>();
        mock.Setup(s => s.DeletePlaceAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<bool>.Unauthorized("not owner"));

        var controller = CreateController(mock, 8);

        var res = await controller.DeletePlace(7);

        res.Should().BeOfType<ObjectResult>();
        var obj = res as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task UpdatePlace_ReturnsForbidden_WhenEditingOthersPlace()
    {
        var mock = new Mock<IPlaceService>();
        mock.Setup(s => s.UpdatePlaceAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<UpdatePlaceRequest>()))
            .ReturnsAsync(Result<PlaceResponse>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 10);

        var result = await controller.UpdatePlace(7, new UpdatePlaceRequest { Title = "attempt" });

        result.Result.Should().BeOfType<ObjectResult>();
        var obj = result.Result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }
}
