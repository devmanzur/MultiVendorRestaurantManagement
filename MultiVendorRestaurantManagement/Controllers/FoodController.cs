using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Food.RegisterFood;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/foods")]
    public class FoodController : BaseController
    {
        public FoodController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{restaurant}")]
        public async Task<IActionResult> RegisterFood(long restaurant, [FromForm] RegisterFoodRequest request)
        {
            var command = new RegisterFoodCommand(restaurant, request.Name, request.Type,
                request.CategoryId, request.ImageUrl, request.IsVeg,
                request.IsGlutenFree, request.IsNonVeg, request.UnitPrice);
            return await HandleActionResultFor(command);
        }
    }
}