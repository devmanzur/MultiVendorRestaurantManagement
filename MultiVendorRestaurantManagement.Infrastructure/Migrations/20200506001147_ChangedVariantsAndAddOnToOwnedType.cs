using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class ChangedVariantsAndAddOnToOwnedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.DropIndex(
                name: "IX_Variant_FoodId",
                table: "Variant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn");

            migrationBuilder.DropIndex(
                name: "IX_AddOn_FoodId",
                table: "AddOn");

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Variant",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Variant",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "FoodId",
                table: "Variant",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AddOn",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "FoodId",
                table: "AddOn",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AddOn",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                columns: new[] { "FoodId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn",
                columns: new[] { "FoodId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn");

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Variant",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Variant",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FoodId",
                table: "Variant",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AddOn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AddOn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FoodId",
                table: "AddOn",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_FoodId",
                table: "Variant",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AddOn_FoodId",
                table: "AddOn",
                column: "FoodId");
        }
    }
}
