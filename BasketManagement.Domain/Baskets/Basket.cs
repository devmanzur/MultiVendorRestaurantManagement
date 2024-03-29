﻿using System.Collections.Generic;
using System.Linq;
using BasketManagement.Common.Utils;
using BasketManagement.Domain.Base;
using CSharpFunctionalExtensions;

namespace BasketManagement.Domain.Baskets
{
    public class Basket : Entity
    {
        public string UserId { get; private set; }
        public string UserSessionId { get; private set; }
        private Dictionary<long, BasketItem> _items = new Dictionary<long, BasketItem>();

        private Basket(string userId, string userSessionId)
        {
            UserId = userId;
            UserSessionId = userSessionId;
        }

        public static Basket MakeNew(string userId, string userSessionId)
        {
            return new Basket(userId, userSessionId);
        }

        public IReadOnlyList<BasketItem> Items => _items.Values.ToList();

        public void AddItem(BasketItem item)
        {
            var existing = _items[item.FoodId];
            if (existing.HasValue())
            {
                existing.UpdateQuantity(item.Quantity);
                _items[item.FoodId] = existing;
            }
            else
            {
                _items[item.FoodId] = item;
            }
        }

        public Result Remove(long foodId, int quantity)
        {
            var item = _items[foodId];

            if (item.HasNoValue()) return Result.Failure("item not found");
            
            item.UpdateQuantity(-quantity);

            if (item.IsDropped())
            {
                _items.Remove(foodId);
            }

            return Result.Ok();
        }
    }
}