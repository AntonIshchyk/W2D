using Backend.Contracts.Activities;
using Backend.Contracts.Common;

namespace Backend.Services;

public interface IActivitySuggestionService
{
    Task<Result<ActivitySuggestionResponse>> GetSuggestionsAsync(int userId, GetActivitySuggestionsRequest request, CancellationToken cancellationToken);
}
