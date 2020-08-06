using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Food.GetFoodDetail;
using Catalogue.Application.Foods.FilterFoods;
using Catalogue.Application.Foods.FilterFoods.ByMenu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/foods")]
    public class FoodsController : BaseController
    {
        public FoodsController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet("{food}")]
        public async Task<IActionResult> GetFoodDetail(long food)
        {
            var query = new GetFoodDetailQuery(food);
            return await HandleQueryResultFor(query);
        }
    }
}