using System.Threading.Tasks;
using Common.Utils;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Restaurant.AddMenu;
using MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant;

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
                request.ImageUrl, request.CityId);
            return await HandleActionResultFor(command);
        }

        [HttpPost("{id}/menus")]
        public async Task<IActionResult> AddMenu(long id, [FromForm] AddMenuRequest request)
        {
            var command = new AddMenuCommand(request.NameEng, request.Name, id);
            return await HandleActionResultFor(command);
        }
    }
}