using MediatR;

namespace Catalogue.Application.Base
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}