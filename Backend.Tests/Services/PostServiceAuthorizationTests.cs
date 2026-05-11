using AutoMapper;
using Backend.Contracts.Common;
using Backend.Contracts.Posts;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.Tests.Services;

public class PostServiceAuthorizationTests
{
    [Fact]
    public async Task DeletePostAsync_ReturnsUnauthorized_AndDoesNotDelete_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "owner", Email = "owner@test.local" },
            new User { Id = 2, Username = "attacker", Email = "attacker@test.local" });
        context.Posts.Add(new Post
        {
            Id = 10,
            UserId = 1,
            Title = "owned",
            Description = "post",
            Type = PostType.Question
        });
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.DeletePostAsync(10, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        (await context.Posts.AnyAsync(p => p.Id == 10)).Should().BeTrue();
    }

    [Fact]
    public async Task DeletePostAsync_AsOwner_DeletesPost()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "post-owner-delete", Email = "post-owner-delete@test.local" });
        context.Posts.Add(new Post
        {
            Id = 12,
            UserId = 1,
            Title = "owned",
            Description = "post description",
            Type = PostType.Question
        });
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.DeletePostAsync(12, userId: 1);

        result.Status.Should().Be(ResultStatus.Success);
        (await context.Posts.AnyAsync(p => p.Id == 12)).Should().BeFalse();
    }

    [Fact]
    public async Task UpdatePostAsync_ReturnsUnauthorized_AndDoesNotModify_WhenUserIsNotOwner()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.AddRange(
            new User { Id = 1, Username = "post-owner-update", Email = "post-owner-update@test.local" },
            new User { Id = 2, Username = "post-attacker-update", Email = "post-attacker-update@test.local" });
        context.Posts.Add(new Post
        {
            Id = 13,
            UserId = 1,
            Title = "Original title",
            Description = "Original description text",
            Type = PostType.Question
        });
        await context.SaveChangesAsync();

        var service = new PostService(context, Mock.Of<IMapper>());

        var result = await service.UpdatePostAsync(13, new UpdatePostRequest { Title = "Hacked" }, userId: 2);

        result.Status.Should().Be(ResultStatus.Unauthorized);
        var post = await context.Posts.FirstAsync(p => p.Id == 13);
        post.Title.Should().Be("Original title");
    }

    [Fact]
    public async Task UpdatePostAsync_AsOwner_UpdatesPostFields()
    {
        await using var context = ServiceTestHelpers.CreateInMemoryContext();
        context.Users.Add(new User { Id = 1, Username = "post-owner-edit", Email = "post-owner-edit@test.local" });
        context.Posts.Add(new Post
        {
            Id = 14,
            UserId = 1,
            Title = "Old title",
            Description = "Old description text",
            Type = PostType.Question
        });
        await context.SaveChangesAsync();

        var service = new PostService(context, ServiceTestHelpers.CreateMapper());

        var result = await service.UpdatePostAsync(
            14,
            new UpdatePostRequest
            {
                Title = "New title",
                Description = "New description text",
                Type = (int)PostType.Guide
            },
            userId: 1);

        result.Status.Should().Be(ResultStatus.Success);

        var post = await context.Posts.AsNoTracking().FirstAsync(p => p.Id == 14);
        post.Title.Should().Be("New title");
        post.Description.Should().Be("New description text");
        post.Type.Should().Be(PostType.Guide);
    }
}
