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

namespace Catalogue.Application.Restaurants.GetRestaurants
{
    public class
        GetRestaurantsQueryHandler : IQueryHandler<GetRestaurantsQuery, Result<IPagedList<RestaurantMinimalDto>>>
    {
        private readonly DocumentCollection _collection;

        public GetRestaurantsQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<IPagedList<RestaurantMinimalDto>>> Handle(GetRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var restaurants = await _collection.RestaurantsCollection.Find(Filters.EmptyFilter<RestaurantDocument>())
                .SortByDescending(RestaurantDocument.GetOrderBy(request.OrderBy))
                .Skip(PaginationHelper.Skip(request.PageNumber, request.PageSize))
                .Limit(request.PageSize)
                .Project(Projections.MinimalRestaurantProjection())
                .ToListAsync(cancellationToken);

            return Result.Ok(restaurants.ToPagedList(request.PageNumber, request.PageSize));
        }
    }
}