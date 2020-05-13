using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.City.RegisterCity
{
    public class RegisterCityCommand : IRequest<Result>
    {
        public RegisterCityCommand(string code, string nameEng, string name)
        {
            Code = code;
            NameEng = nameEng;
            Name = name;
        }

        public string Name { get; }
        public string NameEng { get; }
        public string Code { get; }
    }

    public class RegisterCityCommandValidator : AbstractValidator<RegisterCityCommand>
    {
        public RegisterCityCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Code).NotNull().NotEmpty();
        }
    }
}