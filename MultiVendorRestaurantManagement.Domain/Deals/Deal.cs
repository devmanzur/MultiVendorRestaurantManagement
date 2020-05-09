using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class Deal : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
        public string ImageUrl { get; private set; }
        public int MinimumItemQuantity { get; private set; }
        public int MaximumItemQuantity { get; private set; }
        public decimal MinimumBillAmount { get; private set; }
        public decimal MaximumBillAmount { get; private set; } = 99999999;
        public decimal DiscountPercentage { get; private set; }
        public decimal MaximumDiscountAmount { get; private set; }
        public decimal FixedDiscountAmount { get; private set; }
        public bool IsFixedDiscount { get; private set; }
        public bool IsPackageDeal { get; private set; }
        public int PackageSize { get; private set; }
        public int FreeItemQuantityInPackage { get; private set; }

        private List<Food> _items = new List<Food>();
        public IReadOnlyList<Food> Items => _items.ToList();
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        protected Deal(string name, string description, string descriptionEng, string imageUrl, DateTime startDate,
            DateTime endDate)
        {
            Name = name;
            Description = description;
            DescriptionEng = descriptionEng;
            ImageUrl = imageUrl;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static Deal CreatePercentageDiscountDeal(string name, string description, string descriptionEng,
            string imageUrl,
            decimal discountPercent, int minCount, int maxCount, decimal minAmount, decimal maxDiscount,
            DateTime startDate,
            DateTime endDate)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetPercentage(discountPercent, minAmount, minCount, maxCount, maxDiscount);
            return deal;
        }

        public static Deal CreateFixedDiscountDeal(string name, string description, string descriptionEng,
            string imageUrl,
            decimal discount, int minCount, int maxCount, decimal minBill, DateTime startDate, DateTime endDate)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetFixedDeal(minCount, maxCount, minBill, discount);
            return deal;
        }

        //buy 2 get 1 deals
        public static Deal CreateBuyXGetYDeal(string name, string description, string descriptionEng, string imageUrl,
            int packageSize, int freeItemCount, DateTime startDate, DateTime endDate)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetPackageDeal(packageSize, freeItemCount);
            return deal;
        }

        private void SetPackageDeal(int packageSize, int freeItemCount)
        {
            IsPackageDeal = true;
            FreeItemQuantityInPackage = freeItemCount;
            PackageSize = packageSize;
            //nullify others
            IsFixedDiscount = false;
            FixedDiscountAmount = 0;
            DiscountPercentage = 0;
        }

        private void SetFixedDeal(int minCount, int maxCount, decimal minAmount, decimal amount)
        {
            IsFixedDiscount = true;
            FixedDiscountAmount = amount;
            MaximumDiscountAmount = amount;
            MinimumBillAmount = minAmount;
            MinimumItemQuantity = minCount;
            MaximumItemQuantity = maxCount;
            //nullifyOthers
            DiscountPercentage = 0;
            IsPackageDeal = false;
        }

        private void SetPercentage(decimal discountPercent, decimal minAmount, int minCount, int maxCount,
            decimal maxDiscount)
        {
            DiscountPercentage = discountPercent;
            MinimumBillAmount = minAmount;
            MinimumItemQuantity = minCount;
            MaximumItemQuantity = maxCount;
            MaximumDiscountAmount = maxDiscount;
            //nullify others
            IsFixedDiscount = false;
            FixedDiscountAmount = 0;
        }

        public void AddItem(Food food)
        {
            CheckRule(new ConditionMustBeTrueRule(food.HasValue(), "food is not valid"));
            CheckRule(new ConditionMustBeTrueRule(!_items.Contains(food), "discount already contains the food"));
            _items.Add(food);
        }

        public override IDomainEvent GetAddedDomainEvent()
        {
            return new DealCreatedEvent(Name);
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new DealDeletedEvent(Id);
        }

        private bool IsDiscountApplicable(Food item, int count, decimal totalAmountSpent)
        {
            if (count == 0) return false;
            if (!_items.Contains(item)) return false;

            if (count >= MinimumItemQuantity && count <= MaximumItemQuantity)
            {
                if (totalAmountSpent >= MinimumBillAmount && totalAmountSpent <= MaximumBillAmount)
                {
                    return true;
                }
            }

            return false;
        }

        public decimal GetDiscountAmountFor(Food item, int count, decimal totalAmountSpent)
        {
            return IsPackageDeal
                ? CalculatePackageDealPrice(item, count, totalAmountSpent)
                : CalculateNormalDealPrice(item, count, totalAmountSpent);
        }

        private decimal CalculatePackageDealPrice(Food item, int count, decimal totalAmountSpent)
        {
            if (count < PackageSize) return 0;

            if (!IsDiscountApplicable(item, count, totalAmountSpent)) return 0;

            var packagesBought = count / PackageSize;
            var unitPrice = item.UnitPrice.Value;
            return unitPrice * packagesBought * FreeItemQuantityInPackage;
        }

        private decimal CalculateNormalDealPrice(Food item, int count, decimal totalAmountSpent)
        {
            if (count == 0) return 0;

            if (!IsDiscountApplicable(item, count, totalAmountSpent)) return 0;

            if (IsFixedDiscount) return FixedDiscountAmount;

            var totalPrice = item.UnitPrice.Value * count;
            var discount = totalPrice * (DiscountPercentage / (100 + DiscountPercentage));

            return discount > MaximumDiscountAmount ? MaximumDiscountAmount : discount;
        }
    }
}