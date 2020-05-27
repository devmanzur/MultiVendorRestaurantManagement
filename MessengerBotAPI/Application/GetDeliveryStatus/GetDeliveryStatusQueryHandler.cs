using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.GetDeliveryStatus
{
    public class GetDeliveryStatusQueryHandler : IQueryHandler<GetDeliveryStatusQuery, Result<object>>
    {
        public async Task<Result<object>> Handle(GetDeliveryStatusQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok("delivery status not available");
        }
    }
}