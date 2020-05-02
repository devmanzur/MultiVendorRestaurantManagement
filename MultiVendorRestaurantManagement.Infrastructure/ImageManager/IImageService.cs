using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace MultiVendorRestaurantManagement.Infrastructure.ImageManager
{
    public interface IImageService
    {
        Task<Result<string>> UploadImageAsync(IFormFile image);
    }
}