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
    public async Task GetActivities_ReturnsPagedActivities()
    {
        // Arrange
        var paginatedResult = new PaginatedResult<Activity>
        {
            Items = new List<Activity>
            {
                new Activity { Id = 1, Title = "Activity 1" },
                new Activity { Id = 2, Title = "Activity 2" },
                new Activity { Id = 3, Title = "Activity 3" }
            },
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 3
        };
        _mockActivityService.Setup(x => x.GetActivitiesAsync(It.IsAny<int>(), It.IsAny<int>(), null, null))
            .ReturnsAsync(paginatedResult);

        // Act
        var result = await _controller.GetActivities(1, 10);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var pagedResult = okResult.Value.Should().BeOfType<PaginatedResult<Activity>>().Subject;
        pagedResult.Items.Should().HaveCount(3);
        pagedResult.PageNumber.Should().Be(1);
        pagedResult.PageSize.Should().Be(10);
        pagedResult.TotalCount.Should().Be(3);
    }

    [Fact]
    public async Task GetActivities_WithInvalidPageNumber_ReturnsBadRequest()
    {
        // Act
        var result = await _controller.GetActivities(0, 10);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task GetActivities_WithInvalidPageSize_ReturnsBadRequest()
    {
        // Act
        var result = await _controller.GetActivities(1, 101);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
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
        SetupControllerUser(userId: 1, isAdmin: true);
        var activity = new Activity
        {
            Title = "New Activity",
            Description = "Test Description",
            CategoryId = 1
        };
        var createdActivity = new Activity
        {
            Id = 1,
            Title = activity.Title,
            Description = activity.Description,
            CategoryId = 1
        };
        _mockActivityService.Setup(x => x.CategoryExistsAsync(1))
            .ReturnsAsync(true);
        _mockActivityService.Setup(x => x.CreateActivityAsync(It.IsAny<Activity>()))
            .ReturnsAsync(createdActivity);

        // Act
        var result = await _controller.CreateActivity(activity);

        // Assert
        var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        var returnedActivity = createdResult.Value.Should().BeOfType<Activity>().Subject;
        returnedActivity.Title.Should().Be("New Activity");
    }

    [Fact]
    public async Task CreateActivity_InvalidCategory_ReturnsBadRequest()
    {
        // Arrange
        SetupControllerUser(userId: 1);
        var activity = new Activity
        {
            Title = "Test",
            Description = "Test Description",
            CategoryId = 999
        };
        _mockActivityService.Setup(x => x.CategoryExistsAsync(999))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.CreateActivity(activity);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    #endregion

    #region UpdateActivity Tests

    [Fact]
    public async Task UpdateActivity_AuthenticatedUser_ReturnsUpdatedActivity()
    {
        // Arrange
        SetupControllerUser(userId: 1, isAdmin: true);
        var existingActivity = new Activity
        {
            Id = 1,
            Title = "Original",
            Description = "Description",
            CategoryId = 1
        };
        var updatedActivity = new Activity
        {
            Id = 1,
            Title = "Updated",
            Description = "Updated Description",
            CategoryId = 1
        };
        _mockActivityService.Setup(x => x.GetActivityByIdAsync(1))
            .ReturnsAsync(existingActivity);
        _mockActivityService.Setup(x => x.CategoryExistsAsync(1))
            .ReturnsAsync(true);
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
    public async Task DeleteActivity_AuthenticatedUser_ReturnsNoContent()
    {
        // Arrange
        SetupControllerUser(userId: 1, isAdmin: true);
        var activity = new Activity
        {
            Id = 1,
            Title = "To Delete"
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

    #endregion
}

