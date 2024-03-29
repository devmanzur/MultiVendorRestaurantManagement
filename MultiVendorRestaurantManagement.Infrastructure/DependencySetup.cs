﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.ImageManager;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public static class DependencySetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestaurantManagementContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventDispatcher>();
            services.AddScoped<IImageService, MinioImageUploadService>();
            services.AddScoped<ITableDataProvider, TableDataProvider>();
            services.AddScoped<DocumentCollection>();
        }
    }
}