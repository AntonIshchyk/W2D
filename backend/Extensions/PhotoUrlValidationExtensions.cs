namespace Backend.Extensions;

public static class PhotoUrlValidationExtensions
{
    public static bool TryValidateOptionalPhotoUrl(string? photoUrl, string fieldName, out string? error)
    {
        error = null;

        if (string.IsNullOrWhiteSpace(photoUrl))
        {
            return true;
        }

        string normalizedUrl = photoUrl.Trim();
        if (!IsValidHttpUrl(normalizedUrl))
        {
            error = $"Invalid URL in {fieldName}: {photoUrl}";
            return false;
        }

        return true;
    }

    public static bool TryValidatePhotoUrls(IEnumerable<string>? photoUrls, string fieldName, out string? error)
    {
        error = null;

        if (photoUrls == null)
        {
            return true;
        }

        foreach (string url in photoUrls)
        {
            if (string.IsNullOrWhiteSpace(url) || !IsValidHttpUrl(url.Trim()))
            {
                error = $"Invalid URL in {fieldName}: {url}";
                return false;
            }
        }

        return true;
    }

    private static bool IsValidHttpUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? uri)
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}