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
            .AsNoTracking()
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetApprovedActivitiesAsync()
    {
        return await _context.Activities
            .AsNoTracking()
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .Where(a => a.Status == ActivityStatus.Approved)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<Activity?> GetActivityByIdAsync(int id)
    {
        return await _context.Activities
            .AsNoTracking()
            .Include(a => a.CreatedBy)
            .Include(a => a.ApprovedBy)
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Activity> CreateActivityAsync(Activity activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task<Activity?> UpdateActivityAsync(int id, Activity activity)
    {
        var existingActivity = await _context.Activities
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (existingActivity == null)
        {
            return null;
        }

        existingActivity.Title = activity.Title;
        existingActivity.Description = activity.Description;
        existingActivity.CategoryId = activity.CategoryId;
        existingActivity.LocationType = activity.LocationType;
        existingActivity.CostLevel = activity.CostLevel;
        existingActivity.PhysicalActivityLevel = activity.PhysicalActivityLevel;
        existingActivity.Sociability = activity.Sociability;
        existingActivity.EquipmentLevel = activity.EquipmentLevel;
        existingActivity.EntryLevel = activity.EntryLevel;

        // Tags are already tracked entities from controller validation
        existingActivity.Tags.Clear();
        if (activity.Tags != null)
        {
            foreach (var tag in activity.Tags)
            {
                existingActivity.Tags.Add(tag);
            }
        }

        existingActivity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingActivity;
    }

    public async Task<bool> DeleteActivityAsync(int id)
    {
        var activity = await _context.Activities
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);

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
        var activity = await _context.Activities
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);

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
        var activity = await _context.Activities
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (activity == null)
        {
            return null;
        }

        activity.Status = ActivityStatus.Rejected;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
    {
        return await _context.Categories.AnyAsync(c => c.Id == categoryId);
    }

    public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds)
    {
        return await _context.Tags
            .Where(t => tagIds.Contains(t.Id))
            .ToListAsync();
    }
}
