using Catalogue.Application.Base;
using MediatR;

namespace Catalogue.Base
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}