using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Categorize = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    MinimumItemQuantity = table.Column<int>(nullable: false),
                    MaximumItemQuantity = table.Column<int>(nullable: false),
                    MinimumBillAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumBillAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FixedDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsFixedDiscount = table.Column<bool>(nullable: false),
                    IsPackageDeal = table.Column<bool>(nullable: false),
                    PackageSize = table.Column<int>(nullable: false),
                    FreeItemQuantityInPackage = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: false),
                    Flat = table.Column<string>(nullable: true),
                    HouseNo = table.Column<string>(nullable: true),
                    DeliveryLocation = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PricingPolicy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumCharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumCharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FixedCharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaxItemCountInFixedPrice = table.Column<int>(nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    FixedDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsFixedDiscount = table.Column<bool>(nullable: false),
                    MinimumBillAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimumItemQuantity = table.Column<int>(nullable: false),
                    MaximumItemQuantity = table.Column<int>(nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false),
                    StarRate = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<long>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locality_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponCode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false),
                    IsDelivered = table.Column<bool>(nullable: false),
                    GeneratedAt = table.Column<DateTime>(nullable: false),
                    UsedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    PromotionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponCode_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    LocalityId = table.Column<long>(nullable: false),
                    ManagerId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: false),
                    OpeningHour = table.Column<int>(nullable: false),
                    ClosingHour = table.Column<int>(nullable: false),
                    SubscriptionType = table.Column<string>(nullable: false),
                    ContractStatus = table.Column<string>(nullable: false),
                    PricingPolicyId = table.Column<long>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    TotalRatingsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_PricingPolicy_PricingPolicyId",
                        column: x => x.PricingPolicyId,
                        principalTable: "PricingPolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeographicLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicLocation_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RestaurantId = table.Column<long>(nullable: true),
                    DetailId = table.Column<long>(nullable: true),
                    State = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    PayableAmount = table.Column<decimal>(nullable: false),
                    PaymentType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderDetail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCategory",
                columns: table => new
                {
                    RestaurantId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => new { x.RestaurantId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCuisine",
                columns: table => new
                {
                    RestaurantId = table.Column<long>(nullable: false),
                    CuisineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCuisine", x => new { x.RestaurantId, x.CuisineId });
                    table.ForeignKey(
                        name: "FK_RestaurantCuisine_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCuisine_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<long>(nullable: true),
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OldUnitPrice = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    IsGlutenFree = table.Column<bool>(nullable: false),
                    IsVeg = table.Column<bool>(nullable: false),
                    IsNonVeg = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    IngredientsString = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: true),
                    CuisineId = table.Column<long>(nullable: true),
                    DealId = table.Column<long>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    TotalRatingsCount = table.Column<int>(nullable: false),
                    TotalOrderCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Food_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Food_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Food_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Food_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FoodId = table.Column<long>(nullable: false),
                    FoodName = table.Column<string>(nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddOn",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddOn_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodTag",
                columns: table => new
                {
                    FoodId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTag", x => new { x.FoodId, x.TagId });
                    table.ForeignKey(
                        name: "FK_FoodTag_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OldPrice = table.Column<decimal>(nullable: false),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variant_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddOn_FoodId",
                table: "AddOn",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameEng",
                table: "Categories",
                column: "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Code",
                table: "Cities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_NameEng",
                table: "Cities",
                column: "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CouponCode_Code",
                table: "CouponCode",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCode_PromotionId",
                table: "CouponCode",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCode_Username",
                table: "CouponCode",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_Name",
                table: "Cuisines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_NameEng",
                table: "Cuisines",
                column: "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_EndDate",
                table: "Deals",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_Name",
                table: "Deals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_StartDate",
                table: "Deals",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategoryId",
                table: "Food",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_CuisineId",
                table: "Food",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_DealId",
                table: "Food",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MenuId",
                table: "Food",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Name",
                table: "Food",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantId",
                table: "Food",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTag_TagId",
                table: "FoodTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicLocation_RestaurantId",
                table: "GeographicLocation",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locality_CityId",
                table: "Locality",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_Code",
                table: "Locality",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locality_Name",
                table: "Locality",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locality_NameEng",
                table: "Locality",
                column: "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Name",
                table: "Menu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_NameEng",
                table: "Menu",
                column: "NameEng",
                unique: true,
                filter: "[NameEng] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DetailId",
                table: "Order",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantId",
                table: "Order",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_EndDate",
                table: "Promotions",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_Name",
                table: "Promotions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategory_CategoryId",
                table: "RestaurantCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCuisine_CuisineId",
                table: "RestaurantCuisine",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocalityId",
                table: "Restaurants",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Name",
                table: "Restaurants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PhoneNumber",
                table: "Restaurants",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PricingPolicyId",
                table: "Restaurants",
                column: "PricingPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_FoodId",
                table: "Variant",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOn");

            migrationBuilder.DropTable(
                name: "CouponCode");

            migrationBuilder.DropTable(
                name: "FoodTag");

            migrationBuilder.DropTable(
                name: "GeographicLocation");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DropTable(
                name: "RestaurantCuisine");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "PricingPolicy");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
