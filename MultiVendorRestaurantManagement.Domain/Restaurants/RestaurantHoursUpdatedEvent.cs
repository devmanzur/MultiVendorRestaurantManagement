using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantHoursUpdatedEvent : DomainEventBase
    {
        public RestaurantHoursUpdatedEvent(long id, int openingHour, int closingHour)
        {
            RestaurantId = id;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
        }

        public long RestaurantId { get; }
        public int OpeningHour { get; }
        public int ClosingHour { get; }
    }
}