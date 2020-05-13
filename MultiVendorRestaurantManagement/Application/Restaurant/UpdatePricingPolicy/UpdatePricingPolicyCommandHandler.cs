using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdatePricingPolicy
{
    public class UpdatePricingPolicyCommandHandler : ICommandHandler<UpdatePricingPolicyCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePricingPolicyCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdatePricingPolicyCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.PricingPolicy).SingleOrDefaultAsync(
                x => x.Id == request.RestaurantId,
                cancellationToken);
            if (request.HasValue())
            {
                restaurant.SetPricingPolicy(new PricingPolicy(request.MinimumCharge, request.MaximumCharge,
                    request.FixedCharge, request.MaxItemCountInFixedPrice, request.AdditionalPricePerUnit));
                var result = await _unitOfWork.CommitAsync(cancellationToken);
                return result > 0 ? Result.Ok() : Result.Failure("failed to update pricing policy");
            }

            return Result.Failure("invalid restaurant");
        }
    }
}