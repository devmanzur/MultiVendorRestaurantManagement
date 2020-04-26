using System;
using MediatR;

namespace MultiVendorRestaurantManagement.Domain.Base
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}