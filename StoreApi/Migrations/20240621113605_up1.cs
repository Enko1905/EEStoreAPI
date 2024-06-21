using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApi.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SubCategoryStasus",
                table: "SubCategories",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MainCategoryStasus",
                table: "MainCategories",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CategoryStasus",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryStasus",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "MainCategoryStasus",
                table: "MainCategories");

            migrationBuilder.DropColumn(
                name: "CategoryStasus",
                table: "Categories");
        }
    }
}
