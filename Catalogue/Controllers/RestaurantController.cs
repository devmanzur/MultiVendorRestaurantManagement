using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Foods.FilterFoods;
using Catalogue.Application.Foods.FilterFoods.ByMenu;
using Catalogue.Application.Restaurants.GetRestaurants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : BaseController
    {
        public RestaurantController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(GeneralPaginationQuery paginationQuery)
        {
            var query = new GetRestaurantsQuery(paginationQuery);
            return await HandleQueryResultFor(query);
        }
        
        [HttpGet("{restaurant}/menus/{menu}/foods")]
        public async Task<IActionResult> GetFoodsByMenu(long restaurant, long menu,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsByMenuQuery(paginationQuery, restaurant, menu);
            return await HandleQueryResultFor(query);
        }
        
        [HttpGet("{restaurant}/foods")]
        public async Task<IActionResult> GetFoodsByRestaurant(long restaurant,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsQuery(paginationQuery, restaurant, "restaurant");
            return await HandleQueryResultFor(query);
        }
    }
}