using Microsoft.AspNetCore.Http;

namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class ImageUploadRequest
    {
        public IFormFile File { get; set; }
    }
}