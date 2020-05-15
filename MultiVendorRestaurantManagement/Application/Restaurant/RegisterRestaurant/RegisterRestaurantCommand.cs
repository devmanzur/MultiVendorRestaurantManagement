using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommand : IRequest<Result>
    {
        public RegisterRestaurantCommand(string name, string phoneNumber, long localityId, int openingHour,
            int closingHour, string subscriptionType, string contractStatus, string imageUrl, long cityId,
            long categoryId, string address, double lat, double lon, string description, string descriptionEng)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            LocalityId = localityId;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            ImageUrl = imageUrl;
            CityId = cityId;
            CategoryId = categoryId;
            Address = address;
            Lat = lat;
            Lon = lon;
            Description = description;
            DescriptionEng = descriptionEng;
            SubscriptionType = SubscriptionHelper.ConvertToSubscription(subscriptionType);
            ContractStatus = ContractStatusHelper.ConvertToContractStatus(contractStatus);
        }

        public string Description { get; }
        public string DescriptionEng { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public long LocalityId { get; }
        public long CityId { get; }
        public string ImageUrl { get; }
        public int OpeningHour { get; }
        public int ClosingHour { get; }
        public SubscriptionType SubscriptionType { get; }
        public ContractStatus ContractStatus { get; }
        public long CategoryId { get; }
        public string Address { get; }
        public double Lat { get; }
        public double Lon { get; }
    }

    public class RegisterRestaurantCommandValidator : AbstractValidator<RegisterRestaurantCommand>
    {
        public RegisterRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
            RuleFor(x => x.LocalityId).NotNull().NotEmpty();
            RuleFor(x => x.CityId).NotNull().NotEmpty();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.Lat).NotNull().NotEqual(0);
            RuleFor(x => x.Lon).NotNull().NotEqual(0);
            RuleFor(x => x.OpeningHour).NotNull().NotEmpty().Must(HelperFunctions.Valid24HourFormat);
            RuleFor(x => x.ClosingHour).NotNull().NotEmpty().Must(HelperFunctions.Valid24HourFormat)
                .NotEqual(x => x.OpeningHour);
            RuleFor(x => x.SubscriptionType)
                .NotEqual(SubscriptionType.Invalid);
            RuleFor(x => x.ContractStatus)
                .NotEqual(ContractStatus.Invalid);
        }
    }
}