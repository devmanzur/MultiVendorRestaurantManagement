using Common.Invariants;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Categories.RegisterCategory
{
    public class RegisterCategoryCommand : IRequest<Result>
    {
        public string NameEng { get; }
        public string Name { get; }
        public string ImageUrl { get; }
        public Categorize Categorize { get; private set; }

        public RegisterCategoryCommand(string nameEng, string name, string categorize, string imageUrl)
        {
            NameEng = nameEng;
            Name = name;
            ImageUrl = imageUrl;
            Categorize = CategorizeHelper.ConvertToCategorize(categorize);
        }
    }

    public class RegisterCategoryCommandValidator : AbstractValidator<RegisterCategoryCommand>
    {
        public RegisterCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            RuleFor(x => x.Categorize).NotNull().NotEmpty()
                .NotEqual(Categorize.Invalid);
        }
    }
}