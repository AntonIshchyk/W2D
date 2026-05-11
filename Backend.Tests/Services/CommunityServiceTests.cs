using Backend.Contracts.Common;
using Backend.Models;
using Backend.Services;
using FluentAssertions;

namespace Backend.Tests.Services;

public class CommunityServiceTests
{
    [Fact]
    public async Task GetCommunitiesAsync_ReturnsCommunitiesSortedByName()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Communities.AddRange(
            new Community { Id = 1, Name = "z-last", Description = "z" },
            new Community { Id = 2, Name = "a-first", Description = "a" },
            new Community { Id = 3, Name = "m-mid", Description = "m" });
        await context.SaveChangesAsync();

        var service = new CommunityService(context);

        var result = await service.GetCommunitiesAsync();

        result.Select(c => c.Name).Should().Equal("a-first", "m-mid", "z-last");
    }

    [Fact]
    public async Task GetCommunityByIdAsync_ReturnsNotFound_WhenMissing()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        var service = new CommunityService(context);

        var result = await service.GetCommunityByIdAsync(123);

        result.Status.Should().Be(ResultStatus.NotFound);
    }

    [Fact]
    public async Task GetCommunityByIdAsync_ReturnsCommunity_WhenExists()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Communities.Add(new Community { Id = 4, Name = "travel", Description = "desc" });
        await context.SaveChangesAsync();

        var service = new CommunityService(context);

        var result = await service.GetCommunityByIdAsync(4);

        result.Status.Should().Be(ResultStatus.Success);
        result.Value.Should().NotBeNull();
        result.Value!.Name.Should().Be("travel");
    }
}
