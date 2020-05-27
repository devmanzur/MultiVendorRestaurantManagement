using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.GetCategoryMenu
{
    public class GetCategoryMenuQueryHandler : IQueryHandler<GetCategoryMenuQuery, Result<object>>
    {
        public async Task<Result<object>> Handle(GetCategoryMenuQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok("menu for this category is not available");

        }
    }
}