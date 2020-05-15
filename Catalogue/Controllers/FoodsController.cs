using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.Application.Foods.FilterFoods;
using Catalogue.Application.Foods.FilterFoods.ByMenu;
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

        
        


    }
}