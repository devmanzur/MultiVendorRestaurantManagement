using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Restaurants;
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

        public FoodStatus Status { get; protected set; } = FoodStatus.Available;

        //default, single, double, large, extra-large
        private List<Variant> _variants = new List<Variant>();
        public IReadOnlyList<Variant> Variants { get; protected set; }

        private List<Tag> _tags = new List<Tag>();
        public List<Tag> Tags { get; set; }

        private List<AddOn> _addOns = new List<AddOn>();
        public List<AddOn> AddOns => _addOns.ToList();
        
        private List<FoodCategory> _categories = new List<FoodCategory>();
        public IReadOnlyList<FoodCategory> Categories => _categories.ToList();

        public bool IsOnPromotion { get; protected set; } = false;
        public Promotion Promotion { get; protected set; }

        public string Discount { get; private set; }

        public string ImageUrl { get; private set; }
        
        public double Rating  { get; private set; }

        public int TotalRatingsCount  { get; private set; }


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
            GenerateAdditionalTags();
        }

        private void GenerateAdditionalTags()
        {
            if (IsGlutenFree)
                _tags.Add(new Tag("gluten-free", "senza glutine"));
            if (IsNonVeg)
                _tags.Add(new Tag("non-veg", "non-veg"));
            if (IsVeg)
                _tags.Add(new Tag("veg", "veg"));
            
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
    }
}