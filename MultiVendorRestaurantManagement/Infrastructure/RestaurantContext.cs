using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Domain.Restaurants.Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Restaurants.Restaurant>(builder =>
                {
                    builder.Property(x => x.State)
                        .HasConversion<string>();
                    builder.Property(x => x.SubscriptionType)
                        .HasConversion<string>();
                    builder.Property(x => x.ContractStatus)
                        .HasConversion<string>();
                    builder.HasOne(x => x.PricingPolicy)
                        .WithOne(p => p.Restaurant);
                    builder.HasMany(x => x.FoodList)
                        .WithOne(f => f.Restaurant)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                    builder.HasMany(x => x.MenuList)
                        .WithOne(f => f.Restaurant)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            );

            modelBuilder.Entity<Food>(x =>
                {
                    x.HasOne<Domain.Restaurants.Restaurant>();
                    x.Property(p => p.UnitPrice)
                        .HasConversion(p => p.Value, p => MoneyValue.Of(p));
                    x.Property(p => p.OldUnitPrice)
                        .HasConversion(p => p.Value, p => MoneyValue.Of(p));
                    x.Property(x => x.Type)
                        .HasConversion<string>();
                    x.Property(x => x.Status)
                        .HasConversion<string>();
                    
                    x.HasMany(x => x.Variants)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

                    x.HasMany(x => x.AddOns)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            );

        }
    }
}