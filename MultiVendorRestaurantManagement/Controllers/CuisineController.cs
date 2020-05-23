using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Cuisine;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Categories.RegisterCategory;
using MultiVendorRestaurantManagement.Application.Categories.UpdateCategory;
using MultiVendorRestaurantManagement.Application.Cuisines;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/cuisines")]
    public class CuisineController : BaseController
    {
        public CuisineController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCuisine([FromForm] RegisterCuisineRequest request)
        {
            var command =
                new RegisterCuisineCommand(request.NameEng, request.Name, request.ImageUrl);
            return await HandleActionResultFor(command);
        }
        
    }
}