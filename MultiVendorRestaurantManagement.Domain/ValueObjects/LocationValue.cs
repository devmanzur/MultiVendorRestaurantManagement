namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class LocationValue : ValueObject
    {
        public LocationValue(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}