using Common.Invariants;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Orders;
using MultiVendorRestaurantManagement.Domain.Promotions;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Infrastructure.EntityFramework
{
    public class RestaurantManagementContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public RestaurantManagementContext(DbContextOptions<RestaurantManagementContext> options)
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
                    builder.Property(x => x.ImageUrl).IsRequired();

                    builder.HasIndex(u => u.Name);

                    builder.Property(p => p.UnitPrice)
                        .IsRequired()
                        .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
                    builder.Property(p => p.OldUnitPrice)
                        .IsRequired()
                        .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
                    builder.Property(x => x.Type)
                        .IsRequired()
                        .HasConversion<string>();
                    builder.Property(x => x.Status)
                        .IsRequired()
                        .HasConversion<string>();

                    builder.HasMany(x => x.Variants)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

                    builder.HasMany(x => x.AddOns)
                        .WithOne(v => v.Food)
                        .OnDelete(DeleteBehavior.Cascade)
                        .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);


                    builder.Metadata
                        .FindNavigation("Tags")
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            );

            modelBuilder.Entity<Variant>(builder =>
            {
                builder.Property(x => x.Price)
                    .IsRequired()
                    .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
                builder.Property(x => x.OldPrice)
                    .IsRequired()
                    .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
                builder.Property(x => x.Name)
                    .IsRequired();
                builder.Property(x => x.NameEng)
                    .IsRequired();
                builder.Property(x => x.Description)
                    .IsRequired();
                builder.Property(x => x.DescriptionEng)
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasMany(x => x.Items)
                    .WithOne(v => v.Order)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                builder.HasOne(x => x.Detail);
                builder.Property(x => x.State)
                    .IsRequired()
                    .HasConversion<string>();
                builder.Property(x => x.Type)
                    .IsRequired()
                    .HasConversion<string>();
                builder.Property(x => x.PaymentType)
                    .IsRequired()
                    .HasConversion<string>();
                builder.Property(p => p.PayableAmount)
                    .IsRequired()
                    .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
                builder.Property(p => p.TotalAmount)
                    .IsRequired()
                    .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
            });

            modelBuilder.Entity<OrderDetail>(builder =>
            {
                builder.Property(x => x.Address)
                    .IsRequired();
                builder.Property(x => x.CustomerName)
                    .IsRequired();
                builder.Property(x => x.ContactNumber)
                    .IsRequired();
                builder.Property(x => x.DeliveryLocationCustom)
                    .IsRequired()
                    .HasConversion(x => $"{x.Latitude},{x.Longitude}", x => new LocationCustomValue(x));
            });

            modelBuilder.Entity<City>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();
                builder.Property(x => x.NameEng)
                    .IsRequired();
                builder.Property(x => x.Code)
                    .IsRequired();

                builder.HasIndex(u => u.Name)
                    .IsUnique();
                builder.HasIndex(u => u.NameEng)
                    .IsUnique();
                builder.HasIndex(u => u.Code)
                    .IsUnique();

                builder.HasMany(x => x.Localities)
                    .WithOne(x => x.City)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Locality>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();

                builder.Property(x => x.NameEng)
                    .IsRequired();

                builder.Property(x => x.Code)
                    .IsRequired();

                builder.HasIndex(u => u.Name)
                    .IsUnique();
                builder.HasIndex(u => u.NameEng)
                    .IsUnique();
                builder.HasIndex(u => u.Code)
                    .IsUnique();
            });

            modelBuilder.Entity<Restaurant>(builder =>
                {
                    builder.HasIndex(u => u.Name)
                        .IsUnique();
                    builder.HasIndex(u => u.PhoneNumberCustom)
                        .IsUnique();
                    builder.Property(x => x.Name)
                        .IsRequired();
                    builder.Property(x => x.PhoneNumberCustom)
                        .IsRequired()
                        .HasConversion(x => x.GetCompletePhoneNumber(),
                            p => PhoneNumberCustomValue.Of(SupportedCountryCode.Italy, p));
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

            modelBuilder.Entity<Menu>(builder =>
            {
                builder.Property(x => x.Name).IsRequired();
                builder.HasIndex(u => u.Name)
                    .IsUnique();
                builder.HasIndex(u => u.NameEng)
                    .IsUnique();
            });
            modelBuilder.Entity<Promotion>(builder =>
            {
                builder.Property(x => x.StartDate)
                    .IsRequired();
                builder.Property(x => x.Description)
                    .IsRequired();
                builder.Property(x => x.Name)
                    .IsRequired();
                builder.Property(x => x.ImageUrl)
                    .IsRequired();
                builder.Property(x => x.EndDate)
                    .IsRequired();

                builder.Property(x=>x.FixedDiscountAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.MinimumBillAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.MaximumDiscountAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.DiscountPercentage)
                    .HasColumnType("decimal(18,4)");
                
                builder.HasIndex(x => x.Name)
                    .IsUnique();
                builder.HasIndex(x => x.EndDate);
                builder.Property("_items").HasColumnName("Items");
                builder.HasMany(x => x.CouponCodes)
                    .WithOne(x=>x.Promotion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Deal>(builder =>
            {
                builder.Property(x => x.StartDate)
                    .IsRequired();
                builder.Property(x => x.Description)
                    .IsRequired();
                builder.Property(x => x.Name)
                    .IsRequired();
                builder.Property(x => x.ImageUrl)
                    .IsRequired();
                builder.Property(x => x.EndDate)
                    .IsRequired();
                builder.Property(x => x.MinimumBillAmount)
                    .IsRequired();
                builder.Property(x => x.MinimumItemQuantity)
                    .IsRequired();
                builder.Property(x => x.IsFixedDiscount)
                    .IsRequired();
                builder.Property(x => x.IsPackageDeal)
                    .IsRequired();

                builder.Property(x=>x.FixedDiscountAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.MinimumBillAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.MaximumBillAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.MaximumDiscountAmount)
                    .HasColumnType("decimal(18,4)");
                builder.Property(x=>x.DiscountPercentage)
                    .HasColumnType("decimal(18,4)");
                
                builder.HasIndex(x => x.Name)
                    .IsUnique();
                builder.HasIndex(x => x.EndDate);
                builder.HasIndex(x => x.StartDate);

                builder.HasMany(x => x.Items)
                    .WithOne(x => x.Deal)
                    .OnDelete(DeleteBehavior.SetNull)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);


            });
            
            modelBuilder.Entity<CouponCode>(builder =>
            {
                builder.HasIndex(x => x.Code);
                builder.HasIndex(x => x.Username);
                builder.Property(x => x.GeneratedAt)
                    .IsRequired();
                builder.Property(x => x.Code)
                    .IsRequired();
                builder.Property(x => x.CreatedBy)
                    .IsRequired();
            });

            modelBuilder.Entity<Review>(builder =>
                {
                    builder.Property(x => x.StarRate)
                        .IsRequired();
                    builder.Property(x => x.UserPhoneNumberCustom)
                        .IsRequired();
                    builder.Property(x => x.ItemId)
                        .IsRequired();
                    builder.Property(x => x.UserPhoneNumberCustom)
                        .HasConversion(x => x.GetCompletePhoneNumber(),
                            p => PhoneNumberCustomValue.Of(SupportedCountryCode.Italy, p));
                }
            );
            modelBuilder.Entity<AddOn>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();

                builder.Property(x => x.Description)
                    .IsRequired();

                builder.Property(p => p.Price)
                    .IsRequired()
                    .HasConversion(p => p.Value, p => MoneyCustomValue.Of(p));
            });

            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.Property(x => x.Quantity)
                    .IsRequired();
                builder.Property(x => x.FoodId)
                    .IsRequired();
                builder.Property(x => x.FoodName)
                    .IsRequired();
                builder.Property(p => p.Total)
                    .IsRequired()
                    .HasColumnType("decimal(18,4)");
                builder.Property(p => p.Discount)
                    .HasColumnType("decimal(18,4)");
            });
            modelBuilder.Entity<PricingPolicy>(x =>
            {
                x.Property(p => p.MinimumCharge)
                    .IsRequired()
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.MaximumCharge)
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.FixedCharge).IsRequired()
                    .HasColumnType("decimal(18,4)");
                x.Property(p => p.AdditionalPrice)
                    .HasColumnType("decimal(18,4)");
            });

            modelBuilder.Entity<Tag>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();

                builder.Property(x => x.NameEng)
                    .IsRequired();
            });

            modelBuilder.Entity<FoodTag>(builder =>
            {
                builder.HasKey(x => new {x.FoodId, x.TagId});

                builder.HasOne(x => x.Food)
                    .WithMany(f => f.Tags)
                    .HasForeignKey(x => x.FoodId);

                builder.HasOne(x => x.Tag)
                    .WithMany(f => f.Foods)
                    .HasForeignKey(x => x.TagId);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.Property(x => x.Name)
                    .IsRequired();
                builder.Property(x => x.NameEng)
                    .IsRequired();
                builder.Property(x => x.ImageUrl)
                    .IsRequired();
                builder.Property(x => x.Categorize)
                    .IsRequired()
                    .HasConversion<string>();

                builder.HasMany(x => x.Foods)
                    .WithOne(x => x.Category)
                    .OnDelete(DeleteBehavior.Restrict)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

                builder.HasMany(x => x.Restaurants)
                    .WithOne(x => x.Category)
                    .OnDelete(DeleteBehavior.Restrict)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}