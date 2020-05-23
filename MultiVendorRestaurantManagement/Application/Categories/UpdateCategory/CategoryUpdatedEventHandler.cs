using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Category;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;

namespace MultiVendorRestaurantManagement.Application.Categories.UpdateCategory
{
    public class CategoryUpdatedEventHandler : INotificationHandler<CategoryUpdatedEvent>
    {
        private readonly DocumentCollection _collection;

        public CategoryUpdatedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var category = await _collection.CategoriesCollection.Find(x => x.CategoryId == notification.CategoryId)
                .FirstOrDefaultAsync(cancellationToken);
            if (category.HasValue())
            {
                category.Name = notification.Name;
                category.NameEng = notification.NameEng;
                if (notification.ImageUrl.HasValue()) category.ImageUrl = notification.ImageUrl;
                
                

                await _collection.CategoriesCollection.ReplaceOneAsync(x => x.Id == category.Id, category,
                    cancellationToken: cancellationToken);
            }
        }
    }
}