using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class ChangedVariantsAndAddOnToOwnedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                "PK_Variant",
                "Variant");

            migrationBuilder.DropIndex(
                "IX_Variant_FoodId",
                "Variant");

            migrationBuilder.DropPrimaryKey(
                "PK_AddOn",
                "AddOn");

            migrationBuilder.DropIndex(
                "IX_AddOn_FoodId",
                "AddOn");

            migrationBuilder.AlterColumn<string>(
                "NameEng",
                "Variant",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Variant",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                "FoodId",
                "Variant",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AddOn",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                "FoodId",
                "AddOn",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "AddOn",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                "PK_Variant",
                "Variant",
                new[] {"FoodId", "Id"});

            migrationBuilder.AddPrimaryKey(
                "PK_AddOn",
                "AddOn",
                new[] {"FoodId", "Id"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                "PK_Variant",
                "Variant");

            migrationBuilder.DropPrimaryKey(
                "PK_AddOn",
                "AddOn");

            migrationBuilder.AlterColumn<string>(
                "NameEng",
                "Variant",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Variant",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                "FoodId",
                "Variant",
                "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AddOn",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "AddOn",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                "FoodId",
                "AddOn",
                "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                "PK_Variant",
                "Variant",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_AddOn",
                "AddOn",
                "Id");

            migrationBuilder.CreateIndex(
                "IX_Variant_FoodId",
                "Variant",
                "FoodId");

            migrationBuilder.CreateIndex(
                "IX_AddOn_FoodId",
                "AddOn",
                "FoodId");
        }
    }
}