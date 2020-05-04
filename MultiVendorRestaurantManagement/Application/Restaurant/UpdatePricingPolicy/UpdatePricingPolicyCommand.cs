using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdatePricingPolicy
{
    public class UpdatePricingPolicyCommand : IRequest<Result>
    {
        public long RestaurantId { get; }
        public decimal MinimumCharge { get; }
        public decimal MaximumCharge { get; }
        public decimal FixedCharge { get; }
        public int MaxItemCountInFixedPrice { get; }
        public decimal AdditionalPricePerUnit { get; }

        public UpdatePricingPolicyCommand(long restaurantId, decimal minimumCharge, decimal maximumCharge,
            decimal fixedCharge, int maxItemCountInFixedPrice, decimal additionalPricePerUnit)
        {
            RestaurantId = restaurantId;
            MinimumCharge = minimumCharge;
            MaximumCharge = maximumCharge;
            FixedCharge = fixedCharge;
            MaxItemCountInFixedPrice = maxItemCountInFixedPrice;
            AdditionalPricePerUnit = additionalPricePerUnit;
        }
    }

    public class UpdatePricingPolicyCommandValidator : AbstractValidator<UpdatePricingPolicyCommand>
    {
        public UpdatePricingPolicyCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty().NotEqual(0);
            RuleFor(x => x.MinimumCharge).NotNull().NotEmpty().Must(HelperFunctions.ValidAmount);
            RuleFor(x => x.MaximumCharge).Must(HelperFunctions.ValidAmount);
            RuleFor(x => x.FixedCharge).Must(HelperFunctions.ValidAmount);
            RuleFor(x => x.AdditionalPricePerUnit).Must(HelperFunctions.ValidAmount);
            RuleFor(x => x.MaxItemCountInFixedPrice).Must(HelperFunctions.ValidCount);
        }
    }
}