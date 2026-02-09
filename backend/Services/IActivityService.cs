using Backend.Models;
using Backend.Contracts.Common;
using Backend.Constants;

namespace Backend.Services;

public interface IActivityService
{
    Task<IEnumerable<Activity>> GetAllActivitiesAsync();
    Task<ScrollResult<Activity>> GetActivitiesAsync(int? cursor = null, int limit = PaginationConstants.DefaultPageSize, int? categoryId = null, List<int>? tagIds = null, string? search = null);
    Task<Activity?> GetActivityByIdAsync(int id);
    Task<Activity> CreateActivityAsync(Activity activity);
    Task<Activity?> UpdateActivityAsync(int id, Activity activity);
    Task<bool> DeleteActivityAsync(int id);
    Task<bool> CategoryExistsAsync(int categoryId);
    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);
}
