using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class AddedManyToManyTagNavigationToFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Tag_Food_FoodId",
                "Tag");

            migrationBuilder.DropPrimaryKey(
                "PK_Tag",
                "Tag");

            migrationBuilder.DropIndex(
                "IX_Tag_FoodId",
                "Tag");

            migrationBuilder.DropColumn(
                "FoodId",
                "Tag");

            migrationBuilder.RenameTable(
                "Tag",
                newName: "Tags");

            migrationBuilder.AddPrimaryKey(
                "PK_Tags",
                "Tags",
                "Id");

            migrationBuilder.CreateTable(
                "FoodTag",
                table => new
                {
                    FoodId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTag", x => new {x.FoodId, x.TagId});
                    table.ForeignKey(
                        "FK_FoodTag_Food_FoodId",
                        x => x.FoodId,
                        "Food",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_FoodTag_Tags_TagId",
                        x => x.TagId,
                        "Tags",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_FoodTag_TagId",
                "FoodTag",
                "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "FoodTag");

            migrationBuilder.DropPrimaryKey(
                "PK_Tags",
                "Tags");

            migrationBuilder.RenameTable(
                "Tags",
                newName: "Tag");

            migrationBuilder.AddColumn<long>(
                "FoodId",
                "Tag",
                "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                "PK_Tag",
                "Tag",
                "Id");

            migrationBuilder.CreateIndex(
                "IX_Tag_FoodId",
                "Tag",
                "FoodId");

            migrationBuilder.AddForeignKey(
                "FK_Tag_Food_FoodId",
                "Tag",
                "FoodId",
                "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}