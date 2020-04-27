﻿using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Variant : Entity
    {
        public Variant(string name, string nameEng, MoneyValue price)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
        }

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public MoneyValue Price { get; private set; }
        public virtual Food Food { get; protected set; }
    }
}