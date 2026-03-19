using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Tag : BaseModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;


    public List<Event> Events { get; set; } = new List<Event>();
}
