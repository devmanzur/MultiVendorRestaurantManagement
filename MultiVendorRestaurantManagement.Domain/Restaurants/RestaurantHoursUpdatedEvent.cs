using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantHoursUpdatedEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public int OpeningHour { get; }
        public int ClosingHour { get; }

        public RestaurantHoursUpdatedEvent( long id,  int openingHour,  int closingHour)
        {
            RestaurantId = id;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
        }
    }
}