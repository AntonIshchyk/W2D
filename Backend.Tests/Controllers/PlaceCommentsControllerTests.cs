using Backend.Contracts.Common;
using Backend.Contracts.Comments;
using Backend.Services;
using Backend.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Backend.Tests.Controllers;

public class PlaceCommentsControllerTests
{
    private PlaceCommentsController CreateController(Mock<ICommentService> mock, int userId = 1)
    {
        var controller = new PlaceCommentsController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task CreatePlaceComment_ReturnsCreated_OnSuccess()
    {
        var mock = new Mock<ICommentService>();
        var resp = new CommentResponse { Id = 7 };
        mock.Setup(s => s.CreatePlaceCommentAsync(It.IsAny<int>(), It.IsAny<CreateCommentRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<CommentResponse>.Success(resp));

        var controller = CreateController(mock);
        var request = new CreateCommentRequest { Content = "x" };

        var result = await controller.CreateComment(3, request);

        result.Result.Should().BeOfType<CreatedResult>();
    }

    [Fact]
    public async Task UpdatePlaceComment_ReturnsForbidden_WhenEditingOthersComment()
    {
        var mock = new Mock<ICommentService>();
        mock.Setup(s => s.UpdatePlaceCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<UpdateCommentRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<CommentResponse>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 20);

        var result = await controller.UpdateComment(3, 9, new UpdateCommentRequest { Content = "try" });

        result.Result.Should().BeOfType<ObjectResult>();
        var obj = result.Result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task DeletePlaceComment_ReturnsForbidden_WhenDeletingOthersComment()
    {
        var mock = new Mock<ICommentService>();
        mock.Setup(s => s.DeletePlaceCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<bool>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 20);

        var result = await controller.DeleteComment(3, 9);

        result.Should().BeOfType<ObjectResult>();
        var obj = result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }
}
