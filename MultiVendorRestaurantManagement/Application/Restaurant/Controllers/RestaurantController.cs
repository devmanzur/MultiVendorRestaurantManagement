using System.Threading.Tasks;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.Dto.Request;
using MultiVendorRestaurantManagement.Restaurant.RegisterRestaurant;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("restaurants")]
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
            var command = new RegisterRestaurantCommand(request.Name, request.PhoneNumber, request.AreaCode,
                request.RestaurantCategories,
                request.OpeningHour, request.ClosingHour, request.SubscriptionType, request.ContractStatus);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok(result.Value));
            }

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}