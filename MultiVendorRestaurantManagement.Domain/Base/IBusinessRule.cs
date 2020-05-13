namespace MultiVendorRestaurantManagement.Domain.Base
{
    public interface IBusinessRule
    {
        string ErrorMessage { get; }
        bool IsBroken();
    }
}