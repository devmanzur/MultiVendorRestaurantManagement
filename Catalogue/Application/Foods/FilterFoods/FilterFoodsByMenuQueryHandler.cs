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

namespace Catalogue.Application.Foods.FilterFoods
{
    public class FilterFoodsByMenuQueryHandler : IQueryHandler<FilterFoodsByMenuQuery, Result<IPagedList<FoodMinimalDto>>>
    {
        private readonly DocumentCollection _collection;

        public FilterFoodsByMenuQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<IPagedList<FoodMinimalDto>>> Handle(FilterFoodsByMenuQuery request,
            CancellationToken cancellationToken)
        {
            var foods = await _collection.FoodCollection
                .Find(x => x.RestaurantId == request.RestaurantId && x.MenuId == request.MenuId)
                .SortByDescending(FoodDocument.GetOrderBy(request.OrderBy))
                .Skip(PaginationHelper.Skip(request.PageNumber, request.PageSize))
                .Limit(request.PageSize)
                .Project(Projections.MinimalFoodProjection())
                .ToListAsync(cancellationToken);

            return Result.Ok(foods.ToPagedList(request.PageNumber, request.PageSize));
        }
    }
}