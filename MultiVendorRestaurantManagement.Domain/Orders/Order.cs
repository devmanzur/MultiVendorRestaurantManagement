﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _items = new List<OrderItem>();

        public Order(OrderType type, MoneyValue totalAmount,
            MoneyValue payableAmount, SupportedPaymentType paymentType)
        {
            Type = type;
            TotalAmount = totalAmount;
            PayableAmount = payableAmount;
            PaymentType = paymentType;
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; protected set; }
        public Restaurant Restaurant { get; private set; }
        public virtual OrderDetail Detail { get; protected set; }
        public IReadOnlyList<OrderItem> Items => _items.ToList();

        public OrderState State { get; protected set; } = OrderState.Pending;
        public OrderType Type { get; protected set; }
        public MoneyValue TotalAmount { get; protected set; }
        public MoneyValue PayableAmount { get; protected set; }
        public SupportedPaymentType PaymentType { get; protected set; }
    }
}