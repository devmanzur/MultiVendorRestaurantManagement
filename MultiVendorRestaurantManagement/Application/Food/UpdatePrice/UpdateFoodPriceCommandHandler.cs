using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Food.UpdatePrice
{
    public class UpdateFoodPriceCommandHandler : ICommandHandler<UpdateFoodPriceCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFoodPriceCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateFoodPriceCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods).ThenInclude(x => x.Variants)
                .FirstOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken: cancellationToken);

            if (restaurant.HasValue() || restaurant.Foods.HasValue())
            {
                var food = restaurant.Foods.FirstOrDefault(x => x.Id == request.FoodId);
                if (food.HasValue())
                {
                    restaurant.UpdateVariantPriceFor(food, request.VariantPriceUpdates);
                }

                var result = await _unitOfWork.CommitAsync(cancellationToken);
                return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
            }

            return Result.Failure("invalid request");
        }
    }
}