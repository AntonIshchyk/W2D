using System.Security.Claims;

namespace Backend.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal? user)
    {
        if (user == null)
        {
            return null;
        }

        string? userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return null;
        }

        return int.TryParse(userIdClaim, out int userId) ? userId : null;
    }

    public static bool IsAdmin(this ClaimsPrincipal? user)
    {
        if (user == null)
        {
            return false;
        }

        return user.FindFirst(ClaimTypes.Role)?.Value == "Admin";
    }

    public static bool GetHasPassword(this ClaimsPrincipal? user)
    {
        if (user == null)
        {
            return false;
        }

        return user.FindFirst("hasPassword")?.Value == "true";
    }
}
