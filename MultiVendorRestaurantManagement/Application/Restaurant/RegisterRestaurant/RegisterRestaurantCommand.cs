using System.Collections.Generic;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommand : IRequest<Result>
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public long LocalityId { get; }
        public long CityId { get; }
        public string ImageUrl { get; }
        public int OpeningHour { get; }
        public int ClosingHour { get; }
        public SubscriptionType SubscriptionType { get; }
        public ContractStatus ContractStatus { get; }

        public RegisterRestaurantCommand(string name, string phoneNumber, long localityId, int openingHour, int closingHour,
            string subscriptionType, string contractStatus, string imageUrl, long cityId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            LocalityId = localityId;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            ImageUrl = imageUrl;
            CityId = cityId;
            SubscriptionType = SubscriptionHelper.ConvertToSubscription(subscriptionType);
            ContractStatus = ContractStatusHelper.ConvertToContractStatus(contractStatus);
        }
    }

    public class RegisterRestaurantCommandValidator : AbstractValidator<RegisterRestaurantCommand>
    {
        public RegisterRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
            RuleFor(x => x.LocalityId).NotNull().NotEmpty();
            RuleFor(x => x.CityId).NotNull().NotEmpty();
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            RuleFor(x => x.OpeningHour).NotNull().NotEmpty().Must(Valid24HourFormat);
            RuleFor(x => x.ClosingHour).NotNull().NotEmpty().Must(Valid24HourFormat)
                .NotEqual(x => x.OpeningHour);
            RuleFor(x => x.SubscriptionType)
                .NotEqual(SubscriptionType.Invalid);
            RuleFor(x => x.ContractStatus)
                .NotEqual(ContractStatus.Invalid);
        }

        private static bool Valid24HourFormat(int hour)
        {
            return hour <= 24 && hour >= 0;
        }
    }
}