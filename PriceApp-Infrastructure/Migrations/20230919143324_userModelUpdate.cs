using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f0c0774-ac6d-4b17-91d9-09c0dc7d3c05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca61303a-74b1-40f7-9134-26dfe757657f");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2530242c-9a63-427e-8632-606662f70f9c", null, "Admin", "ADMIN" },
                    { "4057f750-d920-49d6-b231-b99754c6179b", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 33, 24, 233, DateTimeKind.Local).AddTicks(6731));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2530242c-9a63-427e-8632-606662f70f9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4057f750-d920-49d6-b231-b99754c6179b");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f0c0774-ac6d-4b17-91d9-09c0dc7d3c05", null, "Admin", "ADMIN" },
                    { "ca61303a-74b1-40f7-9134-26dfe757657f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 14, 19, 17, 979, DateTimeKind.Local).AddTicks(1785));
        }
    }
}
