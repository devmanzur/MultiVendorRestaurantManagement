using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.GetFoodDetails
{
    public class GetFoodDetailQueryHandler : IQueryHandler<GetFoodDetailQuery, Result<object>>
    {
        public async Task<Result<object>> Handle(GetFoodDetailQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok("details for this food not available");

        }
    }
}