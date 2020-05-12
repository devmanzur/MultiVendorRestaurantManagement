using System.Threading.Tasks;
using Catalogue.Common.Utility;
using Catalogue.Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> HandleQueryResultFor<T>(IRequest<Result<T>> command)
        {
            var result = await _mediator.Send(command);
            return HandleQueryResponse(result);
        }

        private IActionResult HandleQueryResponse<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(Envelope.Ok(result.Value));
            }

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}