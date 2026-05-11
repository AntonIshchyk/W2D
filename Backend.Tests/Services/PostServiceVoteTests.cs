using AutoMapper;
using Backend.Contracts.Common;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.Tests.Services;

public class PostServiceVoteTests
{
    [Fact]
    public async Task VotePostAsync_ReturnsInvalid_WhenVoteValueOutOfRange()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostAsync(context, postId: 1, ownerId: 1, voterId: 2);

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(1, userId: 2, value: 2);

        result.Status.Should().Be(ResultStatus.Invalid);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 1);
        post.Score.Should().Be(0);
        (await context.PostVotes.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task VotePostAsync_ReturnsNotFound_WhenPostMissing()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        context.Users.Add(new User { Id = 2, Username = "voter", Email = "voter@test.local" });
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(999, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.NotFound);
    }

    [Fact]
    public async Task VotePostAsync_CreatesUpvote_AndIncrementsScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostAsync(context, postId: 2, ownerId: 1, voterId: 2);

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(2, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 2);
        var vote = await context.PostVotes.AsNoTracking().SingleAsync(v => v.PostId == 2 && v.UserId == 2);
        post.Score.Should().Be(1);
        vote.Value.Should().Be(1);
    }

    [Fact]
    public async Task VotePostAsync_SwitchesUpvoteToDownvote_AndAppliesDelta()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostAsync(context, postId: 3, ownerId: 1, voterId: 2);
        context.PostVotes.Add(new PostVote { UserId = 2, PostId = 3, Value = 1 });
        var seededPost = await context.Posts.FirstAsync(p => p.Id == 3);
        seededPost.Score = 1;
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(3, userId: 2, value: -1);

        result.Status.Should().Be(ResultStatus.Success);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 3);
        var vote = await context.PostVotes.AsNoTracking().SingleAsync(v => v.PostId == 3 && v.UserId == 2);
        post.Score.Should().Be(-1);
        vote.Value.Should().Be(-1);
    }

    [Fact]
    public async Task VotePostAsync_ClearsExistingVote_WhenValueZero()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostAsync(context, postId: 4, ownerId: 1, voterId: 2);
        context.PostVotes.Add(new PostVote { UserId = 2, PostId = 4, Value = 1 });
        var seededPost = await context.Posts.FirstAsync(p => p.Id == 4);
        seededPost.Score = 1;
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(4, userId: 2, value: 0);

        result.Status.Should().Be(ResultStatus.Success);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 4);
        post.Score.Should().Be(0);
        (await context.PostVotes.AnyAsync(v => v.PostId == 4 && v.UserId == 2)).Should().BeFalse();
    }

    [Fact]
    public async Task VotePostAsync_SameVote_IsIdempotentForScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostAsync(context, postId: 5, ownerId: 1, voterId: 2);
        context.PostVotes.Add(new PostVote { UserId = 2, PostId = 5, Value = 1 });
        var seededPost = await context.Posts.FirstAsync(p => p.Id == 5);
        seededPost.Score = 1;
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.VotePostAsync(5, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 5);
        post.Score.Should().Be(1);
        (await context.PostVotes.CountAsync(v => v.PostId == 5 && v.UserId == 2)).Should().Be(1);
    }

    private static async Task SeedPostAsync(AppDbContext context, int postId, int ownerId, int voterId)
    {
        context.Users.AddRange(
            new User { Id = ownerId, Username = "owner", Email = $"owner{ownerId}@test.local" },
            new User { Id = voterId, Username = "voter", Email = $"voter{voterId}@test.local" });
        context.Posts.Add(new Post
        {
            Id = postId,
            UserId = ownerId,
            Title = "post",
            Description = "post description",
            Type = PostType.Question,
            Score = 0
        });
        await context.SaveChangesAsync();
    }
}
