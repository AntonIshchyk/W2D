using Backend.Models;

namespace Backend.Services;

public interface IActivityService
{
    Task<IEnumerable<Activity>> GetAllActivitiesAsync();
    Task<PaginatedResult<Activity>> GetActivitiesAsync(int pageNumber = 1, int pageSize = 10);
    Task<Activity?> GetActivityByIdAsync(int id);
    Task<Activity> CreateActivityAsync(Activity activity);
    Task<Activity?> UpdateActivityAsync(int id, Activity activity);
    Task<bool> DeleteActivityAsync(int id);
    Task<bool> CategoryExistsAsync(int categoryId);
    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);
}
