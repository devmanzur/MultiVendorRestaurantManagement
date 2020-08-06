using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Deals;
using Catalogue.Application.Foods.FilterFoods;
using Catalogue.Common.Cache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/deals")]
    public class DealsController : BaseController
    {
        public DealsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet] 
        public async Task<IActionResult> GetDeals([FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new GetDealsQuery(paginationQuery);
            return await HandleQueryResultFor(query);
        }
        
        
        [HttpGet("{deal}/foods")]
        public async Task<IActionResult> GetFoodsByDeal(long deal,
            [FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new FilterFoodsQuery(paginationQuery, deal, "deal");
            return await HandleQueryResultFor(query);
        }
        
    }
}