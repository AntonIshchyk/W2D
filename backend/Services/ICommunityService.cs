using Backend.Contracts.Common;
using Backend.Contracts.Communities;

namespace Backend.Services;

public interface ICommunityService
{
    Task<List<CommunityResponse>> GetCommunitiesAsync();
    Task<Result<CommunityResponse>> GetCommunityByIdAsync(int id);
}
