using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Food.AddVariation;
using MultiVendorRestaurantManagement.Application.Food.RegisterFood;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class FoodController : BaseController
    {
        public FoodController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{restaurant}/foods")]
        public async Task<IActionResult> RegisterFood(long restaurant, [FromForm] RegisterFoodRequest request)
        {
            var command = new RegisterFoodCommand(restaurant, request.Name, request.Type,
                request.CategoryId, request.ImageUrl, request.IsVeg,
                request.IsGlutenFree, request.IsNonVeg, request.UnitPrice);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/foods/{food}")]
        public async Task<IActionResult> AddVariant(long restaurant, long food, [FromForm] AddVariantRequest request)
        {
            var command = new AddVariantCommand(restaurant,food,request.Name,request.NameEng,request.Price);
            return await HandleActionResultFor(command);
        }
        
    }
}