using Common.Invariants;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateSubscription
{
    public class UpdateSubscriptionCommand : IRequest<Result>
    {
        public UpdateSubscriptionCommand(long restaurant, string subscription)
        {
            RestaurantId = restaurant;
            SubscriptionType = SubscriptionHelper.ConvertToSubscription(subscription);
        }

        public long RestaurantId { get; }

        public SubscriptionType SubscriptionType { get; }
    }

    public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty().NotEqual(0);
            RuleFor(x => x.SubscriptionType).NotNull().NotEmpty()
                .NotEqual(SubscriptionType.Invalid);
        }
    }
}