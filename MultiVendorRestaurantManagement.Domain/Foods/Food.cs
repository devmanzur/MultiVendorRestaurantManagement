using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Food : Entity
    {
        public Restaurant Restaurant { get; protected set; }
        public string Name { get; protected set; }
        public MoneyValue UnitPrice { get; protected set; }
        public MoneyValue OldUnitPrice { get; protected set; }
        public FoodItemType Type { get; protected set; }

        //adds an extra tag to the list of tags when set true
        public bool IsGlutenFree { get; protected set; }

        //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; protected set; }

        //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; protected set; }

        public FoodStatus Status { get; protected set; }

        //default, single, double, large, extra-large
        private List<Variant> _variants = new List<Variant>();
        public IReadOnlyList<Variant> Variants => _variants.ToList();

        private List<FoodTag> _tags = new List<FoodTag>();
        public List<FoodTag> Tags => _tags.ToList();

        private List<AddOn> _addOns = new List<AddOn>();
        public List<AddOn> AddOns => _addOns.ToList();
        public Category Category { get; private set; }
        public bool IsOnPromotion { get; protected set; }
        public Promotion Promotion { get; protected set; }

        public string Discount { get; private set; }

        public string ImageUrl { get; private set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }


        public Food(string name, MoneyValue unitPrice, FoodItemType type,
            bool isGlutenFree, bool isVeg, bool isNonVeg, string imageUrl)
        {
            ImageUrl = imageUrl;
            Name = name;
            UnitPrice = unitPrice;
            Type = type;
            IsGlutenFree = isGlutenFree;
            IsVeg = !isNonVeg && isVeg;
            IsNonVeg = !isVeg && isNonVeg;
            OldUnitPrice = unitPrice;
            Status = FoodStatus.Available;
            Rating = 0;
            TotalRatingsCount = 0;
        }

        public void AddRating(int remark)
        {
            var temp = TotalRatingsCount * Rating;
            TotalRatingsCount++;
            temp += remark;
            Rating = temp / TotalRatingsCount;
        }

        public void AddToPromotion(Promotion promotion, decimal promotionPrice, string discount)
        {
            Promotion = promotion;
            IsOnPromotion = true;
            UnitPrice = MoneyValue.Of(promotionPrice);
            Discount = discount;
        }

        public void AddVariant(Variant variant)
        {
            CheckRule(new ConditionMustBeTrueRule(variant.HasValue() && MustNotContainVariantWithSameName(variant),
                "variant with same name already exists"));
            _variants.Add(variant);
        }

        private bool MustNotContainVariantWithSameName(Variant variant)
        {
            return _variants.FirstOrDefault(x =>
                string.Equals(x.Name, variant.Name, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public void SetCategory(Category category)
        {
            CheckRule(new ConditionMustBeTrueRule(category != null && category.Categorize == Categorize.Food,
                "invalid category"));
            Category = category;
        }

        public void NewAddOn(AddOn addOn)
        {
            CheckRule(new ConditionMustBeTrueRule(_addOns.All(x => x.Name != addOn.Name),
                "add on with same name already eixists"));
            _addOns.Add(addOn);
        }
    }
}