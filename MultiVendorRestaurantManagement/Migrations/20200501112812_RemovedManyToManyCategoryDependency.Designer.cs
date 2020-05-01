﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20200501112812_RemovedManyToManyCategoryDependency")]
    partial class RemovedManyToManyCategoryDependency
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Cities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NameEng")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.City.Locality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NameEng")
                        .IsUnique();

                    b.ToTable("Locality");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Common.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Common.Promotion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExclusive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Common.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<int>("StarRate")
                        .HasColumnType("int");

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.AddOn", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("AddOn");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNonVeg")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<long?>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OldUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PromotionId")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRatingsCount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MenuId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Variant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DetailId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PayableAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Orders.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Orders.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<long>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.PricingPolicy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AdditionalPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("FixedCharge")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MaxItemCountInFixedPrice")
                        .HasColumnType("int");

                    b.Property<decimal>("MaximumCharge")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("MinimumCharge")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("PricingPolicy");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("ClosingHour")
                        .HasColumnType("int");

                    b.Property<string>("ContractStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LocalityId")
                        .HasColumnType("bigint");

                    b.Property<long>("ManagerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpeningHour")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumberNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PricingPolicyId")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRatingsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocalityId");

                    b.HasIndex("PricingPolicyId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.City.Locality", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Cities.City", "City")
                        .WithMany("Localities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.AddOn", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Foods.Food", "Food")
                        .WithMany("AddOns")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Food", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Common.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Menu", null)
                        .WithMany("Items")
                        .HasForeignKey("MenuId");

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Common.Promotion", "Promotion")
                        .WithMany("Items")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Foods")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Tag", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Foods.Food", null)
                        .WithMany("Tags")
                        .HasForeignKey("FoodId");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Variant", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Foods.Food", "Food")
                        .WithMany("Variants")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Orders.Order", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Orders.OrderDetail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId");

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Orders.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.Menu", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Common.Category", "Category")
                        .WithMany("Restaurants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.City.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.PricingPolicy", "PricingPolicy")
                        .WithMany()
                        .HasForeignKey("PricingPolicyId");
                });
#pragma warning restore 612, 618
        }
    }
}
