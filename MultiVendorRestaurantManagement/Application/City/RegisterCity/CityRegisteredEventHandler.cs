﻿using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.City.RegisterCity
{
    public class CityRegisteredEventHandler : INotificationHandler<CityRegisteredEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly RestaurantContext _context;

        public CityRegisteredEventHandler(DocumentCollection collection, RestaurantContext context)
        {
            _collection = collection;
            _context = context;
        }

        public async Task Handle(CityRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == notification.Name, cancellationToken);

            if (city.HasValue())
            {
                await _collection.CityCollection.InsertOneAsync(
                    new CityDocument(city.Id, city.Code, city.Name, city.NameEng),
                    cancellationToken);
            }
        }
    }
}