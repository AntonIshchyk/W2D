using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

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
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<PaginatedResult<Activity>> GetActivitiesAsync(int pageNumber = 1, int pageSize = 10, int? categoryId = null, List<int>? tagIds = null)
    {
        var query = _context.Activities
            .AsNoTracking()
            .Include(a => a.Category)
            .Include(a => a.Tags)
            .AsQueryable();

        // Filter by category if provided
        if (categoryId.HasValue)
        {
            query = query.Where(a => a.CategoryId == categoryId.Value);
        }

        // Filter by tags if provided (activities must have ALL specified tags)
        if (tagIds != null && tagIds.Any())
        {
            query = query.Where(a => a.Tags.Count(t => tagIds.Contains(t.Id)) == tagIds.Count);
        }

        query = query.OrderByDescending(a => a.CreatedAt);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Activity>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public async Task<Activity?> GetActivityByIdAsync(int id)
    {
        return await _context.Activities
            .AsNoTracking()
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
