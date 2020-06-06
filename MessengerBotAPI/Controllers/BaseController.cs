using System.Threading.Tasks;
using Catalogue.Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using MessengerBotAPI.Application.Base;
using Microsoft.AspNetCore.Mvc;

namespace MessengerBotAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private IActionResult HandleActionResponse<T>(Result<T> result)
        {
            if (result.IsSuccess) return Ok(Envelope.Ok());

            return BadRequest(Envelope.Error(result.Error));
        }

        protected async Task<IActionResult> HandleActionResultFor<T>(IRequest<Result<T>> command)
        {
            var result = await _mediator.Send(command);
            return HandleActionResponse(result);
        }
        
        protected async Task<IActionResult> HandleQueryResultFor<T>(IQuery<Result<T>> query)
        {
            var result = await _mediator.Send(query);
            return HandleQueryResponse(result);
        }

        private IActionResult HandleQueryResponse<T>(Result<T> result)
        {
            if (result.IsSuccess) return Ok(Envelope.Ok(result.Value));

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}