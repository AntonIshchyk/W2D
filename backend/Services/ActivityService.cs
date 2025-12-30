using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public class ActivityService : IActivityService
{
    private readonly AppDbContext _context;

    public ActivityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
    {
        return await _context.Activities
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetApprovedActivitiesAsync()
    {
        return await _context.Activities
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .Where(a => a.Status == ActivityStatus.Approved)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<Activity?> GetActivityByIdAsync(int id)
    {
        return await _context.Activities
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Activity> CreateActivityAsync(Activity activity)
    {
        activity.CreatedAt = DateTime.UtcNow;
        activity.UpdatedAt = DateTime.UtcNow;

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task<Activity?> UpdateActivityAsync(int id, Activity activity)
    {
        var existingActivity = await _context.Activities.FindAsync(id);

        if (existingActivity == null)
        {
            return null;
        }

        existingActivity.Title = activity.Title;
        existingActivity.Description = activity.Description;
        existingActivity.ImageUrl = activity.ImageUrl;
        existingActivity.IsPassive = activity.IsPassive;
        existingActivity.IsSolo = activity.IsSolo;
        existingActivity.LocationType = activity.LocationType;
        existingActivity.EstimatedDuration = activity.EstimatedDuration;
        existingActivity.EntryLevel = activity.EntryLevel;
        existingActivity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingActivity;
    }

    public async Task<bool> DeleteActivityAsync(int id)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity == null)
        {
            return false;
        }

        _context.Activities.Remove(activity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Activity?> ApproveActivityAsync(int id, int approvedByUserId)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity == null)
        {
            return null;
        }

        activity.Status = ActivityStatus.Approved;
        activity.ApprovedByUserId = approvedByUserId;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task<Activity?> RejectActivityAsync(int id)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity == null)
        {
            return null;
        }

        activity.Status = ActivityStatus.Rejected;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return activity;
    }
}
