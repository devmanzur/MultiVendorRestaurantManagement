using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class FoodDocument : BaseDocument
    {
        private const string DefaultVariant = "Normale";
        private const string DefaultVariantEng = "Regular";

        public FoodDocument(long restaurantId, string restaurantName, long foodId, string imageUrl, string name,
            decimal unitPrice,
            decimal oldUnitPrice, string type, long categoryId, string status, bool isGlutenFree, bool isVeg,
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
            GenerateTags();
            AddDefaultVariant();
        }

        private void AddDefaultVariant()
        {
            AddVariant(new VariantDocument(DefaultVariant, nameEng: DefaultVariantEng, price: UnitPrice, "", ""));
        }

        private void GenerateTags()
        {
            if (IsGlutenFree)
            {
                FoodTags.Add(new FoodTagDocument("Senza glutine", "Gluten free"));
            }

            if (!IsVeg && IsNonVeg)
            {
                FoodTags.Add(new FoodTagDocument("Cibo non vegano", "Non-Veg"));
            }

            if (!IsNonVeg && IsVeg)
            {
                FoodTags.Add(new FoodTagDocument("Cibo vegano", "Vegan"));
            }
        }

        public long RestaurantId { get; private set; }
        public long DealId { get; private set; }
        public string DealDescription { get; private set; }
        public string DealDescriptionEng { get; private set; }
        public string RestaurantName { get; private set; }
        public long FoodId { get; private set; }
        public string ImageUrl { get; private set; }
        public string Name { get; private set; }

        public bool IsDiscounted { get; private set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; private set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal OldUnitPrice { get; private set; }

        public DateTime DealEndsOn { get; private set; }
        public string Type { get; private set; }
        public long CategoryId { get; private set; }
        public List<FoodTagDocument> FoodTags { get; private set; } = new List<FoodTagDocument>();
        public string Status { get; private set; }
        public bool IsGlutenFree { get; private set; } //adds an extra tag to the list of tags when set true
        public bool IsVeg { get; private set; } //adds an extra tag to the list of tags when set true
        public bool IsNonVeg { get; private set; } //adds an extra tag to the list of tags when set true
        public List<VariantDocument> Variants { get; protected set; } = new List<VariantDocument>();
        public List<AddOnDocument> AddOns { get; protected set; } = new List<AddOnDocument>();
        public long MenuId { get; private set; }
        public string MenuName { get; private set; }

        public double Rating { get; private set; } = 0;
        public int TotalRatingCount { get; private set; } = 0;
        public int TotalOrderCount { get; private set; } = 0;

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
                if (model.VariantName.Equals(DefaultVariant))
                {
                    UpdateBasePrice(model.NewPrice);
                }

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

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
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

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
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