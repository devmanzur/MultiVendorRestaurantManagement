using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Rules;
using Newtonsoft.Json;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class Promotion : AggregateRoot
    {
        protected Promotion(string name, string imageUrl, string descriptionEng, string description,
            DateTime startDate, DateTime endDate)
        {
            ImageUrl = imageUrl;
            DescriptionEng = descriptionEng;
            Description = description;
            EndDate = endDate;
            Name = name;
            StartDate = startDate;
        }

        public static Promotion CreateFixedPriceDiscountPromotion(string name, string imageUrl, string descriptionEng,
            string description,
            DateTime startDate, DateTime endDate, int minimumItemCount, int maxItemCount, decimal minimumBillAmount,
            decimal discountAmount)
        {
            var promotion = new Promotion(name, imageUrl, descriptionEng, description, startDate, endDate);
            promotion.CreateFixedPriceDiscount(minimumBillAmount, minimumItemCount, maxItemCount, discountAmount);
            return promotion;
        }

        public static Promotion CreatePercentageDiscountPromotion(string name, string imageUrl, string descriptionEng,
            string description, int minItemCount, int maxItemCount, decimal minAmount, decimal maxDiscount,
            decimal discountPercent,
            DateTime startDate, DateTime endDate)
        {
            var promotion = new Promotion(name, imageUrl, descriptionEng, description, startDate, endDate);
            promotion.CreatePercentageDiscount(discountPercent, maxDiscount, minAmount, minItemCount, maxItemCount);
            return promotion;
        }

        private void CreatePercentageDiscount(decimal discountPercent, decimal maxDiscount, decimal minAmount,
            int minItemCount, int maxItemCount)
        {
            DiscountPercentage = discountPercent;
            MinimumBillAmount = minAmount;
            MinimumItemQuantity = minItemCount;
            MaximumItemQuantity = maxItemCount;
            MaximumDiscountAmount = maxDiscount;
            //nullify others
            IsFixedDiscount = false;
            FixedDiscountAmount = 0;
        }

        private void CreateFixedPriceDiscount(decimal minimumBillAmount, int minimumItemCount, int maxItemCount,
            decimal discountAmount)
        {
            IsFixedDiscount = true;
            FixedDiscountAmount = discountAmount;
            MinimumItemQuantity = minimumItemCount;
            MaximumItemQuantity = maxItemCount;
            MinimumBillAmount = minimumBillAmount;
            //nullify others
            DiscountPercentage = 0;
            MaximumDiscountAmount = discountAmount;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private string _items;
        public IReadOnlyList<long> FoodIds => JsonConvert.DeserializeObject<List<long>>(_items);
        public string Description { get; protected set; }
        public string Name { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public string ImageUrl { get; protected set; }

        private List<CouponCode> _couponCodes = new List<CouponCode>();
        public IReadOnlyList<CouponCode> CouponCodes => _couponCodes.ToList();

        public decimal FixedDiscountAmount { get; private set; }
        public bool IsFixedDiscount { get; private set; }

        public decimal MinimumBillAmount { get; private set; }
        public int MinimumItemQuantity { get; private set; }
        public int MaximumItemQuantity { get; private set; }

        public decimal DiscountPercentage { get; private set; }
        public decimal MaximumDiscountAmount { get; private set; }


        public override IDomainEvent GetAddedDomainEvent()
        {
            return new PromotionCreatedEvent();
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new PromotionRemovedEvent();
        }

        public void GenerateCouponCodes(string authority, List<string> phoneNumbers, List<string> codes)
        {
            for (var i = 0; i < phoneNumbers.Count; i++)
            {
                _couponCodes.Add(new CouponCode(codes[i], phoneNumbers[i], authority));
            }
        }

        public void AddFood(Food food)
        {
            var ids = FoodIds.ToList();

            CheckRule(new ConditionMustBeTrueRule(!ids.Contains(food.Id), "food already added to promotion"));
            ids.Add(food.Id);
            _items = JsonConvert.SerializeObject(ids);
        }

        public Result<decimal> GetDiscountByApplying(string phone, string couponCode, List<OrderItem> items)
        {
            var couponValidation = IsValidCoupon(phone, couponCode);
            if (couponValidation.IsSuccess)
            {
                var discount = CalculateDiscountFor(items);
                return Result.Ok<decimal>(discount);
            }

            return Result.Failure<decimal>(couponValidation.Error);
        }

        private decimal CalculateDiscountFor(List<OrderItem> items)
        {
            var validItems = FoodIds.ToList();
            decimal totalPrice = 0;
            var totalQuantity = 0;
            
            items.ForEach(x =>
            {
                if (!validItems.Contains(x.FoodId)) return;
                totalQuantity += x.Quantity;
                totalPrice += x.Total;
            });

            if (!IsDiscountApplicable(totalQuantity, totalPrice)) return 0;
            
            if (IsFixedDiscount) return FixedDiscountAmount;
                
            var discount = totalPrice * (DiscountPercentage / (100 + DiscountPercentage));
            return discount > MaximumDiscountAmount ? MaximumDiscountAmount : discount;

        }

        private Result IsValidCoupon(string phone, string couponCode)
        {
            var coupon = CouponCodes.FirstOrDefault(x => x.Code == couponCode);
            if (coupon.HasValue())
            {
                if (coupon.Username == phone)
                {
                    return Result.Ok();
                }

                return Result.Failure("you cannot use this coupon");
            }

            return Result.Failure("invalid coupon");
        }

        private bool IsDiscountApplicable( int count, decimal totalAmountSpent)
        {
            if (count == 0) return false;
        
            if (count >= MinimumItemQuantity && count <= MaximumItemQuantity)
            {
                if (totalAmountSpent >= MinimumBillAmount)
                {
                    return true;
                }
            }
        
            return false;
        }
    }
}