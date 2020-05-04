using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateSubscription
{
    public class UpdateSubscriptionCommandHandler : ICommandHandler<UpdateSubscriptionCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSubscriptionCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var restaurant =
                await _context.Restaurants.SingleOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken);
            if (restaurant.HasValue())
            {
                restaurant.UpdateSubscription(request.SubscriptionType);
                var result = await _unitOfWork.CommitAsync(cancellationToken);
                return result > 0 ? Result.Ok() : Result.Failure("Failed to update subscription");
            }
            return Result.Failure("invalid restaurant");
        }
    }
}