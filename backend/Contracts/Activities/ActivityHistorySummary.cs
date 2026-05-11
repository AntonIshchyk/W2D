namespace Backend.Contracts.Activities;

public sealed record ActivityHistorySummary(
    List<string> PostsLiked,
    List<string> PostsDisliked,
    List<string> PlacesLiked,
    List<string> PlacesDisliked)
{
    public bool HasAny =>
        PostsLiked.Count > 0 || PostsDisliked.Count > 0 ||
        PlacesLiked.Count > 0 || PlacesDisliked.Count > 0;

    public static ActivityHistorySummary Empty => new([], [], [], []);
}
