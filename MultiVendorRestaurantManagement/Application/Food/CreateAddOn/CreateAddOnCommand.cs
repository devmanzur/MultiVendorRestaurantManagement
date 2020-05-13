using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Application.Food.CreateaAddOn
{
    public class CreateAddOnCommand : IRequest<Result>
    {
        public CreateAddOnCommand(long restaurantId, long foodId, string name, string nameEng, string description,
            string descriptionEng, decimal price)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            Name = name;
            NameEng = nameEng;
            Description = description;
            DescriptionEng = descriptionEng;
            Price = MoneyValue.Of(price);
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public string Name { get; }
        public string Description { get; }
        public string DescriptionEng { get; }
        public string NameEng { get; }
        public MoneyValue Price { get; }
    }

    public class CreateAddOnCommandValidator : AbstractValidator<CreateAddOnCommand>
    {
        public CreateAddOnCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
            RuleFor(x => x.FoodId).NotNull().NotEmpty();
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}