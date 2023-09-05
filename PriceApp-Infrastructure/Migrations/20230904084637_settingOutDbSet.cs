using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class settingOutDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80a7ac5c-71b4-4624-951e-b46c140b21cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6ecde71-89a7-4498-ae93-2acb1a181f34");

            migrationBuilder.CreateTable(
                name: "SettingOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PegDerivedEstimatedCost = table.Column<double>(type: "float", nullable: false),
                    ProfileDerivedEstimatedCost = table.Column<double>(type: "float", nullable: false),
                    LineDerivedEstimatedCost = table.Column<double>(type: "float", nullable: false),
                    NailDerivedEstimatedCost = table.Column<double>(type: "float", nullable: false),
                    BuidingSetbackPermeter = table.Column<double>(type: "float", nullable: false),
                    TotalCostEstimate = table.Column<double>(type: "float", nullable: false),
                    UniqueProjectId = table.Column<int>(type: "int", nullable: false),
                    MaterialEstimateId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingOuts_MaterialEstimates_MaterialEstimateId",
                        column: x => x.MaterialEstimateId,
                        principalTable: "MaterialEstimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1963e34a-caf5-4b59-a8df-cba28bcc27df", null, "Admin", "ADMIN" },
                    { "e3c6eba1-3d1f-4f21-9d10-d793e70efa5c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 46, 37, 801, DateTimeKind.Local).AddTicks(3662), new DateTime(2023, 9, 4, 9, 46, 37, 801, DateTimeKind.Local).AddTicks(3716) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 46, 37, 801, DateTimeKind.Local).AddTicks(3723), new DateTime(2023, 9, 4, 9, 46, 37, 801, DateTimeKind.Local).AddTicks(3725) });

            migrationBuilder.CreateIndex(
                name: "IX_SettingOuts_MaterialEstimateId",
                table: "SettingOuts",
                column: "MaterialEstimateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingOuts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1963e34a-caf5-4b59-a8df-cba28bcc27df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c6eba1-3d1f-4f21-9d10-d793e70efa5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80a7ac5c-71b4-4624-951e-b46c140b21cf", null, "User", "USER" },
                    { "b6ecde71-89a7-4498-ae93-2acb1a181f34", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 20, 58, 890, DateTimeKind.Local).AddTicks(5798), new DateTime(2023, 9, 4, 9, 20, 58, 890, DateTimeKind.Local).AddTicks(5863) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 20, 58, 890, DateTimeKind.Local).AddTicks(5873), new DateTime(2023, 9, 4, 9, 20, 58, 890, DateTimeKind.Local).AddTicks(5875) });
        }
    }
}
