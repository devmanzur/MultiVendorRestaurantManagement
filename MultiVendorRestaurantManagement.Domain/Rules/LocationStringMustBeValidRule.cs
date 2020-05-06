using System;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class LocationStringMustBeValidRule : IBusinessRule
    {
        private readonly string _locationString;

        public LocationStringMustBeValidRule(string locationString)
        {
            _locationString = locationString;
        }
        public bool IsBroken()
        {
            if (string.IsNullOrEmpty(_locationString)) return true;
           
            try
            {
                var latLng = _locationString.Split(",");
                if (latLng.Length < 2) return true;
                var latitude = Convert.ToDouble(latLng[0]);
                var longitude = Convert.ToDouble(latLng[1]);

                if (latitude > 90 || latitude < -90) return true;
                return longitude > 180 || longitude < -180;
            }
            catch (Exception )
            {
                return true;
            }
        }

        public string Message  => "Location must be valid combination of latitude & longitude values";
    }
}