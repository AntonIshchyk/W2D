using AutoMapper;
using Backend.Contracts.Common;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.Tests.Services;

public class CommentServiceVoteTests
{
    [Fact]
    public async Task VoteCommentAsync_ReturnsInvalid_WhenVoteValueOutOfRange()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostCommentAsync(context, postId: 1, commentId: 11, ownerId: 1, voterId: 2);

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(1, 11, userId: 2, value: 2);

        result.Status.Should().Be(ResultStatus.Invalid);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 11);
        comment.Score.Should().Be(0);
        (await context.CommentVotes.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task VoteCommentAsync_ReturnsNotFound_WhenCommentMissing()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        context.Users.Add(new User { Id = 2, Username = "voter", Email = "voter@test.local" });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(1, 999, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.NotFound);
    }

    [Fact]
    public async Task VoteCommentAsync_CreatesUpvote_AndIncrementsCommentScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostCommentAsync(context, postId: 2, commentId: 12, ownerId: 1, voterId: 2);

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(2, 12, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 12);
        var vote = await context.CommentVotes.AsNoTracking().SingleAsync(v => v.CommentId == 12 && v.UserId == 2);
        comment.Score.Should().Be(1);
        vote.Value.Should().Be(1);
    }

    [Fact]
    public async Task VoteCommentAsync_SwitchesUpvoteToDownvote_AndAppliesDelta()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostCommentAsync(context, postId: 3, commentId: 13, ownerId: 1, voterId: 2);
        context.CommentVotes.Add(new CommentVote { UserId = 2, CommentId = 13, Value = 1 });
        var seededComment = await context.Comments.FirstAsync(c => c.Id == 13);
        seededComment.Score = 1;
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(3, 13, userId: 2, value: -1);

        result.Status.Should().Be(ResultStatus.Success);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 13);
        var vote = await context.CommentVotes.AsNoTracking().SingleAsync(v => v.CommentId == 13 && v.UserId == 2);
        comment.Score.Should().Be(-1);
        vote.Value.Should().Be(-1);
    }

    [Fact]
    public async Task VoteCommentAsync_ClearsVote_WhenValueZero()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostCommentAsync(context, postId: 4, commentId: 14, ownerId: 1, voterId: 2);
        context.CommentVotes.Add(new CommentVote { UserId = 2, CommentId = 14, Value = 1 });
        var seededComment = await context.Comments.FirstAsync(c => c.Id == 14);
        seededComment.Score = 1;
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(4, 14, userId: 2, value: 0);

        result.Status.Should().Be(ResultStatus.Success);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 14);
        comment.Score.Should().Be(0);
        (await context.CommentVotes.AnyAsync(v => v.CommentId == 14 && v.UserId == 2)).Should().BeFalse();
    }

    [Fact]
    public async Task VoteCommentAsync_SameVote_IsIdempotentForScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPostCommentAsync(context, postId: 5, commentId: 15, ownerId: 1, voterId: 2);
        context.CommentVotes.Add(new CommentVote { UserId = 2, CommentId = 15, Value = 1 });
        var seededComment = await context.Comments.FirstAsync(c => c.Id == 15);
        seededComment.Score = 1;
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VoteCommentAsync(5, 15, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 15);
        comment.Score.Should().Be(1);
        (await context.CommentVotes.CountAsync(v => v.CommentId == 15 && v.UserId == 2)).Should().Be(1);
    }

    [Fact]
    public async Task VotePlaceCommentAsync_CreatesUpvote_AndIncrementsCommentScore()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceCommentAsync(context, placeId: 6, commentId: 16, ownerId: 1, voterId: 2);

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VotePlaceCommentAsync(6, 16, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.Success);
        var comment = await context.Comments.AsNoTracking().FirstAsync(c => c.Id == 16);
        var vote = await context.CommentVotes.AsNoTracking().SingleAsync(v => v.CommentId == 16 && v.UserId == 2);
        comment.Score.Should().Be(1);
        vote.Value.Should().Be(1);
    }

    [Fact]
    public async Task VotePlaceCommentAsync_ReturnsNotFound_WhenWrongPlaceContext()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        await SeedPlaceCommentAsync(context, placeId: 7, commentId: 17, ownerId: 1, voterId: 2);

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.VotePlaceCommentAsync(999, 17, userId: 2, value: 1);

        result.Status.Should().Be(ResultStatus.NotFound);
    }

    private static async Task SeedPostCommentAsync(AppDbContext context, int postId, int commentId, int ownerId, int voterId)
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
            Type = PostType.Question
        });
        context.Comments.Add(new Comment
        {
            Id = commentId,
            PostId = postId,
            UserId = ownerId,
            Content = "comment",
            Score = 0
        });
        await context.SaveChangesAsync();
    }

    private static async Task SeedPlaceCommentAsync(AppDbContext context, int placeId, int commentId, int ownerId, int voterId)
    {
        context.Users.AddRange(
            new User { Id = ownerId, Username = "owner", Email = $"owner{ownerId}@test.local" },
            new User { Id = voterId, Username = "voter", Email = $"voter{voterId}@test.local" });
        context.Places.Add(new Place
        {
            Id = placeId,
            UserId = ownerId,
            Title = "place",
            Description = "place description"
        });
        context.Comments.Add(new Comment
        {
            Id = commentId,
            PlaceId = placeId,
            UserId = ownerId,
            Content = "comment",
            Score = 0
        });
        await context.SaveChangesAsync();
    }
}
