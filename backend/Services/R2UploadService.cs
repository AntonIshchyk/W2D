using Amazon.S3;
using Amazon.S3.Model;

namespace Backend.Services;

public interface IR2UploadService
{
    Task<PresignedUploadResult> GetPresignedUploadUrlAsync(string fileName, string contentType);
}

public class PresignedUploadResult
{
    public string UploadUrl { get; set; } = null!;
    public string PublicUrl { get; set; } = null!;
    public string Key { get; set; } = null!;
}

public class R2UploadService : IR2UploadService
{
    private readonly IAmazonS3 _s3;
    private readonly string _bucketName;
    private readonly string _publicUrlBase;

    public R2UploadService(IAmazonS3 s3, IConfiguration config)
    {
        _s3 = s3;
        _bucketName = config["R2:BucketName"]!;
        _publicUrlBase = config["R2:PublicUrlBase"]!.TrimEnd('/');
    }

    public async Task<PresignedUploadResult> GetPresignedUploadUrlAsync(string fileName, string contentType)
    {
        string ext = Path.GetExtension(fileName).ToLowerInvariant();
        string key = $"posts/{Guid.NewGuid()}{ext}";

        var request = new GetPreSignedUrlRequest
        {
            BucketName = _bucketName,
            Key = key,
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.AddMinutes(10),
            ContentType = contentType,
        };

        string uploadUrl = await _s3.GetPreSignedURLAsync(request);

        return new PresignedUploadResult
        {
            UploadUrl = uploadUrl,
            PublicUrl = $"{_publicUrlBase}/{key}",
            Key = key,
        };
    }
}