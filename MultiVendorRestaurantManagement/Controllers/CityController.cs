using System.Threading.Tasks;
using Common.Utils;
using CrossCutting.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Request;
using MultiVendorRestaurantManagement.Application.City.AddLocality;
using MultiVendorRestaurantManagement.Application.City.RegisterCity;
using MultiVendorRestaurantManagement.Application.City.RegisterLocality;
using MultiVendorRestaurantManagement.Application.City.RemoveCity;
using MultiVendorRestaurantManagement.Application.City.RemoveLocality;
using MultiVendorRestaurantManagement.Infrastructure.ImageManager;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : BaseController
    {
        public CityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCity([FromForm] RegisterCityRequest request)
        {
            var command = new RegisterCityCommand(request.Code, request.NameEng, request.Name);
            return await HandleActionResultFor(command);
        }

        [HttpDelete("{city}")]
        public async Task<IActionResult> RemoveCity(long city)
        {
            var command = new RemoveCityCommand(city);
            return await HandleActionResultFor(command);
        }

        [HttpPost("{city}/localities")]
        public async Task<IActionResult> RegisterLocality(long city, [FromForm] RegisterLocalityRequest request)
        {
            var command = new AddLocalityCommand(request.Name, request.NameEng, request.Code, city);
            return await HandleActionResultFor(command);
        }

        [HttpDelete("{city}/localities/{locality}")]
        public async Task<IActionResult> RemoveLocality(long city, long locality)
        {
            var command = new RemoveLocalityCommand(city, locality);
            return await HandleActionResultFor(command);
        }
    }
}