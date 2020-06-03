using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Cuisines;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;
using Newtonsoft.Json;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Food : Entity
    {
        private const string DefaultVariant = "Normale";
        private const string DefaultVariantEng = "Regular";

        private readonly List<AddOn> _addOns = new List<AddOn>();

        private readonly List<FoodTag> _tags = new List<FoodTag>();

        //default, single, double, large, extra-large
        private readonly List<Variant> _variants = new List<Variant>();


        protected Food()
        {
        }

        public Food(string name, MoneyValue unitPrice, FoodItemType type,
            bool isGlutenFree, bool isVeg, bool isNonVeg, string imageUrl, Categories.Category category, Cuisine cuisine,
            string description,
            string descriptionEng, Menu menu, List<string> ingredients)
        {
            CheckRule(new ConditionMustBeTrueRule(category.Categorize == Categorize.Food, "invalid category"));

            ImageUrl = imageUrl;
            Category = category;
            Cuisine = cuisine;
            Description = description;
            DescriptionEng = descriptionEng;
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
            Menu = menu;

            void SetDefaultVariant()
            {
                AddVariant(new Variant(DefaultVariant, DefaultVariantEng, unitPrice, "", ""));
            }

            SetIngredients(ingredients);
        }

        private void SetIngredients(List<string> ingredients)
        {
            CheckRule(new ConditionMustBeTrueRule(ingredients.Any(), "ingredients must not be empty"));
            IngredientsString = JsonConvert.SerializeObject(ingredients);
        }

        public List<string> GetIngredients()
        {
            return JsonConvert.DeserializeObject<List<string>>(IngredientsString);
        }

        public Menu Menu { get; protected set; }
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
        public IReadOnlyList<Variant> Variants => _variants.ToList();
        public IReadOnlyList<FoodTag> Tags => _tags.ToList();
        public IReadOnlyList<AddOn> AddOns => _addOns.ToList();

        public string IngredientsString { get; protected set; }
        public Categories.Category Category { get; private set; }
        public Cuisine Cuisine { get; private set; }
        public Deal Deal { get; private set; }
        public string ImageUrl { get; protected set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }
        public int TotalOrderCount { get; protected set; }

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

        public void UpdateCategory(Categories.Category category)
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
            var variant =
                _variants.FirstOrDefault(x => x.Name.ToLowerInvariant() == model.VariantName.ToLowerInvariant());
            if (variant.HasValue())
            {
                if (model.VariantName.Equals(DefaultVariant)) UpdateBasePrice(model.NewPrice);

                variant.UpdatePrice(MoneyValue.Of(model.NewPrice));
                return Result.Ok(variant.IsPriceReduced());
            }

            return Result.Failure<bool>("failed to update");
        }

        private void UpdateBasePrice(decimal price)
        {
            OldUnitPrice = UnitPrice;
            UnitPrice = MoneyValue.Of(price);
        }

        public void SetStatus(FoodStatus status)
        {
            Status = status;
        }

        public void SetOffer(Deal deal)
        {
            Deal = deal;
        }

        public void AddToDeal(Deal deal)
        {
            Deal = deal;
        }
    }
}