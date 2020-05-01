using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true),
                    HouseNo = table.Column<string>(nullable: true),
                    DeliveryLocation = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true)
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
                    MinimumCharge = table.Column<decimal>(nullable: false),
                    MaximumCharge = table.Column<decimal>(nullable: false),
                    FixedCharge = table.Column<decimal>(nullable: false),
                    MaxItemCountInFixedPrice = table.Column<int>(nullable: false),
                    AdditionalPrice = table.Column<decimal>(nullable: false)
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
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsExclusive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<long>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
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
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumberNumber = table.Column<string>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    LocalityId = table.Column<long>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    OpeningHour = table.Column<int>(nullable: false),
                    ClosingHour = table.Column<int>(nullable: false),
                    SubscriptionType = table.Column<string>(nullable: false),
                    ContractStatus = table.Column<string>(nullable: false),
                    PricingPolicyId = table.Column<long>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
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
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                    TotalAmount = table.Column<decimal>(nullable: true),
                    PayableAmount = table.Column<decimal>(nullable: true),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Restaurants_RestaurantId",
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
                    RestaurantId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OldUnitPrice = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    IsGlutenFree = table.Column<bool>(nullable: false),
                    IsVeg = table.Column<bool>(nullable: false),
                    IsNonVeg = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    IsOnPromotion = table.Column<bool>(nullable: false),
                    PromotionId = table.Column<long>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    MenuId = table.Column<long>(nullable: true),
                    RestaurantId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Food_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Restaurants_RestaurantId1",
                        column: x => x.RestaurantId1,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    FoodId = table.Column<long>(nullable: false),
                    FoodName = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    FoodId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    FoodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
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
                name: "IX_Categories_FoodId",
                table: "Categories",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MenuId",
                table: "Food",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_PromotionId",
                table: "Food",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantId",
                table: "Food",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantId1",
                table: "Food",
                column: "RestaurantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_CityId",
                table: "Locality",
                column: "CityId");

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
                name: "IX_RestaurantCategory_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocalityId",
                table: "Restaurants",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PricingPolicyId",
                table: "Restaurants",
                column: "PricingPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_FoodId",
                table: "Tag",
                column: "FoodId");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Promotions");

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
