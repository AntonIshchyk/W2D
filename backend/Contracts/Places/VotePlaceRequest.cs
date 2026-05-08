using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Places;

public class VotePlaceRequest
{
    [Required]
    [Range(-1, 1)]
    public int Value { get; set; }
}