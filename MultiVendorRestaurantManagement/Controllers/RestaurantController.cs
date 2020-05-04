using System.Threading.Tasks;
using Common.Utils;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Restaurant.AddMenu;
using MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours;

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
            var command = new AddMenuCommand(request.NameEng, request.Name, restaurant);
            return await HandleActionResultFor(command);
        }

        [HttpPut("{restaurant}/hours")]
        public async Task<IActionResult> UpdateHours(long restaurant, [FromForm] UpdateRestaurantHoursRequest request)
        {
            var command = new UpdateRestaurantHoursCommand(restaurant, request.OpeningHour, request.ClosingHour);
            return await HandleActionResultFor(command);
        }
    }
}