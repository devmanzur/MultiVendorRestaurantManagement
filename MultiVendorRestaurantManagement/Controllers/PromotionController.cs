using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Promotion;
using MultiVendorRestaurantManagement.Application.Promotions.AddItems;
using MultiVendorRestaurantManagement.Application.Promotions.CreatePromotion;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/promotions")]
    public class PromotionController : BaseController
    {
        public PromotionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreatePromotion([FromForm] CreatePromotionRequest request)
        {
            var command = new CreatePromotionCommand(request.Name, request.ImageUrl, request.Description,
                request.DescriptionEng, request.MinimumQuantity, request.MinimumBillAmount,
                request.IsFixedPriceDiscount, request.DiscountAmount, request.DiscountPercentage,
                request.MaximumDiscount, request.StartDate, request.EndDate);
            return HandleActionResultFor(command);
        }

        [HttpPost("{promotion}/items")]
        public Task<IActionResult> AddItem(long promotion, AddItemsToPromotionRequest request)
        {
            var command = new AddPromotionalItemsCommand(promotion, request.FoodIds);
            return HandleActionResultFor(command);
        }
    }
}