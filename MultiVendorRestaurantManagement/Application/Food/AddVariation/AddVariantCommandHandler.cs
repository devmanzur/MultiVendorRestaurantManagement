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

namespace MultiVendorRestaurantManagement.Application.Food.AddVariation
{
    public class AddVariantCommandHandler : ICommandHandler<AddVariantCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddVariantCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddVariantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods).ThenInclude(x => x.Variants)
                .FirstOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken: cancellationToken);
            if (restaurant.HasValue() && restaurant.Foods.HasValue())
            {
                var food = restaurant.Foods.FirstOrDefault(x => x.Id == request.FoodId);
                if (food.HasValue())
                {
                    restaurant.AddNewVariantFor(food, new Variant(request.Name, request.NameEng, request.Price));

                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0 ? Result.Ok() : Result.Failure("failed to add variant");
                }

                return Result.Failure("food not found");
            }

            return Result.Failure("restaurant not found");
        }
    }
}