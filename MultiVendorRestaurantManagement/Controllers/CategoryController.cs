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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] RegisterCategoryRequest request)
        {
            var command = new RegisterCategoryCommand(request.NameEng, request.Name,request.Categorize,request.ImageUrl);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}