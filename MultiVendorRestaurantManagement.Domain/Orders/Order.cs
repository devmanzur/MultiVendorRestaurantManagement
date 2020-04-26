using System;
using System.Collections.Generic;
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Restaurants;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    public class Order : Entity
    {
        public Order(OrderDetail detail, List<OrderItem> items, OrderType type, string totalAmount, string payableAmount, SupportedPaymentType paymentType)
        {
            Detail = detail;
            Items = items;
            Type = type;
            TotalAmount = totalAmount;
            PayableAmount = payableAmount;
            PaymentType = paymentType;
        }

        public DateTime CreatedAt { get; protected set; }
        public Restaurant Restaurant { get; private set; }
        public OrderDetail Detail { get; protected set; }
        public List<OrderItem> Items { get; protected set; }
        public OrderState State { get; protected set; } = OrderState.Pending;
        public OrderType Type { get; protected set; }
        public string TotalAmount { get; protected set; }
        public string PayableAmount { get; protected set; }
        public SupportedPaymentType PaymentType { get; protected set; }
    }
}