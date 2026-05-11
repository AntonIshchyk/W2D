using Backend.Controllers;
using Backend.Contracts.Common;
using Backend.Contracts.Posts;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Backend.Tests.Controllers;

public class PostsControllerTests
{
    private PostsController CreateController(Mock<IPostService> mock, int userId = 1)
    {
        var controller = new PostsController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task GetPosts_ReturnsBadRequest_WhenLimitInvalid()
    {
        var mock = new Mock<IPostService>();
        var controller = CreateController(mock);

        var result = await controller.GetPosts(limit: 0);

        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task GetPost_ReturnsNotFound_WhenServiceReturnsNotFound()
    {
        var mock = new Mock<IPostService>();
        mock.Setup(s => s.GetPostByIdAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<PostResponse>.NotFound("missing"));

        var controller = CreateController(mock, 5);

        var result = await controller.GetPost(123);

        result.Result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task CreatePost_ReturnsCreated_OnSuccess()
    {
        var mock = new Mock<IPostService>();
        var resp = new PostResponse { Id = 10 };
        mock.Setup(s => s.CreatePostAsync(It.IsAny<CreatePostRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<PostResponse>.Success(resp));

        var controller = CreateController(mock);
        var request = new CreatePostRequest { Title = "t", Description = "short description" };

        var result = await controller.CreatePost(request);

        result.Result.Should().BeOfType<CreatedAtActionResult>();
    }

    [Fact]
    public async Task UpdatePost_ReturnsNotFound_WhenMissing()
    {
        var mock = new Mock<IPostService>();
        mock.Setup(s => s.UpdatePostAsync(It.IsAny<int>(), It.IsAny<UpdatePostRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<PostResponse>.NotFound("nope"));

        var controller = CreateController(mock, 3);

        var result = await controller.UpdatePost(5, new UpdatePostRequest { Title = "x", Description = "desc", Type = 1 });

        result.Result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task UpdatePost_ReturnsForbidden_WhenEditingOthersPost()
    {
        var mock = new Mock<IPostService>();
        mock.Setup(s => s.UpdatePostAsync(It.IsAny<int>(), It.IsAny<UpdatePostRequest>(), It.IsAny<int>()))
            .ReturnsAsync(Result<PostResponse>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 99);

        var result = await controller.UpdatePost(5, new UpdatePostRequest { Title = "x", Description = "desc", Type = 1 });

        result.Result.Should().BeOfType<ObjectResult>();
        var obj = result.Result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task DeletePost_ReturnsForbidden_WhenDeletingOthersPost()
    {
        var mock = new Mock<IPostService>();
        mock.Setup(s => s.DeletePostAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(Result<bool>.Unauthorized("not owner"));

        var controller = CreateController(mock, userId: 42);

        var result = await controller.DeletePost(123);

        result.Should().BeOfType<ObjectResult>();
        var obj = result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }
}
