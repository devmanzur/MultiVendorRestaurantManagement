using Catalogue.Application.Base;
using Catalogue.Base;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Infrastructure.Mongo.Documents;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Food.GetFoodDetail
{
    public class GetFoodDetailQuery : IQuery<Result<FoodDocument>>
    {
        public long FoodId { get; }

        public GetFoodDetailQuery(long foodId)
        {
            FoodId = foodId;
        }
    }
}