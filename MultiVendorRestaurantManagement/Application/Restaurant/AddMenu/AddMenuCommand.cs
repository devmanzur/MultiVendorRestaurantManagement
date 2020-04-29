using System.Data;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddMenu
{
    public class AddMenuCommand : IRequest<Result>
    {
        public long RestaurantId { get; private set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public AddMenuCommand(string nameEng, string name, long restaurantId)
        {
            NameEng = nameEng;
            Name = name;
            RestaurantId = restaurantId;
        }
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