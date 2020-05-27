using Catalogue.Base;
using MediatR;

namespace MessengerBotAPI.Application.Base
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}