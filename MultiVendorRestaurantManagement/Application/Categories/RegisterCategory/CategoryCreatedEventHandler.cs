using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Category;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Categories.RegisterCategory
{
    public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly ITableDataProvider _tableDataProvider;

        public CategoryCreatedEventHandler(ITableDataProvider tableDataProvider, DocumentCollection collection)
        {
            _tableDataProvider = tableDataProvider;
            _collection = collection;
        }

        public async Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            var category = await _tableDataProvider.GetCategoryAsync(notification.CategoryName);
            if (category.HasValue())
                await _collection.CategoriesCollection.InsertOneAsync(new CategoryDocument(category.Id,
                    category.ImageUrl, category.Name, category.NameEng, category.Categorize));
        }
    }
}