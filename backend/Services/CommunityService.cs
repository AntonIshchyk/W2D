using Backend.Contracts.Common;
using Backend.Contracts.Communities;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CommunityService : ICommunityService
{
    private readonly AppDbContext _context;

    public CommunityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CommunityResponse>> GetCommunitiesAsync()
    {
        return await _context.Communities
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CommunityResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            })
            .ToListAsync();
    }

    public async Task<Result<CommunityResponse>> GetCommunityByIdAsync(int id)
    {
        CommunityResponse? community = await _context.Communities
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CommunityResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            })
            .FirstOrDefaultAsync();

        if (community == null)
        {
            return Result<CommunityResponse>.NotFound("Community not found.");
        }

        return Result<CommunityResponse>.Success(community);
    }
}
