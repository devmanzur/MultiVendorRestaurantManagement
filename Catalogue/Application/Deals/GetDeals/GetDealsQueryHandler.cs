using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Utils;
using CSharpFunctionalExtensions;
using MongoDB.Driver;

namespace Catalogue.Application.Deals.GetDeals
{
    public class GetDealsQueryHandler : IQueryHandler<GetDealsQuery, Result<IPagedList<DealMinimalDto>>>
    {
        private readonly DocumentCollection _collection;

        public GetDealsQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<IPagedList<DealMinimalDto>>> Handle(GetDealsQuery request,
            CancellationToken cancellationToken)
        {
            var items = await _collection.DealCollection.Find(Filters.EmptyFilter<DealDocument>())
                .SortByDescending(x => x.EndDate)
                .Skip(PaginationHelper.Skip(request.PageNumber, request.PageSize))
                .Limit(request.PageSize)
                .Project(Projections.MinimalDealProjection())
                .ToListAsync(cancellationToken);
            return Result.Ok(items.ToPagedList(request.PageNumber, request.PageSize));
        }
    }
}