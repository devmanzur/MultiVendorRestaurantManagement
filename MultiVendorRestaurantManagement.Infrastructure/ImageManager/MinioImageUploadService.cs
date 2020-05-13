using System.IO;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;

namespace MultiVendorRestaurantManagement.Infrastructure.ImageManager
{
    public class MinioImageUploadService : IImageService
    {
        private const string ContentType = "image/jpeg";
        private readonly MinioConfiguration _config;


        public MinioImageUploadService(IConfiguration configuration)
        {
            _config = configuration.GetSection("MinioConfiguration").Get<MinioConfiguration>();
        }

        public async Task<Result<string>> UploadImageAsync(IFormFile image)
        {
            var client = new MinioClient(_config.Server, _config.AccessKey, _config.SecretKey);
            var imageId = await Run(client, image, _config.BucketName);
            return imageId.HasValue() ? Result.Ok(imageId) : Result.Failure<string>("failed to upload image");
        }

        private async Task<string> Run(MinioClient client, IFormFile file, string bucket)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            var fileName = HelperFunctions.GenerateReferenceNumber() + extension;

            await SetupBucket(client, bucket);
            var path = await WriteFile(file, fileName);
            await client.PutObjectAsync(bucket, fileName, path, ContentType);
            File.Delete(path);
            return fileName;
        }

        private async Task<string> WriteFile(IFormFile file, string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName).ToLower();
            await using var bits = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(bits);
            bits.Close();
            return path;
        }

        private static async Task SetupBucket(MinioClient client, string bucket)
        {
            var found = await client.BucketExistsAsync(bucket);
            if (!found) await client.MakeBucketAsync(bucket);
        }
    }
}