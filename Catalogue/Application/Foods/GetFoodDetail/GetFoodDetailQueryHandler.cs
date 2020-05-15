using System.Threading;
using System.Threading.Tasks;
using Catalogue.Application.Food.GetFoodDetail;
using Catalogue.Base;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using MongoDB.Driver;

namespace Catalogue.Application.Foods.GetFoodDetail
{
    public class GetFoodDetailQueryHandler : IQueryHandler<GetFoodDetailQuery, Result<FoodDocument>>
    {
        private readonly DocumentCollection _collection;

        public GetFoodDetailQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<FoodDocument>> Handle(GetFoodDetailQuery request, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(x => x.FoodId == request.FoodId)
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                return Result.Ok(food);
            }

            return Result.Failure<FoodDocument>("not found");
        }
    }
}