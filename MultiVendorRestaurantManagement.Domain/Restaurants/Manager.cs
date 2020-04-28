using Common.Invariants;
using Microsoft.AspNetCore.Identity;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Manager : IdentityUser
    {
        public Manager(string device, string name, long restaurantId)
        {
            Device = device;
            Name = name;
            RestaurantId = restaurantId;
            Role = ApplicationUserRole.Manager;
        }

        public string Device { get; protected set; }
        public string Name { get; protected set; }
        public long RestaurantId { get; private set; }
        public ApplicationUserRole Role  { get; private set; }
        
        
    }
}