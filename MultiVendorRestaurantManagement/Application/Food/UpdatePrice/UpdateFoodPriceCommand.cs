using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Application.Food.UpdatePrice
{
    public class UpdateFoodPriceCommand : IRequest<Result>
    {
        public UpdateFoodPriceCommand(long restaurantId, long foodId, List<VariantPriceUpdateModel> variantPriceUpdates)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantPriceUpdates = variantPriceUpdates;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public List<VariantPriceUpdateModel> VariantPriceUpdates { get; set; }
    }

    public class UpdateFoodPriceCommandValidator : AbstractValidator<UpdateFoodPriceCommand>
    {
        public UpdateFoodPriceCommandValidator()
        {
            RuleFor(x => x.VariantPriceUpdates.FirstOrDefault().HasValue());
        }
    }
}