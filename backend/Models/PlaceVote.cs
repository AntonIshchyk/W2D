using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class PlaceVote : BaseModel
{
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public int PlaceId { get; set; }
    public Place Place { get; set; } = null!;

    [Required]
    public int Value { get; set; }
}