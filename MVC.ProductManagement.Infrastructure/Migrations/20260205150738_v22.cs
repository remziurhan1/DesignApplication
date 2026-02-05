using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v22 : Migration
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
                    ShellLength = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false),
                    LiquidDensity = table.Column<double>(type: "float", nullable: false),
                    SectorWidth = table.Column<double>(type: "float", nullable: false),
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
                    TotalWeldLength = table.Column<double>(type: "float", nullable: false),
                    TotalFilmCost = table.Column<double>(type: "float", nullable: false),
                    InnerTankTotalLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankTotalLength = table.Column<double>(type: "float", nullable: false),
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Fluids",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), "H", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CNG", 1 },
                    { new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), "C", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LOX", 1 },
                    { new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), "D", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LIN", 1 },
                    { new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), "B", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LNG", 1 },
                    { new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), "F", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "FUEL", 1 },
                    { new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), "G", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GOX", 1 },
                    { new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), "E", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CO2", 1 },
                    { new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), "A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LPG", 1 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "Group", "MaterialNumber", "ModifiedBy", "ModifiedDate", "Name", "Notes", "Standard", "Status" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7532), null, null, 7850.0, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0 });

            migrationBuilder.InsertData(
                table: "SFeatures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), "PN", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Basınç Sınıfı (Pressure Nominal)", 1, 1 },
                    { new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), "SURFACE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey Tipi (Flange Face)", 3, 1 },
                    { new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), "DN", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Anma Çapı (Nominal Diameter)", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "SProductGroups",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), "G", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pim, Gresörlük, Gupilya", 1 },
                    { new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), "E", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrik Malzemeleri", 1 },
                    { new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), "B", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Somunlar", 1 },
                    { new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), "A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Cıvatalar, Perçinler", 1 },
                    { new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), "D", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Rekorlar ve Dirsekler", 1 },
                    { new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), "C", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pul ve Rondelalar", 1 },
                    { new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), "H", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Hortumlar, Kelepçeler, Klipsler", 1 },
                    { new Guid("e36337f1-7967-db93-2e0d-242546697931"), "F", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Aksesuarlar (Vana, Termometre vs.)", 1 },
                    { new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), "Z", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Gruplanmamış Standart Parçalar", 1 }
                });

            migrationBuilder.InsertData(
                table: "StockSequences",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "LastNumber", "ModifiedBy", "ModifiedDate", "Prefix4", "StartNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("01016317-a4e0-e483-e2a4-2ceb7fa8f1ac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA3", 0, 1 },
                    { new Guid("04b46eea-2124-7e22-841f-18923c928c0f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE0", 0, 1 },
                    { new Guid("0b9e68d8-e8bb-7345-f141-92c305e1e816"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC6", 0, 1 },
                    { new Guid("0e152dff-4c00-8e5c-a4d2-55b54960206f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA2", 0, 1 },
                    { new Guid("15c7507a-9f9b-20fd-6ec0-e39cacc0e59e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE5", 0, 1 },
                    { new Guid("16359c70-042f-9e42-85a9-0c4aa4c56d21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC7", 0, 1 },
                    { new Guid("168a8095-3cc6-c69c-a0bd-ebb53caeafa7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB0", 0, 1 },
                    { new Guid("1692528e-624a-89c7-65a3-be284d6a673d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA0", 0, 1 },
                    { new Guid("1c313c8d-33d3-f18c-5bfa-114bcb62a55e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA0", 0, 1 },
                    { new Guid("1e7f8749-39bf-9828-b6c8-f0b4885201a0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC0", 0, 1 },
                    { new Guid("24647e99-46dc-6a79-e589-0bd97659aea4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA5", 0, 1 },
                    { new Guid("257bd970-05c4-751f-8180-fdb0233d77e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA5", 0, 1 },
                    { new Guid("25bed300-11ac-8798-e35b-99ff8a9cc130"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB4", 0, 1 },
                    { new Guid("27a4669d-51b4-6aff-3f89-8afe3021291d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC3", 0, 1 },
                    { new Guid("2947ec74-c544-cbb4-dc6f-ab077e6c9b1e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA1", 0, 1 },
                    { new Guid("2a7e5b70-d953-e686-4d16-b8dbdec08c3e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC4", 0, 1 },
                    { new Guid("2ad2b3c7-d999-080b-c743-e66c58458a46"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB9", 0, 1 },
                    { new Guid("2b2074cd-dbd0-5f20-c6bb-fa36013ee4cd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE1", 0, 1 },
                    { new Guid("2b42df79-8ebd-4d8f-a582-b09b22da3451"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA3", 0, 1 },
                    { new Guid("2bae01fc-51b6-e4a0-1e1e-1e2d7632ca52"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAD0", 0, 1 },
                    { new Guid("2f6dfa2b-8f7f-7e4e-b0d6-8fd5c39cc3b8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBD0", 0, 1 },
                    { new Guid("2fbf1894-a8ae-2edb-5a77-4c2fd63e25aa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA1", 0, 1 },
                    { new Guid("302ac8ae-1132-043b-fd25-5fc33b8f71b0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC2", 0, 1 },
                    { new Guid("33aac10b-421b-4644-58ab-a0b2207dd006"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA4", 0, 1 },
                    { new Guid("34d9cc2d-feec-edfe-3a15-296f01769dd9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB9", 0, 1 },
                    { new Guid("35dc9616-c0b6-f384-0da8-c20f8a866ce9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF7", 0, 1 },
                    { new Guid("38cb1d14-d4d0-c02e-3f17-14797270a8ba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA8", 0, 1 },
                    { new Guid("3bb55cc5-fe82-75ca-abec-b0798d295939"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB0", 0, 1 },
                    { new Guid("40933366-a230-60ef-ed1b-8dfe6bb95cdc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA4", 0, 1 },
                    { new Guid("4382d52a-173e-a191-81c2-5ced16b2407c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC0", 0, 1 },
                    { new Guid("446aed7c-61ff-62f6-f34a-90f3471964e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA7", 0, 1 },
                    { new Guid("49d63223-95aa-dbc2-6c4a-94658a969eb1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC0", 0, 1 },
                    { new Guid("4c2d1dae-aea9-f36f-01df-0c3d29e18136"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB2", 0, 1 },
                    { new Guid("4d366856-c4f4-5783-32da-bba6ec7a0981"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC8", 0, 1 },
                    { new Guid("4f695a4c-db8f-56ed-8b48-b04a04138844"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE2", 0, 1 },
                    { new Guid("516d4a63-72bd-bc79-a964-b5695fc5c16a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE4", 0, 1 },
                    { new Guid("51984092-6ceb-20fe-52b2-6c9340a9aa9c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE8", 0, 1 },
                    { new Guid("52ff9dec-e03a-7b3a-5ccb-5bedd50678e2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAD1", 0, 1 },
                    { new Guid("54b68a8c-52a8-a0b8-6e9f-9474d6c9f338"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF6", 0, 1 },
                    { new Guid("5894bd46-0272-1c11-5340-4f3b8a4808f4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB8", 0, 1 },
                    { new Guid("5971ee4a-2baa-aa54-b533-d9fcec909249"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB1", 0, 1 },
                    { new Guid("59fd2e1f-ef7d-895e-1b09-7550c7cdc02d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF3", 0, 1 },
                    { new Guid("5eaf082c-951d-02e1-1106-d96879ff7e21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF8", 0, 1 },
                    { new Guid("5fc1f762-9b00-aa70-021e-200ecfb9362d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBD1", 0, 1 },
                    { new Guid("63efac71-abd9-09e3-ba04-9bb3aab352f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF2", 0, 1 },
                    { new Guid("6588efc8-40c2-3c85-c069-3e8a2d2400a1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA6", 0, 1 },
                    { new Guid("661ec3a1-aab2-c08d-222a-4f7661c9ec76"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC1", 0, 1 },
                    { new Guid("67da5134-fb6a-97d5-b623-2c752cd8cf9a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB2", 0, 1 },
                    { new Guid("6bf7293e-6d93-57ee-6baf-a4fc88ae187c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA7", 0, 1 },
                    { new Guid("6c4fc270-699a-a103-6678-9771a29672ff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB3", 0, 1 },
                    { new Guid("6e9184c7-db20-fb4b-1fb6-0c494b13a7f2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB6", 0, 1 },
                    { new Guid("6f1467f9-f6b0-d017-184c-f1ba8bb8d23d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB1", 0, 1 },
                    { new Guid("75a71400-e49e-ebca-b206-b09024e3ee83"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF9", 0, 1 },
                    { new Guid("7b28731a-c4c5-e59d-1e8a-825237ab36fc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB7", 0, 1 },
                    { new Guid("7c2b25b3-d160-7949-fd8c-a682e5fd3b0a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB5", 0, 1 },
                    { new Guid("7c47ba34-0281-cbf8-d305-1f6431d2ff30"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF0", 0, 1 },
                    { new Guid("83da4f95-2247-a1d3-484c-d11a7b55879b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC1", 0, 1 },
                    { new Guid("85c836c6-9327-a681-34a2-a9cfe15298da"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB4", 0, 1 },
                    { new Guid("88e424db-ad8c-5ced-1d8c-6951705b3039"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB7", 0, 1 },
                    { new Guid("8cb063c8-b5d7-1667-4b4e-6b0dc8bc8ed3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB3", 0, 1 },
                    { new Guid("93047b51-4c62-fecb-0295-194fdbe9e9d7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBE1", 0, 1 },
                    { new Guid("937b88be-cbbc-e1bf-ffa5-a04499d06579"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA3", 0, 1 },
                    { new Guid("9868b7ad-7586-24f9-fec5-cf37f26072ac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE7", 0, 1 },
                    { new Guid("9ea57885-a3d7-87e3-0188-e5721d680e38"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB5", 0, 1 },
                    { new Guid("a12f6d5b-ef10-c238-78ed-9fcd906056c3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA6", 0, 1 },
                    { new Guid("a1340f00-e620-466a-2dab-253915b62123"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE6", 0, 1 },
                    { new Guid("a2eb0676-290d-f924-452e-d49d9a9b1006"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA2", 0, 1 },
                    { new Guid("a4141846-5dc9-4824-baff-c9c87e444c1b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA9", 0, 1 },
                    { new Guid("a91c7959-db11-10f5-bd76-0280bde2e27e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA8", 0, 1 },
                    { new Guid("ac9ea1f0-238d-0be4-3b45-f4933a8d300c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC1", 0, 1 },
                    { new Guid("b4519f06-565e-4fbd-574c-b6a09e8aeecf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA5", 0, 1 },
                    { new Guid("b8a956d6-3815-42ef-c54c-3b71c39e66e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF5", 0, 1 },
                    { new Guid("bac90f00-80b6-2703-f447-e3819d07f044"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA2", 0, 1 },
                    { new Guid("bdd0c721-a225-bc8f-a811-0e3aeb17c79c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC3", 0, 1 },
                    { new Guid("be8207cf-2545-1c28-b048-e21a3f19c5c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC2", 0, 1 },
                    { new Guid("bfd2f5af-07e7-a2da-f90d-81af14e90920"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC5", 0, 1 },
                    { new Guid("c57d23cc-6821-713c-ceda-84f56c6e9439"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC4", 0, 1 },
                    { new Guid("cac01515-f504-becb-0f75-7d183d246fd1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA8", 0, 1 },
                    { new Guid("d1199c79-94d8-1902-e0a5-d905dc8729c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF1", 0, 1 },
                    { new Guid("d2747ea3-4527-4dec-5d48-19f9cb86f4d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB6", 0, 1 },
                    { new Guid("d2cbcf8c-1d36-0a28-5ac1-c985d79243d2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC6", 0, 1 },
                    { new Guid("d63acd7f-1016-9dfa-bc31-b7f8e19ff3e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE3", 0, 1 },
                    { new Guid("da9e8ef3-83ad-985a-bf4a-0636c1d49e6b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA9", 0, 1 },
                    { new Guid("db31f507-351c-ca53-2b55-b7dfca6b3a9a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF4", 0, 1 },
                    { new Guid("dbcd451e-e187-31f5-67a4-07a6b68d9770"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA0", 0, 1 },
                    { new Guid("dfebc11f-4b48-2226-5cbe-ee78206f7520"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC5", 0, 1 },
                    { new Guid("e699ca25-e08c-ecf0-5ee2-cfde3649093b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA7", 0, 1 },
                    { new Guid("e82626da-cb3e-58c5-e940-95ddd2a8c5f0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBE0", 0, 1 },
                    { new Guid("e925807e-38b2-20cc-2171-1aeb1c7a1624"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA6", 0, 1 },
                    { new Guid("eea332da-4c6c-0e1d-cccf-608e79670f40"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB8", 0, 1 },
                    { new Guid("f02185ee-de2e-1ea1-8d97-ce46ac24db9e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA1", 0, 1 },
                    { new Guid("f4233558-4090-5239-b767-e190a532efac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC2", 0, 1 },
                    { new Guid("f9bac86b-1090-67e4-4ef8-af587ee5c44c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC3", 0, 1 },
                    { new Guid("fb04a072-8da4-f2de-5089-00f2a9526cd0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA4", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "Notes", "ProductStandard", "Status", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7560), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Standard plate form for P355NH", "EN 10028-3", 0, 250.0, 1.0, 1.5, null });

            migrationBuilder.InsertData(
                table: "SFeatureValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "SFeatureId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("01175f21-981d-6ca8-d9c5-e7480162a958"), "PN16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN16", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 2, 1 },
                    { new Guid("054a46bb-a68a-9cda-34ff-ee128d50441b"), "DN125", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN125", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 10, 1 },
                    { new Guid("06fc354a-6eb6-3800-1cc3-58e9b6f2dcb0"), "DN150", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN150", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 11, 1 },
                    { new Guid("0f50e81b-d7a5-8e49-4bfb-f4fc900f691b"), "PN63", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN63", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 5, 1 },
                    { new Guid("25eb7a79-d5d8-461a-5f95-d866d44ef99b"), "DN20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN20", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 2, 1 },
                    { new Guid("50e9c503-d522-d137-f809-66fede14647d"), "PN10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN10", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 1, 1 },
                    { new Guid("547ed733-bbae-de9a-b066-fba661a1037f"), "DN80", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN80", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 8, 1 },
                    { new Guid("6e0339fb-2e14-6a52-fe61-deaf9000ed2a"), "RTJ", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ring Type Joint (Halka Tipli)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 2, 1 },
                    { new Guid("7a85d618-b989-23d9-16f9-53e854e1a109"), "DN40", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN40", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 5, 1 },
                    { new Guid("883815cb-61d4-492a-9c6c-bbc4acbd409f"), "DN65", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN65", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 7, 1 },
                    { new Guid("8d37e681-5779-9f0b-5b55-91bd20e1b8d8"), "DN200", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN200", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 12, 1 },
                    { new Guid("8ede875d-5589-bea9-3f46-54de32eb0aa0"), "DN32", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN32", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 4, 1 },
                    { new Guid("90124067-0b01-b301-0bfc-96e541a77327"), "DN10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN10", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 0, 1 },
                    { new Guid("90d76f02-88e8-557f-0ff5-047d87abef8f"), "PN25", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN25", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 3, 1 },
                    { new Guid("95075295-0726-bb0d-7259-9aa7a8e404eb"), "PN100", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN100", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 6, 1 },
                    { new Guid("96f2bef8-bb50-de79-4b77-7b177be48fed"), "DN50", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN50", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 6, 1 },
                    { new Guid("a344226c-0b4f-a4da-1d09-1e3e4498534c"), "PN160", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN160", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 7, 1 },
                    { new Guid("a4d30506-1b81-ee2d-d0e8-996f756308ad"), "DN100", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN100", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 9, 1 },
                    { new Guid("afa4c457-a7f4-ce14-e9e0-e11cd164a46c"), "FF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Flat Face (Düz Yüzey)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 1, 1 },
                    { new Guid("b0f8df36-9a7a-b248-5333-3f769f3fe3d1"), "DN25", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN25", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 3, 1 },
                    { new Guid("d5ca1f2d-52f9-485a-9b10-fc63a421c774"), "DN15", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN15", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 1, 1 },
                    { new Guid("d92f72dd-7c16-a741-a861-74f69d24cfbd"), "RF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Raised Face (Kabarık Yüzey)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 0, 1 },
                    { new Guid("e3ec4c06-4dfa-27e2-5b20-8eb3ed2a398b"), "TG", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tongue and Groove (Dil ve Oluk)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 4, 1 },
                    { new Guid("e61b6269-1fc9-a7cd-e92e-9238b9ade432"), "PN250", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN250", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 8, 1 },
                    { new Guid("e6734936-277e-946d-9feb-e1b45de88784"), "PN6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN6", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 0, 1 },
                    { new Guid("f05a20d9-40a3-2693-91a9-c97cb621ae02"), "LJ", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Lap Joint (Gevşek Flanş)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 3, 1 },
                    { new Guid("f7b34953-03ac-6e96-880b-c54bfa1ce84b"), "PN320", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN320", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 9, 1 },
                    { new Guid("f7c3851c-5b27-8fb1-fdbe-44bd11a9a69c"), "PN40", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN40", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "SProducts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "PrefixIndex", "SProductGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), "SBB5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI CROM", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), "SBA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB CROM", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), "SAE2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN CELIK", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), "F9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), "SBB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 12.9", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), "SAE5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN SOMUN", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), "SBA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 12.9", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), "SAC5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB SAC VİDASI/AKILLI VİDA CROM", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), "SBE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN WHITWORTH / UNC / UNF", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), "SBB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB FIBERLI CROM", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), "SBA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI CROM", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), "SAA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB CROM", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), "F8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), "SAA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 12.9", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), "SAA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), "SAD0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A193 B7", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), "SBC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI 10.9", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), "SAA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 10.9", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), "SAC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB TORNAVİDA YARIKLI 8.8", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), "SAB8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS CROM", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), "SBA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 8.8 FIBERLI", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), "SAB6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB TORNAVİDA YARIKLI 8.8", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), "SAB5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), "SAA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), "F5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), "SBC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN HALKALI", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), "SBA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 8.8", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), "F7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("697cf80a-b06a-c5cf-204c-914210302181"), "F3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), "SAC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB SAC VİDASI/AKILLI VİDA CROM", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), "SBD1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB A194-7", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), "SBE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN ÖZEL GRUP (Ör: UZATMALI)", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), "SAB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB YILDIZ KANALLI 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), "SBB2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 8.8", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), "SAE4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN KROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), "SAB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB TORNAVİDA YARIKLI 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), "SBB7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KAYNAK 10.9", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), "SAE7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SETŞKUR", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), "SAD1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A320 L7", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), "SAA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), "SBB6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KAYNAK 8.8", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), "SBA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 12.9", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), "F2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), "SAA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 12.9", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), "SAA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 10.9", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), "F6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), "SBC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI CROM", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), "SAE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA WHITWORTH / UNC / UNF", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), "SAE6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SAPLAMALAR", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), "SAA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), "SBA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 10.9", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), "SAC6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA KB (KELEBEK BASLI)", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), "SAB7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), "SBA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 10.9 FIBERLI", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), "F4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), "SBB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 12.9 FIBERLI", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), "SAE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA ÖZEL GRUP (Ör: GÖZLÜ)", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), "SAB9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI CROM", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), "SBA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 10.9", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), "SAC4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB İNBUS CROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), "SBB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 10.9", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), "SBC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN KELEBEK", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), "SBB9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI 8.8", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), "F1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), "SAC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB DUZ 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), "SBD0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB A194 2H", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), "SAB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), "SAC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB YILDIZ KANALLI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), "SBA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 8.8", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), "SAB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), "SAA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), "SAE8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "U-BOLT", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), "F0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), "SAE3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN ALUMINYUM", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), "SAB2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS CROM", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), "SBB8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KAYNAK CROM", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 }
                });

            migrationBuilder.InsertData(
                table: "SPrefixRules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FluidId", "ModifiedBy", "ModifiedDate", "Prefix", "SProductGroupId", "SProductId", "Status" },
                values: new object[,]
                {
                    { new Guid("09bca16d-618c-1f36-a4b4-08c452a4e2e2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("0d27e762-6758-cbce-49cc-852c44436c54"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("14ddbcf4-c820-201f-17e2-01dcefe0f4b6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("175362d3-b45f-cb5b-a3e2-21c7e186dae0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("1b019ef8-3079-d437-5640-00b4117ea08f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("1cb09bdc-dff1-3000-8ac2-8af33cd3282f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("299949d5-be36-8c6e-470f-faa28fb7e5af"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("2b375a53-07bf-ffe4-9c21-a482bf77be8c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("2e568aa1-f9db-5848-7d98-582d5b5357c8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("31e59bf6-5de3-0750-10fe-39615ef71ff5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 },
                    { new Guid("33594ffd-4ded-1466-93d1-800ebe82b0b0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("36cebe7d-dcd2-3089-2033-d3e6ec4b850d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("3cd700fb-ae47-30b9-b441-bc78c1a2c9f0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("4b707bf9-ef53-3625-dfe4-647bbf55625a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("4d88655d-5386-2d8b-90a4-75563bf95b90"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("53a7c554-32fc-968a-04e3-dcf680a3c79f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("58b6f4b2-633f-8531-b71e-2ea1a78b4c71"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("5c3cc8f9-cc84-9ae7-7d9a-89183ee9704e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("60a073db-7557-32eb-854d-280833eacd77"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("62fb66d4-7d9c-6712-38d8-e97d499980f6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("6a895009-83fc-600f-0b0b-54ac4730544a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("6fdc4b46-4f76-df0e-ba02-66a04b1eeac3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("70f23f5a-ce75-1382-901f-8f160ef5fdc0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("719f2cc5-44df-4f94-759b-e0b3ddd8917b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("730d4c3a-b37c-ec1f-8865-36e7399b5787"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("73e9e267-69c4-1957-f2d8-0edfe36fcde3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("76dfa081-e967-949d-4c70-ee51c242b58a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("777c1470-dab3-e66d-7a57-4569a02b086f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("7c24ea52-93b5-0ca0-23db-35879d4482fe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("7d1b1307-76db-97a7-bd95-1e0d134f349c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("7e2038c7-653a-9d23-9f8b-91d5a8a4dead"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("7fabe1cc-25b8-4c60-04b0-afb2928b2664"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 1 },
                    { new Guid("82a971b5-42af-16a5-a22f-1ece9e8741ea"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("9bb78401-11ed-b5e6-40ea-8ee8cf633241"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("9d34aaac-acb0-1168-624d-c86293435a23"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("a21d6956-84d3-daf6-d55a-2c0dcfb88202"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("a85523df-5b7b-3442-8c63-ff117b76ba4d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 },
                    { new Guid("b078e392-c5d1-e408-61e8-eabc0c26fa96"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF9", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), 1 },
                    { new Guid("c0caf8c0-fc14-9d22-e349-263b17e4f092"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("ca046319-441a-c8d9-84fa-461c31dbbed7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 1 },
                    { new Guid("cadfa220-8767-f769-9f7f-270c497bc80d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 1 },
                    { new Guid("cae0e0a2-7343-0045-5cab-b6291a23930f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("d781f29c-19d5-550e-5ebf-d292a2c0663b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 },
                    { new Guid("d78f180a-7f6d-75bf-7f2d-5dc4560c8854"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 },
                    { new Guid("db55bd8a-9ce4-136b-3c9a-c4e9a599397b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 },
                    { new Guid("e521982b-e38d-08bc-8733-709206009e73"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 1 },
                    { new Guid("ecbffe18-76ec-3663-83f0-17a91c850d93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("ee3184f7-ad60-6d13-ffe1-00dfde6401ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("ee50326a-e5ab-445a-2a5d-81342060452d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("f1cc7f4a-c2de-f90a-693e-62f881173b08"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 1 },
                    { new Guid("f1ea3b4b-68d6-19df-391b-5ee511364c54"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("f331d41a-0601-9f4c-5545-09a3e1b1ad63"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 1 },
                    { new Guid("f6926b04-61a2-e553-aa01-1fc50f063237"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 1 },
                    { new Guid("f758b8d5-3efb-a9a0-ab27-5035792caaa4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 1 },
                    { new Guid("f7c52295-50da-8a53-f40e-b8be15ebbec8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 1 }
                });

            migrationBuilder.InsertData(
                table: "SProductFeatures",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsRequired", "ModifiedBy", "ModifiedDate", "SFeatureId", "SProductId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("81c8f0ce-cb76-c2ab-3fba-1e4b0438a023"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 },
                    { new Guid("be82f566-416c-f373-7f91-db52d60fdebc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 },
                    { new Guid("f70f41e4-124f-1b58-b57d-c2fb14c44d29"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("0306b909-4b40-44cc-ab00-9f3046cb49b5"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7671), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("052b4fca-d21c-4b01-85ba-7fc4f2ce223b"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7698), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("05900583-8c88-416c-83d5-4931e0233f62"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7601), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("06fc366b-a2af-41c0-b368-3a78904e7b03"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7710), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("0ad62787-2f6b-4fa6-a7a9-7e226f2903f8"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7707), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("0b403a9d-7573-44c1-97f5-f79779283548"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7695), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("130dc35a-8577-470d-9115-dbdd04bf4fbe"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7618), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("1567d933-6678-4d4e-9b29-fd2b03a54bc4"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7612), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("15f83c78-6924-4b68-bb9a-3b3a7ca6893b"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7722), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("17871189-4a16-43b7-ab46-81e7bf386a6b"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7689), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("30698fcb-c743-400e-a3a0-57ac2b820bdf"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7703), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("322ab055-51a8-4d4f-8ad7-7ee92aecad46"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7629), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("36b4165e-da1f-4684-ae45-732e4e0e2da8"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7676), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("37dc5c59-4c62-459e-8987-fcb2539c3447"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7610), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("3b06d527-c9c1-420a-b949-06168c1bc321"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7576), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("4492b117-3eae-45d6-a3c9-b6e02d8b09f7"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7715), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("47346e5d-01f6-4cc8-a009-c0d4c6b7e60c"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7603), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("4f493771-8889-4519-8ead-bf344ee4a4c4"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7701), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("52d9825e-7b81-4623-985f-74f6575a4ee0"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7633), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("54467339-33c4-4ea3-9e86-bd6e087f6b1e"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7687), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("5586ab79-af2c-4331-bee2-99efb8abf86f"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7609), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("58d06064-50f5-44dd-9ffa-a27647295d88"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7631), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("59cd8f88-b099-4f2d-bcab-fe579d4032e7"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7620), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("5bfc386d-e76d-488f-8f6b-069984cacba0"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7674), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("69510cda-d5f1-4871-9ebb-29e288d93379"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7643), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("6a34f53a-f158-449f-b492-ad4b946add85"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7681), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("6e0cd184-53d6-4c14-a946-64bdd8914c49"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7683), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("7780da68-596f-4a49-8a16-1b19c98cc818"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7669), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("825aa50c-6b27-43eb-baf6-09f1a76dd717"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7579), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("839c5053-e6cb-4e9e-b9c1-cbba5b8865cb"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7685), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("875b1876-3f21-4b20-8a06-27f376c26fcf"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7667), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("87d9d3e0-c730-40a2-a1e0-bc622033687a"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7594), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("8d769039-857a-4ea6-86eb-e12505614198"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7693), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("8ea75f89-fd40-44ef-a016-477bf21dddc9"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7590), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("9afe0f6b-a0d1-4e57-9ee0-0f0b35353f46"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7622), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("9d3191a7-fe48-4838-ba30-736862b17484"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7697), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("9f0c0600-e25c-4340-81b5-6e1fd8e5c3a5"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7720), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("a26ade5d-652f-4833-b487-780c77c8c687"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7724), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("a70e15a2-3338-4772-932c-5837e6a296d9"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7588), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("a7c063ac-df44-409c-a810-1fa8f3d5ce25"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7635), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("aa80b634-55db-4b2b-9c4c-a961d62b8160"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7597), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("ad278247-9fa7-4979-aafe-dbbfd0d59f92"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7718), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("b3f883cc-9358-4e2d-a6b9-49ebdf61e55c"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7678), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("b60a0a9b-bdbc-4c2c-9ef2-050e114a7aa0"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7705), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("bffc8988-05cd-4ddd-b68d-1e2fbd9b2e19"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7637), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("c277d244-9117-4629-9b91-b7fa595b8233"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7607), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("cc459d9e-b153-4e5e-9132-a6c68343d2a9"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7615), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("ccf7bcf0-0286-4ac1-9696-5d663c0f0c7a"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7625), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("d3633eab-46af-4e7f-aeee-0cafac65fa88"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7713), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("d7cc5b59-72cc-4c49-89b2-f39f95aeec49"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7627), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("e8842f6f-cf7f-481f-81fa-5e4fb138bc67"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7639), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("ec52d67d-d9c3-4a20-b934-8540b0786de7"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7586), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("f802d6b0-1922-4e0f-a6e2-754a0811acc6"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7712), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("ffb3c871-1635-4f5a-b96e-f6a3e0e2681b"), "SeedData", new DateTime(2026, 2, 5, 15, 7, 37, 960, DateTimeKind.Utc).AddTicks(7599), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 }
                });

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
                name: "IX_StockSequences_Prefix4",
                table: "StockSequences",
                column: "Prefix4",
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
                name: "EN13458Calculations");

            migrationBuilder.DropTable(
                name: "GasTypeDesignStandards");

            migrationBuilder.DropTable(
                name: "GasTypePressures");

            migrationBuilder.DropTable(
                name: "PrefixRules");

            migrationBuilder.DropTable(
                name: "SGroupFilterRules");

            migrationBuilder.DropTable(
                name: "SPrefixRules");

            migrationBuilder.DropTable(
                name: "SProductFeatures");

            migrationBuilder.DropTable(
                name: "StockCardFeatureSelections");

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
                name: "DesignStandards");

            migrationBuilder.DropTable(
                name: "SCategories");

            migrationBuilder.DropTable(
                name: "SFeatureValues");

            migrationBuilder.DropTable(
                name: "StockCards");

            migrationBuilder.DropTable(
                name: "StorageTypes");

            migrationBuilder.DropTable(
                name: "GasTypes");

            migrationBuilder.DropTable(
                name: "MaterialForms");

            migrationBuilder.DropTable(
                name: "SFeatures");

            migrationBuilder.DropTable(
                name: "Fluids");

            migrationBuilder.DropTable(
                name: "SAssemblyGroups");

            migrationBuilder.DropTable(
                name: "SProducts");

            migrationBuilder.DropTable(
                name: "StockSequences");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "SProductGroups");
        }
    }
}
