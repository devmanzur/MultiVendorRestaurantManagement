using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class GeographicLocation : Entity
    {
        public GeographicLocation(string name, double latitude, double longitude)
        {
            CheckRule(new ConditionMustBeTrueRule(!string.IsNullOrEmpty(name) &&
                                                  latitude.HasValue() &&
                                                  longitude.HasValue(),
                "location data is invalid"));
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Name { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}