using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Common.Invariants;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Utils;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace Catalogue.Application.Categories.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, Result<IPagedList<CategoryMinimalDto>>>
    {
        private readonly IDistributedCache _cache;
        private readonly DocumentCollection _collection;

        public GetCategoriesQueryHandler(IDistributedCache cache, DocumentCollection collection)
        {
            _cache = cache;
            _collection = collection;
        }
        
        public async Task<Result<IPagedList<CategoryMinimalDto>>> Handle(GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _collection.CategoriesCollection.Find(Filter())
                .SortByDescending(CategoryDocument.GetOrderBy(request.OrderBy))
                .Skip(PaginationHelper.Skip(request.PageNumber, request.PageSize))
                .Limit(request.PageSize)
                .Project(Projections.MinimalCategoryProjection())
                .ToListAsync(cancellationToken);
            
            return Result.Ok(categories.ToPagedList(request.PageNumber, request.PageSize));
        }

        private static Expression<Func<CategoryDocument, bool>> Filter()
        {
            return x => x.Categorize.Equals(Categorize.Food.ToString());
        }
    }
}