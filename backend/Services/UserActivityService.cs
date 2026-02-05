using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public class UserActivityService : IUserActivityService
{
    private readonly AppDbContext _context;

    public UserActivityService(AppDbContext context)
    {
        _context = context;
    }

    private static IQueryable<UserActivity> IncludeActivityDetails(IQueryable<UserActivity> query)
    {
        return query
            .Include(s => s.Activity!)
                .ThenInclude(a => a.Category)
            .Include(s => s.Activity!)
                .ThenInclude(a => a.Tags);
    }

    public async Task<UserActivity> ScheduleActivityAsync(int userId, int activityId, DateTime plannedDate, string? notes = null)
    {
        var userActivity = new UserActivity
        {
            UserId = userId,
            ActivityId = activityId,
            PlannedDate = plannedDate,
            Notes = notes,
            Status = ScheduleStatus.Planned,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.UserActivities.Add(userActivity);
        await _context.SaveChangesAsync();

        // Load the activity details
        await _context.Entry(userActivity)
            .Reference(s => s.Activity)
            .Query()
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .LoadAsync();

        return userActivity;
    }

    public async Task<UserActivity?> GetExistingUserActivityAsync(int userId, int activityId, DateTime plannedDate)
    {
        return await _context.UserActivities
            .AsNoTracking()
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.ActivityId == activityId &&
                s.PlannedDate.Date == plannedDate.Date &&
                s.Status == ScheduleStatus.Planned);
    }

    public async Task<IEnumerable<UserActivity>> GetUserScheduledActivitiesAsync(int userId)
    {
        return await IncludeActivityDetails(_context.UserActivities.AsNoTracking())
            .Where(s => s.UserId == userId && s.Status == ScheduleStatus.Planned)
            .OrderBy(s => s.PlannedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserActivity>> GetUserCompletedActivitiesAsync(int userId)
    {
        return await IncludeActivityDetails(_context.UserActivities.AsNoTracking())
            .Where(s => s.UserId == userId && s.Status == ScheduleStatus.Completed)
            .OrderByDescending(s => s.CompletedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserActivity>> GetUserHistoryAsync(int userId)
    {
        return await IncludeActivityDetails(_context.UserActivities.AsNoTracking())
            .Where(s => s.UserId == userId && (s.Status == ScheduleStatus.Completed || s.Status == ScheduleStatus.Cancelled))
            .OrderByDescending(s => s.CompletedDate ?? s.UpdatedAt)
            .ToListAsync();
    }

    public async Task<UserActivity?> GetUserActivityByIdAsync(int id, int userId)
    {
        return await IncludeActivityDetails(_context.UserActivities.AsNoTracking())
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);
    }

    public async Task<UserActivity?> MarkAsCompletedAsync(int id, int userId, DateTime? completedDate = null)
    {
        var userActivity = await IncludeActivityDetails(_context.UserActivities)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (userActivity == null)
        {
            return null;
        }

        userActivity.Status = ScheduleStatus.Completed;
        userActivity.CompletedDate = completedDate ?? DateTime.UtcNow;
        userActivity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return userActivity;
    }

    public async Task<UserActivity?> CancelUserActivityAsync(int id, int userId)
    {
        var userActivity = await IncludeActivityDetails(_context.UserActivities)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (userActivity == null)
        {
            return null;
        }

        userActivity.Status = ScheduleStatus.Cancelled;
        userActivity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return userActivity;
    }

    public async Task<bool> DeleteUserActivityAsync(int id, int userId)
    {
        var userActivity = await _context.UserActivities
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (userActivity == null)
        {
            return false;
        }

        _context.UserActivities.Remove(userActivity);
        await _context.SaveChangesAsync();

        return true;
    }
}
