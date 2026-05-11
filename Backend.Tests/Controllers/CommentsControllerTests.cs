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

public class CommentsControllerTests
{
    private CommentsController CreateController(Mock<ICommentService> mock, int userId = 1)
    {
        var controller = new CommentsController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task CreateComment_ReturnsCreated_OnSuccess()
    {
        var mock = new Mock<ICommentService>();
        var resp = new CommentResponse { Id = 2 };
        mock.Setup(s => s.CreateCommentAsync(It.IsAny<int>(), It.IsAny<CreateCommentRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<CommentResponse>.Success(resp));

        var controller = CreateController(mock);
        var request = new CreateCommentRequest { Content = "hi" };

        var result = await controller.CreateComment(5, request);

        result.Result.Should().BeOfType<CreatedResult>();
    }

    [Fact]
    public async Task DeleteComment_ReturnsNoContent_OnSuccess()
    {
        var mock = new Mock<ICommentService>();
        mock.Setup(s => s.DeleteCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<bool>.Success(true));

        var controller = CreateController(mock);

        var result = await controller.DeleteComment(1, 2);

        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteComment_ReturnsForbidden_WhenDeletingOthersComment()
    {
        var mock = new Mock<ICommentService>();
        mock.Setup(s => s.DeleteCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<bool>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 10);

        var res = await controller.DeleteComment(1, 2);

        res.Should().BeOfType<ObjectResult>();
        var obj = res as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task UpdateComment_ReturnsForbidden_WhenEditingOthersComment()
    {
        var mock = new Mock<ICommentService>();
        mock.Setup(s => s.UpdateCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<UpdateCommentRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<CommentResponse>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 15);

        var result = await controller.UpdateComment(1, 2, new UpdateCommentRequest { Content = "edit" });

        result.Result.Should().BeOfType<ObjectResult>();
        var obj = result.Result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }
}
