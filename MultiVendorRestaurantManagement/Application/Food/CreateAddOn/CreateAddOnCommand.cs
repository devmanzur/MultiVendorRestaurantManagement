using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Application.Food.CreateaAddOn
{
    public class CreateAddOnCommand : IRequest<Result>
    {
        public CreateAddOnCommand(long restaurantId, long foodId, string name, string nameEng, string description, string descriptionEng, decimal price)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            Name = name;
            NameEng = nameEng;
            Description = description;
            DescriptionEng = descriptionEng;
            Price = MoneyCustomValue.Of(price);
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
        public string NameEng { get; private set; }
        public MoneyCustomValue Price { get; private set; }
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