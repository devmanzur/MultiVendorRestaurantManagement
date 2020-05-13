using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Categories;
using Catalogue.Application.Categories.GetCategories;
using Catalogue.Common.Cache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ResponseCache(Duration = CacheDuration.DurationInSeconds)]
        public async Task<IActionResult> GetCategories([FromQuery] GeneralPaginationQuery paginationQuery)
        {
            var query = new GetCategoriesQuery(paginationQuery);
            return await HandleQueryResultFor(query);
        }
    }
}