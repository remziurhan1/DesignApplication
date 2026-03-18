using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class vhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

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
                name: "CapacityGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InnerDiameter = table.Column<double>(type: "float", nullable: false),
                    MinCapacity = table.Column<double>(type: "float", nullable: false),
                    MaxCapacity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignStandards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignStandards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductCodePrefix = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GasGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ChemicalFormula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MolecularWeight = table.Column<double>(type: "float", nullable: true),
                    CriticalTemperature = table.Column<double>(type: "float", nullable: true),
                    CriticalPressure = table.Column<double>(type: "float", nullable: true),
                    BoilingPoint = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Standard = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Density = table.Column<double>(type: "float(10)", precision: 10, scale: 3, nullable: false),
                    ColdStretchYieldStrength = table.Column<double>(type: "float", nullable: true),
                    ElasticModulus = table.Column<double>(type: "float", nullable: true),
                    YieldFactorK = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SProductGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockMainCodeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMainCodeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockProductGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefix4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    StartNumber = table.Column<int>(type: "int", nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Density = table.Column<double>(type: "float(10)", precision: 10, scale: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTypes", x => x.Id);
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
                name: "CapacityOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CapacityGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CapacityValue = table.Column<double>(type: "float", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultShellLength = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityOptions_CapacityGroups_CapacityGroupId",
                        column: x => x.CapacityGroupId,
                        principalTable: "CapacityGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GasTypeDesignStandards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GasTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignStandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasTypeDesignStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasTypeDesignStandards_DesignStandards_DesignStandardId",
                        column: x => x.DesignStandardId,
                        principalTable: "DesignStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GasTypeDesignStandards_GasTypes_GasTypeId",
                        column: x => x.GasTypeId,
                        principalTable: "GasTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GasTypePressures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GasTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PressureValue = table.Column<double>(type: "float", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasTypePressures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasTypePressures_GasTypes_GasTypeId",
                        column: x => x.GasTypeId,
                        principalTable: "GasTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThermodynamicProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GasTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false),
                    VL = table.Column<double>(type: "float", nullable: false),
                    VG = table.Column<double>(type: "float", nullable: false),
                    HL = table.Column<double>(type: "float", nullable: false),
                    HG = table.Column<double>(type: "float", nullable: false),
                    R = table.Column<double>(type: "float", nullable: false),
                    SL = table.Column<double>(type: "float", nullable: false),
                    SG = table.Column<double>(type: "float", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermodynamicProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThermodynamicProperties_GasTypes_GasTypeId",
                        column: x => x.GasTypeId,
                        principalTable: "GasTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormType = table.Column<int>(type: "int", nullable: false),
                    ThicknessMin = table.Column<double>(type: "float", nullable: false),
                    ThicknessMax = table.Column<double>(type: "float", nullable: false),
                    ProductStandard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeldingFactor = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TargetPrice = table.Column<double>(type: "float(10)", precision: 10, scale: 3, nullable: true),
                    ColdStretchYieldStrength = table.Column<double>(type: "float(10)", precision: 10, scale: 3, nullable: true),
                    SectionArea = table.Column<double>(type: "float(12)", precision: 12, scale: 3, nullable: true),
                    MomentOfInertia = table.Column<double>(type: "float(14)", precision: 14, scale: 3, nullable: true),
                    SectionModulus = table.Column<double>(type: "float(14)", precision: 14, scale: 3, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialForms_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SFeatureValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFeatureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SFeatureValues_SFeatures_SFeatureId",
                        column: x => x.SFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAssemblyGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Step3Letter = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Step4Digit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAssemblyGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SAssemblyGroups_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SGroupFilterRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FluidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGroupFilterRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SGroupFilterRules_Fluids_FluidId",
                        column: x => x.FluidId,
                        principalTable: "Fluids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGroupFilterRules_SCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGroupFilterRules_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrefixIndex = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SProducts_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockSubCodeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockMainCodeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubCodeGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSubCodeGroups_StockMainCodeGroups_StockMainCodeGroupId",
                        column: x => x.StockMainCodeGroupId,
                        principalTable: "StockMainCodeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageTypeProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature_C = table.Column<double>(type: "float", nullable: false),
                    Pressure_bar = table.Column<double>(type: "float", nullable: false),
                    SpecificVolume_Liquid_dm3kg = table.Column<double>(type: "float", nullable: false),
                    SpecificVolume_Gas_m3kg = table.Column<double>(type: "float", nullable: false),
                    Enthalpy_Liquid_kJkg = table.Column<double>(type: "float", nullable: false),
                    Enthalpy_Gas_kJkg = table.Column<double>(type: "float", nullable: false),
                    GasConstant_kJkgK = table.Column<double>(type: "float", nullable: false),
                    Entropy_Liquid_kJkgK = table.Column<double>(type: "float", nullable: false),
                    Entropy_Gas_kJkgK = table.Column<double>(type: "float", nullable: false),
                    StorageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTypeProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageTypeProperties_StorageTypes_StorageTypeId",
                        column: x => x.StorageTypeId,
                        principalTable: "StorageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD2000Calculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    ShellLength = table.Column<double>(type: "float", nullable: false),
                    DesignPressure = table.Column<double>(type: "float", nullable: false),
                    DesignTemperatureMin = table.Column<double>(type: "float", nullable: false),
                    DesignTemperatureMax = table.Column<double>(type: "float", nullable: false),
                    CorrosionAllowance = table.Column<double>(type: "float", nullable: false),
                    WeldJointFactor = table.Column<double>(type: "float", nullable: false),
                    AllowableStress = table.Column<double>(type: "float", nullable: false),
                    ShellAllowableStress = table.Column<double>(type: "float", nullable: false),
                    HeadAllowableStress = table.Column<double>(type: "float", nullable: false),
                    EstimatedShellThickness = table.Column<double>(type: "float", nullable: false),
                    EstimatedHeadThickness = table.Column<double>(type: "float", nullable: false),
                    Beta = table.Column<double>(type: "float", nullable: false),
                    TankOrientation = table.Column<int>(type: "int", nullable: false),
                    StorageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsManualDensity = table.Column<bool>(type: "bit", nullable: false),
                    LiquidDensity = table.Column<double>(type: "float", nullable: false),
                    StaticPressure = table.Column<double>(type: "float", nullable: false),
                    ShellMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShellMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeadMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeadMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShellThickness = table.Column<double>(type: "float", nullable: false),
                    HeadThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedShellThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedHeadThickness = table.Column<double>(type: "float", nullable: false),
                    TestPressure = table.Column<double>(type: "float", nullable: false),
                    WeldLength1500 = table.Column<double>(type: "float", nullable: false),
                    WeldLength2000 = table.Column<double>(type: "float", nullable: false),
                    WeldLength3000 = table.Column<double>(type: "float", nullable: false),
                    WeldLength4000 = table.Column<double>(type: "float", nullable: false),
                    SurfaceArea = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD2000Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AD2000Calculations_MaterialForms_HeadMaterialFormId",
                        column: x => x.HeadMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000Calculations_MaterialForms_ShellMaterialFormId",
                        column: x => x.ShellMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000Calculations_Materials_HeadMaterialId",
                        column: x => x.HeadMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000Calculations_Materials_ShellMaterialId",
                        column: x => x.ShellMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllowableStresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Stress = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowableStresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowableStresses_MaterialForms_MaterialFormId",
                        column: x => x.MaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EN13458Calculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuterDiameter = table.Column<double>(type: "float", nullable: false),
                    OuterTankDiameter = table.Column<double>(type: "float", nullable: false),
                    ShellLength = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false),
                    LiquidDensity = table.Column<double>(type: "float", nullable: false),
                    WeldLength1500 = table.Column<double>(type: "float", nullable: false),
                    WeldLength2000 = table.Column<double>(type: "float", nullable: false),
                    WeldLength2500 = table.Column<double>(type: "float", nullable: false),
                    WeldLength3000 = table.Column<double>(type: "float", nullable: false),
                    InnerShellMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InnerShellMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InnerHeadMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InnerHeadMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OuterShellMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OuterShellMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OuterHeadMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OuterHeadMaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InnerShellMaterialStrength = table.Column<double>(type: "float", nullable: false),
                    InnerHeadMaterialStrength = table.Column<double>(type: "float", nullable: false),
                    OuterShellMaterialStrength = table.Column<double>(type: "float", nullable: false),
                    OuterHeadMaterialStrength = table.Column<double>(type: "float", nullable: false),
                    InnerShellThickness = table.Column<double>(type: "float", nullable: false),
                    InnerHeadThickness = table.Column<double>(type: "float", nullable: false),
                    OuterShellThickness = table.Column<double>(type: "float", nullable: false),
                    OuterHeadThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedInnerShellThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedInnerHeadThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedOuterShellThickness = table.Column<double>(type: "float", nullable: false),
                    RoundedOuterHeadThickness = table.Column<double>(type: "float", nullable: false),
                    DesignPressure = table.Column<double>(type: "float", nullable: false),
                    TestPressure = table.Column<double>(type: "float", nullable: false),
                    StaticPressure = table.Column<double>(type: "float", nullable: false),
                    InnerTankHeadPulDiameter = table.Column<double>(type: "float", nullable: false),
                    OuterTankHeadPulDiameter = table.Column<double>(type: "float", nullable: false),
                    InnerTankHeadWeight = table.Column<double>(type: "float", nullable: false),
                    OuterTankHeadWeight = table.Column<double>(type: "float", nullable: false),
                    InnerTankHeadWeldLength = table.Column<double>(type: "float", nullable: false),
                    InnerTankCircumferenceWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankHeadWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankCircumferenceWeldLength = table.Column<double>(type: "float", nullable: false),
                    TotalWeldLength = table.Column<double>(type: "float", nullable: false),
                    TotalFilmCost = table.Column<double>(type: "float", nullable: false),
                    InnerTankTotalLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankTotalLength = table.Column<double>(type: "float", nullable: false),
                    InnerVolume = table.Column<double>(type: "float", nullable: false),
                    OuterVolume = table.Column<double>(type: "float", nullable: false),
                    InnerSurfaceArea = table.Column<double>(type: "float", nullable: false),
                    OuterSurfaceArea = table.Column<double>(type: "float", nullable: false),
                    InnerTankWeight = table.Column<double>(type: "float", nullable: false),
                    OuterTankWeight = table.Column<double>(type: "float", nullable: false),
                    PerliteVolume = table.Column<double>(type: "float", nullable: false),
                    PerliteWeight = table.Column<double>(type: "float", nullable: false),
                    GasNitrogenVolume = table.Column<double>(type: "float", nullable: false),
                    LiquidNitrogenVolume = table.Column<double>(type: "float", nullable: false),
                    BucklingWaveNumber = table.Column<double>(type: "float", nullable: false),
                    ElasticBucklingPressureP1 = table.Column<double>(type: "float", nullable: false),
                    PlasticCollapsePressureP2 = table.Column<double>(type: "float", nullable: false),
                    DesignExternalPressurePv = table.Column<double>(type: "float", nullable: false),
                    SupportRingRequired = table.Column<bool>(type: "bit", nullable: false),
                    SupportRingCriticalPressurePe = table.Column<double>(type: "float", nullable: false),
                    SupportRingStressX = table.Column<double>(type: "float", nullable: false),
                    SupportRingAllowableStress = table.Column<double>(type: "float", nullable: false),
                    SupportRingAdequate = table.Column<bool>(type: "bit", nullable: false),
                    HeadCollapsePressure = table.Column<double>(type: "float", nullable: false),
                    RequiredProfileCount = table.Column<int>(type: "int", nullable: false),
                    ProfileDevelopedLength = table.Column<double>(type: "float", nullable: false),
                    TotalProfileLength = table.Column<double>(type: "float", nullable: false),
                    ProfileWeldLength = table.Column<double>(type: "float", nullable: false),
                    InnerDevelopedLength = table.Column<double>(type: "float", nullable: false),
                    OuterDevelopedLength = table.Column<double>(type: "float", nullable: false),
                    InnerSectorPlan1500 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerSectorPlan2000 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerSectorPlan2500 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerSectorPlan3000 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuterSectorPlan1500 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuterSectorPlan2000 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuterSectorPlan2500 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuterSectorPlan3000 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EN13458Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_MaterialForms_InnerHeadMaterialFormId",
                        column: x => x.InnerHeadMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_MaterialForms_InnerShellMaterialFormId",
                        column: x => x.InnerShellMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_MaterialForms_OuterHeadMaterialFormId",
                        column: x => x.OuterHeadMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_MaterialForms_OuterShellMaterialFormId",
                        column: x => x.OuterShellMaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_Materials_InnerHeadMaterialId",
                        column: x => x.InnerHeadMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_Materials_InnerShellMaterialId",
                        column: x => x.InnerShellMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_Materials_OuterHeadMaterialId",
                        column: x => x.OuterHeadMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_Materials_OuterShellMaterialId",
                        column: x => x.OuterShellMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458Calculations_StorageTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "StorageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YieldStrengths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    ThicknessMin = table.Column<double>(type: "float", nullable: false),
                    ThicknessMax = table.Column<double>(type: "float", nullable: false),
                    Rp02 = table.Column<double>(type: "float", nullable: false),
                    Rm = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YieldStrengths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YieldStrengths_MaterialForms_MaterialFormId",
                        column: x => x.MaterialFormId,
                        principalTable: "MaterialForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrefixRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FluidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefix4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefixRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrefixRules_Fluids_FluidId",
                        column: x => x.FluidId,
                        principalTable: "Fluids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrefixRules_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrefixRules_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SFeatureValueDependencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFeatureValueDependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SFeatureValueDependencies_SFeatureValues_SourceValueId",
                        column: x => x.SourceValueId,
                        principalTable: "SFeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueDependencies_SFeatureValues_TargetValueId",
                        column: x => x.TargetValueId,
                        principalTable: "SFeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueDependencies_SFeatures_SourceFeatureId",
                        column: x => x.SourceFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueDependencies_SFeatures_TargetFeatureId",
                        column: x => x.TargetFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueDependencies_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SFeatureValueRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFeatureValueRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SFeatureValueRules_SFeatureValues_SFeatureValueId",
                        column: x => x.SFeatureValueId,
                        principalTable: "SFeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueRules_SFeatures_SFeatureId",
                        column: x => x.SFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SFeatureValueRules_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SPrefixRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FluidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPrefixRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SPrefixRules_Fluids_FluidId",
                        column: x => x.FluidId,
                        principalTable: "Fluids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SPrefixRules_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SPrefixRules_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SProductFeatureRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false),
                    FixedValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProductFeatureRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SProductFeatureRules_SFeatureValues_FixedValueId",
                        column: x => x.FixedValueId,
                        principalTable: "SFeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SProductFeatureRules_SFeatures_SFeatureId",
                        column: x => x.SFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SProductFeatureRules_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SProductFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SProductFeatures_SFeatures_SFeatureId",
                        column: x => x.SFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SProductFeatures_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCode8 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Prefix4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Serial4 = table.Column<int>(type: "int", nullable: false),
                    OptionKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FluidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SAssemblyGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockSequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCards_Fluids_FluidId",
                        column: x => x.FluidId,
                        principalTable: "Fluids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCards_SAssemblyGroups_SAssemblyGroupId",
                        column: x => x.SAssemblyGroupId,
                        principalTable: "SAssemblyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCards_SProductGroups_SProductGroupId",
                        column: x => x.SProductGroupId,
                        principalTable: "SProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCards_SProducts_SProductId",
                        column: x => x.SProductId,
                        principalTable: "SProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCards_StockSequences_StockSequenceId",
                        column: x => x.StockSequenceId,
                        principalTable: "StockSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockSubCodeRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSubCodeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubCodeRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSubCodeRules_StockSubCodeGroups_StockSubCodeGroupId",
                        column: x => x.StockSubCodeGroupId,
                        principalTable: "StockSubCodeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EN13458CostDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostGroupCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CostGroupName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CalculatedThickness = table.Column<double>(type: "float", nullable: false),
                    UsedThickness = table.Column<double>(type: "float", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TheoreticalWeight = table.Column<double>(type: "float", nullable: false),
                    ItemCost = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EN13458CostDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458CostDetails_EN13458Calculations_EN13458CalculationId",
                        column: x => x.EN13458CalculationId,
                        principalTable: "EN13458Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockCardFeatureSelections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SFeatureValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCardFeatureSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCardFeatureSelections_SFeatureValues_SFeatureValueId",
                        column: x => x.SFeatureValueId,
                        principalTable: "SFeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCardFeatureSelections_SFeatures_SFeatureId",
                        column: x => x.SFeatureId,
                        principalTable: "SFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCardFeatureSelections_StockCards_StockCardId",
                        column: x => x.StockCardId,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockCardPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TargetPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StockCardPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCardPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCardPrices_StockCardPrices_StockCardPriceId",
                        column: x => x.StockCardPriceId,
                        principalTable: "StockCardPrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockCardPrices_StockCards_StockCardId",
                        column: x => x.StockCardId,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedStockCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSubCodeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSubCodeRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GeneratedCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TargetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedStockCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodes_StockSubCodeGroups_StockSubCodeGroupId",
                        column: x => x.StockSubCodeGroupId,
                        principalTable: "StockSubCodeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodes_StockSubCodeRules_StockSubCodeRuleId",
                        column: x => x.StockSubCodeRuleId,
                        principalTable: "StockSubCodeRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StockCardDatasheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StockCardPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCardDatasheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCardDatasheets_StockCardPrices_StockCardPriceId",
                        column: x => x.StockCardPriceId,
                        principalTable: "StockCardPrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockCardDatasheets_StockCards_StockCardId",
                        column: x => x.StockCardId,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockCardInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockBefore = table.Column<int>(type: "int", nullable: false),
                    StockAfter = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReferenceDocument = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StockCardPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCardInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCardInventories_StockCardPrices_StockCardPriceId",
                        column: x => x.StockCardPriceId,
                        principalTable: "StockCardPrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockCardInventories_StockCards_StockCardId",
                        column: x => x.StockCardId,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockProductGroupItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProductGroupItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockProductGroupItems_GeneratedStockCodes_GeneratedStockCodeId",
                        column: x => x.GeneratedStockCodeId,
                        principalTable: "GeneratedStockCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProductGroupItems_StockProductGroups_StockProductGroupId",
                        column: x => x.StockProductGroupId,
                        principalTable: "StockProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "ElasticModulus", "Group", "MaterialNumber", "ModifiedBy", "ModifiedDate", "Name", "Notes", "Standard", "Status", "YieldFactorK" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(462), null, null, 7850.0, null, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(467), null, null, 8000.0, null, "Austenitic stainless steel", "1.4301", null, null, "X5CrNi18-10", "EN 10028-7 stainless pressure vessel steel", 0, 0, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(474), null, null, 7850.0, 206000.0, "Structural steel", "1.0038", null, null, "S235JR", "Profile material for supports/rings", 0, 0, 235.0 }
                });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "Description", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(898), null, null, 460.0, "Liquefied Natural Gas", null, null, "Methane / LNG", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(902), null, null, 808.0, "Liquid Nitrogen", null, null, "Nitrogen / LIN", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(904), null, null, 1141.0, "Liquid Oxygen", null, null, "Oxygen / LOX", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(906), null, null, 1395.0, "Liquid Argon", null, null, "Argon / LAR", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(908), null, null, 1070.0, "Liquid Carbon Dioxide", null, null, "Carbon Dioxide / LCO2", 0 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "MomentOfInertia", "Notes", "ProductStandard", "SectionArea", "SectionModulus", "Status", "TargetPrice", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(548), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Standard plate form for P355NH", "EN 10028-3", null, null, 0, null, 250.0, 1.0, 1.5, null },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(556), null, null, 1, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Seamless pipe form for P355NH", "EN 10216-3", null, null, 0, null, 40.0, 2.0, 2.2999999999999998, 1.0 },
                    { new Guid("44444444-4444-4444-4444-444444444441"), 400.0, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(552), null, null, 0, new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, "Plate form for X5CrNi18-10 (Cold stretch optional)", "EN 10028-7", null, null, 0, null, 200.0, 1.0, 4.5, null },
                    { new Guid("66666666-6666-6666-6666-666666666661"), null, "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(569), null, null, 4, new Guid("55555555-5555-5555-5555-555555555555"), null, null, 101700.0, "S235JR kutu profil 40x40x3 mm", "EN 10025-2", 444.0, 5080.0, 0, null, 30.0, 3.0, 1.2, null }
                });

            migrationBuilder.InsertData(
                table: "StorageTypeProperties",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Enthalpy_Gas_kJkg", "Enthalpy_Liquid_kJkg", "Entropy_Gas_kJkgK", "Entropy_Liquid_kJkgK", "GasConstant_kJkgK", "ModifiedBy", "ModifiedDate", "Pressure_bar", "SpecificVolume_Gas_m3kg", "SpecificVolume_Liquid_dm3kg", "Status", "StorageTypeId", "Temperature_C" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(935), null, null, 688.0, 200.0, 4.9626999999999999, 1.0, 488.0, null, null, 2.3839999999999999, 0.25041999999999998, 2.4674, 0, new Guid("10000000-0000-0000-0000-000000000001"), -150.0 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(940), null, null, 281.19, 81.790000000000006, 2.4571000000000001, -0.1275, 199.40000000000001, null, null, 0.98999999999999999, 0.2215, 1.2352000000000001, 0, new Guid("10000000-0000-0000-0000-000000000002"), -196.0 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(943), null, null, 367.88, 200.0, 2.3632, 1.0, 167.88, null, null, 12.214, 0.02129, 1.0495000000000001, 0, new Guid("10000000-0000-0000-0000-000000000003"), -150.0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("0313f1d6-e2c0-4d06-bb69-2a6380b88973"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(656), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("03cb09c0-01b7-4293-a743-872b9c085820"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(658), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("0506bee1-a4ee-4a7d-a2bd-79108e0fc33d"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(699), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("072163c1-9b77-4437-8cbe-03dcac620021"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(801), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 150.0, 0, 300.0, 200.0, 1.0 },
                    { new Guid("0b07ca9c-2d8e-4ae9-bdb7-4c58f930b3e4"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(677), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("1008937b-9957-4176-839c-70e429a0e016"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(660), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("11bd5d71-a115-452c-ad7b-298ae2ab755e"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(662), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("15c917f2-b823-49af-9713-159985ab36d7"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(716), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("1992264e-9fdb-4448-94bd-050facb18e41"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(702), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("1c3be7ab-c9ee-4d88-baef-be9f6eb7c87a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(820), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 252.0, 0, 250.0, 40.0, 2.0 },
                    { new Guid("1f27249e-80f8-4e85-bd2b-40c58686e3b3"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(675), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("201767b2-8294-40cb-a9bb-5b32913141ed"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(653), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("25af8385-ce0d-45c2-9780-dd59c13deae1"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(626), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("29c3094f-c9d7-45b4-93f5-0365d26d8afe"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(815), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 299.0, 0, 150.0, 40.0, 2.0 },
                    { new Guid("2b9dadff-eaf3-493d-a9fc-62872d40d30e"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(714), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("2e777af6-d556-43ac-890a-89911a0d475a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(829), null, null, new Guid("66666666-6666-6666-6666-666666666661"), null, null, 360.0, 235.0, 0, 20.0, 30.0, 3.0 },
                    { new Guid("2ec3ffa6-7b18-4c27-9b6b-7221c288eaaf"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(720), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("2fb36a59-55be-4b1c-a665-1e71a9aad509"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(650), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("30357c8f-8231-439e-86c0-0f056a110be9"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(707), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("31d3312e-09da-4f38-856a-cc3a43a741c0"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(792), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 195.0, 0, 100.0, 200.0, 1.0 },
                    { new Guid("39f8d888-4e5a-4a76-9586-99aab646fbc1"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(824), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 214.0, 0, 350.0, 40.0, 2.0 },
                    { new Guid("3be67657-d26a-4d18-9f71-60b83da30e3a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(695), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("3c65ac5c-a01f-4082-89d5-9a5c68165c00"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(685), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("457a7eb4-17c7-4f7e-a017-75547a31bef0"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(774), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("460848f9-4469-4922-899e-0cf04f197c25"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(772), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("465fbb44-6865-4d8c-b823-524fe89e28bf"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(722), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("4a183dc4-2805-4de1-9df0-c07fbeee4b5d"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(751), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("4b05337f-eb1d-4cf8-b701-ae1766d52440"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(686), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("5374f942-9a63-4d73-b247-37eb151a320b"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(758), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("56541b72-2d83-4d32-8b64-7325eb0c2ab2"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(672), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("585685e4-964b-4aa2-b180-7462187b886a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(636), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("5a4de231-d410-4703-a2d8-2c10dddf39bd"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(718), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("61c3a03f-31c6-4572-8774-69898c461fe8"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(790), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 205.0, 0, 50.0, 200.0, 1.0 },
                    { new Guid("6221b4ca-8bb9-41eb-813d-c0fea4416a0a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(645), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("69fc32cf-21ec-4fc6-830b-e4fe123de6ef"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(799), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 160.0, 0, 250.0, 200.0, 1.0 },
                    { new Guid("70a9ec60-4e92-4833-aef3-fe490590c4ca"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(697), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("77bc0a04-00e3-45f4-8809-adf3203eaf84"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(822), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 232.0, 0, 300.0, 40.0, 2.0 },
                    { new Guid("77daa89c-c675-49a4-a1b9-e446a0b1d77d"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(794), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 185.0, 0, 150.0, 200.0, 1.0 },
                    { new Guid("7dfe7f77-fc42-4fa9-bc6f-6347904c4e57"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(756), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("7e8820bc-2fc7-4133-be87-2034e5969604"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(796), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 170.0, 0, 200.0, 200.0, 1.0 },
                    { new Guid("8fb751b9-0f12-469e-a934-46e1d76091dc"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(681), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("945e658c-b4b0-447c-82f5-a8a1436efc04"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(690), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("95603a08-d9f0-4ebc-a90c-06ac00528fc0"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(778), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 350.0, 0, -196.0, 200.0, 1.0 },
                    { new Guid("985e3110-6734-4871-bbe5-f41a559a00d6"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(784), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 300.0, 0, -100.0, 200.0, 1.0 },
                    { new Guid("9a3fd78e-e26d-40ca-bdae-c718d8710f37"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(712), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("9b8eb1a2-f500-4aa8-acc8-3372d849c921"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(787), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 210.0, 0, 20.0, 200.0, 1.0 },
                    { new Guid("9c42cd01-0a7c-4d93-be63-f7f89d771e54"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(754), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("a2988a88-48d7-4d4d-8e47-73532812fcee"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(642), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("af124efa-0c74-4712-81f0-c89346f8f63b"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(827), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 202.0, 0, 400.0, 40.0, 2.0 },
                    { new Guid("b0c4a436-0734-4a79-9ee9-e035ef6c6f40"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(811), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 343.0, 0, 50.0, 40.0, 2.0 },
                    { new Guid("b0ee3bff-8476-4d6f-82ab-745ed2cfb4b6"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(629), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("b1b5de3a-e11e-4316-adff-9864dae9dd33"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(665), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("b1bfe297-5389-4e28-a3e3-ecf2f99a7ee0"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(648), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("b59f5c55-7a63-427d-8ccb-3d360b2b1653"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(818), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 275.0, 0, 200.0, 40.0, 2.0 },
                    { new Guid("b5ce9339-ef52-4e28-b4c5-4b79cd76a69f"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(635), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("c08eb533-ab71-4dfa-b714-abeaacb79ddf"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(667), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("c62d57b6-3081-4070-a534-7c6c0ea2a478"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(709), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("ccb3a00e-992f-4d7a-b876-4647e208dd7a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(693), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("cdd432ac-e57e-4408-9727-71970d5421ac"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(704), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("ce02197f-fd9f-4ffc-a61b-a0c8e011cb96"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(769), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("d137613c-dc41-4a05-943c-6882bd9f158d"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(688), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("db029a4f-2fa9-4983-b790-72208d8f1d21"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(760), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("dd200103-0279-4e21-9c10-57a8ea509fbd"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(781), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 330.0, 0, -150.0, 200.0, 1.0 },
                    { new Guid("e128de5f-6d04-49a5-9366-f0aa64c6fa2c"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(765), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("e1942b69-209d-4d40-be7a-4d68e1acf23a"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(785), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 260.0, 0, -50.0, 200.0, 1.0 },
                    { new Guid("e1f29bd3-fd44-4d85-8cf7-e65cb93bcc66"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(670), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("e685df85-aaf3-414e-b5b6-7fa7df598512"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(804), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 140.0, 0, 350.0, 200.0, 1.0 },
                    { new Guid("e6d867a8-3f33-491f-b2f2-cd337bdd94c3"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(679), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("e81897d6-e1ca-466c-ac68-3e76920f891e"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(640), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("ea22d132-97e0-42b7-b646-c5f9fc622d46"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(776), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("eaf31001-7b03-4b1b-bcb1-6a9667f5aaa9"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(813), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 323.0, 0, 100.0, 40.0, 2.0 },
                    { new Guid("eb57d00c-a3c2-484c-897b-cede542270de"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(749), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("ec28c3ab-70f0-403b-b7be-e75d35e0f348"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(767), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("ee857e72-0fd5-4b29-9995-93a3bf2aadf3"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(805), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 130.0, 0, 400.0, 200.0, 1.0 },
                    { new Guid("f14c7dec-2225-49bc-b094-751d59e6e96d"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(763), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("f38ff170-2241-4976-8cea-bbc8600b71e8"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(631), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("fdb68df7-ae9e-4e5f-8f5d-5fc0379fec61"), "SeedData", new DateTime(2026, 3, 18, 7, 54, 50, 265, DateTimeKind.Utc).AddTicks(810), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 355.0, 0, 20.0, 40.0, 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AD2000Calculations_HeadMaterialFormId",
                table: "AD2000Calculations",
                column: "HeadMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000Calculations_HeadMaterialId",
                table: "AD2000Calculations",
                column: "HeadMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000Calculations_ShellMaterialFormId",
                table: "AD2000Calculations",
                column: "ShellMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000Calculations_ShellMaterialId",
                table: "AD2000Calculations",
                column: "ShellMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowableStresses_MaterialFormId",
                table: "AllowableStresses",
                column: "MaterialFormId");

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
                name: "IX_CapacityOptions_CapacityGroupId",
                table: "CapacityOptions",
                column: "CapacityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignStandards_Code",
                table: "DesignStandards",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_InnerHeadMaterialFormId",
                table: "EN13458Calculations",
                column: "InnerHeadMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_InnerHeadMaterialId",
                table: "EN13458Calculations",
                column: "InnerHeadMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_InnerShellMaterialFormId",
                table: "EN13458Calculations",
                column: "InnerShellMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_InnerShellMaterialId",
                table: "EN13458Calculations",
                column: "InnerShellMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_OuterHeadMaterialFormId",
                table: "EN13458Calculations",
                column: "OuterHeadMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_OuterHeadMaterialId",
                table: "EN13458Calculations",
                column: "OuterHeadMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_OuterShellMaterialFormId",
                table: "EN13458Calculations",
                column: "OuterShellMaterialFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_OuterShellMaterialId",
                table: "EN13458Calculations",
                column: "OuterShellMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458Calculations_ProductTypeId",
                table: "EN13458Calculations",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458CostDetails_EN13458CalculationId",
                table: "EN13458CostDetails",
                column: "EN13458CalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluids_Code",
                table: "Fluids",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluids_Name",
                table: "Fluids",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GasTypeDesignStandards_DesignStandardId",
                table: "GasTypeDesignStandards",
                column: "DesignStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_GasTypeDesignStandards_GasTypeId_DesignStandardId",
                table: "GasTypeDesignStandards",
                columns: new[] { "GasTypeId", "DesignStandardId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasTypePressures_GasTypeId",
                table: "GasTypePressures",
                column: "GasTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GasTypes_Code",
                table: "GasTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodes_StockSubCodeGroupId",
                table: "GeneratedStockCodes",
                column: "StockSubCodeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodes_StockSubCodeRuleId",
                table: "GeneratedStockCodes",
                column: "StockSubCodeRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialForms_MaterialId",
                table: "MaterialForms",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_FluidId_SProductGroupId_SProductId",
                table: "PrefixRules",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_Prefix4",
                table: "PrefixRules",
                column: "Prefix4",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_SProductGroupId",
                table: "PrefixRules",
                column: "SProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_SProductId",
                table: "PrefixRules",
                column: "SProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SAssemblyGroups_SProductGroupId",
                table: "SAssemblyGroups",
                column: "SProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SAssemblyGroups_Step3Letter_Step4Digit",
                table: "SAssemblyGroups",
                columns: new[] { "Step3Letter", "Step4Digit" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SCategories_Code",
                table: "SCategories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SFeatures_Code",
                table: "SFeatures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueDependencies_SourceFeatureId",
                table: "SFeatureValueDependencies",
                column: "SourceFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueDependencies_SourceValueId",
                table: "SFeatureValueDependencies",
                column: "SourceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueDependencies_SProductId_SourceFeatureId_SourceValueId",
                table: "SFeatureValueDependencies",
                columns: new[] { "SProductId", "SourceFeatureId", "SourceValueId" });

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueDependencies_TargetFeatureId",
                table: "SFeatureValueDependencies",
                column: "TargetFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueDependencies_TargetValueId",
                table: "SFeatureValueDependencies",
                column: "TargetValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueRules_SFeatureId",
                table: "SFeatureValueRules",
                column: "SFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueRules_SFeatureValueId",
                table: "SFeatureValueRules",
                column: "SFeatureValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValueRules_SProductId_SFeatureId_SFeatureValueId",
                table: "SFeatureValueRules",
                columns: new[] { "SProductId", "SFeatureId", "SFeatureValueId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SFeatureValues_SFeatureId_Code",
                table: "SFeatureValues",
                columns: new[] { "SFeatureId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_CategoryId_FluidId_SProductGroupId",
                table: "SGroupFilterRules",
                columns: new[] { "CategoryId", "FluidId", "SProductGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_FluidId",
                table: "SGroupFilterRules",
                column: "FluidId");

            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_SProductGroupId",
                table: "SGroupFilterRules",
                column: "SProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_FluidId",
                table: "SPrefixRules",
                column: "FluidId");

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_SProductGroupId_FluidId_SProductId",
                table: "SPrefixRules",
                columns: new[] { "SProductGroupId", "FluidId", "SProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_SProductId",
                table: "SPrefixRules",
                column: "SProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SProductFeatureRules_FixedValueId",
                table: "SProductFeatureRules",
                column: "FixedValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SProductFeatureRules_SFeatureId",
                table: "SProductFeatureRules",
                column: "SFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SProductFeatureRules_SProductId_SFeatureId",
                table: "SProductFeatureRules",
                columns: new[] { "SProductId", "SFeatureId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SProductFeatures_SFeatureId",
                table: "SProductFeatures",
                column: "SFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SProductFeatures_SProductId_SFeatureId",
                table: "SProductFeatures",
                columns: new[] { "SProductId", "SFeatureId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SProductGroups_Code",
                table: "SProductGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SProducts_SProductGroupId_Code",
                table: "SProducts",
                columns: new[] { "SProductGroupId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCardDatasheets_IsActive",
                table: "StockCardDatasheets",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardDatasheets_Status",
                table: "StockCardDatasheets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardDatasheets_StockCardId",
                table: "StockCardDatasheets",
                column: "StockCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardDatasheets_StockCardId_Version",
                table: "StockCardDatasheets",
                columns: new[] { "StockCardId", "Version" });

            migrationBuilder.CreateIndex(
                name: "IX_StockCardDatasheets_StockCardPriceId",
                table: "StockCardDatasheets",
                column: "StockCardPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardFeatureSelections_SFeatureId",
                table: "StockCardFeatureSelections",
                column: "SFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardFeatureSelections_SFeatureValueId",
                table: "StockCardFeatureSelections",
                column: "SFeatureValueId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardFeatureSelections_StockCardId_SFeatureId",
                table: "StockCardFeatureSelections",
                columns: new[] { "StockCardId", "SFeatureId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_MovementDate",
                table: "StockCardInventories",
                column: "MovementDate");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_MovementType",
                table: "StockCardInventories",
                column: "MovementType");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_Status",
                table: "StockCardInventories",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_StockCardId",
                table: "StockCardInventories",
                column: "StockCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_StockCardId_MovementDate",
                table: "StockCardInventories",
                columns: new[] { "StockCardId", "MovementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_StockCardInventories_StockCardPriceId",
                table: "StockCardInventories",
                column: "StockCardPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_IsActive",
                table: "StockCardPrices",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_Status",
                table: "StockCardPrices",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_StockCardId",
                table: "StockCardPrices",
                column: "StockCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_StockCardId_IsActive_ValidFrom",
                table: "StockCardPrices",
                columns: new[] { "StockCardId", "IsActive", "ValidFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_StockCardPriceId",
                table: "StockCardPrices",
                column: "StockCardPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCardPrices_ValidFrom",
                table: "StockCardPrices",
                column: "ValidFrom");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_FluidId_SProductGroupId_SProductId_OptionKey",
                table: "StockCards",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId", "OptionKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_SAssemblyGroupId",
                table: "StockCards",
                column: "SAssemblyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_SProductGroupId",
                table: "StockCards",
                column: "SProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_SProductId",
                table: "StockCards",
                column: "SProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_StockCode8",
                table: "StockCards",
                column: "StockCode8",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_StockSequenceId",
                table: "StockCards",
                column: "StockSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMainCodeGroups_Code",
                table: "StockMainCodeGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockProductGroupItems_GeneratedStockCodeId",
                table: "StockProductGroupItems",
                column: "GeneratedStockCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProductGroupItems_StockProductGroupId_GeneratedStockCodeId",
                table: "StockProductGroupItems",
                columns: new[] { "StockProductGroupId", "GeneratedStockCodeId" });

            migrationBuilder.CreateIndex(
                name: "IX_StockSequences_Prefix4",
                table: "StockSequences",
                column: "Prefix4",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockSubCodeGroups_StockMainCodeGroupId_Code",
                table: "StockSubCodeGroups",
                columns: new[] { "StockMainCodeGroupId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockSubCodeRules_StockSubCodeGroupId_RuleCode",
                table: "StockSubCodeRules",
                columns: new[] { "StockSubCodeGroupId", "RuleCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageTypeProperties_StorageTypeId",
                table: "StorageTypeProperties",
                column: "StorageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ThermodynamicProperties_GasTypeId_Temperature_Pressure",
                table: "ThermodynamicProperties",
                columns: new[] { "GasTypeId", "Temperature", "Pressure" });

            migrationBuilder.CreateIndex(
                name: "IX_YieldStrengths_MaterialFormId",
                table: "YieldStrengths",
                column: "MaterialFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AD2000Calculations");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AllowableStresses");

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
                name: "CapacityOptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EN13458CostDetails");

            migrationBuilder.DropTable(
                name: "GasTypeDesignStandards");

            migrationBuilder.DropTable(
                name: "GasTypePressures");

            migrationBuilder.DropTable(
                name: "PrefixRules");

            migrationBuilder.DropTable(
                name: "SFeatureValueDependencies");

            migrationBuilder.DropTable(
                name: "SFeatureValueRules");

            migrationBuilder.DropTable(
                name: "SGroupFilterRules");

            migrationBuilder.DropTable(
                name: "SPrefixRules");

            migrationBuilder.DropTable(
                name: "SProductFeatureRules");

            migrationBuilder.DropTable(
                name: "SProductFeatures");

            migrationBuilder.DropTable(
                name: "StockCardDatasheets");

            migrationBuilder.DropTable(
                name: "StockCardFeatureSelections");

            migrationBuilder.DropTable(
                name: "StockCardInventories");

            migrationBuilder.DropTable(
                name: "StockProductGroupItems");

            migrationBuilder.DropTable(
                name: "StorageTypeProperties");

            migrationBuilder.DropTable(
                name: "ThermodynamicProperties");

            migrationBuilder.DropTable(
                name: "YieldStrengths");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CapacityGroups");

            migrationBuilder.DropTable(
                name: "EN13458Calculations");

            migrationBuilder.DropTable(
                name: "DesignStandards");

            migrationBuilder.DropTable(
                name: "SCategories");

            migrationBuilder.DropTable(
                name: "SFeatureValues");

            migrationBuilder.DropTable(
                name: "StockCardPrices");

            migrationBuilder.DropTable(
                name: "GeneratedStockCodes");

            migrationBuilder.DropTable(
                name: "StockProductGroups");

            migrationBuilder.DropTable(
                name: "GasTypes");

            migrationBuilder.DropTable(
                name: "MaterialForms");

            migrationBuilder.DropTable(
                name: "StorageTypes");

            migrationBuilder.DropTable(
                name: "SFeatures");

            migrationBuilder.DropTable(
                name: "StockCards");

            migrationBuilder.DropTable(
                name: "StockSubCodeRules");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Fluids");

            migrationBuilder.DropTable(
                name: "SAssemblyGroups");

            migrationBuilder.DropTable(
                name: "SProducts");

            migrationBuilder.DropTable(
                name: "StockSequences");

            migrationBuilder.DropTable(
                name: "StockSubCodeGroups");

            migrationBuilder.DropTable(
                name: "SProductGroups");

            migrationBuilder.DropTable(
                name: "StockMainCodeGroups");
        }
    }
}
