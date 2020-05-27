using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
        {
            return Result.Ok(10);
        }
    }
}