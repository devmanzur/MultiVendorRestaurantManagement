namespace BasketManagement.Domain.Base
{
    public interface IBusinessRule
    {
        string ErrorMessage { get; }
        bool IsBroken();
    }
}