using Backend.Models;

namespace Backend.Services;

public interface IUserActivityService
{
    Task<UserActivity> ScheduleActivityAsync(int userId, int activityId, DateTime plannedDate, string? notes = null);
    Task<UserActivity?> GetExistingUserActivityAsync(int userId, int activityId, DateTime plannedDate);
    Task<IEnumerable<UserActivity>> GetUserScheduledActivitiesAsync(int userId);
    Task<IEnumerable<UserActivity>> GetUserCompletedActivitiesAsync(int userId);
    Task<IEnumerable<UserActivity>> GetUserHistoryAsync(int userId);
    Task<UserActivity?> GetUserActivityByIdAsync(int id, int userId);
    Task<UserActivity?> MarkAsCompletedAsync(int id, int userId, DateTime? completedDate = null);
    Task<UserActivity?> CancelUserActivityAsync(int id, int userId);
    Task<bool> DeleteUserActivityAsync(int id, int userId);
}
