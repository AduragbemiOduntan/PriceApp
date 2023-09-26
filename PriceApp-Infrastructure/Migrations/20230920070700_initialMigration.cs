﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

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
                    Appellation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingOuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialEstimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appellation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SettingOutStageId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialEstimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialEstimates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialEstimates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialEstimates_SettingOuts_SettingOutStageId",
                        column: x => x.SettingOutStageId,
                        principalTable: "SettingOuts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30a6b18c-22f3-41f7-b4ca-e5b926c0d843", null, "User", "USER" },
                    { "9d2da15f-6d2e-4f00-9605-4f5ec000e090", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "ProductName", "State", "UnitOfMeasurement", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6461), null, "Sharp sand", null, null, "Sharp Sand 5 Ton Trip", "Lagos", "Tonnage", 25000.0 },
                    { 2, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6548), null, "Sharp sand", null, null, "Sharp Sand 5 Ton Trip", "Delta", "Tonnage", 27000.0 },
                    { 3, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6553), null, "Water proof", null, null, "Cement", "Lagos", "Bag", 4000.0 },
                    { 4, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6557), null, "Water proof", null, null, "Cement", "Delta", "Bag", 4200.0 },
                    { 5, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6561), null, "Hard, granular stone used for construction", null, null, "3/4 Granite 5 Ton Trip", "Lagos", "Tonnage", 63400.0 },
                    { 6, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6565), null, "Hard, granular stone used for construction", null, null, "3/4 Granite 5 Ton Trip", "Delta", "Tonnage", 63600.0 },
                    { 7, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6569), null, "", null, null, "Iron Y10 High Yield Local", "Lagos", "Tonnage", 350000.0 },
                    { 8, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6573), null, "", null, null, "Iron Y10 High Yield Local", "Delta", "Tonnage", 380000.0 },
                    { 9, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6577), null, "", null, null, "Iron Y12 High Yield Local", "Lagos", "Tonnage", 380000.0 },
                    { 10, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6581), null, "", null, null, "Iron Y12 High Yield Local", "Delta", "Tonnage", 380000.0 },
                    { 11, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6585), null, "", null, null, "Iron Y16 High Yield Local", "Lagos", "Tonnage", 380000.0 },
                    { 12, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6589), null, "", null, null, "Iron Y16 High Yield Local", "Delta", "Tonnage", 380000.0 },
                    { 13, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6593), null, "", null, null, "9 Inches Block", "Lagos", "Tonnage", 650.0 },
                    { 14, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6597), null, "", null, null, "9 Inches Block", "Delta", "Tonnage", 700.0 },
                    { 15, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6601), null, "Filling sand", null, null, "Laterite 5 Ton Trip", "Lagos", "Tonnage", 6000.0 },
                    { 16, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6605), null, "Filling sand", null, null, "Laterite 5 Ton Trip", "Delta", "Tonnage", 7500.0 },
                    { 17, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6609), null, "Filling sand", null, null, "Plaster Sand 5 Ton Trip", "Lagos", "Tonnage", 5000.0 },
                    { 18, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6613), null, "Filling sand", null, null, "Plaster Sand 5 Ton Trip", "Delta", "Tonnage", 5500.0 },
                    { 19, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6616), null, "For setting-out", null, null, "Peg", "Lagos", "Unit", 400.0 },
                    { 20, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6621), null, "For setting-out", null, null, "Peg", "Delta", "Unit", 450.0 },
                    { 21, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6624), null, "For setting-out", null, null, "Profile", "Lagos", "Unit", 650.0 },
                    { 22, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6628), null, "For setting-out", null, null, "Profile", "Delta", "Unit", 650.0 },
                    { 23, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6632), null, "For setting-out", null, null, "Line", "Lagos", "Unit", 900.0 },
                    { 24, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6635), null, "For setting-out", null, null, "Line", "Delta", "Unit", 920.0 },
                    { 25, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6639), null, "For wood work", null, null, "Nail", "Lagos", "Bag", 4000.0 },
                    { 26, new DateTime(2023, 9, 20, 8, 7, 0, 278, DateTimeKind.Local).AddTicks(6643), null, "For wood work", null, null, "Nail", "Lagos", "Bag", 4000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstimates_ProductId",
                table: "MaterialEstimates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstimates_SettingOutStageId",
                table: "MaterialEstimates",
                column: "SettingOutStageId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstimates_UserId",
                table: "MaterialEstimates",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MaterialEstimates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SettingOuts");
        }
    }
}
