using CSharpFunctionalExtensions;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateCategory
{
    public class UpdateRestaurantCategoryCommand : IRequest<Result>
    {
        public UpdateRestaurantCategoryCommand(long restaurantId, long categoryId)
        {
            RestaurantId = restaurantId;
            CategoryId = categoryId;
        }

        public long RestaurantId { get; }
        public long CategoryId { get; }
    }
}