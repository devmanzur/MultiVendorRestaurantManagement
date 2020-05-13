using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours
{
    public class UpdateRestaurantHoursCommand : IRequest<Result>
    {
        public UpdateRestaurantHoursCommand(long restaurantId, int openingHour, int closingHour)
        {
            RestaurantId = restaurantId;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
        }

        public long RestaurantId { get; }
        public int OpeningHour { get; }
        public int ClosingHour { get; }
    }

    public class UpdateRestaurantHoursCommandValidator : AbstractValidator<UpdateRestaurantHoursCommand>
    {
        public UpdateRestaurantHoursCommandValidator()
        {
            RuleFor(x => x.OpeningHour).NotNull().NotEmpty().Must(HelperFunctions.Valid24HourFormat);
            RuleFor(x => x.ClosingHour).NotNull().NotEmpty().Must(HelperFunctions.Valid24HourFormat);
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
        }
    }
}