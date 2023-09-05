using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEscavation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af955ebb-d6ff-477b-879b-1dec0829627b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b3b549-5d6e-4bd1-8699-6bc1c3ca8192");

            migrationBuilder.CreateTable(
                name: "Escavations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Girth = table.Column<double>(type: "float", nullable: false),
                    uniqueProjectId = table.Column<int>(type: "int", nullable: false),
                    PricePerMeter = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escavations", x => x.Id);
                });

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
                columns: new[] { "CreatedAt", "ModifiedAt", "UnitOfMeasurement" },
                values: new object[] { new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4728), new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4802), "Tonnage" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4815), new DateTime(2023, 9, 4, 11, 7, 54, 370, DateTimeKind.Local).AddTicks(4818) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escavations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d5495c9-0688-4777-9caf-4897f78a7d68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7132924f-93d4-42b3-adf9-58bd5d69db4b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af955ebb-d6ff-477b-879b-1dec0829627b", null, "Admin", "ADMIN" },
                    { "f6b3b549-5d6e-4bd1-8699-6bc1c3ca8192", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "UnitOfMeasurement" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4831), new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4895), "Ton" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4901), new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4902) });
        }
    }
}
