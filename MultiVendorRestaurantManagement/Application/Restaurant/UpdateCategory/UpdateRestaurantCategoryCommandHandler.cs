using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateCategory
{
    public class UpdateRestaurantCategoryCommandHandler : ICommandHandler<UpdateRestaurantCategoryCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRestaurantCategoryCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateRestaurantCategoryCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Category).FirstOrDefaultAsync(
                x => x.Id == request.RestaurantId,
                cancellationToken: cancellationToken);
            if (restaurant.HasValue())
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId,
                    cancellationToken: cancellationToken);
                if (category.HasValue())
                {
                    restaurant.SetCategory(category);
                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0 ? Result.Ok() : Result.Failure("failed to update category");
                }

                return Result.Failure("category not found");
            }

            return Result.Failure("restaurant not found");
        }
    }
}