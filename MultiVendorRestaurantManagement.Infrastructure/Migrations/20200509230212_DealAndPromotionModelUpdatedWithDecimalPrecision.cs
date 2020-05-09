﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class DealAndPromotionModelUpdatedWithDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumBillAmount",
                table: "Deal",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumBillAmount",
                table: "Deal",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
