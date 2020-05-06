﻿using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Application.Food.AddVariation
{
    public class AddVariantCommand : IRequest<Result>
    {
        public AddVariantCommand(long restaurantId, long foodId, string name, string nameEng, decimal price)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            Name = name;
            NameEng = nameEng;
            Price = MoneyValue.Of(price);
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public MoneyValue Price { get; private set; }
    }

    public class AddVariationCommandValidator : AbstractValidator<AddVariantCommand>
    {
        public AddVariationCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
            RuleFor(x => x.FoodId).NotNull().NotEmpty();
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            
        }
    }
}