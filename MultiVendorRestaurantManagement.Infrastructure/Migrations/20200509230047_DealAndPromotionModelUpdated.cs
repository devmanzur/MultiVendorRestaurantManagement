using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class DealAndPromotionModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food");

            migrationBuilder.DropIndex(
                "IX_Food_PromotionId",
                "Food");

            migrationBuilder.DropColumn(
                "IsExclusive",
                "Promotions");

            migrationBuilder.DropColumn(
                "PromotionalCustomers",
                "Promotions");

            migrationBuilder.DropColumn(
                "Discount",
                "Food");

            migrationBuilder.DropColumn(
                "IsOnPromotion",
                "Food");

            migrationBuilder.DropColumn(
                "PromotionId",
                "Food");

            migrationBuilder.AddColumn<decimal>(
                "DiscountPercentage",
                "Promotions",
                "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                "FixedDiscountAmount",
                "Promotions",
                "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                "IsFixedDiscount",
                "Promotions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                "MaximumDiscountAmount",
                "Promotions",
                "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                "MaximumItemQuantity",
                "Promotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                "MinimumBillAmount",
                "Promotions",
                "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                "MinimumItemQuantity",
                "Promotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "Items",
                "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                "DealId",
                "Food",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "TotalOrderCount",
                "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "CouponCode",
                table => new
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
                        "FK_CouponCode_Promotions_PromotionId",
                        x => x.PromotionId,
                        "Promotions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Deal",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DescriptionEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    MinimumItemQuantity = table.Column<int>(nullable: false),
                    MaximumItemQuantity = table.Column<int>(nullable: false),
                    MinimumBillAmount = table.Column<decimal>("decimal(18,4)", nullable: false),
                    MaximumBillAmount = table.Column<decimal>(nullable: false),
                    DiscountPercentage = table.Column<decimal>("decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>("decimal(18,4)", nullable: false),
                    FixedDiscountAmount = table.Column<decimal>("decimal(18,4)", nullable: false),
                    IsFixedDiscount = table.Column<bool>(nullable: false),
                    IsPackageDeal = table.Column<bool>(nullable: false),
                    PackageSize = table.Column<int>(nullable: false),
                    FreeItemQuantityInPackage = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Deal", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Food_DealId",
                "Food",
                "DealId");

            migrationBuilder.CreateIndex(
                "IX_CouponCode_Code",
                "CouponCode",
                "Code");

            migrationBuilder.CreateIndex(
                "IX_CouponCode_PromotionId",
                "CouponCode",
                "PromotionId");

            migrationBuilder.CreateIndex(
                "IX_CouponCode_Username",
                "CouponCode",
                "Username");

            migrationBuilder.CreateIndex(
                "IX_Deal_EndDate",
                "Deal",
                "EndDate");

            migrationBuilder.CreateIndex(
                "IX_Deal_Name",
                "Deal",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Deal_StartDate",
                "Deal",
                "StartDate");

            migrationBuilder.AddForeignKey(
                "FK_Food_Deal_DealId",
                "Food",
                "DealId",
                "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Deal_DealId",
                "Food");

            migrationBuilder.DropTable(
                "CouponCode");

            migrationBuilder.DropTable(
                "Deal");

            migrationBuilder.DropIndex(
                "IX_Food_DealId",
                "Food");

            migrationBuilder.DropColumn(
                "DiscountPercentage",
                "Promotions");

            migrationBuilder.DropColumn(
                "FixedDiscountAmount",
                "Promotions");

            migrationBuilder.DropColumn(
                "IsFixedDiscount",
                "Promotions");

            migrationBuilder.DropColumn(
                "MaximumDiscountAmount",
                "Promotions");

            migrationBuilder.DropColumn(
                "MaximumItemQuantity",
                "Promotions");

            migrationBuilder.DropColumn(
                "MinimumBillAmount",
                "Promotions");

            migrationBuilder.DropColumn(
                "MinimumItemQuantity",
                "Promotions");

            migrationBuilder.DropColumn(
                "Items",
                "Promotions");

            migrationBuilder.DropColumn(
                "DealId",
                "Food");

            migrationBuilder.DropColumn(
                "TotalOrderCount",
                "Food");

            migrationBuilder.AddColumn<bool>(
                "IsExclusive",
                "Promotions",
                "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                "PromotionalCustomers",
                "Promotions",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Discount",
                "Food",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "IsOnPromotion",
                "Food",
                "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                "PromotionId",
                "Food",
                "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Food_PromotionId",
                "Food",
                "PromotionId");

            migrationBuilder.AddForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food",
                "PromotionId",
                "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}