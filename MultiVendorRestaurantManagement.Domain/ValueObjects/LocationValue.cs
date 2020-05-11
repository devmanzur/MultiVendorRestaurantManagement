using System;
using System.Linq;
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
            Latitude =  Convert.ToDouble(items[2]);
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}