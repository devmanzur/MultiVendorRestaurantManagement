using System.Collections.Generic;
using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Common
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

        public Categorize Categorize { get; private set; }
        public List<Food> Foods { get; private set; }
        public List<Restaurant> Restaurants { get; private set; }

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
            CheckRule(new ConditionMustBeTrue(name != Name && nameEng != NameEng, "no changes made"));
            Name = name;
            NameEng = nameEng;
            if (imageUrl.HasValue()) ImageUrl = imageUrl;
            AddDomainEvent(new CategoryUpdatedEvent(Id, name, nameEng, imageUrl));
        }
    }
}