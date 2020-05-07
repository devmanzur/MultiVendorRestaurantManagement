using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Food.RemoveAddOn
{
    public class RemoveAddOnCommand : IRequest<Result>
    {
        public RemoveAddOnCommand(long restaurantId, long foodId, string addOnName)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            AddOnName = addOnName;
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string AddOnName { get; private set; }
    }

    public class RemoveAddOnCommandValidator : AbstractValidator<RemoveAddOnCommand>
    {
        public RemoveAddOnCommandValidator()
        {
            RuleFor(x => x.FoodId).NotNull().NotEmpty();
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
            RuleFor(x => x.AddOnName).NotNull().NotEmpty();
        }
    }
}