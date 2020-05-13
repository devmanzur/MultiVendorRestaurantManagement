using System;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class LocationValue : CustomValueObject
    {
        public LocationValue(string latLng)
        {
            CheckRule(new LocationStringMustBeValidRule(latLng));
            var items = latLng.Split(",");
            Longitude = Convert.ToDouble(items[1]);
            Latitude = Convert.ToDouble(items[2]);
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}