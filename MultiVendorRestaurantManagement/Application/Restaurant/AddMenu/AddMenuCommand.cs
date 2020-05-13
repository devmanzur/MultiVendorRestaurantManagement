using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddMenu
{
    public class AddMenuCommand : IRequest<Result>
    {
        public AddMenuCommand(string nameEng, string name, long restaurantId, string imageUrl)
        {
            NameEng = nameEng;
            Name = name;
            RestaurantId = restaurantId;
            ImageUrl = imageUrl;
        }

        public long RestaurantId { get; }
        public string Name { get; }
        public string NameEng { get; }
        public string ImageUrl { get; }
    }

    public class AddMenuCommandValidator : AbstractValidator<AddMenuCommand>
    {
        public AddMenuCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
        }
    }
}