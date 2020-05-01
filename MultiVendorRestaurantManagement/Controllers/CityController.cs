using System.Threading.Tasks;
using Common.Utils;
using CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.City.RegisterCity;
using MultiVendorRestaurantManagement.Application.City.RegisterLocality;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCity([FromForm] RegisterCityRequest request)
        {
            var command = new RegisterCityCommand(request.Code, request.NameEng, request.Name);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }

            return BadRequest(Envelope.Error(result.Error));
        }


        [HttpPost("{city}/localities")]
        public async Task<IActionResult> RegisterLocality(long city, [FromForm] RegisterLocalityRequest request)
        {
            var command = new RegisterLocalityCommand(request.Name, request.NameEng, request.Code, city);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}