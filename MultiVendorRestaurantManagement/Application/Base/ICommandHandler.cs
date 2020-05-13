using CSharpFunctionalExtensions;
using MediatR;

namespace MultiVendorRestaurantManagement.Base
{
    public interface ICommandHandler<in T> : IRequestHandler<T, Result> where T : IRequest<Result>
    {
    }
}