using System.Security.Claims;

namespace Backend.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal? user)
    {
        if (user == null)
            throw new InvalidOperationException("Authenticated user principal is missing.");

        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim))
            throw new InvalidOperationException("Authenticated user ID claim is missing.");

        if (!int.TryParse(userIdClaim, out var userId))
            throw new InvalidOperationException("Authenticated user ID claim is invalid.");

        return userId;
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
