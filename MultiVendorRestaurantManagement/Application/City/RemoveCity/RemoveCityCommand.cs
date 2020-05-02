using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.City.RemoveCity
{
    public class RemoveCityCommand : IRequest<Result>
    {
        public long CityId { get; }

        public RemoveCityCommand(long cityId)
        {
            CityId = cityId;
        }
    }

    public class RemoveCityCommandValidator : AbstractValidator<RemoveCityCommand>
    {
        public RemoveCityCommandValidator()
        {
            RuleFor(x => x.CityId).NotNull().NotEmpty();
        }
    }
}