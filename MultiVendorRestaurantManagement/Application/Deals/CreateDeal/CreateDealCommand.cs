using System;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Domain.Promotions;

namespace MultiVendorRestaurantManagement.Application.Deals
{
    public class CreateDealCommand : IRequest<Result>
    {
        public CreateDealCommand(string name, string imageUrl, string description, string descriptionEng,
            int minimumQuantity, decimal minimumBillAmount, bool isFixedPriceDiscount,
            in decimal discountAmount, in decimal discountPercentage, in decimal maximumDiscount, DateTime startDate,
            DateTime endDate, int packageSize, int freeItemQuantityInPackage, bool isPackageDeal)
        {
            if (isFixedPriceDiscount && isPackageDeal) throw new ValidationException("deal can be only one type");

            Name = name;
            ImageUrl = imageUrl;
            Description = description;
            DescriptionEng = descriptionEng;
            IsFixedPriceDiscount = isFixedPriceDiscount;
            StartDate = startDate;
            EndDate = endDate;
            IsPackageDeal = isPackageDeal;
            if (isFixedPriceDiscount)
                FixedPriceModel = new FixedDiscountModel(discountAmount, minimumBillAmount, minimumQuantity);
            else if (IsPackageDeal)
                PackageDiscountModel = new PackageDiscountModel(packageSize, freeItemQuantityInPackage);
            else
                PercentageModel = new PercentageDiscountModel(discountPercentage, maximumDiscount, minimumBillAmount,
                    minimumQuantity);
        }

        public string Name { get; }
        public string ImageUrl { get; }
        public string Description { get; }
        public string DescriptionEng { get; }
        public bool IsFixedPriceDiscount { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public PercentageDiscountModel PercentageModel { get; }

        public FixedDiscountModel FixedPriceModel { get; }
        public PackageDiscountModel PackageDiscountModel { get; }

        public bool IsPackageDeal { get; }
    }

    public class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
    {
        public CreateDealCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.DescriptionEng).NotNull().NotEmpty();
            RuleFor(x => x.StartDate).NotNull().NotEmpty();
            RuleFor(x => x.EndDate).NotNull().NotEmpty();
        }
    }
}