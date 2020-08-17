using System.Threading.Tasks;
using Catalogue.Infrastracture.Elastic;
using Catalogue.Infrastracture.Mongo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalogue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : BaseController
    {
        private readonly IElasticSearchService _elasticSearchService;
        private readonly DocumentCollection _documentCollection;

        public SearchController(IMediator mediator, IElasticSearchService elasticSearchService, DocumentCollection documentCollection) : base(mediator)
        {
            _elasticSearchService = elasticSearchService;
            _documentCollection = documentCollection;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var items = await _documentCollection.RestaurantsCollection.AsQueryable().ToListAsync();
            await _elasticSearchService.Insert(items);
            return Ok();
        }
    }
}