using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoyName" },
                values: new object[] { 2, "Demo Category2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoyName" },
                values: new object[] { 3, "Demo Category3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateTime", "Description", "Price", "ProductName", "Stok" },
                values: new object[] { 2, 2, new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1509), "Demo Description_1", 0m, "Demo Product Name_1", 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateTime", "Description", "Price", "ProductName", "Stok" },
                values: new object[] { 3, 3, new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1510), "Demo Description_2", 0m, "Demo Product Name_2", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 5, 1, 0, 54, 874, DateTimeKind.Local).AddTicks(9881));
        }
    }
}
