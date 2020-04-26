using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; protected set; }
        public PhoneNumberValue PhoneNumberValue { get; protected set; }
        public Area Area { get; protected set; }
        public RestaurantState State { get; protected set; }
        public DateTime OpeningHour { get; protected set; }
        public DateTime ClosingHour { get; protected set; }
        public SubscriptionType SubscriptionType { get; protected set; }
        public ContractStatus ContractStatus { get; protected set; }
        public PricingPolicy DeliveryPolicy { get; protected set; }

        public DateTime ExpirationDate { get; protected set; }

        private ICollection<Category> _categories;
        public IReadOnlyList<Category> Categories => _categories.ToList();

        private ICollection<Food> _foods;
        public IReadOnlyList<Food> Foods => _foods.ToList();

        private ICollection<Menu> _menus;
        public IReadOnlyList<Menu> Menus => _menus.ToList();

        private ICollection<Order> _orders;

        public IReadOnlyList<Order> Orders { get; protected set; }
        
        private ICollection<Review> _reviews;

        public IReadOnlyList<Review> Reviews { get; set; }


        private ICollection<string> _imageUrls;

        public Restaurant(string name, string phone, Area area, DateTime openingHour, DateTime closingHour,
            SubscriptionType subscriptionType, ContractStatus contractStatus)
        {
            Name = name;
            Area = area;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            State = RestaurantState.Closed;

            PhoneNumberValue = PhoneNumberValue.Create(phone);
        }

        public IReadOnlyList<string> ImageUrls => _imageUrls.ToList();
    }
}