using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Categories.RegisterCategory;
using MultiVendorRestaurantManagement.Application.Categories.UpdateCategory;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] RegisterCategoryRequest request)
        {
            var command =
                new RegisterCategoryCommand(request.NameEng, request.Name, request.Categorize, request.ImageUrl);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{category}")]
        public async Task<IActionResult> UpdateCategory(long category, [FromForm] UpdateCategoryRequest request)
        {
            var command =
                new UpdateCategoryCommand(request.Name, request.NameEng, category, request.ImageUrl);
            return await HandleActionResultFor(command);
        }
    }
}