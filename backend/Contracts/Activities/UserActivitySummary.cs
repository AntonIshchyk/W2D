namespace Backend.Contracts.Activities;

public class UserActivitySummary
{
    public List<UserActivityItem> PostsCreated { get; set; } = new();
    public List<UserActivityItem> PostsUpvoted { get; set; } = new();
    public List<UserActivityItem> PostsDownvoted { get; set; } = new();

    public List<UserActivityItem> PlacesCreated { get; set; } = new();
    public List<UserActivityItem> PlacesUpvoted { get; set; } = new();
    public List<UserActivityItem> PlacesDownvoted { get; set; } = new();
}

public class UserActivityItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Type { get; set; }
}
