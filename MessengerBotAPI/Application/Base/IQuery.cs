using MediatR;

namespace MessengerBotAPI.Application.Base
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}