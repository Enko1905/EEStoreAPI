using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class init122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoyName" },
                values: new object[] { 1, "Demo Category" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateTime", "Description", "Price", "ProductName", "Stok" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 5, 1, 0, 54, 874, DateTimeKind.Local).AddTicks(9881), "Demo Description", 0m, "Demo Product Name", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
