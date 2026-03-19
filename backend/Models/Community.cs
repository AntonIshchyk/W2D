using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Community : BaseModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
