using System.Collections.Generic;
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
using MultiVendorRestaurantManagement.Application.Food.UpdatePrice;
using MultiVendorRestaurantManagement.Application.Food.UpdateStatus;
using MultiVendorRestaurantManagement.Domain.Foods;

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
            var command = new AddVariantCommand(restaurant, food, request.Name, request.NameEng, request.Price,
                request.Description, request.DescriptionEng);
            return await HandleActionResultFor(command);
        }


        [HttpPut("{restaurant}/foods/{food}/variants/price")]
        public async Task<IActionResult> UpdateVariantPrice(long restaurant, long food, UpdateFoodPriceRequest request)
        {
            var updates = new List<VariantPriceUpdateModel>();
            request.VariantPrices.ForEach(x => updates.Add(new VariantPriceUpdateModel(x.VariantName, x.NewPrice)));
            if (updates.Count <= 0) return BadRequest();
            
            var command = new UpdateFoodPriceCommand(restaurant, food, updates);
            return await HandleActionResultFor(command);

        }

        [HttpDelete("{restaurant}/foods/{food}/variants")]
        public async Task<IActionResult> RemoveVariant(long restaurant, long food,
            [FromForm] RemoveVariantRequest request)
        {
            var command = new RemoveVariantCommand(restaurant, food, request.VariantName);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/foods/{food}/add-ons")]
        public async Task<IActionResult> CreateAddOns(long restaurant, long food, [FromForm] CreateAddOnRequest request)
        {
            var command = new CreateAddOnCommand(restaurant, food, request.Name, request.NameEng, request.Description,
                request.DescriptionEng, request.Price);
            return await HandleActionResultFor(command);
        }
        
        
        [HttpPut("{restaurant}/foods/{food}/available")]
        public async Task<IActionResult> MakeFoodAvailable(long restaurant, long food)
        {
            var command = UpdateFoodStatusCommand.Available(restaurant,food);
            return await HandleActionResultFor(command);
        }
        
        
        [HttpPut("{restaurant}/foods/{food}/unavailable")]
        public async Task<IActionResult> MakeFoodUnavailable(long restaurant, long food)
        {
            var command = UpdateFoodStatusCommand.Unavailable(restaurant,food);
            return await HandleActionResultFor(command);
        }
        
        [HttpPut("{restaurant}/foods/{food}/out-of-stock")]
        public async Task<IActionResult> FoodOutOfStock(long restaurant, long food)
        {
            var command = UpdateFoodStatusCommand.OutOfStock(restaurant,food);
            return await HandleActionResultFor(command);
        }

        [HttpDelete("{restaurant}/foods/{food}/add-ons")]
        public async Task<IActionResult> RemoveAddOns(long restaurant, long food, [FromForm] RemoveAddOnRequest request)
        {
            var command = new RemoveAddOnCommand(restaurant, food, request.AddOnName);
            return await HandleActionResultFor(command);
        }
    }
}