using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Categories.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Result>
    {
        public UpdateCategoryCommand(string name, string nameEng, long id, string imageUrl)
        {
            Name = name;
            NameEng = nameEng;
            Id = id;
            ImageUrl = imageUrl;
        }

        public string Name { get; }
        public string NameEng { get; }
        public long Id { get; }
        public string ImageUrl { get; }
    }

    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}