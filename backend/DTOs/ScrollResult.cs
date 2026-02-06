namespace Backend.DTOs;

public class ScrollResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int? NextCursor { get; set; }
    public bool HasMore { get; set; }
    public int TotalCount { get; set; }
}
