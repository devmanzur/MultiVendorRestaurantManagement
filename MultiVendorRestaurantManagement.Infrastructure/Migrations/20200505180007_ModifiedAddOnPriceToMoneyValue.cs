﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class ModifiedAddOnPriceToMoneyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AddOn",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AddOn",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
