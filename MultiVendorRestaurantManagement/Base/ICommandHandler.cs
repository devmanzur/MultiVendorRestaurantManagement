using CSharpFunctionalExtensions;
using MediatR;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours;

namespace MultiVendorRestaurantManagement.Base
{
    public interface ICommandHandler<in T>: IRequestHandler<T,Result> where T : IRequest<Result>
    {
        
    }
}