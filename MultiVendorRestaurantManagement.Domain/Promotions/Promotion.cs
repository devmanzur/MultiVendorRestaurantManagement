using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Rules;
using Newtonsoft.Json;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class Promotion : AggregateRoot
    {
        private readonly List<CouponCode> _couponCodes = new List<CouponCode>();

        private string _items;

        protected Promotion()
        {
        }

        protected Promotion(string name, string imageUrl, string descriptionEng, string description,
            DateTime startDate, DateTime endDate, string type)
        {
            ImageUrl = imageUrl;
            DescriptionEng = descriptionEng;
            Description = description;
            EndDate = endDate;
            Type = type;
            Name = name;
            StartDate = startDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Type { get; }

        public IReadOnlyList<long> FoodIds
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<List<long>>(_items);
                }
                catch (Exception)
                {
                    return new List<long>();
                }
            }
        }

        public string Description { get; protected set; }
        public string Name { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public string ImageUrl { get; protected set; }
        public IReadOnlyList<CouponCode> CouponCodes => _couponCodes.ToList();

        public decimal FixedDiscountAmount { get; private set; }
        public bool IsFixedDiscount { get; private set; }

        public decimal MinimumBillAmount { get; private set; }
        public int MinimumItemQuantity { get; private set; }
        public int MaximumItemQuantity { get; private set; }

        public decimal DiscountPercentage { get; private set; }
        public decimal MaximumDiscountAmount { get; private set; }

        public static Promotion CreateFixedPriceDiscountPromotion(string name, string imageUrl, string description,
            string descriptionEng, DateTime startDate,
            in DateTime endDate, FixedDiscountModel model)
        {
            var promotion = new Promotion(name, imageUrl, descriptionEng, description, startDate, endDate,
                model.Type.ToString());
            promotion.CreateFixedPriceDiscount(model);
            return promotion;
        }

        public static Promotion CreatePercentageDiscountPromotion(string name, string imageUrl, string descriptionEng,
            string description,
            DateTime startDate, DateTime endDate, PercentageDiscountModel model)
        {
            var promotion = new Promotion(name, imageUrl, descriptionEng, description, startDate, endDate,
                model.Type.ToString());
            promotion.CreatePercentageDiscount(model);
            return promotion;
        }

        private void CreatePercentageDiscount(PercentageDiscountModel model)
        {
            DiscountPercentage = model.DiscountPercentage;
            MinimumBillAmount = model.MinBillAmount;
            MinimumItemQuantity = model.MinQuantity;
            MaximumItemQuantity = model.MaxQuantity;
            MaximumDiscountAmount = model.MaxDiscountAmount;
            //nullify others
            IsFixedDiscount = false;
            FixedDiscountAmount = 0;
        }

        private void CreateFixedPriceDiscount(FixedDiscountModel model)
        {
            IsFixedDiscount = true;
            FixedDiscountAmount = model.DiscountAmount;
            MinimumItemQuantity = model.MinQuantity;
            MaximumItemQuantity = model.MaxQuantity;
            MinimumBillAmount = model.MinBillAmount;
            //nullify others
            DiscountPercentage = 0;
            MaximumDiscountAmount = model.DiscountAmount;
        }

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
                _couponCodes.Add(new CouponCode(codes[i], phoneNumbers[i], authority));
        }

        public void AddFood(long foodId)
        {
            var ids = FoodIds.ToList();

            CheckRule(new ConditionMustBeTrueRule(!ids.Contains(foodId), $"food {foodId} already in promotion"));
            ids.Add(foodId);
            _items = JsonConvert.SerializeObject(ids);
        }

        public Result<decimal> GetDiscountByApplying(string phone, string couponCode, List<OrderItem> items)
        {
            var couponValidation = IsValidCoupon(phone, couponCode);
            if (couponValidation.IsSuccess)
            {
                var discount = CalculateDiscountFor(items);
                return Result.Ok(discount);
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
                if (coupon.Username == phone) return Result.Ok();

                return Result.Failure("you cannot use this coupon");
            }

            return Result.Failure("invalid coupon");
        }

        private bool IsDiscountApplicable(int count, decimal totalAmountSpent)
        {
            if (count == 0) return false;

            if (count >= MinimumItemQuantity && count <= MaximumItemQuantity)
                if (totalAmountSpent >= MinimumBillAmount)
                    return true;

            return false;
        }
    }
}