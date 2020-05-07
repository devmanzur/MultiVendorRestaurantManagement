using System.Threading.Tasks;
using Common.Utils;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Restaurant.AddFoodToMenu;
using MultiVendorRestaurantManagement.Application.Restaurant.AddMenu;
using MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateCategory;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdatePricingPolicy;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateSubscription;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : BaseController
    {
        public RestaurantController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRestaurant([FromForm] RegisterRestaurantRequest request)
        {
            var command = new RegisterRestaurantCommand(request.Name, request.PhoneNumber, request.LocalityId,
                request.OpeningHour, request.ClosingHour, request.SubscriptionType, request.ContractStatus,
                request.ImageUrl, request.CityId, request.CategoryId);
            return await HandleActionResultFor(command);
        }

        [HttpPost("{restaurant}/menus")]
        public async Task<IActionResult> AddMenu(long restaurant, [FromForm] AddMenuRequest request)
        {
            var command = new AddMenuCommand(request.NameEng, request.Name, restaurant, request.ImageUrl);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/hours")]
        public async Task<IActionResult> UpdateHours(long restaurant, [FromForm] UpdateRestaurantHoursRequest request)
        {
            var command = new UpdateRestaurantHoursCommand(restaurant, request.OpeningHour, request.ClosingHour);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/subscription")]
        public async Task<IActionResult> UpdateSubscription(long restaurant,
            [FromForm] UpdateSubscriptionRequest request)
        {
            var command = new UpdateSubscriptionCommand(restaurant, request.Subscription);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/pricing")]
        public async Task<IActionResult> UpdatePricingPolicy(long restaurant,
            [FromForm] UpdatePricingPolicyRequest request)
        {
            var command = new UpdatePricingPolicyCommand(restaurant, request.MinimumCharge, request.MaximumCharge,
                request.FixedCharge, request.MaxItemCountInFixedPrice, request.AdditionalPricePerUnit);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/category")]
        public async Task<IActionResult> UpdateCategory(long restaurant,
            [FromForm] UpdateRestaurantCategoryRequest request)
        {
            var command = new UpdateRestaurantCategoryCommand(restaurant, request.CategoryId);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/menus/{menu}/foods")]
        public async Task<IActionResult> AddFoodToMenu(long restaurant, long menu,
            [FromForm] AddFoodToMenuRequest request)
        {
            var command = new AddFoodToMenuCommand(restaurant, menu, request.FoodId);
            return await HandleActionResultFor(command);
        }
    }
}