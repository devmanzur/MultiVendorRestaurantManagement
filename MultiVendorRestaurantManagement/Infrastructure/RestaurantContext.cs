using Common.Invariants;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.City;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Domain.Restaurants.Restaurant> Restaurants { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(builder =>
                {
                    builder.Property(x => x.Name).IsRequired();
                    builder.Property(x => x.IsVeg).IsRequired();
                    builder.Property(x => x.IsNonVeg).IsRequired();
                    builder.Property(x => x.IsGlutenFree).IsRequired();
                    builder.Property(p => p.UnitPrice)
                        .IsRequired()
                        .HasConversion(p => p.Value, p => MoneyValue.Of(p));
                    builder.Property(p => p.OldUnitPrice)
                        .IsRequired()
                        .HasConversion(p => p.Value, p => MoneyValue.Of(p));
                    builder.Property(x => x.Type)
                        .IsRequired()
                        .HasConversion<string>();
                    builder.Property(x => x.Status)
                        .IsRequired()
                        .HasConversion<string>();

                    builder.HasMany(x => x.Categories)
                        .WithOne()
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.Metadata
                        .FindNavigation("Categories")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);

                    builder.HasMany(x => x.Variants)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade);
                    builder.Metadata
                        .FindNavigation("Variants")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);

                    builder.HasMany(x => x.AddOns)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.Metadata
                        .FindNavigation("AddOns")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            );

            modelBuilder.Entity<Variant>()
                .Property(x => x.Price)
                .HasConversion(p => p.Value, p => MoneyValue.Of(p));

            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasMany(x => x.Items)
                    .WithOne(v => v.Order)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                builder.HasOne(x => x.Detail);
                builder.Property(x => x.State)
                    .HasConversion<string>();
                builder.Property(x => x.Type)
                    .HasConversion<string>();
                builder.Property(x => x.PaymentType)
                    .HasConversion<string>();
                builder.Property(p => p.PayableAmount)
                    .HasConversion(p => p.Value, p => MoneyValue.Of(p));
                builder.Property(p => p.TotalAmount)
                    .HasConversion(p => p.Value, p => MoneyValue.Of(p));
            });

            modelBuilder.Entity<OrderDetail>(builder =>
            {
                builder.Property(x => x.DeliveryLocation)
                    .HasConversion(x => $"{x.Latitude},{x.Longitude}", x => new LocationValue(x));
            });

            modelBuilder.Entity<City>(builder =>
            {
                builder.HasMany(x => x.Localities)
                    .WithOne(x => x.City)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Locality>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();

                builder.Property(x => x.Code)
                    .IsRequired();
            });

            modelBuilder.Entity<Domain.Restaurants.Restaurant>(builder =>
                {
                    builder.Property(x => x.Name)
                        .IsRequired();
                    builder.Property(x => x.PhoneNumberNumber)
                        .IsRequired()
                        .HasConversion(x => x.GetCompletePhoneNumber(),
                            p => PhoneNumberValue.Of(SupportedCountryCode.Italy, p));
                    builder.HasOne(x => x.Locality)
                        .WithMany()
                        .IsRequired();
                    builder.Property(x => x.OpeningHour)
                        .IsRequired();
                    builder.Property(x => x.ClosingHour)
                        .IsRequired();
                    builder.Property(x => x.State)
                        .IsRequired()
                        .HasConversion<string>();

                    builder.Property(x => x.SubscriptionType)
                        .IsRequired()
                        .HasConversion<string>();
                    builder.Property(x => x.ContractStatus)
                        .IsRequired()
                        .HasConversion<string>();

                    builder.HasOne(x => x.PricingPolicy);

                    builder.HasMany(x => x.Categories)
                        .WithOne()
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.Metadata
                        .FindNavigation("Categories")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);

                    builder.HasMany(x => x.Foods)
                        .WithOne(f => f.Restaurant)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.Metadata
                        .FindNavigation("Foods")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);

                    builder.HasMany(x => x.Menus)
                        .WithOne(f => f.Restaurant)
                        .OnDelete(DeleteBehavior.Cascade);
                    builder.Metadata
                        .FindNavigation("Menus")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
                    builder.HasMany(x => x.Orders)
                        .WithOne(f => f.Restaurant)
                        .OnDelete(DeleteBehavior.Cascade);
                    builder.Metadata
                        .FindNavigation("Orders")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            );

            modelBuilder.Entity<Promotion>(builder =>
            {
                builder.HasMany(x => x.Items)
                    .WithOne(x => x.Promotion)
                    .OnDelete(DeleteBehavior.NoAction)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                builder.Metadata
                    .FindNavigation("Items")
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Review>(builder =>
                {
                    builder.Property(x => x.UserPhoneNumber)
                        .HasConversion(x => x.GetCompletePhoneNumber(),
                            p => PhoneNumberValue.Of(SupportedCountryCode.Italy, p));
                }
            );
            modelBuilder.Entity<AddOn>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<OrderItem>(x =>
            {
                x.Property(p => p.Total)
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.Discount)
                    .HasColumnType("decimal(18,4)");
            });
            modelBuilder.Entity<PricingPolicy>(x =>
            {
                x.Property(p => p.MinimumCharge)
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.MaximumCharge)
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.FixedCharge)
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.AdditionalPrice)
                    .HasColumnType("decimal(18,4)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}