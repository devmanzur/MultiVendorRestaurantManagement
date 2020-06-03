using System.Threading.Tasks;
using BasketManagement.Domain.Baskets;
using CSharpFunctionalExtensions;

namespace BasketManagement.Domain.Interfaces
{
    public interface IBasketService
    {
        Task<Result> AddToBasket(string userId, string sessionId, BasketItem item);
        Task<Result> ClearBasket(string userId, string sessionId);
    }
}