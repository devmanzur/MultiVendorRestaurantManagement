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
        public bool IsOnPromotion { get; protected set; } = false;
        public FoodItemType Type { get; protected set; }
        
        //adds an extra tag to the list of tags when set true
        public bool IsGlutenFree { get; protected set; }

        //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; protected set; }

        //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; protected set; }

        public FoodStatus Status { get; protected set; } = FoodStatus.Available;

        //default, single, double, large, extra-large
        public ICollection<Variant> _variants;
        public IReadOnlyList<Variant> Variants { get; protected set; }

        private ICollection<Tag> _tags;
        public List<Tag> Tags { get; set; }

        private ICollection<AddOn> _addOns;
        public List<AddOn> AddOns => _addOns.ToList();
        
        private ICollection<Category> _categories;
        public IReadOnlyList<Category> Categories => _categories.ToList();
        private ICollection<string> _imageUrls;
        public IReadOnlyList<string> ImageUrls => _imageUrls.ToList();



        public Food(Restaurant restaurant, string name, MoneyValue unitPrice, FoodItemType type, 
            bool isGlutenFree, bool isVeg, bool isNonVeg, List<Variant> variants, ICollection<string> imageUrls,
            ICollection<Tag> tags, ICollection<AddOn> addOns, ICollection<Category> categories)
        {
            Restaurant = restaurant;
            Name = name;
            UnitPrice = unitPrice;
            Type = type;
            IsGlutenFree = isGlutenFree;
            IsVeg = !isNonVeg && isVeg;
            IsNonVeg = !isVeg && isNonVeg;
            _variants = variants;
            _imageUrls = imageUrls;
            _tags = tags;
            _addOns = addOns;
            _categories = categories;
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
    }
}