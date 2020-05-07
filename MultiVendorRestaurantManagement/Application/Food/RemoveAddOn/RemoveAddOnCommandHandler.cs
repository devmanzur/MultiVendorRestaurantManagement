using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Food.RemoveAddOn
{
    public class RemoveAddOnCommandHandler : ICommandHandler<RemoveAddOnCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAddOnCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveAddOnCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods)
                .ThenInclude(x => x.AddOns)
                .FirstOrDefaultAsync(cancellationToken);
            if (restaurant.HasValue())
            {
                var food = restaurant.Foods.FirstOrDefault(x => x.Id == request.FoodId);
                if (food.HasValue())
                {
                    var addOn = food.AddOns.FirstOrDefault(x => x.Name == request.AddOnName);
                    if (addOn.HasValue())
                    {
                        restaurant.RemoveAddOnFor(food,addOn);
                        var result = await _unitOfWork.CommitAsync(cancellationToken);
                        return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
                    }
                }
            }

            return Result.Failure("invalid request");
        }
    }
}