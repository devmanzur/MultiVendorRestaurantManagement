﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    [DbContext(typeof(RestaurantManagementContext))]
    [Migration("20200628191838_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Categories.Category", b =>
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NameEng")
                        .IsUnique();

                    b.ToTable("Categories");
                });

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

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Cities.Locality", b =>
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

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Cuisines.Cuisine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NameEng")
                        .IsUnique();

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Deals.Deal", b =>
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

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FixedDiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("FreeItemQuantityInPackage")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFixedDiscount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPackageDeal")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaximumBillAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("MaximumDiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MaximumItemQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("MinimumBillAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MinimumItemQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PackageSize")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EndDate");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StartDate");

                    b.ToTable("Deals");
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
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<long?>("CuisineId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DealId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientsString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNonVeg")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<long?>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("OldUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalOrderCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalRatingsCount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CuisineId");

                    b.HasIndex("DealId");

                    b.HasIndex("MenuId");

                    b.HasIndex("Name");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.FoodTag", b =>
                {
                    b.Property<long>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("FoodId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("FoodTag");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.Variant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

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

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Promotions.CouponCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<long?>("PromotionId")
                        .HasColumnType("bigint");

                    b.Property<string>("UsedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("PromotionId");

                    b.HasIndex("Username");

                    b.ToTable("CouponCode");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Promotions.Promotion", b =>
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

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FixedDiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFixedDiscount")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaximumDiscountAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MaximumItemQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("MinimumBillAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MinimumItemQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_items")
                        .HasColumnName("Items")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EndDate");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.GeographicLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("GeographicLocation");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameEng")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NameEng")
                        .IsUnique()
                        .HasFilter("[NameEng] IS NOT NULL");

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

                    b.Property<int>("ClosingHour")
                        .HasColumnType("int");

                    b.Property<string>("ContractStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEng")
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OpeningHour")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("LocalityId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("PricingPolicyId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.RestaurantCategory", b =>
                {
                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("RestaurantId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("RestaurantCategory");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.RestaurantCuisine", b =>
                {
                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("CuisineId")
                        .HasColumnType("bigint");

                    b.HasKey("RestaurantId", "CuisineId");

                    b.HasIndex("CuisineId");

                    b.ToTable("RestaurantCuisine");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Cities.Locality", b =>
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
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Categories.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Cuisines.Cuisine", "Cuisine")
                        .WithMany("Foods")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Deals.Deal", "Deal")
                        .WithMany("Items")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Menu", "Menu")
                        .WithMany("Items")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Foods")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Foods.FoodTag", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Foods.Food", "Food")
                        .WithMany("Tags")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Foods.Tag", "Tag")
                        .WithMany("Foods")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Promotions.CouponCode", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Promotions.Promotion", "Promotion")
                        .WithMany("CouponCodes")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.GeographicLocation", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithOne("GeographicLocation")
                        .HasForeignKey("MultiVendorRestaurantManagement.Domain.Restaurants.GeographicLocation", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Cities.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.PricingPolicy", "PricingPolicy")
                        .WithMany()
                        .HasForeignKey("PricingPolicyId");
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.RestaurantCategory", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Categories.Category", "Category")
                        .WithMany("Restaurants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Categories")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiVendorRestaurantManagement.Domain.Restaurants.RestaurantCuisine", b =>
                {
                    b.HasOne("MultiVendorRestaurantManagement.Domain.Cuisines.Cuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiVendorRestaurantManagement.Domain.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Cuisines")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
