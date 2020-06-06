using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.Order.AddToCart
{
    public class AddFoodToCartCommandHandler : IRequestHandler<AddFoodToCartCommand, Result<object>>
    {
        private AddFoodToCartCommand _request;

        public async Task<Result<object>> Handle(AddFoodToCartCommand request, CancellationToken cancellationToken)
        {
            _request = request;
            return Result.Ok(request.QueryResult.FulfillmentText);
        }
    }
}