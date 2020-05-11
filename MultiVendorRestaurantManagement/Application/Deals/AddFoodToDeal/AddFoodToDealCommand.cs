using System.Collections.Generic;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.ApiContract.Deal;
using MultiVendorRestaurantManagement.Domain.Promotions;

namespace MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal
{
    public class AddFoodToDealCommand : IRequest<Result>
    {
        public AddFoodToDealCommand(long dealId, List<FoodPromotionDto> models)
        {
            DealId = dealId;
            ConvertToModel(models);
        }

        private void ConvertToModel(List<FoodPromotionDto> dtos)
        {
            dtos.ForEach(x => { Models.Add(new FoodPromotionIncludeModel(x.FoodId, x.RestaurantId)); });
        }

        public long DealId { get; }
        public List<FoodPromotionIncludeModel> Models { get; } = new List<FoodPromotionIncludeModel>();
    }

    public class AddFoodToDealCommandValidator : AbstractValidator<AddFoodToDealCommand>
    {
        public AddFoodToDealCommandValidator()
        {
            RuleFor(x => x.Models).NotNull().NotEmpty();
            RuleFor(x => x.DealId).NotNull().NotEqual(0);
        }
    }
}