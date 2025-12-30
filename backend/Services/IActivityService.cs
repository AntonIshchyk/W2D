using Backend.Models;

namespace Backend.Services;

public interface IActivityService
{
    Task<IEnumerable<Activity>> GetAllActivitiesAsync();
    Task<IEnumerable<Activity>> GetApprovedActivitiesAsync();
    Task<Activity?> GetActivityByIdAsync(int id);
    Task<Activity> CreateActivityAsync(Activity activity);
    Task<Activity?> UpdateActivityAsync(int id, Activity activity);
    Task<bool> DeleteActivityAsync(int id);
    Task<Activity?> ApproveActivityAsync(int id, int approvedByUserId);
    Task<Activity?> RejectActivityAsync(int id);
}
