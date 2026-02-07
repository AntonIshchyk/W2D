using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Backend.Constants;

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

    public async Task<ScrollResult<Activity>> GetActivitiesAsync(int? cursor = null, int limit = PaginationConstants.DefaultPageSize, int? categoryId = null, List<int>? tagIds = null)
    {
        IQueryable<Activity> query = _context.Activities
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
        if (tagIds != null && tagIds.Count != 0)
        {
            query = query.Where(a => a.Tags.Count(t => tagIds.Contains(t.Id)) == tagIds.Count);
        }

        // Get total count AFTER applying filters but BEFORE cursor
        int totalCount = await query.CountAsync();

        // Apply cursor if provided
        if (cursor.HasValue)
        {
            query = query.Where(a => a.Id < cursor.Value);
        }

        // Fetch one extra item to determine if there are more results
        List<Activity> items = await query
            .OrderByDescending(a => a.Id)
            .Take(limit + 1)
            .ToListAsync();

        bool hasMore = items.Count > limit;
        if (hasMore)
        {
            items = items.Take(limit).ToList();
        }

        int? nextCursor = items.Any() ? items.Last().Id : (int?)null;

        return new ScrollResult<Activity>
        {
            Items = items,
            NextCursor = hasMore ? nextCursor : null,
            HasMore = hasMore,
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
        Activity? existingActivity = await _context.Activities
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
            foreach (Tag tag in activity.Tags)
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
        Activity? activity = await _context.Activities
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
