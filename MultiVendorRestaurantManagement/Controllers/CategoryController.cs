using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Categories.RegisterCategory;

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
    }
}