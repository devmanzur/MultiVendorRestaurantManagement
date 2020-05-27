using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.Order.LastOrderRepeat
{
    public class RepeatLastOrderCommandHandler : IRequestHandler<RepeatLastOrderCommand, Result<object>>
    {
        public async Task<Result<object>> Handle(RepeatLastOrderCommand request, CancellationToken cancellationToken)
        {
            return Result.Ok("failed to repeat last order");

        }
    }
}