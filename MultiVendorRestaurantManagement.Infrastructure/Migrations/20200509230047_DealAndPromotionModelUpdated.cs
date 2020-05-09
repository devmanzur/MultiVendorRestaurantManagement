using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class DealAndPromotionModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_PromotionId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "IsExclusive",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromotionalCustomers",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "IsOnPromotion",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Food");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Promotions",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FixedDiscountAmount",
                table: "Promotions",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixedDiscount",
                table: "Promotions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumDiscountAmount",
                table: "Promotions",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaximumItemQuantity",
                table: "Promotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumBillAmount",
                table: "Promotions",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MinimumItemQuantity",
                table: "Promotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Items",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DealId",
                table: "Food",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalOrderCount",
                table: "Food",
                nullable: false,
                defaultValue: 0);

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
                name: "Deal",
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
                    MaximumBillAmount = table.Column<decimal>(nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FixedDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsFixedDiscount = table.Column<bool>(nullable: false),
                    IsPackageDeal = table.Column<bool>(nullable: false),
                    PackageSize = table.Column<int>(nullable: false),
                    FreeItemQuantityInPackage = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_DealId",
                table: "Food",
                column: "DealId");

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
                name: "IX_Deal_EndDate",
                table: "Deal",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_Name",
                table: "Deal",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deal_StartDate",
                table: "Deal",
                column: "StartDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Deal_DealId",
                table: "Food",
                column: "DealId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Deal_DealId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "CouponCode");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropIndex(
                name: "IX_Food_DealId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "FixedDiscountAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsFixedDiscount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MaximumDiscountAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MaximumItemQuantity",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MinimumBillAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MinimumItemQuantity",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Items",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DealId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "TotalOrderCount",
                table: "Food");

            migrationBuilder.AddColumn<bool>(
                name: "IsExclusive",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PromotionalCustomers",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnPromotion",
                table: "Food",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "PromotionId",
                table: "Food",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_PromotionId",
                table: "Food",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
