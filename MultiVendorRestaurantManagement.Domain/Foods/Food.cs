using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Food : Entity
    {
        private const string DefaultVariant = "Normale";
        private const string DefaultVariantEng = "Regular";

        public Restaurant Restaurant { get; protected set; }
        public string Name { get; protected set; }
        public MoneyCustomValue UnitPrice { get; protected set; }
        public MoneyCustomValue OldUnitPrice { get; protected set; }
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
        public Deal Deal { get; private set; }
        public string ImageUrl { get; private set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }
        public int TotalOrderCount { get; private set; }


        protected Food()
        {
        }

        public Food(string name, MoneyCustomValue unitPrice, FoodItemType type,
            bool isGlutenFree, bool isVeg, bool isNonVeg, string imageUrl, Category category)
        {
            ImageUrl = imageUrl;
            Category = category;
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
            TotalOrderCount = 0;
            SetDefaultVariant();

            void SetDefaultVariant()
            {
                AddVariant(new Variant(DefaultVariant, nameEng: DefaultVariantEng, price: unitPrice, "", ""));
            }
        }

        public void AddRating(int remark)
        {
            var temp = TotalRatingsCount * Rating;
            TotalRatingsCount++;
            temp += remark;
            Rating = temp / TotalRatingsCount;
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

        public void UpdateCategory(Category category)
        {
            CheckRule(new ConditionMustBeTrueRule(category != null && category.Categorize == Categorize.Food,
                "invalid category"));
            Category = category;
        }

        public void NewAddOn(AddOn addOn)
        {
            CheckRule(new ConditionMustBeTrueRule(_addOns.All(x => x.Name != addOn.Name),
                "add on with same name already exists"));
            _addOns.Add(addOn);
        }

        public void RemoveVariant(Variant variant)
        {
            CheckRule(new ConditionMustBeTrueRule(_variants.Contains(variant), "variant not found"));
            CheckRule(new ConditionMustBeTrueRule(_variants.Count > 1, "food must have at least one variant"));
            _variants.Remove(variant);
        }

        public void RemoveAddOn(AddOn addOn)
        {
            CheckRule(new ConditionMustBeTrueRule(_addOns.Contains(addOn), "add-on not found"));
            _addOns.Remove(addOn);
        }

        public Result<bool> UpdateVariantPrice(VariantPriceUpdateModel model)
        {
            var variant = _variants.FirstOrDefault(x => x.Name == model.VariantName);
            if (variant.HasValue())
            {
                if (model.VariantName.Equals(DefaultVariant))
                {
                    UpdateBasePrice(model.NewPrice);
                }

                variant.UpdatePrice(MoneyCustomValue.Of(model.NewPrice));
                return Result.Ok(variant.IsPriceReduced());
            }

            return Result.Failure<bool>("failed to update");
        }

        private void UpdateBasePrice(decimal price)
        {
            OldUnitPrice = UnitPrice;
            UnitPrice = MoneyCustomValue.Of(price);
        }

        public void SetStatus(FoodStatus status)
        {
            Status = status;
        }

        public void SetOffer(Deal deal)
        {
            Deal = deal;
        }
    }
}