using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v43 : Migration
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
                name: "EN13458CostAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionNo = table.Column<int>(type: "int", nullable: false),
                    RevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
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
                    table.PrimaryKey("PK_EN13458CostAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458CostAnalyses_EN13458Calculations_EN13458CalculationId",
                        column: x => x.EN13458CalculationId,
                        principalTable: "EN13458Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EN13458CostAnalysisItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ItemKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ItemSourceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CostGroupCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CostGroupName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StockCodeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CalculatedThickness = table.Column<double>(type: "float", nullable: false),
                    UsedThickness = table.Column<double>(type: "float", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    TheoreticalWeight = table.Column<double>(type: "float", nullable: false),
                    UseManualUnitPrice = table.Column<bool>(type: "bit", nullable: false),
                    ManualUnitPrice = table.Column<double>(type: "float", nullable: true),
                    StockUnitPrice = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_EN13458CostAnalysisItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458CostAnalysisItems_EN13458CostAnalyses_EN13458CostAnalysisId",
                        column: x => x.EN13458CostAnalysisId,
                        principalTable: "EN13458CostAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8214), null, null, 7850.0, null, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8219), null, null, 8000.0, null, "Austenitic stainless steel", "1.4301", null, null, "X5CrNi18-10", "EN 10028-7 stainless pressure vessel steel", 0, 0, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8224), null, null, 7850.0, 206000.0, "Structural steel", "1.0038", null, null, "S235JR", "Profile material for supports/rings", 0, 0, 235.0 }
                });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "Description", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8560), null, null, 460.0, "Liquefied Natural Gas", null, null, "Methane / LNG", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8563), null, null, 808.0, "Liquid Nitrogen", null, null, "Nitrogen / LIN", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8589), null, null, 1141.0, "Liquid Oxygen", null, null, "Oxygen / LOX", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8591), null, null, 1395.0, "Liquid Argon", null, null, "Argon / LAR", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8594), null, null, 1070.0, "Liquid Carbon Dioxide", null, null, "Carbon Dioxide / LCO2", 0 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "MomentOfInertia", "Notes", "ProductStandard", "SectionArea", "SectionModulus", "Status", "TargetPrice", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8282), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Standard plate form for P355NH", "EN 10028-3", null, null, 0, null, 250.0, 1.0, 1.5, null },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8297), null, null, 1, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Seamless pipe form for P355NH", "EN 10216-3", null, null, 0, null, 40.0, 2.0, 2.2999999999999998, 1.0 },
                    { new Guid("44444444-4444-4444-4444-444444444441"), 400.0, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8287), null, null, 0, new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, "Plate form for X5CrNi18-10 (Cold stretch optional)", "EN 10028-7", null, null, 0, null, 200.0, 1.0, 4.5, null },
                    { new Guid("66666666-6666-6666-6666-666666666661"), null, "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8301), null, null, 4, new Guid("55555555-5555-5555-5555-555555555555"), null, null, 101700.0, "S235JR kutu profil 40x40x3 mm", "EN 10025-2", 444.0, 5080.0, 0, null, 30.0, 3.0, 1.2, null }
                });

            migrationBuilder.InsertData(
                table: "StorageTypeProperties",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Enthalpy_Gas_kJkg", "Enthalpy_Liquid_kJkg", "Entropy_Gas_kJkgK", "Entropy_Liquid_kJkgK", "GasConstant_kJkgK", "ModifiedBy", "ModifiedDate", "Pressure_bar", "SpecificVolume_Gas_m3kg", "SpecificVolume_Liquid_dm3kg", "Status", "StorageTypeId", "Temperature_C" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8614), null, null, 688.0, 200.0, 4.9626999999999999, 1.0, 488.0, null, null, 2.3839999999999999, 0.25041999999999998, 2.4674, 0, new Guid("10000000-0000-0000-0000-000000000001"), -150.0 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8617), null, null, 281.19, 81.790000000000006, 2.4571000000000001, -0.1275, 199.40000000000001, null, null, 0.98999999999999999, 0.2215, 1.2352000000000001, 0, new Guid("10000000-0000-0000-0000-000000000002"), -196.0 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8620), null, null, 367.88, 200.0, 2.3632, 1.0, 167.88, null, null, 12.214, 0.02129, 1.0495000000000001, 0, new Guid("10000000-0000-0000-0000-000000000003"), -150.0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("03f6cdbd-9a87-4834-b816-c2903985b1e7"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8398), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("082566de-04a3-44fd-b1c7-4ab832a04f89"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8384), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("099c87ed-3bf9-4809-9db5-e119da8616c6"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8408), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("0de2fe32-b97b-40c1-bed8-53ea45b4641c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8490), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 195.0, 0, 100.0, 200.0, 1.0 },
                    { new Guid("0f0ac91f-05b1-462e-83f4-44efb2491f6e"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8518), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 214.0, 0, 350.0, 40.0, 2.0 },
                    { new Guid("102daf37-c844-417c-aeaa-624fd5c53021"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8382), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("16c4ba02-4ee6-4e5d-a9c0-c2af684e3a95"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8395), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("19af95c8-8ac5-4d62-bbf6-512d71de8308"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8477), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("26dfed37-a650-4e1b-8fb5-0b5caf5b0d69"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8376), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("2b11f33e-b183-4d1d-b502-abfaf27518fa"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8500), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 140.0, 0, 350.0, 200.0, 1.0 },
                    { new Guid("2db2a438-e4fe-4143-a49a-e1fc513c2386"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8485), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 260.0, 0, -50.0, 200.0, 1.0 },
                    { new Guid("3426fb11-6b0f-4783-b918-3f4ec8347f1f"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8475), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("35984f4b-7a55-4328-af94-9d2be0ee65df"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8417), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("3a66c187-0f7a-43d0-a3cb-86a6807a9c4e"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8486), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 210.0, 0, 20.0, 200.0, 1.0 },
                    { new Guid("3a9106fe-8ef3-4ec9-a6a5-8c9a3810c84c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8404), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("3fcf1848-3828-4415-b94f-5a534d0b41a7"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8517), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 232.0, 0, 300.0, 40.0, 2.0 },
                    { new Guid("4192a58a-7a67-4d41-9192-fdef890015d8"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8419), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("45d8b874-5f9e-4861-95b8-eaa674e97e54"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8371), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("49464c61-1f0f-4cc0-a263-1d6fc60064dc"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8330), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("49cb8e8a-7ec8-4f39-8d46-1f2a4f2ddc32"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8424), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("5185685e-16aa-4bca-89a2-c52c1ee00747"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8397), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("52f7af7c-abdc-4d83-9fde-16f83ae3da08"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8447), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("5647d758-f645-40c7-be0c-50dfd825ae7d"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8436), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("58506221-9a62-45b5-be78-f8c76c8e299c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8481), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 330.0, 0, -150.0, 200.0, 1.0 },
                    { new Guid("588aa624-a379-479c-9314-edefe0396340"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8435), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("5ecfddb8-8b16-4349-9a6e-8273eed96173"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8503), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 130.0, 0, 400.0, 200.0, 1.0 },
                    { new Guid("5f1e25b7-19b8-443b-a6bb-9ea9dab1a1c4"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8514), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 275.0, 0, 200.0, 40.0, 2.0 },
                    { new Guid("5f6b9998-5eaf-4b02-b385-d6351a76b63c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8325), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("5fa3399b-1b13-4c2b-9c32-eb7487154101"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8428), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("668478a5-8653-4a9b-ad36-ef13c1bb726c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8323), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("6efdc200-2cd0-4228-8d88-25eb704bc124"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8338), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("6f620d4c-c93d-4527-9d51-55599b4702fe"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8492), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 185.0, 0, 150.0, 200.0, 1.0 },
                    { new Guid("70d4cd48-2b7f-4a86-98dc-d7670169ff19"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8521), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 202.0, 0, 400.0, 40.0, 2.0 },
                    { new Guid("70fb15f1-4e62-4d04-872a-9fd8052f07ab"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8415), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("794a7bff-9198-44c7-8273-0554a25d028a"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8321), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("7ddd1dd5-86d9-4fba-86b6-5153e86d86a3"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8444), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("85f4f8bf-cc99-491d-90ba-0dff4ef0c89a"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8413), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("8bed78fc-9e0f-462a-a6bf-ec7ae7ae7046"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8442), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("8ed802c2-bec4-4769-9fae-c05db682c206"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8498), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 150.0, 0, 300.0, 200.0, 1.0 },
                    { new Guid("90c22ebc-ddfe-444b-933e-aa671b8e2c6f"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8432), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("9170de41-39cd-436a-8427-534ac4ac71c7"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8389), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("95782d3b-6809-4555-a86c-afbfd7998761"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8440), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("9cb744a9-b31f-4f1e-b835-1d6cfdb005cf"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8336), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("9d8d2948-597e-40ca-848c-2d493a8a3618"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8479), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 350.0, 0, -196.0, 200.0, 1.0 },
                    { new Guid("9e463d77-382f-4465-9b0a-f0c827ec9057"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8430), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("a4c1ad3f-88f6-4e75-aaa6-12a73fd18f9b"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8400), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("a55551d1-1379-46ea-a18b-493cf04d71dc"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8378), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("acacac06-c350-49d8-b32d-efdd1249af43"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8523), null, null, new Guid("66666666-6666-6666-6666-666666666661"), null, null, 360.0, 235.0, 0, 20.0, 30.0, 3.0 },
                    { new Guid("b3b6d6b1-cd94-455d-989a-3d52c0526c07"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8380), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("b94034a0-fdb7-47a4-b0fa-09370b29364f"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8372), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("bac70592-0f77-4084-902a-921e4281fa71"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8511), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 299.0, 0, 150.0, 40.0, 2.0 },
                    { new Guid("baf7aa0c-6e0f-4d2c-bdda-1e7625e303ba"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8403), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("be8f376d-ab7b-4aa5-a1ca-deb0cfdd9aa8"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8421), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("c1a32eef-a16a-48a1-a784-786a5c1e606d"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8410), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("c32a54d0-af10-4b42-8deb-d07117c6bdb5"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8365), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("c5dfd542-c171-4399-86cf-50c108ab84fb"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8450), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("c67a3067-e046-477b-85a3-ca1506f54589"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8483), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 300.0, 0, -100.0, 200.0, 1.0 },
                    { new Guid("cbe09107-dda7-458e-a760-f4e2d7b0a725"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8515), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 252.0, 0, 250.0, 40.0, 2.0 },
                    { new Guid("cd469787-a3e7-4a99-a614-34c572ea0574"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8334), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("cd72ba19-bad2-41f6-ade7-bdddcc65ac22"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8427), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("d248172c-3338-45d2-adf4-9586e5321020"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8387), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("d2821e74-9afc-4801-8bbc-b586aa685cca"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8392), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("dc29808b-d545-4d3c-bd54-f87ce2930272"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8406), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("dc3d5555-1c35-488a-9ac1-f4ef713ca20c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8423), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("de6762f5-e927-45df-9cdf-ab3101b63dcc"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8391), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("e09abd67-0244-435b-9cc9-6b256cdb78cb"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8328), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("e0fa2c8c-33ce-44a3-8747-c2aa46ef3d9d"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8506), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 355.0, 0, 20.0, 40.0, 2.0 },
                    { new Guid("e116825b-582b-4212-ac34-051b46e12233"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8438), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("e1d0e55f-7381-4019-aa77-452c41295294"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8374), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("e52aa69d-cdef-4744-b122-ac9047866c25"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8367), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("e7e3caa6-1d3e-4267-8277-e9f606ddcc4e"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8489), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 205.0, 0, 50.0, 200.0, 1.0 },
                    { new Guid("e8d43773-69fc-4d4e-bee3-ef2690b0991c"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8445), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("e93f9a12-afee-4336-9318-0b3f7bc3b6e4"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8496), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 160.0, 0, 250.0, 200.0, 1.0 },
                    { new Guid("ee2db628-a36a-45be-a6d6-fe4f89f829e8"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8340), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("faee7d94-86f7-4b96-840b-55d0d1e64f0d"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8509), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 323.0, 0, 100.0, 40.0, 2.0 },
                    { new Guid("fdb1fde2-ef5a-4a07-9bec-aa5fc07db536"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8507), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 343.0, 0, 50.0, 40.0, 2.0 },
                    { new Guid("fe7e0929-4bcf-4257-a034-fd34a6550f31"), "SeedData", new DateTime(2026, 3, 18, 10, 46, 54, 419, DateTimeKind.Utc).AddTicks(8494), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 170.0, 0, 200.0, 200.0, 1.0 }
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
                name: "IX_EN13458CostAnalyses_EN13458CalculationId_RevisionNo",
                table: "EN13458CostAnalyses",
                columns: new[] { "EN13458CalculationId", "RevisionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EN13458CostAnalysisItems_EN13458CostAnalysisId",
                table: "EN13458CostAnalysisItems",
                column: "EN13458CostAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458CostAnalysisItems_EN13458CostAnalysisId_ItemKey",
                table: "EN13458CostAnalysisItems",
                columns: new[] { "EN13458CostAnalysisId", "ItemKey" });

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
                name: "EN13458CostAnalysisItems");

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
                name: "EN13458CostAnalyses");

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
                name: "EN13458Calculations");

            migrationBuilder.DropTable(
                name: "SFeatures");

            migrationBuilder.DropTable(
                name: "StockCards");

            migrationBuilder.DropTable(
                name: "StockSubCodeRules");

            migrationBuilder.DropTable(
                name: "MaterialForms");

            migrationBuilder.DropTable(
                name: "StorageTypes");

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
                name: "Materials");

            migrationBuilder.DropTable(
                name: "SProductGroups");

            migrationBuilder.DropTable(
                name: "StockMainCodeGroups");
        }
    }
}
