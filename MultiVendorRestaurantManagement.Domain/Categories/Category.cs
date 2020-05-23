using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Category;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Categories
{
    public class Category : AggregateRoot
    {
        public Category(string name, string nameEng, string imageUrl, Categorize categorize)
        {
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
            Categorize = categorize;
        }

        public string ImageUrl { get; protected set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }

        private readonly List<Food> _foods = new List<Food>();
        public IReadOnlyList<Food> Foods => _foods.ToList();
        
        private readonly List<RestaurantCategory> _restaurants = new List<RestaurantCategory>();
        public IReadOnlyList<RestaurantCategory> Restaurants => _restaurants.ToList();
        
        public Categorize Categorize { get; }
        public override IDomainEvent GetAddedDomainEvent()
        {
            return new CategoryCreatedEvent(Name, Categorize);
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new CategoryRemovedEvent();
        }

        public void Update(string name, string nameEng, string imageUrl)
        {
            CheckRule(new ConditionMustBeTrueRule(name != Name && nameEng != NameEng, "no changes made"));
            Name = name;
            NameEng = nameEng;
            if (imageUrl.HasValue()) ImageUrl = imageUrl;
            AddDomainEvent(new CategoryUpdatedEvent(Id, name, nameEng, imageUrl));
        }
    }
}