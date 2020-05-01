using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class AddedCategorieToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Locality",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locality",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "RestaurantCategory",
                columns: table => new
                {
                    RestaurantId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => new { x.CategoryId, x.RestaurantId });
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
                name: "IX_RestaurantCategory_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DropIndex(
                name: "IX_Locality_Code",
                table: "Locality");

            migrationBuilder.DropIndex(
                name: "IX_Locality_Name",
                table: "Locality");

            migrationBuilder.DropIndex(
                name: "IX_Locality_NameEng",
                table: "Locality");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Code",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_NameEng",
                table: "Cities");

            migrationBuilder.AddColumn<long>(
                name: "AreaId",
                table: "Restaurants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Locality",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locality",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
