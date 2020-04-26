using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using CrossCutting;
using CrossCutting.Utils;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace MultiVendorRestaurantManagement.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommand : IRequest<Result<string>>
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public string AreaCode { get; }
        public IReadOnlyList<string?> RestaurantCategories { get; }
        public DateTime OpeningHour { get; }
        public DateTime ClosingHour { get; }
        public SubscriptionType SubscriptionType { get; }
        public ContractStatus ContractStatus { get; }

        public RegisterRestaurantCommand(string name, string phoneNumber, string areaCode,
            IReadOnlyList<string> categories, DateTime openingHour, DateTime closingHour,
            string subscriptionType, string contractStatus)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            AreaCode = areaCode;
            RestaurantCategories = (categories != null && categories.Count > 0) ? categories : null;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
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
            RuleFor(x => x.AreaCode).NotNull().NotEmpty();
            RuleFor(x => x.OpeningHour).NotNull().NotEmpty();
            RuleFor(x => x.ClosingHour).NotNull().NotEmpty();
            RuleFor(x => x.SubscriptionType)
                .NotEqual(SubscriptionType.Invalid);
            RuleFor(x => x.ContractStatus)
                .NotEqual(ContractStatus.Invalid);
            RuleFor(x => x.RestaurantCategories).NotNull().NotEmpty()
                .Must(ValidationHelper.ContainValidItem()).WithMessage("Category must be selected");
        }

        
        
    }
}