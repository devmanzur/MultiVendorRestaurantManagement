namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class UpdateRestaurantHoursRequest
    {
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
    }
}