using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2530242c-9a63-427e-8632-606662f70f9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4057f750-d920-49d6-b231-b99754c6179b");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355d934c-d185-4fe0-8851-5fb4a57d7f49", null, "Admin", "ADMIN" },
                    { "c51f96bd-a226-42d5-8c6c-3497a6d66dcc", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 16, 25, 31, 852, DateTimeKind.Local).AddTicks(7987));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355d934c-d185-4fe0-8851-5fb4a57d7f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c51f96bd-a226-42d5-8c6c-3497a6d66dcc");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
