namespace Backend.Contracts.Activities;

public class ActivitySuggestionResponse
{
    public string Summary { get; set; } = string.Empty;
    public List<string> Suggestions { get; set; } = new();
    public List<SuggestedPlace> Places { get; set; } = new();
}

public class SuggestedPlace
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? LocationName { get; set; }
}
