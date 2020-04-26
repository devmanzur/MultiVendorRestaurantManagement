using System;
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
        public Order(OrderDetail detail, List<OrderItem> items, OrderType type, MoneyValue totalAmount,
            MoneyValue payableAmount, SupportedPaymentType paymentType, Restaurant restaurant)
        {
            Detail = detail;
            _items = items;
            Type = type;
            TotalAmount = totalAmount;
            PayableAmount = payableAmount;
            PaymentType = paymentType;
            Restaurant = restaurant;
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; protected set; }
        public Restaurant Restaurant { get; private set; }
        public OrderDetail Detail { get; protected set; }

        private ICollection<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items.ToList();

        public OrderState State { get; protected set; } = OrderState.Pending;
        public OrderType Type { get; protected set; }
        public MoneyValue TotalAmount { get; protected set; }
        public MoneyValue PayableAmount { get; protected set; }
        public SupportedPaymentType PaymentType { get; protected set; }
    }
}