using AutoMapper;
using Backend.Contracts.Common;
using Backend.Contracts.Comments;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.Tests.Services;

public class CommentServiceAuthorizationTests
{
    [Fact]
    public async Task DeleteCommentAsync_ReturnsUnauthorized_AndDoesNotSoftDelete_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "comment-owner", Email = "comment-owner@test.local" },
            new User { Id = 2, Username = "outsider", Email = "outsider@test.local" });
        context.Posts.Add(new Post
        {
            Id = 9,
            UserId = 1,
            Title = "post",
            Description = "description",
            Type = PostType.Guide,
            CommentCount = 1
        });
        context.Comments.Add(new Comment
        {
            Id = 100,
            PostId = 9,
            UserId = 1,
            Content = "owned comment"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.DeleteCommentAsync(9, 100, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 100);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 9);
        comment.IsDeleted.Should().BeFalse();
        post.CommentCount.Should().Be(1);
    }

    [Fact]
    public async Task UpdateCommentAsync_ReturnsUnauthorized_AndDoesNotModify_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "comment-owner-2", Email = "comment-owner-2@test.local" },
            new User { Id = 2, Username = "attacker-2", Email = "attacker-2@test.local" });
        context.Posts.Add(new Post
        {
            Id = 11,
            UserId = 1,
            Title = "post",
            Description = "description",
            Type = PostType.Guide
        });
        context.Comments.Add(new Comment
        {
            Id = 101,
            PostId = 11,
            UserId = 1,
            Content = "Original content"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.UpdateCommentAsync(11, 101, new UpdateCommentRequest { Content = "Tampered" }, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 101);
        comment.Content.Should().Be("Original content");
    }

    [Fact]
    public async Task DeleteCommentAsync_AsOwner_SoftDeletesComment_AndDecrementsPostCommentCount()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        context.Users.Add(new User { Id = 1, Username = "owner-post-comment-delete", Email = "owner-post-comment-delete@test.local" });
        context.Posts.Add(new Post
        {
            Id = 15,
            UserId = 1,
            Title = "post",
            Description = "description",
            Type = PostType.Question,
            CommentCount = 1
        });
        context.Comments.Add(new Comment
        {
            Id = 102,
            PostId = 15,
            UserId = 1,
            Content = "to be deleted"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.DeleteCommentAsync(15, 102, userId: 1);

        result.Status.Should().Be(ResultStatus.Success);

        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 102);
        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 15);

        comment.IsDeleted.Should().BeTrue();
        post.CommentCount.Should().Be(0);
    }

    [Fact]
    public async Task UpdateCommentAsync_AsOwner_UpdatesCommentContent()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "owner-post-comment-update", Email = "owner-post-comment-update@test.local" });
        context.Posts.Add(new Post
        {
            Id = 16,
            UserId = 1,
            Title = "post",
            Description = "description",
            Type = PostType.Question
        });
        context.Comments.Add(new Comment
        {
            Id = 103,
            PostId = 16,
            UserId = 1,
            Content = "old content"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.UpdateCommentAsync(
            16,
            103,
            new UpdateCommentRequest { Content = " updated content " },
            userId: 1);

        result.Status.Should().Be(ResultStatus.Success);
        result.Value.Should().NotBeNull();
        result.Value!.Content.Should().Be("updated content");

        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 103);
        comment.Content.Should().Be("updated content");
    }

    [Fact]
    public async Task DeletePlaceCommentAsync_ReturnsUnauthorized_AndDoesNotSoftDelete_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "place-comment-owner", Email = "place-comment-owner@test.local" },
            new User { Id = 2, Username = "place-comment-attacker", Email = "place-comment-attacker@test.local" });
        context.Places.Add(new Place
        {
            Id = 21,
            UserId = 1,
            Title = "place",
            Description = "description",
            CommentCount = 1
        });
        context.Comments.Add(new Comment
        {
            Id = 201,
            PlaceId = 21,
            UserId = 1,
            Content = "owned place comment"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.DeletePlaceCommentAsync(21, 201, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 201);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 21);
        comment.IsDeleted.Should().BeFalse();
        place.CommentCount.Should().Be(1);
    }

    [Fact]
    public async Task UpdatePlaceCommentAsync_ReturnsUnauthorized_AndDoesNotModify_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "place-comment-owner-2", Email = "place-comment-owner-2@test.local" },
            new User { Id = 2, Username = "place-comment-attacker-2", Email = "place-comment-attacker-2@test.local" });
        context.Places.Add(new Place
        {
            Id = 22,
            UserId = 1,
            Title = "place",
            Description = "description"
        });
        context.Comments.Add(new Comment
        {
            Id = 202,
            PlaceId = 22,
            UserId = 1,
            Content = "Original place comment"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.UpdatePlaceCommentAsync(22, 202, new UpdateCommentRequest { Content = "Tampered place" }, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 202);
        comment.Content.Should().Be("Original place comment");
    }

    [Fact]
    public async Task DeletePlaceCommentAsync_AsOwner_SoftDeletesComment_AndDecrementsPlaceCommentCount()
    {
        var (context, connection) = ServiceTestHelpers.CreateSqliteContext();
        await using var _ = context;
        await using var __ = connection;
        context.Users.Add(new User { Id = 1, Username = "owner-place-delete", Email = "owner-place-delete@test.local" });
        context.Places.Add(new Place
        {
            Id = 23,
            UserId = 1,
            Title = "place",
            Description = "description",
            CommentCount = 1
        });
        context.Comments.Add(new Comment
        {
            Id = 203,
            PlaceId = 23,
            UserId = 1,
            Content = "to be deleted"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.DeletePlaceCommentAsync(23, 203, userId: 1);

        result.Status.Should().Be(ResultStatus.Success);

        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 203);
        var place = await context.Places.AsNoTracking().FirstAsync(p => p.Id == 23);

        comment.IsDeleted.Should().BeTrue();
        place.CommentCount.Should().Be(0);
    }

    [Fact]
    public async Task UpdatePlaceCommentAsync_AsOwner_UpdatesCommentContent()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "owner-place-update", Email = "owner-place-update@test.local" });
        context.Places.Add(new Place
        {
            Id = 24,
            UserId = 1,
            Title = "place",
            Description = "description"
        });
        context.Comments.Add(new Comment
        {
            Id = 204,
            PlaceId = 24,
            UserId = 1,
            Content = "old content"
        });
        await context.SaveChangesAsync();

        var service = new CommentService(context, Mock.Of<IMapper>());

        var result = await service.UpdatePlaceCommentAsync(
            24,
            204,
            new UpdateCommentRequest { Content = " updated content " },
            userId: 1);

        result.Status.Should().Be(ResultStatus.Success);
        result.Value.Should().NotBeNull();
        result.Value!.Content.Should().Be("updated content");

        var comment = await context.Comments.IgnoreQueryFilters().FirstAsync(c => c.Id == 204);
        comment.Content.Should().Be("updated content");
    }
}
