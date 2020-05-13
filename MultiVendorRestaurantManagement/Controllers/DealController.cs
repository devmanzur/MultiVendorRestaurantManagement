using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.ApiContract.Deal;
using MultiVendorRestaurantManagement.Application.Deals;
using MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal;
using MultiVendorRestaurantManagement.Application.Deals.CreateDeal;

namespace MultiVendorRestaurantManagement.Controllers
{
    [ApiController]
    [Route("api/deals")]
    public class DealController : BaseController
    {
        public DealController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateDeal([FromForm] CreateDealRequest request)
        {
            var command = new CreateDealCommand(request.Name, request.ImageUrl, request.Description,
                request.DescriptionEng, request.MinimumQuantity, request.MinimumBillAmount,
                request.IsFixedPriceDiscount, request.DiscountAmount, request.DiscountPercentage,
                request.MaximumDiscount, request.StartDate, request.EndDate, request.PackSize, request.FreeItemCount,
                request.IsPackageDeal);
            return HandleActionResultFor(command);
        }

        [HttpPost("{deal}")]
        public Task<IActionResult> AddFoodToDeal(long deal, AddFoodsToDealRequest request)
        {
            var command = new AddFoodToDealCommand(deal, request.Models);
            return HandleActionResultFor(command);
        }
    }
}