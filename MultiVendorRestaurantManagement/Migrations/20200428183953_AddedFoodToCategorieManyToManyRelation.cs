using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class AddedFoodToCategorieManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_Food_FoodId",
                table: "FoodCategories");

            migrationBuilder.DropTable(
                name: "RestaurantCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "NameEng",
                table: "FoodCategories");

            migrationBuilder.RenameTable(
                name: "FoodCategories",
                newName: "FoodCategory");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCategories_FoodId",
                table: "FoodCategory",
                newName: "IX_FoodCategory_FoodId");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "FoodCategory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodCategory",
                table: "FoodCategory",
                columns: new[] { "CategoryId", "FoodId" });

            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategory_Categories_CategoryId",
                table: "FoodCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategory_Food_FoodId",
                table: "FoodCategory",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategory_Categories_CategoryId",
                table: "FoodCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategory_Food_FoodId",
                table: "FoodCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodCategory",
                table: "FoodCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoodCategory");

            migrationBuilder.RenameTable(
                name: "FoodCategory",
                newName: "FoodCategories");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCategory_FoodId",
                table: "FoodCategories",
                newName: "IX_FoodCategories_FoodId");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "FoodCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEng",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RestaurantCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategories_RestaurantId",
                table: "RestaurantCategories",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_Food_FoodId",
                table: "FoodCategories",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
