using MediatR;

namespace Catalogue.Base
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}