using System;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Promotions;

namespace MultiVendorRestaurantManagement.Application.Promotions.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<Result>
    {
        public string Name { get; }
        public string ImageUrl { get; }
        public string Description { get; }
        public string DescriptionEng { get; }
        public bool IsFixedPriceDiscount { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        
        public PercentagePromotionModel PercentageModel { get;  }

        public FixedPromotionModel FixedPriceModel { get;  }


        public CreatePromotionCommand(string name, string imageUrl, string description, string descriptionEng,
            int minimumQuantity, decimal minimumBillAmount, bool isFixedPriceDiscount,
            in decimal discountAmount, in decimal discountPercentage, in decimal maximumDiscount, DateTime startDate,
            DateTime endDate)
        {
            Name = name;
            ImageUrl = imageUrl;
            Description = description;
            DescriptionEng = descriptionEng;
            IsFixedPriceDiscount = isFixedPriceDiscount;
            StartDate = startDate;
            EndDate = endDate;
            if (isFixedPriceDiscount)
            {
                FixedPriceModel = new FixedPromotionModel(discountAmount, minimumBillAmount, minimumQuantity);
            }
            else
            {
                PercentageModel = new PercentagePromotionModel(discountPercentage, maximumDiscount, minimumBillAmount,
                    minimumQuantity);
            }
        }
    }

    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator()
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