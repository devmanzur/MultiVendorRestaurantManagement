namespace MultiVendorRestaurantManagement.Domain.Base
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}