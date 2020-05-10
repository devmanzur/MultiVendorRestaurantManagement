using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.PipelineBehaviour
{
    
    public class RequestValidationBehaviour<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            //this is bad code but default asp.net DI doesn't support result from pipeline
            if (failures.Any()) throw new ValidationException(failures);

            return await next();
        }
    }
}