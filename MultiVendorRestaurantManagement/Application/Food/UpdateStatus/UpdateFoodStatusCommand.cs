using Common.Invariants;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Food.UpdateStatus
{
    public class UpdateFoodStatusCommand : IRequest<Result>
    {
        private UpdateFoodStatusCommand(long restaurantId, long foodId, FoodStatus status = FoodStatus.Invalid)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            Status = status;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public FoodStatus Status { get; }

        public static UpdateFoodStatusCommand Unavailable(long restaurantId, long foodId)
        {
            return new UpdateFoodStatusCommand(restaurantId, foodId, FoodStatus.Unavailable);
        }

        public static UpdateFoodStatusCommand Available(long restaurantId, long foodId)
        {
            return new UpdateFoodStatusCommand(restaurantId, foodId, FoodStatus.Available);
        }

        public static UpdateFoodStatusCommand OutOfStock(long restaurantId, long foodId)
        {
            return new UpdateFoodStatusCommand(restaurantId, foodId, FoodStatus.OutOfStock);
        }
    }

    public class UpdateFoodStatusCommandValidator : AbstractValidator<UpdateFoodStatusCommand>
    {
        public UpdateFoodStatusCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotNull().NotEqual(0);
            RuleFor(x => x.FoodId).NotNull().NotEqual(0);
            RuleFor(x => x.Status).NotNull().NotEqual(FoodStatus.Invalid);
        }
    }
}