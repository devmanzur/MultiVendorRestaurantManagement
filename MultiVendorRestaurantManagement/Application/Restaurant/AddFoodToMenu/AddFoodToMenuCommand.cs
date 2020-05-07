using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddFoodToMenu
{
    public class AddFoodToMenuCommand : IRequest<Result>
    {
        public AddFoodToMenuCommand(long restaurantId,  long menuId,long foodId)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            MenuId = menuId;
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public long MenuId { get; private set; }
    }

    public class AddFoodToMenuCommandValidator : AbstractValidator<AddFoodToMenuCommand>
    {
        public AddFoodToMenuCommandValidator()
        {
            RuleFor(x => x.FoodId).NotNull().NotEqual(0);
            RuleFor(x => x.RestaurantId).NotNull().NotEqual(0);
            RuleFor(x => x.MenuId).NotNull().NotEqual(0);
        }
    }
}