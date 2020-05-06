using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.ValueObjects;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Food.RegisterFood
{
    public class RegisterFoodCommandHandler : ICommandHandler<RegisterFoodCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterFoodCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterFoodCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Foods)
                .FirstOrDefaultAsync(x => x.Id == request.RestaurantId, cancellationToken: cancellationToken);
            if (restaurant.HasValue())
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId,
                    cancellationToken: cancellationToken);

                if (category.HasValue())
                {
                    var food = new Domain.Foods.Food(
                        type: request.Type,
                        name: request.Name,
                        unitPrice: request.UnitPrice,
                        isGlutenFree: request.IsGlutenFree,
                        isVeg: request.IsVeg,
                        isNonVeg: request.IsNonVeg,
                        imageUrl: request.ImageUrl
                    );

                    food.SetCategory(category);
                    SetDefaultVariant(food);
                    restaurant.AddFood(food);
                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    
                    
                    return result > 0 ? Result.Ok() : Result.Failure("failed to add food");
                }

                return Result.Failure("invalid category");
            }

            return Result.Failure("restaurant not found");
        }

        private void SetDefaultVariant(Domain.Foods.Food food)
        {
            food.AddVariant(new Variant("Normale", nameEng: "Regular", price: food.UnitPrice) );
        }
    }
}