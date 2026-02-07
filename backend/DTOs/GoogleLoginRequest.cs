using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class GoogleLoginRequest
{
    [Required]
    public string Credential { get; set; } = string.Empty;
}
