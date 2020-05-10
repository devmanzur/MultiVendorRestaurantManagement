using System.Collections.Generic;
using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Promotions.AddItems
{
    public class AddPromotionalItemsCommand : IRequest<Result>
    {
        public long PromotionId { get; }
        public List<long> FoodIds { get; }

        public AddPromotionalItemsCommand(long promotionId, List<long> foodIds)
        {
            PromotionId = promotionId;
            FoodIds = foodIds;
        }
    }

    public class AddPromotionalItemsCommandValidator : AbstractValidator<AddPromotionalItemsCommand>
    {
        public AddPromotionalItemsCommandValidator()
        {
            RuleFor(x => x.FoodIds).NotNull().NotEmpty();
            RuleFor(x => x.PromotionId).NotNull().NotEqual(0);
        }
    }
}