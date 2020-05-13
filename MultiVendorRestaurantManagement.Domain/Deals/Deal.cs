using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Promotions;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class Deal : AggregateRoot
    {
        private readonly List<Food> _items = new List<Food>();

        protected Deal()
        {
            
        }
        
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

        public string Name { get; }
        public string Description { get; }
        public string DescriptionEng { get; }
        public string ImageUrl { get; }
        public int MinimumItemQuantity { get; private set; }
        public int MaximumItemQuantity { get; private set; }
        public decimal MinimumBillAmount { get; private set; }
        public decimal MaximumBillAmount { get; } = 99999999;
        public decimal DiscountPercentage { get; private set; }
        public decimal MaximumDiscountAmount { get; private set; }
        public decimal FixedDiscountAmount { get; private set; }
        public bool IsFixedDiscount { get; private set; }
        public bool IsPackageDeal { get; private set; }
        public int PackageSize { get; private set; }
        public int FreeItemQuantityInPackage { get; private set; }
        public IReadOnlyList<Food> Items => _items.ToList();
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public static Deal CreatePercentageDiscountDeal(string name, string description, string descriptionEng,
            string imageUrl,
            DateTime startDate,
            DateTime endDate,
            PercentageDiscountModel model)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetPercentage(model);
            return deal;
        }

        public static Deal CreateFixedDiscountDeal(string name, string description, string descriptionEng,
            string imageUrl,
            DateTime startDate, DateTime endDate, FixedDiscountModel model)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetFixedDeal(model);
            return deal;
        }

        //buy 2 free 1 deals
        public static Deal CreateBuyXGetYDeal(string name, string description, string descriptionEng, string imageUrl,
            DateTime startDate, DateTime endDate,
            PackageDiscountModel model)
        {
            var deal = new Deal(name, description, descriptionEng, imageUrl, startDate, endDate);
            deal.SetPackageDeal(model.PackageSize, model.FreeItemQuantityInPackage);
            return deal;
        }

        private void SetPackageDeal(int buyCount, int freeCount)
        {
            IsPackageDeal = true;
            FreeItemQuantityInPackage = freeCount;
            PackageSize = buyCount;
            //nullify others
            IsFixedDiscount = false;
            FixedDiscountAmount = 0;
            DiscountPercentage = 0;
        }

        private void SetFixedDeal(FixedDiscountModel model)
        {
            IsFixedDiscount = true;
            FixedDiscountAmount = model.DiscountAmount;
            MaximumDiscountAmount = model.DiscountAmount;
            MinimumBillAmount = model.MinBillAmount;
            MinimumItemQuantity = model.MinQuantity;
            MaximumItemQuantity = model.MaxQuantity;
            //nullifyOthers
            DiscountPercentage = 0;
            IsPackageDeal = false;
        }

        private void SetPercentage(PercentageDiscountModel model)
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

        public void AddItem(Food food)
        {
            CheckRule(new ConditionMustBeTrueRule(food.HasValue(), "food is not valid"));
            CheckRule(new ConditionMustBeTrueRule(!_items.Contains(food), "discount already contains the food"));
            _items.Add(food);
            AddDomainEvent(new FoodAddedToDealEvent(Id, food.Id, Description, DescriptionEng, EndDate));
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
                if (totalAmountSpent >= MinimumBillAmount && totalAmountSpent <= MaximumBillAmount)
                    return true;

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