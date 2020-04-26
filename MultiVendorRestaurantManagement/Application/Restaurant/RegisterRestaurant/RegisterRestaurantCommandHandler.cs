using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MultiVendorRestaurantManagement.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand,Result<string>>
    {
        public async Task<Result<string>> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            return Result.Success("successfully created");
        }
    }
}