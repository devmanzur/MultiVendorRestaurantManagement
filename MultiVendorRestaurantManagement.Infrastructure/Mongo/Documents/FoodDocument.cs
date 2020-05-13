using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class FoodDocument : BaseDocument
    {
        private const string DefaultVariant = "Normale";
        private const string DefaultVariantEng = "Regular";

        public FoodDocument(long restaurantId, string restaurantName, long foodId, string imageUrl, string name,
            decimal unitPrice,
            decimal oldUnitPrice, string type, long categoryId, string categoryName, string status, bool isGlutenFree,
            bool isVeg,
            bool isNonVeg)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
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
            CategoryName = categoryName;
            GenerateTags();
            AddDefaultVariant();
        }

        public long RestaurantId { get; set; }
        public long DealId { get; private set; }
        public string DealDescription { get; private set; }
        public string DealDescriptionEng { get; private set; }
        public string RestaurantName { get; set; }
        public long FoodId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public bool IsDiscounted { get; private set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; private set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal OldUnitPrice { get; private set; }

        public DateTime DealEndsOn { get; private set; }
        public string Type { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<FoodTagDocument> FoodTags { get; set; } = new List<FoodTagDocument>();
        public string Status { get; private set; }
        public bool IsGlutenFree { get; set; } //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; set; } //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; set; } //adds an extra tag to the list of tags when set true
        public List<VariantDocument> Variants { get; protected set; } = new List<VariantDocument>();
        public List<AddOnDocument> AddOns { get; protected set; } = new List<AddOnDocument>();
        public long MenuId { get; private set; }
        public string MenuName { get; private set; }

        public double Rating { get; private set; } = 0;
        public int TotalRatingCount { get;private set; } = 0;
        public int TotalOrderCount { get; private set;} = 0;

        private void AddDefaultVariant()
        {
            AddVariant(new VariantDocument(DefaultVariant, DefaultVariantEng, UnitPrice, "", ""));
        }

        private void GenerateTags()
        {
            if (IsGlutenFree) FoodTags.Add(new FoodTagDocument("Senza glutine", "Gluten free"));

            if (!IsVeg && IsNonVeg) FoodTags.Add(new FoodTagDocument("Cibo non vegano", "Non-Veg"));

            if (!IsNonVeg && IsVeg) FoodTags.Add(new FoodTagDocument("Cibo vegano", "Vegan"));
        }

        public void AddVariant(VariantDocument variant)
        {
            Variants.Add(variant);
        }

        public void RemoveVariant(string variantName)
        {
            var variant = Variants.Find(x => x.Name == variantName);
            Variants.Remove(variant);
        }

        public void NewAddOn(AddOnDocument variant)
        {
            AddOns.Add(variant);
        }

        public void RemoveAddOn(string addOnName)
        {
            var addOn = AddOns.Find(x => x.Name == addOnName);
            AddOns.Remove(addOn);
        }

        public void UpdateMenu(long menuId, string name)
        {
            MenuId = menuId;
            MenuName = name;
        }

        public void UpdateVariantPrice(VariantPriceUpdateModel model)
        {
            var variant = Variants.FirstOrDefault(x => x.Name == model.VariantName);
            if (variant.HasValue())
            {
                if (model.VariantName.Equals(DefaultVariant)) UpdateBasePrice(model.NewPrice);

                variant.UpdatePrice(model.NewPrice);
            }
        }

        private void UpdateBasePrice(decimal price)
        {
            OldUnitPrice = UnitPrice;
            UnitPrice = price;
        }

        public void UpdateStatus(FoodStatus status)
        {
            Status = status.ToString();
        }

        public void SetOnDiscount()
        {
            IsDiscounted = true;
        }

        public void SetDeal(in long dealId, string description, string descriptionEng, DateTime endDate)
        {
            DealId = dealId;
            DealDescription = description;
            DealDescriptionEng = descriptionEng;
            DealEndsOn = endDate;
        }
    }

    public class VariantDocument
    {
        public VariantDocument(string name, string nameEng, decimal price, string description, string descriptionEng)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
            OldPrice = price;
            Description = description;
            DescriptionEng = descriptionEng;
        }

        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }
        public decimal Price { get; private set; }
        public decimal OldPrice { get; private set; }

        public void UpdatePrice(decimal price)
        {
            OldPrice = Price;
            Price = price;
        }
    }

    public class AddOnDocument
    {
        public AddOnDocument(string name, string nameEng, string description, string descriptionEng, decimal price)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
            Description = description;
            DescriptionEng = descriptionEng;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Description { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public decimal Price { get; protected set; }
    }

    public class FoodTagDocument
    {
        public FoodTagDocument(string name, string nameEng)
        {
            Name = name;
            NameEng = nameEng;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
    }
}