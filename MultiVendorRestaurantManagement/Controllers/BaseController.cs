using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MultiVendorRestaurantManagement.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private IActionResult HandleActionResponse(Result result)
        {
            if (result.IsSuccess) return Ok(Envelope.Ok());

            return BadRequest(Envelope.Error(result.Error));
        }

        protected async Task<IActionResult> HandleActionResultFor(IRequest<Result> command)
        {
            var result = await _mediator.Send(command);
            return HandleActionResponse(result);
        }
    }
}