using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Food.UpdateStatus
{
    public class UpdateFoodStatusCommandHandler : ICommandHandler<UpdateFoodStatusCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFoodStatusCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateFoodStatusCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants
                .Include(x => x.Foods)
                .FirstOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken);

            if (restaurant.HasValue() && restaurant.Foods.Any())
            {
                var food = restaurant.Foods.FirstOrDefault(f => f.Id == request.FoodId);
                if (food.HasValue())
                {
                    restaurant.UpdateStatusFor(food, request.Status);
                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
                }
            }

            return Result.Failure("invalid request");
        }
    }
}