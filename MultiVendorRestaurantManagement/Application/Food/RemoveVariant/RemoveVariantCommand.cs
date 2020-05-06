using System.Data;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Food.RemoveVariant
{
    public class RemoveVariantCommand : IRequest<Result>
    {
        public RemoveVariantCommand(long restaurantId, long foodId, string variantName)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantName = variantName;
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string VariantName { get; private set; }
    }

    public class RemoveVariantCommandValidator : AbstractValidator<RemoveVariantCommand>
    {
        public RemoveVariantCommandValidator()
        {
            RuleFor(x => x.FoodId).NotNull().NotEmpty();
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
            RuleFor(x => x.VariantName).NotNull().NotEmpty();
        }
    }
    
}