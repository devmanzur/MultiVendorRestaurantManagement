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
        public PhoneNumberValue PhoneNumberNumber { get; protected set; }
        public long AreaId { get; protected set; }
        public Locality Locality { get; protected set; }
        public Manager Manager { get; private set; }
        public RestaurantState State { get; protected set; }
        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public SubscriptionType SubscriptionType { get; protected set; }
        public ContractStatus ContractStatus { get; protected set; }
        public PricingPolicy PricingPolicy { get; protected set; }
        public DateTime ExpirationDate { get; protected set; }

        private List<Food> _foods = new List<Food>();
        public IReadOnlyList<Food> Foods => _foods.ToList();

        private List<Menu> _menus = new List<Menu>();
        public IReadOnlyList<Menu> Menus => _menus.ToList();

        private List<Order> _orders = new List<Order>();
        public IReadOnlyList<Order> Orders { get; protected set; }

        public string ImageUrl { get; private set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }

        public Restaurant(string name, int openingHour, int closingHour,
            SubscriptionType subscriptionType, ContractStatus contractStatus, PhoneNumberValue phoneNumberNumber,
            string imageUrl)
        {
            ImageUrl = imageUrl;
            Name = name;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            State = RestaurantState.Closed;
            ExpirationDate = GenerateExpirationDateFromSubscriptionType(subscriptionType);
            PhoneNumberNumber = phoneNumberNumber;
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

        public void AddRating(int remark)
        {
            var temp = TotalRatingsCount * Rating;
            TotalRatingsCount++;
            temp += remark;
            Rating = temp / TotalRatingsCount;
        }
    }
}