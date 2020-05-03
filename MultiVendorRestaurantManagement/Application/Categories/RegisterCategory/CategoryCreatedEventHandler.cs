using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Categories.RegisterCategory
{
    public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
    {
        private readonly ITableDataProvider _tableDataProvider;
        private readonly DocumentCollection _collection;

        public CategoryCreatedEventHandler(ITableDataProvider tableDataProvider, DocumentCollection collection)
        {
            _tableDataProvider = tableDataProvider;
            _collection = collection;
        }

        public async Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            var category = await _tableDataProvider.GetCategoryAsync(notification.CategoryName);
            if (category.HasValue())
            {
                await _collection.CategoriesCollection.InsertOneAsync(new CategoryDocument(category.Id,
                    category.ImageUrl, category.Name, category.NameEng, category.Categorize));
            }
        }
    }
}