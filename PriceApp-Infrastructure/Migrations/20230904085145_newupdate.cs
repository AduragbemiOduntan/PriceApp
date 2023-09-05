using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingOuts_MaterialEstimates_MaterialEstimateId",
                table: "SettingOuts");

            migrationBuilder.DropIndex(
                name: "IX_SettingOuts_MaterialEstimateId",
                table: "SettingOuts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1963e34a-caf5-4b59-a8df-cba28bcc27df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c6eba1-3d1f-4f21-9d10-d793e70efa5c");

            migrationBuilder.DropColumn(
                name: "MaterialEstimateId",
                table: "SettingOuts");

            migrationBuilder.AddColumn<int>(
                name: "SettingOutStageId",
                table: "MaterialEstimates",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4831), new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4901), new DateTime(2023, 9, 4, 9, 51, 44, 873, DateTimeKind.Local).AddTicks(4902) });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstimates_SettingOutStageId",
                table: "MaterialEstimates",
                column: "SettingOutStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstimates_SettingOuts_SettingOutStageId",
                table: "MaterialEstimates",
                column: "SettingOutStageId",
                principalTable: "SettingOuts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstimates_SettingOuts_SettingOutStageId",
                table: "MaterialEstimates");

            migrationBuilder.DropIndex(
                name: "IX_MaterialEstimates_SettingOutStageId",
                table: "MaterialEstimates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af955ebb-d6ff-477b-879b-1dec0829627b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b3b549-5d6e-4bd1-8699-6bc1c3ca8192");

            migrationBuilder.DropColumn(
                name: "SettingOutStageId",
                table: "MaterialEstimates");

            migrationBuilder.AddColumn<int>(
                name: "MaterialEstimateId",
                table: "SettingOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SettingOuts_MaterialEstimates_MaterialEstimateId",
                table: "SettingOuts",
                column: "MaterialEstimateId",
                principalTable: "MaterialEstimates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
