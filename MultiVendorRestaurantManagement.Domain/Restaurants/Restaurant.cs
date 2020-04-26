using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.City;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public Area Area { get; protected set; }
        public RestaurantState State { get; protected set; }
        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public SubscriptionType SubscriptionType { get; protected set; }
        public ContractStatus ContractStatus { get; protected set; }
        public PricingPolicy PricingPolicy { get; protected set; }
        public DateTime ExpirationDate { get; protected set; }

        private ICollection<Category> _categories;
        public IReadOnlyList<Category> Categories => _categories.ToList();

        private ICollection<Food> _foods = new List<Food>();
        public IReadOnlyList<Food> FoodList => _foods.ToList();

        private ICollection<Menu> _menus;
        public IReadOnlyList<Menu> MenuList => _menus.ToList();

        private ICollection<Order> _orders;

        public IReadOnlyList<Order> Orders { get; protected set; }
        
        private ICollection<string> _imageUrls;
        public IReadOnlyList<string> ImageUrls => _imageUrls.ToList();

        public Restaurant(string name, string phone, Area area, int openingHour, int closingHour,
            SubscriptionType subscriptionType, ContractStatus contractStatus, ICollection<Category> categories)
        {
            Name = name;
            Area = area;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            _categories = categories;
            State = RestaurantState.Closed;
            PhoneNumber = PhoneNumberValue.Of(SupportedCountryCode.Italy, phone).GetCompletePhoneNumber();
            ExpirationDate = GenerateExpirationDateFromSubscriptionType(subscriptionType);
        }

        private DateTime GenerateExpirationDateFromSubscriptionType(SubscriptionType subscriptionType)
        {
            switch (subscriptionType)
            {
                case SubscriptionType.Monthly:
                    return DateTime.Now.AddMonths(1);
                    
                case SubscriptionType.Yearly:
                    return DateTime.Now.AddMonths(12);

                case SubscriptionType.BiYearly:
                    return DateTime.Now.AddMonths(6);
                default:
                    return DateTime.Now;
            }
        }

        public void SetPricingPolicy(PricingPolicy policy)
        {
            PricingPolicy = policy;
        }

        public void AddFood(Food food)
        {
            _foods.Add(food);
        }
    }
}