using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using MultiVendorRestaurantManagement.Restaurant.RegisterRestaurant;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand,Result<string>>
    {
        public async Task<Result<string>> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            return Result.Success("successfully created");
        }
    }
}