using System.Security.Claims;

namespace Backend.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal? user)
    {
        if (user == null)
            return null;
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim))
            return null;
        return int.TryParse(userIdClaim, out var userId) ? userId : null;
    }

    public static bool IsAdmin(this ClaimsPrincipal? user)
    {
        if (user == null)
        {
            return false;
        }

        return user.FindFirst(ClaimTypes.Role)?.Value == "Admin";
    }

}
