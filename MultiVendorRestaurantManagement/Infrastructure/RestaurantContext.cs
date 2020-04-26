using Microsoft.EntityFrameworkCore;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Domain.Restaurants.Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}