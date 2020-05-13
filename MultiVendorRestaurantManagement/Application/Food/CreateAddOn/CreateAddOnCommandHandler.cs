using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Food.CreateaAddOn
{
    public class CreateAddOnCommandHandler : ICommandHandler<CreateAddOnCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAddOnCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAddOnCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods).ThenInclude(x => x.AddOns)
                .FirstOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken);
            if (restaurant.HasValue() && restaurant.Foods.HasValue())
            {
                var food = restaurant.Foods.FirstOrDefault(x => x.Id == request.FoodId);
                if (food.HasValue())
                {
                    restaurant.CreateNewAddOnFor(food,
                        new AddOn(request.Name, request.NameEng, request.Description, request.DescriptionEng,
                            request.Price));
                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
                }
            }

            return Result.Failure("invalid request");
        }
    }
}