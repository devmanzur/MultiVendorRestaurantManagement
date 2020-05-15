using System.Threading.Tasks;
using Catalogue.Base;
using Catalogue.Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        protected const int DefaultPageSize = 20;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> HandleQueryResultFor<T>(IQuery<Result<T>> command)
        {
            var result = await _mediator.Send(command);
            return HandleQueryResponse(result);
        }

        private IActionResult HandleQueryResponse<T>(Result<T> result)
        {
            if (result.IsSuccess) return Ok(Envelope.Ok(result.Value));

            return BadRequest(Envelope.Error(result.Error));
        }
    }
}