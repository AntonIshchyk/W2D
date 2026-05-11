using System.Security.Claims;
using Backend.Controllers;
using Backend.Contracts.Activities;
using Backend.Contracts.Common;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Backend.Tests.Controllers;

public class ActivitiesControllerTests
{
    private ActivitiesController CreateController(Mock<IActivitySuggestionService> mock, int userId = 42)
    {
        var controller = new ActivitiesController(mock.Object);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }, "test"));
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        return controller;
    }

    [Fact]
    public async Task GetSuggestions_ReturnsOk_OnSuccess()
    {
        var mock = new Mock<IActivitySuggestionService>();
        var response = new ActivitySuggestionResponse { Summary = "ok", Suggestions = new List<string> { "a" } };
        mock.Setup(s => s.GetSuggestionsAsync(It.IsAny<int>(), It.IsAny<GetActivitySuggestionsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ActivitySuggestionResponse>.Success(response));

        var controller = CreateController(mock, 1);
        var request = new GetActivitySuggestionsRequest { Social = "solo", Mood = "happy", Latitude = 0, Longitude = 0 };

        var actionResult = await controller.GetSuggestions(request, CancellationToken.None);

        actionResult.Result.Should().BeOfType<OkObjectResult>();
        var ok = actionResult.Result as OkObjectResult;
        ok!.Value.Should().BeEquivalentTo(response);
    }

    [Fact]
    public async Task GetSuggestions_ReturnsForbidden_OnUnauthorizedResult()
    {
        var mock = new Mock<IActivitySuggestionService>();
        mock.Setup(s => s.GetSuggestionsAsync(It.IsAny<int>(), It.IsAny<GetActivitySuggestionsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ActivitySuggestionResponse>.Unauthorized("nope"));

        var controller = CreateController(mock, 2);
        var request = new GetActivitySuggestionsRequest { Social = "s", Mood = "m", Latitude = 0, Longitude = 0 };

        var actionResult = await controller.GetSuggestions(request, CancellationToken.None);

        actionResult.Result.Should().BeOfType<ObjectResult>();
        var obj = actionResult.Result as ObjectResult;
        obj!.StatusCode.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public async Task GetSuggestions_ReturnsBadRequest_OnInvalidResult()
    {
        var mock = new Mock<IActivitySuggestionService>();
        mock.Setup(s => s.GetSuggestionsAsync(It.IsAny<int>(), It.IsAny<GetActivitySuggestionsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ActivitySuggestionResponse>.Invalid("bad"));

        var controller = CreateController(mock, 3);
        var request = new GetActivitySuggestionsRequest { Social = "s", Mood = "m", Latitude = 0, Longitude = 0 };

        var actionResult = await controller.GetSuggestions(request, CancellationToken.None);

        actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task GetSuggestions_Throws_WhenNoPrincipal()
    {
        var mock = new Mock<IActivitySuggestionService>();
        mock.Setup(s => s.GetSuggestionsAsync(It.IsAny<int>(), It.IsAny<GetActivitySuggestionsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<ActivitySuggestionResponse>.Success(new ActivitySuggestionResponse()));

        var controller = new ActivitiesController(mock.Object);
        controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }; // no user

        await FluentActions.Invoking(() => controller.GetSuggestions(new GetActivitySuggestionsRequest { Social = "s", Mood = "m", Latitude = 0, Longitude = 0 }, CancellationToken.None))
            .Should().ThrowAsync<InvalidOperationException>();
    }
}
