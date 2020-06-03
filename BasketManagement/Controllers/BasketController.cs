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
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(AddBasketItemRequest request)
        {
            var task = await _basketService.AddToBasket(
                request.UserId,
                request.SessionId,
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

        [HttpDelete]
        public async Task<IActionResult> ClearBasket(ClearBasketRequest request)
        {
            var task = await _basketService.ClearBasket(request.UserId,
                request.SessionId);
            return HandleTaskResult(task);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveBasketItem()
        {
            return Ok("");
        }

        [HttpGet]
        public async Task<IActionResult> ViewBasket()
        {
            return Ok("");
        }
    }
}