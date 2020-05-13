using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Foods.FilterFoods;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api")]
    public class FoodsController : BaseController
    {
        public FoodsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("categories/{category}/foods")]
        public async Task<IActionResult> GetFoodsByCategory(long category,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsQuery(paginationQuery, category, "category");
            return await HandleQueryResultFor(query);
        }

        [HttpGet("deals/{deal}/foods")]
        public async Task<IActionResult> GetFoodsByDeal(long deal,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsQuery(paginationQuery, deal, "deal");
            return await HandleQueryResultFor(query);
        }

        [HttpGet("restaurants/{restaurant}/foods")]
        public async Task<IActionResult> GetFoodsByRestaurant(long restaurant,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsQuery(paginationQuery, restaurant, "restaurant");
            return await HandleQueryResultFor(query);
        }

        [HttpGet("restaurants/{restaurant}/menus/{menu}/foods")]
        public async Task<IActionResult> GetFoodsByMenu(long restaurant, long menu,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsByMenuQuery(paginationQuery, restaurant, menu);
            return await HandleQueryResultFor(query);
        }
    }
}