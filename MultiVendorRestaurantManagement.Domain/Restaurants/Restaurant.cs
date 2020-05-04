﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; protected set; }
        public PhoneNumberValue PhoneNumber { get; protected set; }
        public Locality Locality { get; protected set; }
        public long ManagerId { get; private set; }
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

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }

        public Restaurant(string name, int openingHour, int closingHour,
            SubscriptionType subscriptionType, ContractStatus contractStatus, PhoneNumberValue phoneNumber,
            string imageUrl)
        {
            CheckRule(new OpeningAndClosingHoursAreValid(openingHour, closingHour));
            CheckRule(new ConditionMustBeTrueRule(subscriptionType != SubscriptionType.Invalid,
                "subscription must be valid"));
            CheckRule(new ConditionMustBeTrueRule(contractStatus != ContractStatus.Invalid,
                "contract must be valid"));
            CheckRule(new ConditionMustBeTrueRule(phoneNumber != null,
                "phone number be valid"));

            ImageUrl = imageUrl;
            Name = name;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            State = RestaurantState.Open;
            ExpirationDate = GenerateExpirationDateFromSubscriptionType(subscriptionType);
            PhoneNumber = phoneNumber;
        }

        private DateTime GenerateExpirationDateFromSubscriptionType(SubscriptionType subscriptionType)
        {
            return subscriptionType switch
            {
                SubscriptionType.Monthly => DateTime.Now.AddMonths(1),
                SubscriptionType.Yearly => DateTime.Now.AddMonths(12),
                SubscriptionType.BiYearly => DateTime.Now.AddMonths(6),
                _ => DateTime.Now
            };
        }

        public void SetPricingPolicy(PricingPolicy policy)
        {
            CheckRule(new PricingPolicyMustBeValidRule(policy));

            if (PricingPolicy == null)
            {
                PricingPolicy = policy;
            }
            else
            {
                PricingPolicy.UpdateBy(policy);
            }
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

        public void SetLocality(Locality locality)
        {
            Locality = locality;
        }

        public void AssignManager(long managerId)
        {
            ManagerId = managerId;
        }

        public void AddMenu(Menu menu)
        {
            CheckRule(new ConditionMustBeTrueRule(
                _menus.FirstOrDefault(
                    x => string.Equals(x.Name, menu.Name, StringComparison.InvariantCultureIgnoreCase)) == null,
                "restaurant must not contain menu with same name"));
            _menus.Add(menu);
        }

        public override IDomainEvent GetAddedDomainEvent()
        {
            return new RestaurantRegisteredEvent(PhoneNumber.GetCompletePhoneNumber());
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new RestaurantRemovedEvent();
        }

        public void SetCategory(Category category)
        {
            Category = category;
        }

        public void UpdateHours(int openingHour, int closingHour)
        {
            CheckRule(new ConditionMustBeTrueRule(openingHour != closingHour && closingHour > openingHour,
                "invalid opening and closing hour"));
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            AddDomainEvent(new RestaurantHoursUpdatedEvent(Id, openingHour, closingHour));
        }

        public void UpdateSubscription(SubscriptionType subscriptionType)
        {
            CheckRule(new ConditionMustBeTrueRule(subscriptionType != SubscriptionType.Invalid,
                "invalid subscription"));
            SubscriptionType = subscriptionType;
            AddDomainEvent(new SubscriptionUpdatedEvent(Id, subscriptionType));
        }
    }
}