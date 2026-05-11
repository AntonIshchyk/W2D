using Backend.Contracts.Communities;
using Backend.Services;
using Backend.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Backend.Tests.Controllers;

public class CommunitiesControllerTests
{
    [Fact]
    public async Task GetCommunities_ReturnsOk()
    {
        var mock = new Mock<ICommunityService>();
        mock.Setup(s => s.GetCommunitiesAsync()).ReturnsAsync(new List<CommunityResponse>());

        var controller = new CommunitiesController(mock.Object);

        var result = await controller.GetCommunities();

        result.Result.Should().BeOfType<OkObjectResult>();
    }
}
