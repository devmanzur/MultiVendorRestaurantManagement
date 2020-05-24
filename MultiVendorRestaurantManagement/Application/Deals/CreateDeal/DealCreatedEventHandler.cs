using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Deals
{
    public class DealCreatedEventHandler : INotificationHandler<DealCreatedEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly ITableDataProvider _tableDataProvider;

        public DealCreatedEventHandler(DocumentCollection collection, ITableDataProvider tableDataProvider)
        {
            _collection = collection;
            _tableDataProvider = tableDataProvider;
        }

        public async Task Handle(DealCreatedEvent notification, CancellationToken cancellationToken)
        {
            var data = await _tableDataProvider.GetDeal(notification.DealName);
            if (data.HasValue())
            {
                var deal = new DealDocument(data.Id, data.Name, data.Description, data.DescriptionEng, data.ImageUrl,
                    data.StartDate, data.EndDate, data.IsFixedDiscount, data.IsPackageDeal);

                if (data.IsFixedDiscount)
                    deal.CreateFixedDiscount(data.FixedDiscountAmount, data.MinimumBillAmount,
                        data.MinimumItemQuantity);
                else if (data.IsPackageDeal)
                    deal.CreatePackageDiscount(data.PackageSize, data.FreeItemQuantityInPackage);
                else
                    deal.CreatePercentageDeal(data.DiscountPercentage, data.MaximumDiscountAmount,
                        data.MinimumBillAmount, data.MinimumItemQuantity);

                await _collection.DealCollection.InsertOneAsync(deal, cancellationToken: cancellationToken);
            }
        }
    }
}