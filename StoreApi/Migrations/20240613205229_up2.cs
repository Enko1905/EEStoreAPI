using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApi.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomAttributes_Products_ProductsProductId",
                table: "ProductCustomAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomAttributes_ProductsProductId",
                table: "ProductCustomAttributes");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProductCustomAttributes");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomAttributes_ProductId",
                table: "ProductCustomAttributes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomAttributes_Products_ProductId",
                table: "ProductCustomAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomAttributes_Products_ProductId",
                table: "ProductCustomAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomAttributes_ProductId",
                table: "ProductCustomAttributes");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProductCustomAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomAttributes_ProductsProductId",
                table: "ProductCustomAttributes",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomAttributes_Products_ProductsProductId",
                table: "ProductCustomAttributes",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
