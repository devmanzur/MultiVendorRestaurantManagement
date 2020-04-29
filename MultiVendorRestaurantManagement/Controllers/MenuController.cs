using System.Threading.Tasks;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.Restaurant.AddMenu;
using MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("restaurants/{restaurantId}/menus")]
        public async Task<IActionResult> RegisterRestaurant(long restaurantId, [FromForm] AddMenuRequest request)
        {
            var command = new AddMenuCommand(request.NameEng, request.Name, restaurantId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }
            return BadRequest(Envelope.Error(result.Error));
        }
    }
}