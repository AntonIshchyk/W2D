using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Backend.Services;

namespace Backend.Controllers;

public class PresignRequest
{
    public string FileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
}

[ApiController]
[Route("api/[controller]")]
[Authorize]
[EnableRateLimiting("fixed")]
public class UploadsController : ControllerBase
{
    private readonly IR2UploadService _uploadService;

    private static readonly HashSet<string> AllowedTypes = new()
    {
        "image/jpeg", "image/jpg", "image/png", "image/webp", "image/gif"
    };

    public UploadsController(IR2UploadService uploadService)
    {
        _uploadService = uploadService;
    }

    private static bool IsValidFileName(string fileName)
    {
        if (fileName.Contains("..") || fileName.StartsWith("/") || fileName.StartsWith("\\"))
            return false;

        return System.Text.RegularExpressions.Regex.IsMatch(
            fileName, @"^[\w\-\.]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }

    [HttpPost("presign")]
    public async Task<IActionResult> Presign([FromBody] PresignRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FileName) || string.IsNullOrWhiteSpace(request.ContentType))
            return BadRequest(new { message = "FileName and ContentType are required" });

        if (!AllowedTypes.Contains(request.ContentType.ToLower()))
            return BadRequest(new { message = "Only JPEG, PNG, WebP and GIF images are allowed" });

        if (!IsValidFileName(request.FileName))
            return BadRequest(new { message = "Invalid filename format. Only alphanumeric characters, dots, hyphens, and underscores are allowed" });

        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
        string sanitized = $"{userId}/{DateTime.UtcNow:yyyyMMdd_HHmmss}_{System.IO.Path.GetFileName(request.FileName)}";

        var result = await _uploadService.GetPresignedUploadUrlAsync(sanitized, request.ContentType);

        return Ok(new
        {
            uploadUrl = result.UploadUrl,
            publicUrl = result.PublicUrl,
        });
    }
}
