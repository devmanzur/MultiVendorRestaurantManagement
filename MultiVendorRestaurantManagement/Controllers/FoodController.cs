using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Food.AddVariation;
using MultiVendorRestaurantManagement.Application.Food.CreateaAddOn;
using MultiVendorRestaurantManagement.Application.Food.RegisterFood;
using MultiVendorRestaurantManagement.Application.Food.RemoveAddOn;
using MultiVendorRestaurantManagement.Application.Food.RemoveVariant;

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

        [HttpPut("{restaurant}/foods/{food}/variants")]
        public async Task<IActionResult> AddVariant(long restaurant, long food, [FromForm] AddVariantRequest request)
        {
            var command = new AddVariantCommand(restaurant,food,request.Name,request.NameEng,request.Price, request.Description,request.DescriptionEng);
            return await HandleActionResultFor(command);
        }
        
        [HttpDelete("{restaurant}/foods/{food}/variants")]
        public async Task<IActionResult> RemoveVariant(long restaurant, long food, [FromForm] RemoveVariantRequest request)
        {
            var command = new RemoveVariantCommand(restaurant,food,request.VariantName);
            return await HandleActionResultFor(command);
        }
        
        [HttpPut("{restaurant}/foods/{food}/add-ons")]
        public async Task<IActionResult> CreateAddOns(long restaurant, long food, [FromForm] CreateAddOnRequest request)
        {
            var command = new CreateAddOnCommand(restaurant,food,request.Name,request.NameEng, request.Description,request.DescriptionEng,request.Price);
            return await HandleActionResultFor(command);
        }
        
        [HttpDelete("{restaurant}/foods/{food}/add-ons")]
        public async Task<IActionResult> RemoveAddOns(long restaurant, long food, [FromForm] RemoveAddOnRequest request)
        {
            var command = new RemoveAddOnCommand(restaurant,food,request.AddOnName);
            return await HandleActionResultFor(command);
        }
        
        
        
    }
}