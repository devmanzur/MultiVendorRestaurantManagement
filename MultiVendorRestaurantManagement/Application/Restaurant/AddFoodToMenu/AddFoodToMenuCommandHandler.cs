using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddFoodToMenu
{
    public class AddFoodToMenuCommandHandler : ICommandHandler<AddFoodToMenuCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddFoodToMenuCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddFoodToMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods)
                .Include(x => x.Menus).ThenInclude(x => x.Items).FirstOrDefaultAsync(cancellationToken);
            if (restaurant.HasValue())
            {
                var menu = restaurant.Menus.FirstOrDefault(x => x.Id == request.MenuId);
                if (menu.HasValue())
                {
                    var food = restaurant.Foods.FirstOrDefault(x => x.Id == request.FoodId);
                    if (food.HasValue()) restaurant.AddFoodToMenu(menu, food);

                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
                }
            }

            return Result.Failure("invalid request");
        }
    }
}