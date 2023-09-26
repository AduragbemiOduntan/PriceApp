﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;

#nullable disable

namespace PriceApp_Infrastructure.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230921202245_secondMigration")]
    partial class secondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ec920c71-06c3-40c1-a50e-54ca79160189",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "4a3931fb-c80a-4898-af77-2d1f7d50f54a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.MaterialEstimate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appellation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int?>("SettingOutStageId")
                        .HasColumnType("int");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SettingOutStageId");

                    b.HasIndex("UserId");

                    b.ToTable("MaterialEstimates");
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8187),
                            Description = "Sharp sand",
                            ProductName = "Sharp Sand 5 Ton Trip",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 25000.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8256),
                            Description = "Sharp sand",
                            ProductName = "Sharp Sand 5 Ton Trip",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 27000.0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8259),
                            Description = "Water proof",
                            ProductName = "Cement",
                            State = "Lagos",
                            UnitOfMeasurement = "Bag",
                            UnitPrice = 4000.0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8262),
                            Description = "Water proof",
                            ProductName = "Cement",
                            State = "Delta",
                            UnitOfMeasurement = "Bag",
                            UnitPrice = 4200.0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8265),
                            Description = "Hard, granular stone used for construction",
                            ProductName = "3/4 Granite 5 Ton Trip",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 63400.0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8268),
                            Description = "Hard, granular stone used for construction",
                            ProductName = "3/4 Granite 5 Ton Trip",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 63600.0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8271),
                            Description = "",
                            ProductName = "Iron Y10 High Yield Local",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 350000.0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8275),
                            Description = "",
                            ProductName = "Iron Y10 High Yield Local",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 380000.0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8277),
                            Description = "",
                            ProductName = "Iron Y12 High Yield Local",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 380000.0
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8280),
                            Description = "",
                            ProductName = "Iron Y12 High Yield Local",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 380000.0
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8342),
                            Description = "",
                            ProductName = "Iron Y16 High Yield Local",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 380000.0
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8345),
                            Description = "",
                            ProductName = "Iron Y16 High Yield Local",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 380000.0
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8348),
                            Description = "",
                            ProductName = "9 Inches Block",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 650.0
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8351),
                            Description = "",
                            ProductName = "9 Inches Block",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 700.0
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8354),
                            Description = "Filling sand",
                            ProductName = "Laterite 5 Ton Trip",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 6000.0
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8357),
                            Description = "Filling sand",
                            ProductName = "Laterite 5 Ton Trip",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 7500.0
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8360),
                            Description = "Filling sand",
                            ProductName = "Plaster Sand 5 Ton Trip",
                            State = "Lagos",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 5000.0
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8363),
                            Description = "Filling sand",
                            ProductName = "Plaster Sand 5 Ton Trip",
                            State = "Delta",
                            UnitOfMeasurement = "Tonnage",
                            UnitPrice = 5500.0
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8365),
                            Description = "For setting-out",
                            ProductName = "Peg",
                            State = "Lagos",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 400.0
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8368),
                            Description = "For setting-out",
                            ProductName = "Peg",
                            State = "Delta",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 450.0
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8371),
                            Description = "For setting-out",
                            ProductName = "Profile",
                            State = "Lagos",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 650.0
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8373),
                            Description = "For setting-out",
                            ProductName = "Profile",
                            State = "Delta",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 650.0
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8376),
                            Description = "For setting-out",
                            ProductName = "Line",
                            State = "Lagos",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 900.0
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8380),
                            Description = "For setting-out",
                            ProductName = "Line",
                            State = "Delta",
                            UnitOfMeasurement = "Unit",
                            UnitPrice = 920.0
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8382),
                            Description = "For wood work",
                            ProductName = "Nail",
                            State = "Lagos",
                            UnitOfMeasurement = "Bag",
                            UnitPrice = 4000.0
                        },
                        new
                        {
                            Id = 26,
                            CreatedAt = new DateTime(2023, 9, 21, 21, 22, 45, 112, DateTimeKind.Local).AddTicks(8385),
                            Description = "For wood work",
                            ProductName = "Nail",
                            State = "Lagos",
                            UnitOfMeasurement = "Bag",
                            UnitPrice = 4000.0
                        });
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.SettingOutStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appellation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BuidingSetbackPermeter")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LineDerivedEstimatedCost")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NailDerivedEstimatedCost")
                        .HasColumnType("float");

                    b.Property<double>("PegDerivedEstimatedCost")
                        .HasColumnType("float");

                    b.Property<double>("ProfileDerivedEstimatedCost")
                        .HasColumnType("float");

                    b.Property<double>("TotalCostEstimate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SettingOuts");
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PriceApp_Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PriceApp_Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceApp_Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PriceApp_Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.MaterialEstimate", b =>
                {
                    b.HasOne("PriceApp_Domain.Entities.Product", null)
                        .WithMany("MaterialEstimate")
                        .HasForeignKey("ProductId");

                    b.HasOne("PriceApp_Domain.Entities.SettingOutStage", null)
                        .WithMany("MaterialEstimates")
                        .HasForeignKey("SettingOutStageId");

                    b.HasOne("PriceApp_Domain.Entities.User", null)
                        .WithMany("MaterialEstimate")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.Product", b =>
                {
                    b.Navigation("MaterialEstimate");
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.SettingOutStage", b =>
                {
                    b.Navigation("MaterialEstimates");
                });

            modelBuilder.Entity("PriceApp_Domain.Entities.User", b =>
                {
                    b.Navigation("MaterialEstimate");
                });
#pragma warning restore 612, 618
        }
    }
}
