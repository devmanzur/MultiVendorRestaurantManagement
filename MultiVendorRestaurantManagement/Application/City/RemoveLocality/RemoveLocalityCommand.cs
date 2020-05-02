using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.City.RemoveLocality
{
    public class RemoveLocalityCommand : IRequest<Result>
    {
        public long CityId { get; }
        public long LocalityId { get; }

        public RemoveLocalityCommand(long cityId, long localityId)
        {
            CityId = cityId;
            LocalityId = localityId;
        }
    }

    public class RemoveLocalityCommandValidator : AbstractValidator<RemoveLocalityCommand>
    {
        public RemoveLocalityCommandValidator()
        {
            RuleFor(x => x.CityId).NotNull().NotEmpty().NotEqual(0);
            RuleFor(x => x.LocalityId).NotNull().NotEmpty().NotEqual(0);
        }
    }
}