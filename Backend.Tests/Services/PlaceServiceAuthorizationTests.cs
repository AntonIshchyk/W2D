using Backend.Contracts.Common;
using Backend.Contracts.Places;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests.Services;

public class PlaceServiceAuthorizationTests
{
    [Fact]
    public async Task UpdatePlaceAsync_ReturnsUnauthorized_AndDoesNotModify_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "place-owner", Email = "place-owner@test.local" },
            new User { Id = 2, Username = "intruder", Email = "intruder@test.local" });
        context.Places.Add(new Place
        {
            Id = 5,
            UserId = 1,
            Title = "Original title",
            Description = "Original description"
        });
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.UpdatePlaceAsync(5, userId: 2, new UpdatePlaceRequest { Title = "Hacked" });

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var place = await context.Places.FirstAsync(p => p.Id == 5);
        place.Title.Should().Be("Original title");
    }

    [Fact]
    public async Task UpdatePlaceAsync_AsOwner_UpdatesPlaceFields()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "place-owner-update", Email = "place-owner-update@test.local" });
        context.Places.Add(new Place
        {
            Id = 6,
            UserId = 1,
            Title = "Old place title",
            Description = "Old place description"
        });
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.UpdatePlaceAsync(6, userId: 1, new UpdatePlaceRequest
        {
            Title = "New place title",
            Description = "New place description"
        });

        result.Status.Should().Be(ResultStatus.Success);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 6);
        place.Title.Should().Be("New place title");
        place.Description.Should().Be("New place description");
    }

    [Fact]
    public async Task DeletePlaceAsync_ReturnsUnauthorized_AndDoesNotDelete_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "place-owner-delete", Email = "place-owner-delete@test.local" },
            new User { Id = 2, Username = "place-attacker-delete", Email = "place-attacker-delete@test.local" });
        context.Places.Add(new Place
        {
            Id = 7,
            UserId = 1,
            Title = "owned place",
            Description = "owned description"
        });
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.DeletePlaceAsync(7, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        (await context.Places.AnyAsync(p => p.Id == 7)).Should().BeTrue();
    }

    [Fact]
    public async Task DeletePlaceAsync_AsOwner_DeletesPlace()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "place-owner-delete-ok", Email = "place-owner-delete-ok@test.local" });
        context.Places.Add(new Place
        {
            Id = 8,
            UserId = 1,
            Title = "owned place",
            Description = "owned description"
        });
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.DeletePlaceAsync(8, userId: 1);

        result.Status.Should().Be(ResultStatus.Success);
        (await context.Places.AnyAsync(p => p.Id == 8)).Should().BeFalse();
    }
}
