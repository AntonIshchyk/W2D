using Backend.Models;

namespace Backend.Services;

public interface IActivityScheduleService
{
    Task<ActivitySchedule> ScheduleActivityAsync(int userId, int activityId, DateTime plannedDate, string? notes = null);
    Task<ActivitySchedule?> GetExistingScheduleAsync(int userId, int activityId, DateTime plannedDate);
    Task<IEnumerable<ActivitySchedule>> GetUserScheduledActivitiesAsync(int userId);
    Task<IEnumerable<ActivitySchedule>> GetUserCompletedActivitiesAsync(int userId);
    Task<IEnumerable<ActivitySchedule>> GetUserHistoryAsync(int userId);
    Task<ActivitySchedule?> GetScheduleByIdAsync(int id, int userId);
    Task<ActivitySchedule?> MarkAsCompletedAsync(int id, int userId, DateTime? completedDate = null);
    Task<ActivitySchedule?> CancelScheduleAsync(int id, int userId);
    Task<bool> DeleteScheduleAsync(int id, int userId);
}
