﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Cuisines;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Restaurant : AggregateRoot
    {
        private readonly List<Food> _foods = new List<Food>();

        private readonly List<Menu> _menus = new List<Menu>();
        private readonly List<RestaurantCategory> _categories = new List<RestaurantCategory>();
        private readonly List<RestaurantCuisine> _cuisines = new List<RestaurantCuisine>();

        private List<Order> _orders = new List<Order>();

        protected Restaurant()
        {
        }

        public Restaurant(string name, int openingHour, int closingHour,
            SubscriptionType subscriptionType, ContractStatus contractStatus, PhoneNumberValue phoneNumber,
            string imageUrl, Locality locality, GeographicLocation location, string description,
            string descriptionEng)
        {
            CheckRule(new OpeningAndClosingHoursAreValid(openingHour, closingHour));
            CheckRule(new ConditionMustBeTrueRule(subscriptionType != SubscriptionType.Invalid,
                "subscription must be valid"));
            CheckRule(new ConditionMustBeTrueRule(contractStatus != ContractStatus.Invalid,
                "contract must be valid"));
            CheckRule(new ConditionMustBeTrueRule(phoneNumber != null,
                "phone number be valid"));

            ImageUrl = imageUrl;
            Locality = locality;
            GeographicLocation = location;
            Description = description;
            DescriptionEng = descriptionEng;
            Name = name;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            State = RestaurantState.Open;
            ExpirationDate = subscriptionType.GetExpirationTime();
            PhoneNumber = phoneNumber;
        }

        public GeographicLocation GeographicLocation { get; private set; }
        public string Name { get; protected set; }
        public PhoneNumberValue PhoneNumber { get; protected set; }
        public Locality Locality { get; protected set; }
        public long ManagerId { get; private set; }

        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }

        public RestaurantState State { get; private set; }

        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public SubscriptionType SubscriptionType { get; protected set; }
        public ContractStatus ContractStatus { get; protected set; }
        public PricingPolicy PricingPolicy { get; protected set; }
        public DateTime ExpirationDate { get; protected set; }
        public IReadOnlyList<Food> Foods => _foods.ToList();
        public IReadOnlyList<Menu> Menus => _menus.ToList();
        public IReadOnlyList<RestaurantCategory> Categories => _categories.ToList();
        public IReadOnlyList<RestaurantCuisine> Cuisines => _cuisines.ToList();
        public IReadOnlyList<Order> Orders { get; protected set; }

        public string ImageUrl { get; protected set; }

        public double Rating { get; private set; }

        public int TotalRatingsCount { get; private set; }


        public void SetPricingPolicy(PricingPolicy policy)
        {
            CheckRule(new PricingPolicyMustBeValidRule(policy));

            if (PricingPolicy == null)
                PricingPolicy = policy;
            else
                PricingPolicy.UpdateBy(policy);
        }

        public void AddFood(Food food)
        {
            CheckRule(new ConditionMustBeTrueRule(food.HasValue() && MustNotContainFoodWithSameName(food),
                "food with same name already exists"));
            _foods.Add(food);
            AddDomainEvent(new FoodRegisteredEvent(Id, Name, food.Name, food.Category.Name, food.Menu.Name,
                food.Cuisine.Name, food.GetIngredients()));
        }

        public void AddRating(int remark)
        {
            var temp = TotalRatingsCount * Rating;
            TotalRatingsCount++;
            temp += remark;
            Rating = temp / TotalRatingsCount;
        }

        public void UpdateLocality(Locality locality)
        {
            Locality = locality;
        }

        public void AssignManager(long managerId)
        {
            ManagerId = managerId;
        }

        public void AddMenu(Menu menu)
        {
            CheckRule(new ConditionMustBeTrueRule(menu.HasValue() &&
                                                  MustNotContainMenuWIthSameName(menu),
                "menu with same name already exists"));
            _menus.Add(menu);
            AddDomainEvent(new MenuAddedEvent(Id, menu.Name, menu.NameEng, menu.ImageUrl));
        }

        private bool MustNotContainMenuWIthSameName(Menu menu)
        {
            return _menus.FirstOrDefault(
                       x => string.Equals(x.Name, menu.Name, StringComparison.InvariantCultureIgnoreCase)
                            || string.Equals(x.NameEng, menu.NameEng, StringComparison.InvariantCultureIgnoreCase)) ==
                   null;
        }

        private bool MustNotContainFoodWithSameName(Food food)
        {
            return _foods.FirstOrDefault(
                x => string.Equals(x.Name, food.Name, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public override IDomainEvent GetAddedDomainEvent()
        {
            return new RestaurantRegisteredEvent(PhoneNumber.GetCompletePhoneNumber(),
                _categories.Select(x => x.CategoryId),
                _cuisines.Select(x => x.CuisineId));
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new RestaurantRemovedEvent();
        }

        public void SupportNewCategory(Categories.Category category)
        {
            CheckRule(new ConditionMustBeTrueRule(category.HasValue() && category.Categorize == Categorize.Restaurant,
                "only a category of type restaurant must be assigned"));

            CheckRule(new ConditionMustBeTrueRule(
                _categories.FirstOrDefault(x => x.CategoryId == category.Id).HasNoValue(),
                "category already exists"));
            _categories.Add(new RestaurantCategory(this, category));
        }

        public void SupportNewCuisine(Cuisine cuisine)
        {
            CheckRule(new ConditionMustBeTrueRule(cuisine.HasValue(), "invalid cuisine"));

            CheckRule(new ConditionMustBeTrueRule(_cuisines.FirstOrDefault(x => x.CuisineId == cuisine.Id).HasNoValue(),
                "cuisine already exists"));
            _cuisines.Add(new RestaurantCuisine(this, cuisine));
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
            ExpirationDate = subscriptionType.GetExpirationTime();
            AddDomainEvent(new SubscriptionUpdatedEvent(Id, subscriptionType));
        }

        public void AddNewVariantFor(Food food, Variant variant)
        {
            food.AddVariant(variant);
            AddDomainEvent(new NewVariantAddedEvent(Id, food.Id, variant.Name, variant.NameEng, variant.Price,
                variant.Description, variant.DescriptionEng));
        }

        public void RemoveVariantFor(Food food, Variant variant)
        {
            food.RemoveVariant(variant);
            AddDomainEvent(new VariantRemovedEvent(Id, food.Id, variant.Name));
        }

        public void CreateNewAddOnFor(Food food, AddOn addOn)
        {
            food.NewAddOn(addOn);
            AddDomainEvent(new NewAddOnEvent(Id, food.Id, addOn.Name, addOn.NameEng, addOn.Description,
                addOn.DescriptionEng, addOn.Price));
        }

        public void RemoveAddOnFor(Food food, AddOn addOn)
        {
            food.RemoveAddOn(addOn);
            AddDomainEvent(new AddOnRemovedEvent(Id, food.Id, addOn.Name));
        }

        public void AddFoodToMenu(Menu menu, Food food)
        {
            CheckRule(new ConditionMustBeTrueRule(food != null && menu != null, "invalid menu/food combination"));
            CheckRule(new ConditionMustBeTrueRule(!menu.Items.Contains(food), "menu already has the food"));
            menu.AddItem(food);

            AddDomainEvent(new FoodUpdatedEvent(Id, food.Id, menu.Id, menu.Name));
        }

        public Result UpdateVariantPriceFor(Food food, List<VariantPriceUpdateModel> variantPriceUpdates)
        {
            var isDiscounted = false;

            foreach (var process in variantPriceUpdates.Select(x =>
                {
                    var task = food.UpdateVariantPrice(x);
                    if (!isDiscounted) isDiscounted = task.Value;

                    return task;
                })
                .Where(process => process.IsFailure))
                return Result.Failure(process.Error);
            AddDomainEvent(new FoodUpdatedEvent(Id, food.Id, variantPriceUpdates, isDiscounted));
            return Result.Ok();
        }

        public void UpdateStatusFor(Food food, FoodStatus status)
        {
            food.SetStatus(status);
            AddDomainEvent(new FoodUpdatedEvent(Id, food.Id, status));
        }
    }
}