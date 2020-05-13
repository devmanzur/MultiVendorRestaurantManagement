using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Utils;
using CSharpFunctionalExtensions;
using MongoDB.Driver;

namespace Catalogue.Application.Foods.FilterFoods
{
    public class
        FilterFoodsQueryHandler : IQueryHandler<FilterFoodsQuery, Result<IPagedList<FoodMinimalDto>>>
    {
        private readonly DocumentCollection _collection;

        public FilterFoodsQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<IPagedList<FoodMinimalDto>>> Handle(FilterFoodsQuery request,
            CancellationToken cancellationToken)
        {
            var foods = await _collection.FoodCollection.Find(FilterBy(request))
                .SortByDescending(FoodDocument.GetOrderBy(request.OrderBy))
                .Skip(PaginationHelper.Skip(request.PageNumber, request.PageSize))
                .Limit(request.PageSize)
                .Project(Projections.MinimalFoodProjection())
                .ToListAsync(cancellationToken);

            return Result.Ok(foods.ToPagedList(request.PageNumber, request.PageSize));
        }

        private static Expression<Func<FoodDocument, bool>> FilterBy(FilterFoodsQuery request)
        {
            return request.FilterBy switch
            {
                "category" => x => x.CategoryId == request.FilterValue,
                "deal" => x => x.DealId == request.FilterValue,
                "restaurant" => x => x.RestaurantId == request.FilterValue,
                _ => x => true
            };
        }
    }
}