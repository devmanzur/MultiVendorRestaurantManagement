using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Categorize = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Cities",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Cities", x => x.Id); });

            migrationBuilder.CreateTable(
                "OrderDetail",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_OrderDetail", x => x.Id); });

            migrationBuilder.CreateTable(
                "PricingPolicy",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumCharge = table.Column<decimal>("decimal(18,4)", nullable: false),
                    MaximumCharge = table.Column<decimal>("decimal(18,4)", nullable: false),
                    FixedCharge = table.Column<decimal>("decimal(18,4)", nullable: false),
                    MaxItemCountInFixedPrice = table.Column<int>(nullable: false),
                    AdditionalPrice = table.Column<decimal>("decimal(18,4)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PricingPolicy", x => x.Id); });

            migrationBuilder.CreateTable(
                "Promotions",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    IsExclusive = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Promotions", x => x.Id); });

            migrationBuilder.CreateTable(
                "Reviews",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: false),
                    StarRate = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Reviews", x => x.Id); });

            migrationBuilder.CreateTable(
                "Locality",
                table => new
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
                        "FK_Locality_Cities_CityId",
                        x => x.CityId,
                        "Cities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Restaurants",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    LocalityId = table.Column<long>(nullable: false),
                    ManagerId = table.Column<long>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    OpeningHour = table.Column<int>(nullable: false),
                    ClosingHour = table.Column<int>(nullable: false),
                    SubscriptionType = table.Column<string>(nullable: false),
                    ContractStatus = table.Column<string>(nullable: false),
                    PricingPolicyId = table.Column<long>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<long>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    TotalRatingsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        "FK_Restaurants_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id");
                    table.ForeignKey(
                        "FK_Restaurants_Locality_LocalityId",
                        x => x.LocalityId,
                        "Locality",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Restaurants_PricingPolicy_PricingPolicyId",
                        x => x.PricingPolicyId,
                        "PricingPolicy",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Menu",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        "FK_Menu_Restaurants_RestaurantId",
                        x => x.RestaurantId,
                        "Restaurants",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Order",
                table => new
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
                        "FK_Order_OrderDetail_DetailId",
                        x => x.DetailId,
                        "OrderDetail",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Order_Restaurants_RestaurantId",
                        x => x.RestaurantId,
                        "Restaurants",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Food",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OldUnitPrice = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    IsGlutenFree = table.Column<bool>(nullable: false),
                    IsVeg = table.Column<bool>(nullable: false),
                    IsNonVeg = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    CategoryId = table.Column<long>(nullable: true),
                    IsOnPromotion = table.Column<bool>(nullable: false),
                    PromotionId = table.Column<long>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    TotalRatingsCount = table.Column<int>(nullable: false),
                    MenuId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        "FK_Food_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id");
                    table.ForeignKey(
                        "FK_Food_Menu_MenuId",
                        x => x.MenuId,
                        "Menu",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Food_Promotions_PromotionId",
                        x => x.PromotionId,
                        "Promotions",
                        "Id");
                    table.ForeignKey(
                        "FK_Food_Restaurants_RestaurantId",
                        x => x.RestaurantId,
                        "Restaurants",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "OrderItem",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>("decimal(18,4)", nullable: false),
                    FoodId = table.Column<long>(nullable: false),
                    FoodName = table.Column<string>(nullable: false),
                    Discount = table.Column<decimal>("decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderItem_Order_OrderId",
                        x => x.OrderId,
                        "Order",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AddOn",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>("decimal(18,4)", nullable: false),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOn", x => x.Id);
                    table.ForeignKey(
                        "FK_AddOn_Food_FoodId",
                        x => x.FoodId,
                        "Food",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Tag",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        "FK_Tag_Food_FoodId",
                        x => x.FoodId,
                        "Food",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Variant",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    NameEng = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.Id);
                    table.ForeignKey(
                        "FK_Variant_Food_FoodId",
                        x => x.FoodId,
                        "Food",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AddOn_FoodId",
                "AddOn",
                "FoodId");

            migrationBuilder.CreateIndex(
                "IX_Cities_Code",
                "Cities",
                "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Cities_Name",
                "Cities",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Cities_NameEng",
                "Cities",
                "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Food_CategoryId",
                "Food",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_Food_MenuId",
                "Food",
                "MenuId");

            migrationBuilder.CreateIndex(
                "IX_Food_Name",
                "Food",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Food_PromotionId",
                "Food",
                "PromotionId");

            migrationBuilder.CreateIndex(
                "IX_Food_RestaurantId",
                "Food",
                "RestaurantId");

            migrationBuilder.CreateIndex(
                "IX_Locality_CityId",
                "Locality",
                "CityId");

            migrationBuilder.CreateIndex(
                "IX_Locality_Code",
                "Locality",
                "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Locality_Name",
                "Locality",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Locality_NameEng",
                "Locality",
                "NameEng",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Menu_RestaurantId",
                "Menu",
                "RestaurantId");

            migrationBuilder.CreateIndex(
                "IX_Order_DetailId",
                "Order",
                "DetailId");

            migrationBuilder.CreateIndex(
                "IX_Order_RestaurantId",
                "Order",
                "RestaurantId");

            migrationBuilder.CreateIndex(
                "IX_OrderItem_OrderId",
                "OrderItem",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_Restaurants_CategoryId",
                "Restaurants",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_Restaurants_LocalityId",
                "Restaurants",
                "LocalityId");

            migrationBuilder.CreateIndex(
                "IX_Restaurants_Name",
                "Restaurants",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Restaurants_PhoneNumber",
                "Restaurants",
                "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Restaurants_PricingPolicyId",
                "Restaurants",
                "PricingPolicyId");

            migrationBuilder.CreateIndex(
                "IX_Tag_FoodId",
                "Tag",
                "FoodId");

            migrationBuilder.CreateIndex(
                "IX_Variant_FoodId",
                "Variant",
                "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AddOn");

            migrationBuilder.DropTable(
                "OrderItem");

            migrationBuilder.DropTable(
                "Reviews");

            migrationBuilder.DropTable(
                "Tag");

            migrationBuilder.DropTable(
                "Variant");

            migrationBuilder.DropTable(
                "Order");

            migrationBuilder.DropTable(
                "Food");

            migrationBuilder.DropTable(
                "OrderDetail");

            migrationBuilder.DropTable(
                "Menu");

            migrationBuilder.DropTable(
                "Promotions");

            migrationBuilder.DropTable(
                "Restaurants");

            migrationBuilder.DropTable(
                "Categories");

            migrationBuilder.DropTable(
                "Locality");

            migrationBuilder.DropTable(
                "PricingPolicy");

            migrationBuilder.DropTable(
                "Cities");
        }
    }
}