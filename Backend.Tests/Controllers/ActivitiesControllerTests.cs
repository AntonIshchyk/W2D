using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using FluentAssertions;
using Backend.Controllers;
using Backend.Models;
using Backend.Services;
using System.Security.Claims;

namespace Backend.Tests.Controllers;

public class ActivitiesControllerTests
{
    private readonly Mock<IActivityService> _mockActivityService;
    private readonly ActivitiesController _controller;

    public ActivitiesControllerTests()
    {
        _mockActivityService = new Mock<IActivityService>();
        _controller = new ActivitiesController(_mockActivityService.Object);
    }

    private void SetupControllerUser(int userId, bool isAdmin = false)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Email, "test@example.com"),
            new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "User")
        };

        var identity = new ClaimsIdentity(claims, "TestAuth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = claimsPrincipal }
        };
    }

    #region GetActivities Tests

    [Fact]
    public async Task GetActivities_ReturnsAllActivities()
    {
        // Arrange
        var allActivities = new List<Activity>
        {
            new Activity { Id = 1, Title = "Activity 1" },
            new Activity { Id = 2, Title = "Activity 2" },
            new Activity { Id = 3, Title = "Activity 3" }
        };
        _mockActivityService.Setup(x => x.GetAllActivitiesAsync())
            .ReturnsAsync(allActivities);

        // Act
        var result = await _controller.GetActivities();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var activities = okResult.Value.Should().BeAssignableTo<IEnumerable<Activity>>().Subject;
        activities.Should().HaveCount(3);
    }

    #endregion

    #region GetActivity Tests

    [Fact]
    public async Task GetActivity_ExistingActivity_ReturnsActivity()
    {
        // Arrange
        var activity = new Activity { Id = 1, Title = "Test Activity" };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(activity);

        // Act
        var result = await _controller.GetActivity(1);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedActivity = okResult.Value.Should().BeOfType<Activity>().Subject;
        returnedActivity.Id.Should().Be(1);
        returnedActivity.Title.Should().Be("Test Activity");
    }

    [Fact]
    public async Task GetActivity_NonExistingActivity_ReturnsNotFound()
    {
        // Arrange
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(999))
            .ReturnsAsync((Activity?)null);

        // Act
        var result = await _controller.GetActivity(999);

        // Assert
        result.Result.Should().BeOfType<NotFoundObjectResult>();
    }

    #endregion

    #region CreateActivity Tests

    [Fact]
    public async Task CreateActivity_AuthenticatedUser_CreatesActivity()
    {
        // Arrange
        SetupControllerUser(userId: 1);
        var activity = new Activity
        {
            Title = "New Activity",
            Description = "Test Description"
        };
        var createdActivity = new Activity
        {
            Id = 1,
            Title = activity.Title,
            Description = activity.Description,
            CreatedByUserId = 1
        };
        _mockActivityService.Setup(x => x.CreateActivityAsync(It.IsAny<Activity>()))
            .ReturnsAsync(createdActivity);

        // Act
        var result = await _controller.CreateActivity(activity);

        // Assert
        var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        var returnedActivity = createdResult.Value.Should().BeOfType<Activity>().Subject;
        returnedActivity.CreatedByUserId.Should().Be(1);
    }

    [Fact]
    public async Task CreateActivity_NoUserClaim_ReturnsUnauthorized()
    {
        // Arrange
        var activity = new Activity { Title = "Test" };
        // Don't set up user

        // Act
        var result = await _controller.CreateActivity(activity);

        // Assert
        result.Result.Should().BeOfType<UnauthorizedResult>();
    }

    #endregion

    #region UpdateActivity Tests

    [Fact]
    public async Task UpdateActivity_CreatorUpdatesOwnActivity_ReturnsUpdatedActivity()
    {
        // Arrange
        SetupControllerUser(userId: 1);
        var existingActivity = new Activity
        {
            Id = 1,
            Title = "Original",
            CreatedByUserId = 1
        };
        var updatedActivity = new Activity
        {
            Id = 1,
            Title = "Updated",
            CreatedByUserId = 1
        };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(existingActivity);
        _mockActivityService.Setup(x => x.UpdateActivityAsync(1, It.IsAny<Activity>()))
            .ReturnsAsync(updatedActivity);

        // Act
        var result = await _controller.UpdateActivity(1, updatedActivity);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedActivity = okResult.Value.Should().BeOfType<Activity>().Subject;
        returnedActivity.Title.Should().Be("Updated");
    }

    [Fact]
    public async Task UpdateActivity_NonCreatorUpdatesActivity_ReturnsForbid()
    {
        // Arrange
        SetupControllerUser(userId: 2);
        var existingActivity = new Activity
        {
            Id = 1,
            Title = "Original",
            CreatedByUserId = 1 // Different user
        };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(existingActivity);

        // Act
        var result = await _controller.UpdateActivity(1, existingActivity);

        // Assert
        result.Result.Should().BeOfType<ForbidResult>();
    }

    [Fact]
    public async Task UpdateActivity_ActivityNotFound_ReturnsNotFound()
    {
        // Arrange
        SetupControllerUser(userId: 1);
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(999))
            .ReturnsAsync((Activity?)null);

        // Act
        var result = await _controller.UpdateActivity(999, new Activity());

        // Assert
        result.Result.Should().BeOfType<NotFoundObjectResult>();
    }

    #endregion

    #region DeleteActivity Tests

    [Fact]
    public async Task DeleteActivity_CreatorDeletesOwnActivity_ReturnsNoContent()
    {
        // Arrange
        SetupControllerUser(userId: 1);
        var activity = new Activity
        {
            Id = 1,
            Title = "To Delete",
            CreatedByUserId = 1
        };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(activity);
        _mockActivityService.Setup(x => x.DeleteActivityAsync(1))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteActivity(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteActivity_NonCreatorDeletesActivity_ReturnsForbid()
    {
        // Arrange
        SetupControllerUser(userId: 2);
        var activity = new Activity
        {
            Id = 1,
            Title = "To Delete",
            CreatedByUserId = 1 // Different user
        };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(activity);

        // Act
        var result = await _controller.DeleteActivity(1);

        // Assert
        result.Should().BeOfType<ForbidResult>();
    }

    #endregion
}

