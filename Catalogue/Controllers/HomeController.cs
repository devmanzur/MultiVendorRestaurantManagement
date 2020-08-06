using System.Threading.Tasks;
using Catalogue.Application.Food.GetFoodDetail;
using Catalogue.Application.Home;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeData()
        {
            var query = new GetHomeDataQuery();
            return await HandleQueryResultFor(query);
        }
    }
}