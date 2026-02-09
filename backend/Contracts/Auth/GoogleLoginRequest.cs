using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Auth;

public class GoogleLoginRequest
{
    [Required]
    public string Credential { get; set; } = string.Empty;
}
