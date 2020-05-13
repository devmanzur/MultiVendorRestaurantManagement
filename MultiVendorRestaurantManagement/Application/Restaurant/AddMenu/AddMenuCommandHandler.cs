using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddMenu
{
    public class AddMenuCommandHandler : ICommandHandler<AddMenuCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddMenuCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Menus).SingleOrDefaultAsync(
                x => x.Id == request.RestaurantId,
                cancellationToken);
            if (restaurant.HasNoValue()) return Result.Failure("invalid restaurant");

            restaurant.AddMenu(new Menu(request.Name, request.NameEng, request.ImageUrl));

            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0
                ? Result.Ok("Restaurant registered successfully")
                : Result.Failure<string>("Failed to register restaurant");
        }
    }
}