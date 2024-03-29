﻿using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class TagCreatedEvent : DomainEventBase
    {
        public TagCreatedEvent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}