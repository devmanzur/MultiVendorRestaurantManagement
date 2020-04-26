using System.Collections.Generic;
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Food : Entity{
        public string Name { get; set; }
        private MoneyValue UnitPrice { get; set; }
        private MoneyValue OldUnitPrice { get; set; }
        private bool IsOnPromotion {get; set;}
        public FoodItemType Type { get; set; } 
        public Category Category { get; set; }
        //adds an extra tag to the list of tags when set true
        public bool IsGlutenFree { get; set; }
        //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; set; } 
        //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; set; } 
        public FoodStatus Status { get; set; }  
        //default, single, double, large, extra-large
        public List<Variant> Variant { get; set; }  
        private ICollection<Review> _reviews;
        public IReadOnlyList<Review> Reviews { get; set; }
        public IReadOnlyList<string> ImageUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public List<AddOn> AddOns { get; set; }

    }
}