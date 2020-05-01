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
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRestaurant([FromForm] RegisterRestaurantRequest request)
        {
            var command = new RegisterRestaurantCommand(request.Name, request.PhoneNumber, request.LocalityId,
                request.OpeningHour, request.ClosingHour, request.SubscriptionType, request.ContractStatus,
                request.ImageUrl, request.CityId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok(result.Value));
            }

            return BadRequest(Envelope.Error(result.Error));
        }

        [HttpPost("{id}/menus")]
        public async Task<IActionResult> AddMenu(long id, [FromForm] AddMenuRequest request)
        {
            var command = new AddMenuCommand(request.NameEng, request.Name, id);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}