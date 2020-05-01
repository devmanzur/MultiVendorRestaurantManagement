using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Restaurants;

namespace MultiVendorRestaurantManagement.Infrastructure.Infrastructure.EntityFramework
{
    public interface IContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}