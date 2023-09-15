using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class anotherupdateToMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "658ba863-f66e-4fd6-8654-6b533b357586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9410523b-f84c-46b5-abdc-20d8b8f1d5e5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18dab17b-ac4e-4e8f-8ee1-9bc1e556b871", null, "Admin", "ADMIN" },
                    { "9aec9e4b-1823-4d95-a415-bd85cba56343", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 18, 59, 55, 724, DateTimeKind.Local).AddTicks(9246), new DateTime(2023, 9, 14, 18, 59, 55, 724, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 18, 59, 55, 724, DateTimeKind.Local).AddTicks(9303), new DateTime(2023, 9, 14, 18, 59, 55, 724, DateTimeKind.Local).AddTicks(9304) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18dab17b-ac4e-4e8f-8ee1-9bc1e556b871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aec9e4b-1823-4d95-a415-bd85cba56343");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "658ba863-f66e-4fd6-8654-6b533b357586", null, "User", "USER" },
                    { "9410523b-f84c-46b5-abdc-20d8b8f1d5e5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 18, 58, 50, 923, DateTimeKind.Local).AddTicks(9139), new DateTime(2023, 9, 14, 18, 58, 50, 923, DateTimeKind.Local).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 18, 58, 50, 923, DateTimeKind.Local).AddTicks(9210), new DateTime(2023, 9, 14, 18, 58, 50, 923, DateTimeKind.Local).AddTicks(9212) });
        }
    }
}
