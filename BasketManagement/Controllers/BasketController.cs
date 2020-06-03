using System.Threading.Tasks;
using BasketManagement.ApiContract.Request;
using BasketManagement.Common.Utils;
using BasketManagement.Domain.Baskets;
using BasketManagement.Domain.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace BasketManagement.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("{user}/{session}")]
        public async Task<IActionResult> AddToBasket(string user, string session, AddBasketItemRequest request)
        {
            var task = await _basketService.AddToBasket(
                user,
                session,
                new BasketItem(request.FoodId, request.FoodName, request.ImageUrl,
                    request.UnitPrice, request.Quantity));
            return HandleTaskResult(task);
        }

        private IActionResult HandleTaskResult(Result task)
        {
            if (task.IsSuccess)
            {
                return Ok(Envelope.Ok());
            }

            return BadRequest(Envelope.Error(task.Error));
        }

        [HttpDelete("{user}/{session}")]
        public async Task<IActionResult> ClearBasket(string user, string session)
        {
            var task = await _basketService.ClearBasket(user,
                session);
            return HandleTaskResult(task);
        }

        [HttpDelete("{user}/{session}")]
        public async Task<IActionResult> RemoveBasketItem(string user, string session, RemoveBasketItemRequest request)
        {
            var task = await _basketService.RemoveFromBasket(user, session, request.FoodId, request.Quantity);
            return HandleTaskResult(task);
        }

        [HttpGet("{user}/{session}")]
        public async Task<IActionResult> ViewBasket(string user, string session)
        {
            var basket = await _basketService.GetBasket(user,
                session);
            return Ok(Envelope.Ok(basket));
        }
    }
}