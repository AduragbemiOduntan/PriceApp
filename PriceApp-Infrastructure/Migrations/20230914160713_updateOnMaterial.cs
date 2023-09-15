using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateOnMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d5495c9-0688-4777-9caf-4897f78a7d68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7132924f-93d4-42b3-adf9-58bd5d69db4b");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MaterialEstimates",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "uniqueProjectId",
                table: "Escavations",
                newName: "UniqueProjectId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d047d4c-26b3-4128-9786-1b1a28fd43b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb5049f7-dabb-461f-bf31-f0a63040790e");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "MaterialEstimates",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UniqueProjectId",
                table: "Escavations",
                newName: "uniqueProjectId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d5495c9-0688-4777-9caf-4897f78a7d68", null, "Admin", "ADMIN" },
                    { "7132924f-93d4-42b3-adf9-58bd5d69db4b", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4728), new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4802) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4815), new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4818) });
        }
    }
}
