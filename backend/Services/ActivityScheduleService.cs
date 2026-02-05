using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public class ActivityScheduleService : IActivityScheduleService
{
    private readonly AppDbContext _context;

    public ActivityScheduleService(AppDbContext context)
    {
        _context = context;
    }

    private static IQueryable<ActivitySchedule> IncludeActivityDetails(IQueryable<ActivitySchedule> query)
    {
        return query
            .Include(s => s.Activity)
                .ThenInclude(a => a!.Category)
            .Include(s => s.Activity)
                .ThenInclude(a => a!.Tags);
    }

    public async Task<ActivitySchedule> ScheduleActivityAsync(int userId, int activityId, DateTime plannedDate, string? notes = null)
    {
        var schedule = new ActivitySchedule
        {
            UserId = userId,
            ActivityId = activityId,
            PlannedDate = plannedDate,
            Notes = notes,
            Status = ScheduleStatus.Planned,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.ActivitySchedules.Add(schedule);
        await _context.SaveChangesAsync();

        // Load the activity details
        await _context.Entry(schedule)
            .Reference(s => s.Activity)
            .Query()
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .LoadAsync();

        return schedule;
    }

    public async Task<ActivitySchedule?> GetExistingScheduleAsync(int userId, int activityId, DateTime plannedDate)
    {
        return await _context.ActivitySchedules
            .AsNoTracking()
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.ActivityId == activityId &&
                s.PlannedDate.Date == plannedDate.Date &&
                s.Status == ScheduleStatus.Planned);
    }

    public async Task<IEnumerable<ActivitySchedule>> GetUserScheduledActivitiesAsync(int userId)
    {
        return await IncludeActivityDetails(_context.ActivitySchedules.AsNoTracking())
            .Where(s => s.UserId == userId && s.Status == ScheduleStatus.Planned)
            .OrderBy(s => s.PlannedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<ActivitySchedule>> GetUserCompletedActivitiesAsync(int userId)
    {
        return await IncludeActivityDetails(_context.ActivitySchedules.AsNoTracking())
            .Where(s => s.UserId == userId && s.Status == ScheduleStatus.Completed)
            .OrderByDescending(s => s.CompletedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<ActivitySchedule>> GetUserHistoryAsync(int userId)
    {
        return await IncludeActivityDetails(_context.ActivitySchedules.AsNoTracking())
            .Where(s => s.UserId == userId && (s.Status == ScheduleStatus.Completed || s.Status == ScheduleStatus.Cancelled))
            .OrderByDescending(s => s.CompletedDate ?? s.UpdatedAt)
            .ToListAsync();
    }

    public async Task<ActivitySchedule?> GetScheduleByIdAsync(int id, int userId)
    {
        return await IncludeActivityDetails(_context.ActivitySchedules.AsNoTracking())
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);
    }

    public async Task<ActivitySchedule?> MarkAsCompletedAsync(int id, int userId, DateTime? completedDate = null)
    {
        var schedule = await IncludeActivityDetails(_context.ActivitySchedules)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (schedule == null)
        {
            return null;
        }

        schedule.Status = ScheduleStatus.Completed;
        schedule.CompletedDate = completedDate ?? DateTime.UtcNow;
        schedule.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return schedule;
    }

    public async Task<ActivitySchedule?> CancelScheduleAsync(int id, int userId)
    {
        var schedule = await IncludeActivityDetails(_context.ActivitySchedules)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (schedule == null)
        {
            return null;
        }

        schedule.Status = ScheduleStatus.Cancelled;
        schedule.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return schedule;
    }

    public async Task<bool> DeleteScheduleAsync(int id, int userId)
    {
        var schedule = await _context.ActivitySchedules
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (schedule == null)
        {
            return false;
        }

        _context.ActivitySchedules.Remove(schedule);
        await _context.SaveChangesAsync();

        return true;
    }
}
