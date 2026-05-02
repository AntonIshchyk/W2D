using Backend.Contracts.Places;
using Backend.Contracts.Common;

namespace Backend.Services;

public interface IPlaceService
{
    Task<IEnumerable<PlaceResponse>> GetPlacesAsync(IReadOnlyCollection<int>? communityIds = null, double? minLat = null, double? maxLat = null, double? minLng = null, double? maxLng = null, int? userId = null);
    Task<Result<PlaceResponse>> GetPlaceByIdAsync(int id);
    Task<Result<PlaceResponse>> CreatePlaceAsync(int userId, CreatePlaceRequest request);
    Task<Result<PlaceResponse>> UpdatePlaceAsync(int id, int userId, UpdatePlaceRequest request);
    Task<Result<bool>> DeletePlaceAsync(int id, int userId);
}
