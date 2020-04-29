using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.City.RegisterLocality
{
    public class RegisterLocalityCommand : IRequest<Result>
    {
        public string Name { get; }
        public string NameEng { get; }
        public int Code { get; }
        public long CityId { get; }

        public RegisterLocalityCommand(string name, string nameEng, int code, long cityId)
        {
            Name = name;
            NameEng = nameEng;
            Code = code;
            CityId = cityId;
        }
    }

    public class RegisterLocalityCommandValidator : AbstractValidator<RegisterLocalityCommand>
    {
        public RegisterLocalityCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NameEng).NotNull().NotEmpty();
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.CityId).NotNull().NotEmpty();
        }
    }
}