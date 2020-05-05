using System.Collections.Generic;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class FoodDocument : BaseDocument
    {
        public FoodDocument(long restaurantId, long foodId, string imageUrl, string name, decimal unitPrice,
            decimal oldUnitPrice, string type, long categoryId, string status, bool isGlutenFree, bool isVeg,
            bool isNonVeg)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            ImageUrl = imageUrl;
            Name = name;
            UnitPrice = unitPrice;
            OldUnitPrice = oldUnitPrice;
            Type = type;
            CategoryId = categoryId;
            Status = status;
            IsGlutenFree = isGlutenFree;
            IsVeg = isVeg;
            IsNonVeg = isNonVeg;
            GenerateTags();
        }

        private void GenerateTags()
        {
            if (IsGlutenFree)
            {
                FoodTags.Add(new FoodTagDocument( "Senza glutine", "Gluten free"));
            }
            if (!IsVeg && IsNonVeg)
            {
                FoodTags.Add(new FoodTagDocument( "Cibo non vegano","Non-Veg"));
            }
            if (!IsNonVeg && IsVeg)
            {
                FoodTags.Add(new FoodTagDocument( "Cibo vegano", "Vegan"));
            }
        }

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string ImageUrl { get; private set; }
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal OldUnitPrice { get; private set; }
        public string Type { get; private set; }
        public long CategoryId { get; private set; }
        public List<FoodTagDocument> FoodTags { get; private set; } = new List<FoodTagDocument>();
        public string Status { get; private set; }
        public bool IsGlutenFree { get; private set; } //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; private set; } //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; private set; } //adds an extra tag to the list of tags when set true
        public List<VariantDocument> Variants { get; set; } = new List<VariantDocument>();
        public int OrderCount { get; set; }
        public string PriceTag { get; set; }

        public void AddVariant(VariantDocument variant)
        {
            Variants.Add(variant);
        }
    }

    public class VariantDocument
    {
        public VariantDocument(string name, string nameEng, decimal price)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
        }

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public decimal Price { get; private set; }
    }

    public class FoodTagDocument
    {
        public FoodTagDocument(string name, string nameEng)
        {
            Name = name;
            NameEng = nameEng;
        }

        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}