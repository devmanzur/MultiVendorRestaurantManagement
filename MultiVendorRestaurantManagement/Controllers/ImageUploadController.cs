using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.Infrastructure.ImageManager;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("image")]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageUploadController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            var (isSuccess, _, value, error) = await _imageService.UploadImageAsync(image);
            if (isSuccess)
            {
                return Ok(value);
            }

            return BadRequest(error);
        }
    }
}