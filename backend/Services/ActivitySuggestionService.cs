using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Backend.Contracts.Activities;
using Backend.Contracts.Common;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ActivitySuggestionService : IActivitySuggestionService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IPlaceService _placeService;
    private readonly AppDbContext _dbContext;
    private readonly string _model;
    private const double SearchRadiusKm = 15.0;
    private const double KmPerDegreeLat = 111.0;
    private const int MaxNearbyPlaces = 20;
    private const int MaxSuggestions = 5;
    private const int MaxPlaces = 5;

    public ActivitySuggestionService(
        IHttpClientFactory httpClientFactory,
        IPlaceService placeService,
        AppDbContext dbContext,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _placeService = placeService;
        _dbContext = dbContext;
        _model = configuration["Ollama:Model"] ?? "qwen2.5:7b";
    }

    public async Task<Result<ActivitySuggestionResponse>> GetSuggestionsAsync(
        int userId,
        GetActivitySuggestionsRequest request,
        CancellationToken cancellationToken)
    {
        DateTime sevenDaysAgo = DateTime.UtcNow.AddDays(-7);
        var activitySummary = await GetUserActivitySummaryAsync(userId, sevenDaysAgo, cancellationToken);
        var nearbyPlaces = await GetNearbyPlaceCandidatesAsync(request.Latitude, request.Longitude, cancellationToken);
        string prompt = BuildPrompt(request, activitySummary, nearbyPlaces);

        string? raw = await CallOllamaAsync(prompt, cancellationToken);
        if (raw is null)
        {
            return Result<ActivitySuggestionResponse>.Invalid("Could not reach Ollama. Make sure it is running locally.");
        }

        ActivitySuggestionResponse response = ParseResponse(raw);
        if (response.Suggestions.Count == 0)
        {
            return Result<ActivitySuggestionResponse>.Invalid("No activity suggestions were generated.");
        }

        response.Places = MatchPlacesToSuggestions(response.Suggestions, nearbyPlaces);

        return Result<ActivitySuggestionResponse>.Success(response);
    }

    private async Task<string?> CallOllamaAsync(string prompt, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ollama");
            var response = await client.PostAsJsonAsync(
                "api/generate",
                new OllamaGenerateRequest
                {
                    Model = _model,
                    Prompt = prompt,
                    Stream = false,
                },
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<OllamaGenerateResponse>(cancellationToken);
            return string.IsNullOrWhiteSpace(result?.Response) ? null : result.Response;
        }
        catch
        {
            return null;
        }
    }

    private async Task<List<NearbyPlaceCandidate>> GetNearbyPlaceCandidatesAsync(
        double latitude,
        double longitude,
        CancellationToken cancellationToken)
    {
        double latOffset = SearchRadiusKm / KmPerDegreeLat;
        double lngOffset = SearchRadiusKm / (KmPerDegreeLat * Math.Cos(latitude * Math.PI / 180));

        try
        {
            var nearbyPlaces = await _placeService.GetPlacesAsync(
                minLat: latitude - latOffset,
                maxLat: latitude + latOffset,
                minLng: longitude - lngOffset,
                maxLng: longitude + lngOffset);

            return nearbyPlaces
                .OrderByDescending(p => p.Score)
                .Take(MaxNearbyPlaces)
                .Select(p => new NearbyPlaceCandidate
                {
                    Id = p.Id,
                    Title = p.Title,
                    CommunityName = p.CommunityName,
                    Description = p.Description,
                    Score = p.Score,
                    LocationName = p.LocationName,
                })
                .ToList();
        }
        catch
        {
            return new List<NearbyPlaceCandidate>();
        }
    }

    private async Task<ActivityHistorySummary> GetUserActivitySummaryAsync(int userId, DateTime sevenDaysAgo, CancellationToken cancellationToken)
    {
        async Task<List<string>> PostTitles(bool upvoted)
        {
            return await _dbContext.PostVotes
                .Where(v => v.UserId == userId && v.CreatedAt >= sevenDaysAgo && (upvoted ? v.Value > 0 : v.Value < 0))
                .Include(v => v.Post)
                .OrderByDescending(v => v.CreatedAt)
                .Take(5)
                .Select(v => v.Post.Title)
                .ToListAsync(cancellationToken);
        }

        async Task<List<string>> PlaceTitles(bool upvoted)
        {
            return await _dbContext.PlaceVotes
                .Where(v => v.UserId == userId && v.CreatedAt >= sevenDaysAgo && (upvoted ? v.Value > 0 : v.Value < 0))
                .Include(v => v.Place)
                .OrderByDescending(v => v.CreatedAt)
                .Take(5)
                .Select(v => v.Place.Title)
                .ToListAsync(cancellationToken);
        }

        try
        {
            return new ActivityHistorySummary(
                PostsLiked: await PostTitles(upvoted: true),
                PostsDisliked: await PostTitles(upvoted: false),
                PlacesLiked: await PlaceTitles(upvoted: true),
                PlacesDisliked: await PlaceTitles(upvoted: false));
        }
        catch
        {
            return ActivityHistorySummary.Empty;
        }
    }

    private static string BuildPrompt(
        GetActivitySuggestionsRequest request,
        ActivityHistorySummary history,
        IReadOnlyCollection<NearbyPlaceCandidate> places)
    {
        string location = string.IsNullOrWhiteSpace(request.LocationName)
            ? $"{request.Latitude:F4}, {request.Longitude:F4}"
            : request.LocationName.Trim();

        var sb = new StringBuilder();
        sb.AppendLine("You are an activity recommendation assistant.");
        sb.AppendLine("Return ONLY a JSON object with this exact schema, no extra text:");
        sb.AppendLine("{\"summary\": string, \"suggestions\": string[]}");
        sb.AppendLine();
        sb.AppendLine("Rules:");
        sb.AppendLine($"- suggestions must have exactly {MaxSuggestions} short, practical activity ideas.");
        sb.AppendLine("- each suggestion must be under 120 characters.");
        sb.AppendLine("- tone: warm, positive, specific to the user's mood and company.");
        sb.AppendLine("- if the user has disliked something, avoid similar ideas.");
        sb.AppendLine();
        sb.AppendLine("User:");
        sb.AppendLine($"- going with: {request.Social}");
        sb.AppendLine($"- mood: {request.Mood}");
        sb.AppendLine($"- location: {location}");

        if (!string.IsNullOrWhiteSpace(request.ExtraNotes))
        {
            sb.AppendLine($"- notes: {request.ExtraNotes.Trim()}");
        }

        if (history.HasAny)
        {
            sb.AppendLine();
            sb.AppendLine("Recent activity:");
            if (history.PostsLiked.Count > 0)
            {
                sb.AppendLine($"- liked posts: {string.Join(", ", history.PostsLiked)}");
            }
            if (history.PlacesLiked.Count > 0)
            {
                sb.AppendLine($"- liked places: {string.Join(", ", history.PlacesLiked)}");
            }
            if (history.PostsDisliked.Count > 0)
            {
                sb.AppendLine($"- disliked posts: {string.Join(", ", history.PostsDisliked)}");
            }
            if (history.PlacesDisliked.Count > 0)
            {
                sb.AppendLine($"- disliked places: {string.Join(", ", history.PlacesDisliked)}");
            }
        }

        if (places.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("Nearby places (for context only — do NOT reference IDs):");
            foreach (var place in places)
            {
                string description = place.Description.Trim();
                if (description.Length > 100)
                {
                    description = description[..100].TrimEnd();
                }

                sb.AppendLine($"- {place.Title}: {description}");
            }
        }

        return sb.ToString();
    }

    private static ActivitySuggestionResponse ParseResponse(string raw)
    {
        var json = ExtractJson(raw.Trim());

        if (json is not null)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var summary = root.TryGetProperty("summary", out var s)
                    ? s.GetString()?.Trim() ?? string.Empty
                    : string.Empty;

                var suggestions = root.TryGetProperty("suggestions", out var arr)
                    && arr.ValueKind == JsonValueKind.Array
                    ? arr.EnumerateArray()
                        .Select(e => e.GetString()?.Trim())
                        .Where(v => !string.IsNullOrWhiteSpace(v))
                        .Select(v => v!)
                        .Take(MaxSuggestions)
                        .ToList()
                    : [];

                if (suggestions.Count > 0)
                {
                    return new ActivitySuggestionResponse
                    {
                        Summary = string.IsNullOrWhiteSpace(summary) ? "Here are some activity ideas based on your preferences." : summary,
                        Suggestions = suggestions,
                    };
                }
            }
            catch
            {
            }
        }

        var lines = raw
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(l => l.Trim().TrimStart('-', '*', '•').Trim())
            .Select(l => System.Text.RegularExpressions.Regex.Replace(l, @"^\d+[\.\)]\s*", ""))
            .Where(l => l.Length > 10)
            .Distinct()
            .Take(MaxSuggestions)
            .ToList();

        return new ActivitySuggestionResponse
        {
            Summary = "Here are some activity ideas based on your preferences.",
            Suggestions = lines,
        };
    }

    private static List<SuggestedPlace> MatchPlacesToSuggestions(
        IReadOnlyCollection<string> suggestions,
        IReadOnlyCollection<NearbyPlaceCandidate> places)
    {
        if (places.Count == 0 || suggestions.Count == 0)
        {
            return [];
        }

        var suggestionText = string.Join(" ", suggestions).ToLowerInvariant();

        return places
            .Select(p => new
            {
                Place = p,
                Score = ScoreMatch(p, suggestionText),
            })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Take(MaxPlaces)
            .Select(x => new SuggestedPlace
            {
                Id = x.Place.Id,
                Title = x.Place.Title,
                LocationName = x.Place.LocationName,
            })
            .ToList();
    }

    private static int ScoreMatch(NearbyPlaceCandidate place, string suggestionText)
    {
        var words = (place.Title + " " + place.Description + " " + (place.CommunityName ?? string.Empty))
            .ToLowerInvariant()
            .Split([' ', ',', '.', '-', '/', '(', ')'], StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.Length >= 3)
            .Distinct()
            .ToList();

        return words.Count(w => suggestionText.Contains(w));
    }

    private static string? ExtractJson(string text)
    {
        if (text.StartsWith("```"))
        {
            int firstNewLine = text.IndexOf('\n');
            int lastFence = text.LastIndexOf("```");
            if (firstNewLine >= 0 && lastFence > firstNewLine)
            {
                text = text.Substring(firstNewLine + 1, lastFence - firstNewLine - 1).Trim();
            }
        }

        int start = text.IndexOf('{');
        int end = text.LastIndexOf('}');

        if (start >= 0 && end > start)
        {
            return text.Substring(start, end - start + 1);
        }

        return string.Empty;
    }
}
