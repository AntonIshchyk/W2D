using Backend.Contracts.Common;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Tests.Services;

public class PlaceServiceVoteTests
{
    [Fact]
    public async Task VotePlaceAsync_ReturnsInvalid_WhenVoteValueOutOfRange()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceAsync(context, placeId: 1, ownerId: 1, voterId: 2);

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(1, userId: 2, value: 2);

        result.Status.Should().Be(ResultStatus.Invalid);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 1);
        place.Score.Should().Be(0);
        (await context.PlaceVotes.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task VotePlaceAsync_ReturnsNotFound_WhenPlaceMissing()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        context.Users.Add(new User { Id = 2, Username = "voter", Email = "voter@test.local" });
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(999, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.NotFound);
    }

    [Fact]
    public async Task VotePlaceAsync_CreatesUpvote_AndIncrementsScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceAsync(context, placeId: 2, ownerId: 1, voterId: 2);

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(2, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 2);
        var vote = await context.PlaceVotes.AsNoTracking().SingleAsync(v => v.PlaceId == 2 && v.UserId == 2);
        place.Score.Should().Be(1);
        vote.Value.Should().Be(1);
    }

    [Fact]
    public async Task VotePlaceAsync_SwitchesUpvoteToDownvote_AndAppliesDelta()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceAsync(context, placeId: 3, ownerId: 1, voterId: 2);
        context.PlaceVotes.Add(new PlaceVote { UserId = 2, PlaceId = 3, Value = 1 });
        var seededPlace = await context.Places.FirstAsync(p => p.Id == 3);
        seededPlace.Score = 1;
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(3, userId: 2, value: -1);

        result.Status.Should().Be(ResultStatus.Success);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 3);
        var vote = await context.PlaceVotes.AsNoTracking().SingleAsync(v => v.PlaceId == 3 && v.UserId == 2);
        place.Score.Should().Be(-1);
        vote.Value.Should().Be(-1);
    }

    [Fact]
    public async Task VotePlaceAsync_ClearsExistingVote_WhenValueZero()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceAsync(context, placeId: 4, ownerId: 1, voterId: 2);
        context.PlaceVotes.Add(new PlaceVote { UserId = 2, PlaceId = 4, Value = 1 });
        var seededPlace = await context.Places.FirstAsync(p => p.Id == 4);
        seededPlace.Score = 1;
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(4, userId: 2, value: 0);

        result.Status.Should().Be(ResultStatus.Success);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 4);
        place.Score.Should().Be(0);
        (await context.PlaceVotes.AnyAsync(v => v.PlaceId == 4 && v.UserId == 2)).Should().BeFalse();
    }

    [Fact]
    public async Task VotePlaceAsync_SameVote_IsIdempotentForScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceAsync(context, placeId: 5, ownerId: 1, voterId: 2);
        context.PlaceVotes.Add(new PlaceVote { UserId = 2, PlaceId = 5, Value = 1 });
        var seededPlace = await context.Places.FirstAsync(p => p.Id == 5);
        seededPlace.Score = 1;
        await context.SaveChangesAsync();

        var service = new PlaceService(context);

        var result = await service.VotePlaceAsync(5, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 5);
        place.Score.Should().Be(1);
        (await context.PlaceVotes.CountAsync(v => v.PlaceId == 5 && v.UserId == 2)).Should().Be(1);
    }

    private static async Task SeedPlaceAsync(AppDbContext context, int placeId, int ownerId, int voterId)
    {
        context.Users.AddRange(
            new User { Id = ownerId, Username = "owner", Email = $"owner{ownerId}@test.local" },
            new User { Id = voterId, Username = "voter", Email = $"voter{voterId}@test.local" });
        context.Places.Add(new Place
        {
            Id = placeId,
            UserId = ownerId,
            Title = "place",
            Description = "place description",
            Score = 0
        });
        await context.SaveChangesAsync();
    }
}
