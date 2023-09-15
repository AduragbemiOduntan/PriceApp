using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class anotherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d047d4c-26b3-4128-9786-1b1a28fd43b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb5049f7-dabb-461f-bf31-f0a63040790e");

            migrationBuilder.AlterColumn<string>(
                name: "Stage",
                table: "MaterialEstimates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1cece48-e0d6-420f-9f34-9867405fb44b", null, "Admin", "ADMIN" },
                    { "ffb0bf21-3565-4dca-892a-1e529deca1ee", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 17, 21, 20, 107, DateTimeKind.Local).AddTicks(6264), new DateTime(2023, 9, 14, 17, 21, 20, 107, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 17, 21, 20, 107, DateTimeKind.Local).AddTicks(6336), new DateTime(2023, 9, 14, 17, 21, 20, 107, DateTimeKind.Local).AddTicks(6338) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1cece48-e0d6-420f-9f34-9867405fb44b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb0bf21-3565-4dca-892a-1e529deca1ee");

            migrationBuilder.AlterColumn<string>(
                name: "Stage",
                table: "MaterialEstimates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d047d4c-26b3-4128-9786-1b1a28fd43b0", null, "User", "USER" },
                    { "fb5049f7-dabb-461f-bf31-f0a63040790e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 17, 7, 13, 368, DateTimeKind.Local).AddTicks(8583), new DateTime(2023, 9, 14, 17, 7, 13, 368, DateTimeKind.Local).AddTicks(8631) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 14, 17, 7, 13, 368, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 9, 14, 17, 7, 13, 368, DateTimeKind.Local).AddTicks(8640) });
        }
    }
}
