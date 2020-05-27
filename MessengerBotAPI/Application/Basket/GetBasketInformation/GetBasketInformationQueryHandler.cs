using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.Basket.GetBasketInformation
{
    public class GetBasketInformationQueryHandler : IQueryHandler<GetBasketInformationQuery, Result<object>>
    {
        public async Task<Result<object>> Handle(GetBasketInformationQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok("basket info not available");
        }
    }
}