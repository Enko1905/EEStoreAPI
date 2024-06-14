using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApi.Migrations
{
    public partial class up3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductsProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductsProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductsProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductsProductId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductsProductId",
                table: "ProductImages",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductsProductId",
                table: "OrderDetails",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductsProductId",
                table: "OrderDetails",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductsProductId",
                table: "ProductImages",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
