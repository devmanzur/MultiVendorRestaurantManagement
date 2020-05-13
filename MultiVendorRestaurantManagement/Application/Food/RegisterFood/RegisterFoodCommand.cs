using Common.Invariants;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Application.Food.RegisterFood
{
    public class RegisterFoodCommand : IRequest<Result>
    {
        public RegisterFoodCommand(long restaurantId, string name, string type, long categoryId, string imageUrl,
            bool isVeg,
            bool isGlutenFree, bool isNonVeg, decimal unitPrice)
        {
            RestaurantId = restaurantId;
            Name = name;
            Type = FoodItemTypeHelper.ConvertToFoodItemType(type);
            CategoryId = categoryId;
            ImageUrl = imageUrl;
            IsVeg = isVeg;
            IsGlutenFree = isGlutenFree;
            IsNonVeg = isNonVeg;
            UnitPrice = MoneyValue.Of(unitPrice);
        }

        public long RestaurantId { get; }
        public long CategoryId { get; }
        public string Name { get; }
        public FoodItemType Type { get; }
        public string ImageUrl { get; }
        public bool IsVeg { get; }
        public bool IsGlutenFree { get; }
        public bool IsNonVeg { get; }
        public MoneyValue UnitPrice { get; }
    }

    public class RegisterFoodCommandValidator : AbstractValidator<RegisterFoodCommand>
    {
        public RegisterFoodCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotNull().NotEqual(0);
            RuleFor(x => x.CategoryId).NotNull().NotEqual(0);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.IsNonVeg).NotNull();
            RuleFor(x => x.IsVeg).NotNull();
            RuleFor(x => x.IsGlutenFree).NotNull();
            RuleFor(x => x.UnitPrice).NotNull();
            RuleFor(x => x.Type).NotNull().NotEqual(FoodItemType.Invalid);
        }
    }
}