using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours;
using MultiVendorRestaurantManagement.Domain;

namespace MultiVendorRestaurantManagement.Base
{
    public interface ICommandHandler<in T> : IRequestHandler<T, Result> where T : IRequest<Result>
    {
        
    }
}