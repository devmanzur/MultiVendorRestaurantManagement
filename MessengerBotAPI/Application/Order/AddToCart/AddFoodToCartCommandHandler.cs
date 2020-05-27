using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.Order.AddToCart
{
    public class AddFoodToCartCommandHandler : IRequestHandler<AddFoodToCartCommand, Result<object>>
    {
        public async Task<Result<object>> Handle(AddFoodToCartCommand request, CancellationToken cancellationToken)
        {
            return Result.Ok("add to cart failed");

        }
    }
}