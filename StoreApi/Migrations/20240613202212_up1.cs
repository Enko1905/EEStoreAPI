using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApi.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_ProductsProductId",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductsProductId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "MainCategories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "MainCategories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MainCategories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_ProductId",
                table: "ProductVariants",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_ProductId",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProductVariants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "MainCategories",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "MainCategories",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MainCategories",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductsProductId",
                table: "ProductVariants",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_ProductsProductId",
                table: "ProductVariants",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
