using System.Threading.Tasks;
using BasketManagement.Domain.Baskets;
using CSharpFunctionalExtensions;

namespace BasketManagement.Domain.Interfaces
{
    public interface IBasketService
    {
        Task<Result> AddToBasket(string userId, string sessionId, BasketItem item);
        Task<Result> ClearBasket(string userId, string sessionId);
        Task<Basket> GetBasket(string userId, string sessionId);
        Task<Result> RemoveFromBasket(string user, string session, long foodId, int quantity);
    }
}