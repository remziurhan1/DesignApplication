using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sg5 : Migration
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
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2758), null, null, 7850.0, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0 });

            migrationBuilder.InsertData(
                table: "SFeatures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), "SG_LENGTH", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Boy (mm)", 4, 1 },
                    { new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), "SG_STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 2, 1 },
                    { new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), "SC_MATERIAL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Malzeme", 2, 1 },
                    { new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), "PN", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Basınç Sınıfı (Pressure Nominal)", 1, 1 },
                    { new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), "HEAD_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Baş Tipi", 3, 1 },
                    { new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), "SE_MATERIAL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Malzeme", 2, 1 },
                    { new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), "VOLTAGE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Voltaj", 4, 1 },
                    { new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), "SB_METRIC", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ölçü (Metrik)", 4, 1 },
                    { new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), "SC_METRIC", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ölçü (Metrik)", 4, 1 },
                    { new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), "METRIC", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Metrik Ölçü", 6, 1 },
                    { new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), "SG_COATING", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kaplama", 5, 1 },
                    { new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), "LENGTH", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Boy (mm)", 7, 1 },
                    { new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), "SB_COATING", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey İşlemi", 5, 1 },
                    { new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), "STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 5, 1 },
                    { new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), "ANGLE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Açı", 5, 1 },
                    { new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), "CONNECTION_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Tipi", 1, 1 },
                    { new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), "SE_STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 5, 1 },
                    { new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), "PRODUCT_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ürün Tipi", 1, 1 },
                    { new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), "MATERIAL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Malzeme", 2, 1 },
                    { new Guid("74708664-794d-9dea-796f-719c7b164797"), "SC_STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 3, 1 },
                    { new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), "CROSS_SECTION", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kesit/Kapasite", 3, 1 },
                    { new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), "STRENGTH", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Mukavemet Sınıfı", 8, 1 },
                    { new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), "COLOR_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Renk/Tip", 6, 1 },
                    { new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), "SD_STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 3, 1 },
                    { new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), "SB_STANDARD", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Standart", 3, 1 },
                    { new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), "SB_STRENGTH", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Mukavemet Sınıfı", 2, 1 },
                    { new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), "CONNECTION_SIZE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Ölçüsü", 4, 1 },
                    { new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), "NUT_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Somun Tipi", 1, 1 },
                    { new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), "SG_DIAMETER", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çap (mm)", 3, 1 },
                    { new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), "COATING", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey Kaplama", 9, 1 },
                    { new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), "SURFACE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey Tipi (Flange Face)", 3, 1 },
                    { new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), "PRODUCT_CATEGORY", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ürün Kategorisi", 1, 1 },
                    { new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), "SD_MATERIAL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Malzeme", 2, 1 },
                    { new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), "DN", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Anma Çapı (Nominal Diameter)", 2, 1 },
                    { new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), "SD_COATING", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey İşlemi", 6, 1 },
                    { new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), "WASHER_TYPE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Rondela Tipi", 1, 1 },
                    { new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), "SG_MATERIAL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Malzeme", 1, 1 },
                    { new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), "THREAD_SYSTEM", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diş Sistemi", 4, 1 },
                    { new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), "SC_COATING", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yüzey İşlemi", 5, 1 }
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
                    { new Guid("026ff68f-8b91-d336-7bd8-408e2eac676e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB4", 0, 1 },
                    { new Guid("033cd817-2d1c-02c3-eb9e-33449dadc1ec"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA7", 0, 1 },
                    { new Guid("037a69b8-d4b9-52bd-f15b-f6715dc68044"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC8", 0, 1 },
                    { new Guid("047c2958-e3b2-8809-efa0-c833c3fb3cfb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE0", 0, 1 },
                    { new Guid("04b46eea-2124-7e22-841f-18923c928c0f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE0", 0, 1 },
                    { new Guid("07c30f21-da46-546e-493c-fe6f567c4561"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB9", 0, 1 },
                    { new Guid("0850a96e-4557-b6d5-26a6-3ba4eb76ef05"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB1", 0, 1 },
                    { new Guid("09b443d8-aeb2-a204-ee26-6fd5349d2436"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA9", 0, 1 },
                    { new Guid("0b9e68d8-e8bb-7345-f141-92c305e1e816"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC6", 0, 1 },
                    { new Guid("0bbca75c-b6b1-5f3f-2126-ae11325aa6ae"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA3", 0, 1 },
                    { new Guid("0e152dff-4c00-8e5c-a4d2-55b54960206f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA2", 0, 1 },
                    { new Guid("0ffce261-8b1e-1783-3131-fc6880ea7360"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB3", 0, 1 },
                    { new Guid("1401adb3-3e29-b8ac-2941-b2bbcc2f8668"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB8", 0, 1 },
                    { new Guid("14f0c4bc-b7c8-c675-613f-602b7a2884bb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA1", 0, 1 },
                    { new Guid("15c7507a-9f9b-20fd-6ec0-e39cacc0e59e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE5", 0, 1 },
                    { new Guid("16359c70-042f-9e42-85a9-0c4aa4c56d21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC7", 0, 1 },
                    { new Guid("1651d064-8636-6a2e-fe51-2b568d92c9b0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA8", 0, 1 },
                    { new Guid("168a8095-3cc6-c69c-a0bd-ebb53caeafa7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB0", 0, 1 },
                    { new Guid("1692528e-624a-89c7-65a3-be284d6a673d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA0", 0, 1 },
                    { new Guid("1ab1da7d-715c-a5ce-5787-526010badd51"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB3", 0, 1 },
                    { new Guid("1ba6f76b-7ab3-4c0b-f750-eb707113adad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA4", 0, 1 },
                    { new Guid("1c313c8d-33d3-f18c-5bfa-114bcb62a55e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA0", 0, 1 },
                    { new Guid("1e7f8749-39bf-9828-b6c8-f0b4885201a0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC0", 0, 1 },
                    { new Guid("1eeb6a1f-931a-e0a5-f4a6-f8ad3580a219"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE3", 0, 1 },
                    { new Guid("2049c50b-fb75-3712-5acc-a7b44705ff62"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF3", 0, 1 },
                    { new Guid("21805003-dd35-9203-cc55-fa42e0b94b72"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC6", 0, 1 },
                    { new Guid("24647e99-46dc-6a79-e589-0bd97659aea4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA5", 0, 1 },
                    { new Guid("257bd970-05c4-751f-8180-fdb0233d77e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA5", 0, 1 },
                    { new Guid("25bed300-11ac-8798-e35b-99ff8a9cc130"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB4", 0, 1 },
                    { new Guid("27a4669d-51b4-6aff-3f89-8afe3021291d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC3", 0, 1 },
                    { new Guid("2947ec74-c544-cbb4-dc6f-ab077e6c9b1e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA1", 0, 1 },
                    { new Guid("2a7e5b70-d953-e686-4d16-b8dbdec08c3e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC4", 0, 1 },
                    { new Guid("2ad12443-bc53-c844-eb53-2434f761a351"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA6", 0, 1 },
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
                    { new Guid("36bdf210-35de-4b17-e5ae-6941be73ce59"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC7", 0, 1 },
                    { new Guid("381a7564-293f-e5fe-86d0-a70c17983bce"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF1", 0, 1 },
                    { new Guid("382c6544-f14a-31d6-bf7c-d8c098e45d4c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SED1", 0, 1 },
                    { new Guid("38cb1d14-d4d0-c02e-3f17-14797270a8ba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA8", 0, 1 },
                    { new Guid("3bb55cc5-fe82-75ca-abec-b0798d295939"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB0", 0, 1 },
                    { new Guid("3fc87212-5cba-6458-6994-0a62bb514e95"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC3", 0, 1 },
                    { new Guid("4084f42b-47ee-5e7a-bcd9-00ec7e7458eb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC3", 0, 1 },
                    { new Guid("40933366-a230-60ef-ed1b-8dfe6bb95cdc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA4", 0, 1 },
                    { new Guid("41a4f38a-3c2e-f05a-304a-0fc3b14e2b09"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA1", 0, 1 },
                    { new Guid("42053fca-9c80-ed5c-a554-b4cd8b778a8b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE4", 0, 1 },
                    { new Guid("4382d52a-173e-a191-81c2-5ced16b2407c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC0", 0, 1 },
                    { new Guid("446aed7c-61ff-62f6-f34a-90f3471964e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA7", 0, 1 },
                    { new Guid("49d63223-95aa-dbc2-6c4a-94658a969eb1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC0", 0, 1 },
                    { new Guid("4aa75aba-ea91-14ea-2139-5992dbc367e4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA4", 0, 1 },
                    { new Guid("4c2d1dae-aea9-f36f-01df-0c3d29e18136"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB2", 0, 1 },
                    { new Guid("4d366856-c4f4-5783-32da-bba6ec7a0981"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC8", 0, 1 },
                    { new Guid("4ed33c9e-3569-069b-43ce-d86ae2569ced"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD5", 0, 1 },
                    { new Guid("4f695a4c-db8f-56ed-8b48-b04a04138844"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE2", 0, 1 },
                    { new Guid("512d794b-1e3a-3ac4-f6fb-572a68e073a2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA6", 0, 1 },
                    { new Guid("516d4a63-72bd-bc79-a964-b5695fc5c16a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE4", 0, 1 },
                    { new Guid("51984092-6ceb-20fe-52b2-6c9340a9aa9c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE8", 0, 1 },
                    { new Guid("522bddbb-68dc-9694-b835-5c61cbf2c6dd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEAA", 0, 1 },
                    { new Guid("52ff9dec-e03a-7b3a-5ccb-5bedd50678e2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAD1", 0, 1 },
                    { new Guid("54b68a8c-52a8-a0b8-6e9f-9474d6c9f338"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF6", 0, 1 },
                    { new Guid("58524f7a-45e8-8bcc-4ce3-9dda977200ec"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA5", 0, 1 },
                    { new Guid("5894bd46-0272-1c11-5340-4f3b8a4808f4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB8", 0, 1 },
                    { new Guid("5971ee4a-2baa-aa54-b533-d9fcec909249"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB1", 0, 1 },
                    { new Guid("59fd2e1f-ef7d-895e-1b09-7550c7cdc02d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF3", 0, 1 },
                    { new Guid("5c79bd1f-a61f-712a-2d8c-b25cff7d50b1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA5", 0, 1 },
                    { new Guid("5d9179b2-b817-c059-2948-819f539dfcde"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA6", 0, 1 },
                    { new Guid("5e1260ad-847e-4874-86a0-76011b372844"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF9", 0, 1 },
                    { new Guid("5eaf082c-951d-02e1-1106-d96879ff7e21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF8", 0, 1 },
                    { new Guid("5fc1f762-9b00-aa70-021e-200ecfb9362d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBD1", 0, 1 },
                    { new Guid("62a3a33d-bcfd-d26d-3370-e5aa4f1a874d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA0", 0, 1 },
                    { new Guid("63e2f7ac-2277-8a35-ef30-859b79381d74"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB7", 0, 1 },
                    { new Guid("63efac71-abd9-09e3-ba04-9bb3aab352f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF2", 0, 1 },
                    { new Guid("6588efc8-40c2-3c85-c069-3e8a2d2400a1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA6", 0, 1 },
                    { new Guid("661ec3a1-aab2-c08d-222a-4f7661c9ec76"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC1", 0, 1 },
                    { new Guid("66b0ce40-3eae-dbdb-9fbb-32c0e7d2fe1b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD1", 0, 1 },
                    { new Guid("67da5134-fb6a-97d5-b623-2c752cd8cf9a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB2", 0, 1 },
                    { new Guid("67f4e893-de09-57f8-2ea2-ddadccbded74"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEF0", 0, 1 },
                    { new Guid("6bf7293e-6d93-57ee-6baf-a4fc88ae187c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA7", 0, 1 },
                    { new Guid("6c4fc270-699a-a103-6678-9771a29672ff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB3", 0, 1 },
                    { new Guid("6ce5b980-58dd-4d23-97e3-89a49788f264"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD4", 0, 1 },
                    { new Guid("6e9184c7-db20-fb4b-1fb6-0c494b13a7f2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB6", 0, 1 },
                    { new Guid("6f1467f9-f6b0-d017-184c-f1ba8bb8d23d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB1", 0, 1 },
                    { new Guid("6f30aff2-10dc-778e-09ec-7a5f2ab1f752"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD2", 0, 1 },
                    { new Guid("70e7b39b-5fb1-860d-1179-7941308024ed"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA3", 0, 1 },
                    { new Guid("7291b6e6-bd74-ad49-5d47-1e634cd50c95"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC1", 0, 1 },
                    { new Guid("73c7ab1a-023b-829b-3512-a7ae8cbc9a90"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC2", 0, 1 },
                    { new Guid("74580410-8ef2-2bc3-0982-efcae6c1c6e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA2", 0, 1 },
                    { new Guid("75a71400-e49e-ebca-b206-b09024e3ee83"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF9", 0, 1 },
                    { new Guid("76f609bb-e88f-ce9f-4012-4df1064e502d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA1", 0, 1 },
                    { new Guid("78d46a40-0dc1-b48e-0fc3-ee5871cf71f1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF4", 0, 1 },
                    { new Guid("79235044-8994-3069-8503-67d4cf9da2da"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDG3", 0, 1 },
                    { new Guid("7b28731a-c4c5-e59d-1e8a-825237ab36fc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB7", 0, 1 },
                    { new Guid("7c2b25b3-d160-7949-fd8c-a682e5fd3b0a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB5", 0, 1 },
                    { new Guid("7c47ba34-0281-cbf8-d305-1f6431d2ff30"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF0", 0, 1 },
                    { new Guid("7f044960-9c2b-d32f-6e64-729a82e5bc42"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC2", 0, 1 },
                    { new Guid("83da4f95-2247-a1d3-484c-d11a7b55879b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC1", 0, 1 },
                    { new Guid("85c836c6-9327-a681-34a2-a9cfe15298da"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB4", 0, 1 },
                    { new Guid("88aab533-0b82-a2ea-7280-d2da776c6173"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA7", 0, 1 },
                    { new Guid("88bd927d-1e4c-cb31-6621-d86457e6888d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA8", 0, 1 },
                    { new Guid("88e424db-ad8c-5ced-1d8c-6951705b3039"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB7", 0, 1 },
                    { new Guid("89c00860-6b37-aa9e-b1cf-cd7dca094cf7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA2", 0, 1 },
                    { new Guid("8b095489-b111-7660-0150-fa5c4d35ce14"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC9", 0, 1 },
                    { new Guid("8beffd20-396e-a055-d5a3-67f5469b4826"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA1", 0, 1 },
                    { new Guid("8cb063c8-b5d7-1667-4b4e-6b0dc8bc8ed3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB3", 0, 1 },
                    { new Guid("93047b51-4c62-fecb-0295-194fdbe9e9d7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBE1", 0, 1 },
                    { new Guid("937b88be-cbbc-e1bf-ffa5-a04499d06579"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA3", 0, 1 },
                    { new Guid("93a9c8f0-b4e2-2b7a-9899-d38aa4e97989"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE1", 0, 1 },
                    { new Guid("954a9b87-1112-896e-2da5-1021dc3e92a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB4", 0, 1 },
                    { new Guid("95dbd87f-4992-47bb-42aa-26d3a6ef1d29"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA9", 0, 1 },
                    { new Guid("96f11c17-b45e-5de0-a494-7fdf519a8934"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDI1", 0, 1 },
                    { new Guid("98267808-32bb-684e-9e23-4e1af135b155"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA6", 0, 1 },
                    { new Guid("9868b7ad-7586-24f9-fec5-cf37f26072ac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE7", 0, 1 },
                    { new Guid("987934f7-622e-9b77-1a7c-68187ac287b2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB0", 0, 1 },
                    { new Guid("9bbfbde8-5399-b302-f435-90f865304bc6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB5", 0, 1 },
                    { new Guid("9cd61c46-586f-e16f-ffff-8adce2ea83b2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDG1", 0, 1 },
                    { new Guid("9d2f0012-6fff-9f61-9baf-d132817a797a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA0", 0, 1 },
                    { new Guid("9ea57885-a3d7-87e3-0188-e5721d680e38"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB5", 0, 1 },
                    { new Guid("9f76636d-46fd-baed-ba76-d95b34fe2562"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA9", 0, 1 },
                    { new Guid("a0a9d0b6-235f-ab93-8bd0-560fa3817283"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC0", 0, 1 },
                    { new Guid("a12f6d5b-ef10-c238-78ed-9fcd906056c3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA6", 0, 1 },
                    { new Guid("a1340f00-e620-466a-2dab-253915b62123"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE6", 0, 1 },
                    { new Guid("a2eb0676-290d-f924-452e-d49d9a9b1006"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA2", 0, 1 },
                    { new Guid("a4141846-5dc9-4824-baff-c9c87e444c1b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA9", 0, 1 },
                    { new Guid("a61dbce8-c966-34d7-d1b2-5947ff8fdbf6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA4", 0, 1 },
                    { new Guid("a8a21162-31b8-7049-3bf3-811294d88422"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB2", 0, 1 },
                    { new Guid("a91c7959-db11-10f5-bd76-0280bde2e27e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA8", 0, 1 },
                    { new Guid("a96c0ddd-05f2-c4eb-676a-bebe644f9730"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SED0", 0, 1 },
                    { new Guid("ac9ea1f0-238d-0be4-3b45-f4933a8d300c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC1", 0, 1 },
                    { new Guid("b0a4edc9-f77a-2684-21a5-2067dc1a884e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE2", 0, 1 },
                    { new Guid("b0a7e833-2d0b-9428-30e8-af8d46a391a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC1", 0, 1 },
                    { new Guid("b4519f06-565e-4fbd-574c-b6a09e8aeecf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA5", 0, 1 },
                    { new Guid("b582257e-1b5c-5964-4631-20547ba44592"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD0", 0, 1 },
                    { new Guid("b6d2bcbe-9e92-2fa0-1eb1-6eff1c6ce395"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEE0", 0, 1 },
                    { new Guid("b737d036-6ff2-ee88-d4e8-b9f447ea2612"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC5", 0, 1 },
                    { new Guid("b8a956d6-3815-42ef-c54c-3b71c39e66e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF5", 0, 1 },
                    { new Guid("bac90f00-80b6-2703-f447-e3819d07f044"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA2", 0, 1 },
                    { new Guid("bc39e87b-0266-21fb-225d-1ca23f7b61a6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA2", 0, 1 },
                    { new Guid("bce72a21-7ad0-6ce7-2456-83e896acd05d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA0", 0, 1 },
                    { new Guid("bd2ec289-7bc5-432d-7eb5-547436c0b8e9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCB0", 0, 1 },
                    { new Guid("bdd0c721-a225-bc8f-a811-0e3aeb17c79c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC3", 0, 1 },
                    { new Guid("be609388-2af8-5387-4c8c-9f4a750284df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA8", 0, 1 },
                    { new Guid("be6946d9-99ef-891e-7610-b1dc16b2413f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC0", 0, 1 },
                    { new Guid("be8207cf-2545-1c28-b048-e21a3f19c5c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBC2", 0, 1 },
                    { new Guid("bf50ae35-7ae6-48ba-d91a-7a86c20da203"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA7", 0, 1 },
                    { new Guid("bfd2f5af-07e7-a2da-f90d-81af14e90920"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC5", 0, 1 },
                    { new Guid("c17016ba-69b6-f4fa-d6d8-cdd3efa9f740"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD3", 0, 1 },
                    { new Guid("c3e8d964-26f7-6389-bb31-f90716c8016a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC4", 0, 1 },
                    { new Guid("c57d23cc-6821-713c-ceda-84f56c6e9439"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC4", 0, 1 },
                    { new Guid("c8583115-6b55-731a-2b2a-2d0eb382fc06"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA2", 0, 1 },
                    { new Guid("c9072b3f-8f91-1fdc-c100-db4d882feec1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB6", 0, 1 },
                    { new Guid("cac01515-f504-becb-0f75-7d183d246fd1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFA8", 0, 1 },
                    { new Guid("cbc1a444-ff9f-a13e-7afc-6bf7d35490c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SED9", 0, 1 },
                    { new Guid("ce52ef9f-93a9-c315-8020-beeb7c788166"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB1", 0, 1 },
                    { new Guid("d1199c79-94d8-1902-e0a5-d905dc8729c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF1", 0, 1 },
                    { new Guid("d2747ea3-4527-4dec-5d48-19f9cb86f4d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAB6", 0, 1 },
                    { new Guid("d2cbcf8c-1d36-0a28-5ac1-c985d79243d2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC6", 0, 1 },
                    { new Guid("d63acd7f-1016-9dfa-bc31-b7f8e19ff3e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAE3", 0, 1 },
                    { new Guid("d685a442-7ad5-25fc-d906-d4432cb0cf6a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA0", 0, 1 },
                    { new Guid("d709d2b7-6a4c-28e8-3ba6-1a8d814ea290"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEC4", 0, 1 },
                    { new Guid("d98b8232-4691-7fbd-ff92-ff0789a26392"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB0", 0, 1 },
                    { new Guid("da9e8ef3-83ad-985a-bf4a-0636c1d49e6b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA9", 0, 1 },
                    { new Guid("db31f507-351c-ca53-2b55-b7dfca6b3a9a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFF4", 0, 1 },
                    { new Guid("dbcd451e-e187-31f5-67a4-07a6b68d9770"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA0", 0, 1 },
                    { new Guid("dc7fb47b-c77a-0242-3d4e-e78fc89b16e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB2", 0, 1 },
                    { new Guid("ddc1c18a-0179-5ad8-c231-26b049e45aae"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEG0", 0, 1 },
                    { new Guid("dfebc11f-4b48-2226-5cbe-ee78206f7520"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC5", 0, 1 },
                    { new Guid("e1460aab-8c7a-4147-2625-89656a924a41"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDH0", 0, 1 },
                    { new Guid("e1fe5127-1aed-ea1e-3699-2a77afd8317a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA7", 0, 1 },
                    { new Guid("e2bac1a2-c0d7-795d-f0fd-31837fbb6fab"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA5", 0, 1 },
                    { new Guid("e699ca25-e08c-ecf0-5ee2-cfde3649093b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA7", 0, 1 },
                    { new Guid("e82626da-cb3e-58c5-e940-95ddd2a8c5f0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBE0", 0, 1 },
                    { new Guid("e925807e-38b2-20cc-2171-1aeb1c7a1624"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBA6", 0, 1 },
                    { new Guid("e9b7da90-238b-0b70-cff5-3d4663ad8f55"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA9", 0, 1 },
                    { new Guid("ea34262c-ce06-306f-2d56-b15dabc936f8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEF1", 0, 1 },
                    { new Guid("ea8443d3-005a-dd34-006d-26e743dc92d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA5", 0, 1 },
                    { new Guid("eea332da-4c6c-0e1d-cccf-608e79670f40"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SBB8", 0, 1 },
                    { new Guid("ef4b768d-cf6e-6f2c-6ad7-5455d36a8b09"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA4", 0, 1 },
                    { new Guid("f02185ee-de2e-1ea1-8d97-ce46ac24db9e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA1", 0, 1 },
                    { new Guid("f2c1b37e-9021-99de-0ad7-5055a2a94734"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF2", 0, 1 },
                    { new Guid("f4233558-4090-5239-b767-e190a532efac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAC2", 0, 1 },
                    { new Guid("f4cb5ca0-aaa8-cc9e-1f62-151c19b6c956"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDH1", 0, 1 },
                    { new Guid("f58714c8-8314-a1c2-5363-ed189d83b7bf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA3", 0, 1 },
                    { new Guid("f628aa1d-3760-a37f-909a-9ebd0d83094a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF0", 0, 1 },
                    { new Guid("f6dce319-e757-932d-c5e8-da8dca12354c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA8", 0, 1 },
                    { new Guid("f70dcab0-81cc-a0ce-374f-0111822d91db"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCE1", 0, 1 },
                    { new Guid("f8347ba4-dede-4271-c5e0-f1d7dc323f83"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA3", 0, 1 },
                    { new Guid("f9bac86b-1090-67e4-4ef8-af587ee5c44c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SFC3", 0, 1 },
                    { new Guid("fb04a072-8da4-f2de-5089-00f2a9526cd0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 999, null, null, "SAA4", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "Notes", "ProductStandard", "Status", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2790), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Standard plate form for P355NH", "EN 10028-3", 0, 250.0, 1.0, 1.5, null });

            migrationBuilder.InsertData(
                table: "SFeatureValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "SFeatureId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("000200ce-9c93-cbf9-4215-e9ca6ccc8326"), "Elektrikli Isıtıcılar", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrikli Isıtıcılar", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 24, 1 },
                    { new Guid("001948f8-f78c-36ee-b1af-fbd810e4b322"), "690V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "690V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 11, 1 },
                    { new Guid("00b63f65-5ff7-cf20-ec19-1a8318c4b9e3"), "Silikon", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Silikon", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 4, 1 },
                    { new Guid("00f494eb-cdcf-1d33-ba9d-9bfc5315cfc0"), "Halkalı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Halkalı", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 5, 1 },
                    { new Guid("01175f21-981d-6ca8-d9c5-e7480162a958"), "PN16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN16", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 2, 1 },
                    { new Guid("0199538e-5903-05f1-0d4a-ba697b10e502"), "M8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M8", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 21, 1 },
                    { new Guid("01c2d54f-1fa6-1f3a-edde-c32b883d54f2"), "Çinko Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çinko Kaplama", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 1, 1 },
                    { new Guid("0320313b-0588-75d8-7a03-f5b26eeabc6f"), "Bronz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bronz", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 11, 1 },
                    { new Guid("03684fc1-47c9-3461-cfc0-fbeefa9f6d49"), "Güç Kaynakları", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Güç Kaynakları", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 26, 1 },
                    { new Guid("03b5964f-e34c-60b9-f78d-b0519cd0ef33"), "M20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M20", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 5, 1 },
                    { new Guid("04e9c91c-7ac4-45b7-b573-434056c04727"), "AKB Şapkalı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "AKB Şapkalı", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 1, 1 },
                    { new Guid("04eb13fb-d622-961c-7eda-f265b039d178"), "DIN 2353", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 2353", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 0, 1 },
                    { new Guid("052b61b9-d605-df42-4f2b-757631dddafd"), "Kaplamasız", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kaplamasız", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 0, 1 },
                    { new Guid("052f0900-8b8a-c245-8c93-2a5478fa563c"), "Kauçuk", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kauçuk", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 7, 1 },
                    { new Guid("054a46bb-a68a-9cda-34ff-ee128d50441b"), "DN125", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN125", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 10, 1 },
                    { new Guid("063c5167-6185-00f1-4ebf-8928c86a408e"), "50A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "50A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 27, 1 },
                    { new Guid("066ca5b0-d282-09ef-2863-9d32f4aa8adb"), "Dirsek", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Dirsek", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 2, 1 },
                    { new Guid("06abec0f-74f0-d937-267d-1249d2224e15"), "NR Terminal Pipe", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "NR Terminal Pipe", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 13, 1 },
                    { new Guid("06fc354a-6eb6-3800-1cc3-58e9b6f2dcb0"), "DN150", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN150", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 11, 1 },
                    { new Guid("07cba7c1-ce00-43a1-03ad-cf41995b837f"), "22mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "22mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 8, 1 },
                    { new Guid("08be781f-a378-f4ef-05aa-a2b103571b7d"), "45mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "45 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 8, 1 },
                    { new Guid("08db67ae-5381-5919-54cf-1aa4e6a9bff5"), "1000V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1000V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 12, 1 },
                    { new Guid("090a4836-6cbd-92fa-94ff-55492f799615"), "150mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "150mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 17, 1 },
                    { new Guid("0a634ac7-d633-2b18-3c40-ded61142b5bd"), "Sertleştirilmiş Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sertleştirilmiş Çelik", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 8, 1 },
                    { new Guid("0b6f4e67-6b64-f678-f7d6-7a75f3021d59"), "12mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 11, 1 },
                    { new Guid("0bdeaf2e-0dc8-8b1b-ee1f-0f3d7a85d126"), "Gri", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Gri", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 7, 1 },
                    { new Guid("0dd89a46-4e21-366e-e257-87b6221cb9b3"), "M16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M16", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 25, 1 },
                    { new Guid("0e34f63c-bf68-8964-2767-5f9cb7ad6631"), "Bronz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bronz", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 7, 1 },
                    { new Guid("0f50e81b-d7a5-8e49-4bfb-f4fc900f691b"), "PN63", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN63", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 5, 1 },
                    { new Guid("10019d85-d4c7-8c65-16ce-a19073931b7c"), "DN20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN20", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 15, 1 },
                    { new Guid("10455cdc-79c9-7bf6-549d-2d78ddf1a928"), "Veri Okuma Cihazları", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Veri Okuma Cihazları", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 28, 1 },
                    { new Guid("12a8778a-17ce-8a21-d9a2-f67410f69dd2"), "Mavi", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Mavi", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 2, 1 },
                    { new Guid("133fbe8a-bf15-9265-8c3f-b06a359da7de"), "Krom Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Krom Kaplama", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 2, 1 },
                    { new Guid("13f56aa1-ed4c-11f1-4205-5ae0c8449520"), "10mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 0, 1 },
                    { new Guid("1479fef9-3f13-bc75-2e69-73fbb2156a9f"), "M24", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M24", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 6, 1 },
                    { new Guid("1530668d-bd6c-48a9-96e6-a3f4348da822"), "40mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "40 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 7, 1 },
                    { new Guid("16c45be8-bb6a-b89e-2a87-ce6c23aceb73"), "200mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "200mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 31, 1 },
                    { new Guid("17443fdf-a03f-f8de-cc3d-471162a7292f"), "Galvaniz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Galvaniz", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 4, 1 },
                    { new Guid("18d29cca-78d9-046c-c92c-f1a3f1d0478e"), "Paslanmaz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz", new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), 3, 1 },
                    { new Guid("19186f36-9102-28ae-5a8f-af9516b6214a"), "M8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M8", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 4, 1 },
                    { new Guid("194f8e1c-afe6-8cae-6a83-dc642a58a7ce"), "Kadmiyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kadmiyum", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 3, 1 },
                    { new Guid("19e98d7b-9cee-fc7e-05b5-55e5ef31e1d7"), "10.9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10.9", new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), 1, 1 },
                    { new Guid("1a02ae25-936c-c6da-a64c-a616b0381340"), "SAE J514", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SAE J514", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 2, 1 },
                    { new Guid("1abadabf-03c6-1969-bd99-e12b5553ab74"), "M27", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M27", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 7, 1 },
                    { new Guid("1acfc59c-7bc8-b523-ba59-c2090a3119e8"), "Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Alüminyum", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 1, 1 },
                    { new Guid("1afa19e6-80f3-6e9b-87d0-4f3200edcf07"), "380V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "380V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 7, 1 },
                    { new Guid("1b8bd7a5-2837-79f7-4b41-26948458901a"), "Kablo Endüstriyel", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Endüstriyel", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 35, 1 },
                    { new Guid("1cb6f11a-8719-a8e6-fbf5-2aec19924724"), "Algılayıcılar", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Algılayıcılar", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 30, 1 },
                    { new Guid("1cbcdbb2-9993-6daa-49e9-406827feb971"), "M22", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M22", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 28, 1 },
                    { new Guid("1cca1fc1-5d6c-64a2-a92f-98aa7c4b3973"), "DIN 912", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 912", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 4, 1 },
                    { new Guid("1d45e798-9715-5462-fb10-a64cb824b93d"), "1/2\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1/2\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 2, 1 },
                    { new Guid("1da251f4-1765-1dfa-2c2e-f9c79340e17c"), "Teflon Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Teflon Kaplama", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 7, 1 },
                    { new Guid("1db46594-e918-dd9e-a895-568cfeb84797"), "M10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M10", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 22, 1 },
                    { new Guid("1eaa6727-c99d-750a-f05d-f8e91144f612"), "185mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "185mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 18, 1 },
                    { new Guid("1eb5ea02-cd79-3f69-b4bf-c5f49fd51665"), "Taçlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Taçlı", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 4, 1 },
                    { new Guid("1f59b018-7347-47e2-c454-a753d0fecca9"), "45°", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "45°", new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), 0, 1 },
                    { new Guid("20eec9cc-303a-20ab-0b89-07c158980f2e"), "PE (Polietilen)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PE (Polietilen)", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 8, 1 },
                    { new Guid("22770f34-765b-254e-c92f-597eb03f787c"), "63A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "63A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 28, 1 },
                    { new Guid("23f63db2-b542-bc88-15fb-e686ec534e2d"), "Diyot", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diyot", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 9, 1 },
                    { new Guid("24049a63-eaf9-6c42-d256-4b9c609db082"), "Doğal (Kaplamasız)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Doğal (Kaplamasız)", new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), 0, 1 },
                    { new Guid("24d04ace-80d7-581c-e51d-92a8f4439fff"), "ISO 4017", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 4017", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 2, 1 },
                    { new Guid("25427a4e-6b82-4f60-7aa1-3f2d16728c0e"), "48V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "48V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 2, 1 },
                    { new Guid("25eb7a79-d5d8-461a-5f95-d866d44ef99b"), "DN20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN20", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 2, 1 },
                    { new Guid("2789df7b-10c5-aaf6-a21b-468ea02525cc"), "4\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "4\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 10, 1 },
                    { new Guid("28c5fd8d-51e7-5c2f-7d9d-69fa23a51507"), "Karbon Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Karbon Çelik", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 2, 1 },
                    { new Guid("28ec695d-4545-3b09-01fa-abcd7df88ff7"), "70mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "70mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 14, 1 },
                    { new Guid("298b85b0-e9d1-cfb1-3e4a-b62e1ec6ed6c"), "Düz Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Düz Alüminyum", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 1, 1 },
                    { new Guid("2ba8ebd0-7975-384a-693b-a0b5957e110a"), "400V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "400V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 8, 1 },
                    { new Guid("2bbe22b1-69c7-a2cf-89d3-d8f77b24cc1e"), "200mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "200 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 17, 1 },
                    { new Guid("2d16616a-6fc1-aae8-5c06-fdf39c717ca1"), "16mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "16mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 14, 1 },
                    { new Guid("2d84fbb8-a852-3626-0065-fbbcfa3da91d"), "8.8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "8.8", new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), 0, 1 },
                    { new Guid("2ec08433-934f-dc22-c7ba-0978f7d5ed0e"), "Bakır", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bakır", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 0, 1 },
                    { new Guid("2ec7529e-be49-1390-31b8-0f4a6e613032"), "50mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "50mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 13, 1 },
                    { new Guid("2ec8ef4d-4252-6dee-8b6a-8efad7f258d6"), "M6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M6", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 3, 1 },
                    { new Guid("3062a6e4-be85-ed97-3024-b5810b060a1b"), "65mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "65mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 19, 1 },
                    { new Guid("3111e6ed-962f-d27d-16a7-8192fccd3c3c"), "Square Tapered", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Square Tapered", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 10, 1 },
                    { new Guid("319f3d49-ee9d-1e40-75e3-dd18ceccc745"), "Çok Damarlı (Renkli)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çok Damarlı (Renkli)", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 11, 1 },
                    { new Guid("31a30441-83b5-c4c5-2f6e-778282f1fa06"), "Ampul & Lamba", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ampul & Lamba", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 10, 1 },
                    { new Guid("31cdcc17-92b8-9617-984f-1846cf0dda23"), "Rondela", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Rondela", new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), 3, 1 },
                    { new Guid("31f01e70-2c5f-4773-08fe-003a38fed7b1"), "DN80", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN80", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 21, 1 },
                    { new Guid("32b1714e-5a88-a6f7-bca6-86b8c6a75c49"), "120mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "120mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 16, 1 },
                    { new Guid("34934a78-17cc-cf9a-29b4-1b0f8c2419ba"), "2.5mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "2.5mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 3, 1 },
                    { new Guid("3522c81b-fd2e-3994-166d-7c038bc87b69"), "Bağlantı Kutusu", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Kutusu", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 36, 1 },
                    { new Guid("3532ec52-2275-5b6c-6a66-2cb554583474"), "Kablo Uç Yüksüğü", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Uç Yüksüğü", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 19, 1 },
                    { new Guid("355d7109-7b76-fca1-e92a-b2429ad4f030"), "Pnömatik Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pnömatik Çelik", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 1, 1 },
                    { new Guid("35a35389-81bf-c065-bff7-ea02b6e42eb1"), "Boru Boğazı/Bağlayıcı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Boru Boğazı/Bağlayıcı", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 5, 1 },
                    { new Guid("362bbee5-6f15-92cb-7db2-f3ab07b7fc05"), "Özel Grup (Uzatmalı)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Özel Grup (Uzatmalı)", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 7, 1 },
                    { new Guid("3794dacf-cd2d-69a3-badd-68d5f48b8609"), "Sarı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sarı", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 5, 1 },
                    { new Guid("385ce2c4-061c-2b5e-4123-14f369bf8c30"), "Fittings", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Fittings", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 7, 1 },
                    { new Guid("3897db5b-1967-7666-5dfa-084138fc8c52"), "Plastik (PA)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Plastik (PA)", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 6, 1 },
                    { new Guid("39441e58-c1e5-8bc2-f6f9-4bca62d015e3"), "DN25", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN25", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 16, 1 },
                    { new Guid("3a1a394b-431d-c75e-ade8-3340f53297c6"), "DIN 1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 1", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 0, 1 },
                    { new Guid("3ae125e3-dfa8-7150-35b9-75b584a547c9"), "6mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "6mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 8, 1 },
                    { new Guid("3bf2cd17-ad4d-7844-f0b6-f5f83eab64d4"), "ISO 8734", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 8734", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 5, 1 },
                    { new Guid("3c093f7c-d87e-a922-5013-c4aacb271426"), "Kablo Tambur", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Tambur", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 27, 1 },
                    { new Guid("3c5263d1-16e2-6aad-d4b8-af71d93d11d0"), "Haberleşme Modülleri", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Haberleşme Modülleri", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 31, 1 },
                    { new Guid("3cb9c54a-742e-f45e-1c5c-1f648d5966ad"), "Konnektör & Soket", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Konnektör & Soket", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 8, 1 },
                    { new Guid("3ccd24d0-b2ab-f3ba-b435-154d5e296a3f"), "Kontra", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kontra", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 2, 1 },
                    { new Guid("4007203f-f776-8192-46a6-35ad76457cdc"), "T (Tee)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "T (Tee)", new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), 3, 1 },
                    { new Guid("4032e798-4e64-a4e3-20d0-4782ec892a55"), "Bakır Kalay Kaplı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bakır Kalay Kaplı", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 2, 1 },
                    { new Guid("40de35d8-6524-267d-3875-b0ed9b77c02b"), "DIN 985", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 985", new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), 1, 1 },
                    { new Guid("4198a4bb-7342-906d-736b-031a22433e9a"), "Altıgen Başlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Altıgen Başlı", new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), 0, 1 },
                    { new Guid("43359f5d-52e0-19b5-9812-c8887267a9dd"), "M36", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M36", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 9, 1 },
                    { new Guid("434b4b15-4347-3fb9-c10f-f63da62bf8ac"), "16mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "16mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 10, 1 },
                    { new Guid("4466511a-de8f-fcb8-47de-22935089311e"), "24V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "24V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 1, 1 },
                    { new Guid("4485e1bd-7a82-d19f-3adf-63d5ad5c95db"), "DN100", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN100", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 22, 1 },
                    { new Guid("4531b68e-7fb6-e5a0-a99f-a82e0aa5a07a"), "M27", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M27", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 30, 1 },
                    { new Guid("45381550-72ba-19d8-b15c-d9bb360d0e1d"), "M14", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M14", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 7, 1 },
                    { new Guid("4596fb97-16de-930f-af8d-e21ee34fdeea"), "DIN 2615", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 2615", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 8, 1 },
                    { new Guid("47923c07-e8ae-a6d7-9e41-1b02a4006035"), "BSW", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "BSW", new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), 4, 1 },
                    { new Guid("482b9798-4e9f-9dc5-9516-11f158369d44"), "12mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 3, 1 },
                    { new Guid("49b93af8-8c07-9684-1c13-440b44b96875"), "55mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "55mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 17, 1 },
                    { new Guid("49ce1e0b-bce8-745f-7c32-002d72d6e274"), "Spiral Makaron/Kablo Kılıfı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Spiral Makaron/Kablo Kılıfı", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 14, 1 },
                    { new Guid("49febff1-84e6-c9f6-f7d2-5140c4e9278b"), "4.8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "4.8 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 1, 1 },
                    { new Guid("4a5d4c73-487a-4f41-f371-0c45e3764f4e"), "Yeşil", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeşil", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 4, 1 },
                    { new Guid("4b244b46-f104-161f-c94c-9d8bc0f29921"), "5.8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5.8 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 3, 1 },
                    { new Guid("4b369823-6c66-0324-90b0-589548969e60"), "35mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "35 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 6, 1 },
                    { new Guid("4b555b24-e811-1ac9-8cc2-112e2af58590"), "18mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "18mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 15, 1 },
                    { new Guid("4beee406-3e04-7a76-3ce7-4d310b2d7d95"), "Düz Crom", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Düz Crom", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 3, 1 },
                    { new Guid("4d143434-333f-d50a-afbb-7a799e74b8c5"), "M12", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M12", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 6, 1 },
                    { new Guid("4f1b9f8d-6610-f7f1-bf65-b18c459b6eaf"), "Galvaniz Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Galvaniz Çelik", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 10, 1 },
                    { new Guid("502e9dd8-8205-5a47-0e32-d3ea2c83b5e1"), "M6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M6", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 0, 1 },
                    { new Guid("5054a57a-5d49-8bf1-ac3f-d70cd719220d"), "Paslanmaz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 2, 1 },
                    { new Guid("50e9c503-d522-d137-f809-66fede14647d"), "PN10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN10", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 1, 1 },
                    { new Guid("5278756b-d53a-7349-0537-23bfc79c618e"), "ISO 4014", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 4014", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 3, 1 },
                    { new Guid("5321a4d4-4fe3-d823-105d-a354cf907e9b"), "Şeffaf", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Şeffaf", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 10, 1 },
                    { new Guid("547ed733-bbae-de9a-b066-fba661a1037f"), "DN80", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN80", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 8, 1 },
                    { new Guid("5535d695-a363-3006-8916-ced6dafb51f6"), "DIN 2566", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 2566", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 4, 1 },
                    { new Guid("55450dcf-d74c-733c-a439-bdfd76d1bb74"), "90mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "90mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 23, 1 },
                    { new Guid("55acca10-09f4-d0c7-7fd7-2a53cebe03ae"), "90mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "90 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 13, 1 },
                    { new Guid("5741b242-c0c0-1bbf-fa58-2fbfe00757a0"), "Nikel Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Nikel Kaplama", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 2, 1 },
                    { new Guid("57d4be25-ff82-9f82-305c-7595a4ea6fcf"), "25mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "25mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 9, 1 },
                    { new Guid("57f668c6-00c9-0de4-6088-0067184a8213"), "Nikel Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Nikel Kaplama", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 5, 1 },
                    { new Guid("580742c5-a11f-1d3c-af17-672064b3832c"), "Paslanmaz Çelik AISI 304", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 304", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 1, 1 },
                    { new Guid("585387cc-524f-122d-cbf8-e51f9c2129f9"), "90°", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "90°", new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), 1, 1 },
                    { new Guid("593cb550-1562-4091-01ef-dbc72b30c3fa"), "2.5mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "2.5mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 6, 1 },
                    { new Guid("59b632fb-dae6-1e92-a857-62b0af5e16d9"), "M20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M20", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 5, 1 },
                    { new Guid("59e6ea13-2390-b81a-d65d-21bc3e379504"), "Sarı/Yeşil", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sarı/Yeşil", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 3, 1 },
                    { new Guid("5a4e4d75-234c-6620-e68d-370177192127"), "Fosfor Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Fosfor Kaplama", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 6, 1 },
                    { new Guid("5b8d9f02-dd84-be74-e116-b4f854e842f6"), "Metrik Kısmi Dişli", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Metrik Kısmi Dişli", new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), 1, 1 },
                    { new Guid("5b9e601a-60a1-102f-a0ab-041fa01be2a9"), "M30", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M30", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 8, 1 },
                    { new Guid("5beef565-2c64-1b2e-1082-d9983c78cbf1"), "8mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "8mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 1, 1 },
                    { new Guid("5db16739-5fbc-e7ac-79e1-7852d43fb617"), "70mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "70mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 20, 1 },
                    { new Guid("5e54e5b6-24c5-bba4-590d-6a2e2950d0df"), "14mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "14mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 13, 1 },
                    { new Guid("5ea1df51-05f9-541d-5560-f0bccaf65752"), "M8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M8", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 1, 1 },
                    { new Guid("5f196f20-17cb-99a3-6578-e2bb21482864"), "100mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "100mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 24, 1 },
                    { new Guid("602e4eb0-7b8e-1f8b-65a3-d215eb3ea0dc"), "ISO 8735", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 8735", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 6, 1 },
                    { new Guid("60907e3e-87f0-b2c9-32fe-846733e254fa"), "DN65", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN65", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 20, 1 },
                    { new Guid("60b7e200-9bb4-dac8-c9f7-aa4b6100a8b0"), "Karbon Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Karbon Çelik", new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), 0, 1 },
                    { new Guid("611e154e-286b-cf1e-0e1d-998158e351f1"), "IEC 60227", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "IEC 60227", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 0, 1 },
                    { new Guid("61a72db7-e940-7dfa-2688-7ffdb294d3bf"), "Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Alüminyum", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 3, 1 },
                    { new Guid("6212668f-2c12-4e3e-6a9c-e8ef598b230a"), "240V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "240V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 6, 1 },
                    { new Guid("627fddcf-3d78-b62a-b9ec-bb45b9c736bb"), "M10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M10", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 2, 1 },
                    { new Guid("64685576-d5b0-c2fa-4f04-77639aaa0390"), "Havşa Başlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Havşa Başlı", new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), 1, 1 },
                    { new Guid("64755c38-60e0-715e-290f-3266dac1e65e"), "20mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "20mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 16, 1 },
                    { new Guid("647edef8-b537-5500-e504-285fcc8bbf8b"), "M16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M16", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 4, 1 },
                    { new Guid("6616e215-fa9b-e428-0b64-29ce9da94a22"), "95mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "95mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 15, 1 },
                    { new Guid("66284f57-c985-e5af-1e5c-6f725a3b3ac5"), "Çinko Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çinko Kaplama", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 1, 1 },
                    { new Guid("665ac3ae-896f-a48a-4d79-5e22d7cd77a5"), "M4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M4", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 1, 1 },
                    { new Guid("6722055d-dd00-da19-ba1b-64db3f57ff55"), "Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Alüminyum", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 1, 1 },
                    { new Guid("676678de-6013-61ed-5276-024a0047deaf"), "M36", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M36", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 9, 1 },
                    { new Guid("67c304da-922a-c42d-2c20-fd9900cc6081"), "10mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 10, 1 },
                    { new Guid("688306de-82e0-d9a7-026e-bc60d35938b2"), "M30", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M30", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 14, 1 },
                    { new Guid("68a424f2-44d9-7679-4901-828846d517ad"), "Yaylı Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yaylı Çelik", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 4, 1 },
                    { new Guid("69112c9b-4606-3048-547e-85e91d4ac315"), "M10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M10", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 5, 1 },
                    { new Guid("69568426-1ddb-8156-c99b-03b70325d8c5"), "DIN 71412", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 71412", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 9, 1 },
                    { new Guid("6a5b6ddb-fad8-c270-0807-226a46bcd449"), "1\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 4, 1 },
                    { new Guid("6ca63e7d-5d68-659e-5393-4b321e387cc6"), "Düz Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Düz Çelik", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 0, 1 },
                    { new Guid("6ce08250-71e7-d3bc-5ba9-0295be39afb7"), "M5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M5", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 2, 1 },
                    { new Guid("6d1d6ee8-bbf7-4b02-34f7-59607bcb147f"), "UNC", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "UNC", new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), 2, 1 },
                    { new Guid("6e0339fb-2e14-6a52-fe61-deaf9000ed2a"), "RTJ", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Ring Type Joint (Halka Tipli)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 2, 1 },
                    { new Guid("6e66981a-2d46-d04e-117b-e21f4003ab60"), "ASTM F436", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ASTM F436", new Guid("74708664-794d-9dea-796f-719c7b164797"), 5, 1 },
                    { new Guid("6f23e5b5-e2e0-53ae-ea3b-e0911cb0e8c1"), "30mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "30mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 19, 1 },
                    { new Guid("6f800006-6c8a-23f7-7448-754040d3a6b7"), "Kurşun Asit (Akü)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kurşun Asit (Akü)", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 9, 1 },
                    { new Guid("6f80eef6-e8c5-6f47-da8c-2f66c29a72f4"), "120mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "120 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 15, 1 },
                    { new Guid("708ebc78-d2ef-beec-c039-786c83b7f725"), "Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Alüminyum", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 3, 1 },
                    { new Guid("71237be0-2e1d-a0e8-636e-ef660a96d969"), "300mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "300mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 20, 1 },
                    { new Guid("71e2913b-0867-ee08-185a-baead9712552"), "M27", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M27", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 13, 1 },
                    { new Guid("7261c6d5-2b31-2b95-2613-76d10484b9ff"), "Doğal", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Doğal", new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), 0, 1 },
                    { new Guid("72edc35d-66ef-bfa6-e3bb-786961cc7ab4"), "Silindirik Başlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Silindirik Başlı", new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), 3, 1 },
                    { new Guid("739b4a34-00f0-e002-3b51-edf96c370b91"), "DIN 127", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 127", new Guid("74708664-794d-9dea-796f-719c7b164797"), 1, 1 },
                    { new Guid("7437cfde-5cab-7617-6aae-bc9815ac34aa"), "DIN VDE 0250", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN VDE 0250", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 2, 1 },
                    { new Guid("76293e09-e8fd-c217-d9d6-362543776f80"), "Kablo Tesisat", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Tesisat", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 0, 1 },
                    { new Guid("77c9add0-1120-c4b8-8984-df5ceb23a74b"), "150mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "150mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 28, 1 },
                    { new Guid("79752c22-ada5-42c8-68f6-19ceed0bf0d0"), "35mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "35mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 12, 1 },
                    { new Guid("797aa1ab-38d5-c4b7-ccb8-814251396c17"), "DN32", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN32", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 17, 1 },
                    { new Guid("79a031e9-f197-1780-897e-026f666299d8"), "M6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M6", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 0, 1 },
                    { new Guid("7a85d618-b989-23d9-16f9-53e854e1a109"), "DN40", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN40", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 5, 1 },
                    { new Guid("7ac95671-d079-6417-25e2-0e09189b95b9"), "180°", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "180°", new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), 2, 1 },
                    { new Guid("7aef7adf-9d96-0637-dbf4-254ebec02348"), "Akü", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Akü", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 4, 1 },
                    { new Guid("7bb04c59-4d2e-6d8f-8daa-6ad68c051527"), "Paslanmaz Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik", new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), 1, 1 },
                    { new Guid("7bf8e756-2993-d135-fc2f-dcc096f796fd"), "DIN 7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 7", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 2, 1 },
                    { new Guid("7ca5b462-cee5-4f1e-c683-53e78d8603d9"), "500V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "500V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 10, 1 },
                    { new Guid("7d331339-e607-b884-f7ea-3122b7ad37dc"), "Şalter", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Şalter", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 6, 1 },
                    { new Guid("7d9570e5-e3a1-de37-4d05-7dd28379f93a"), "ASTM A194-2H", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ASTM A194-2H", new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), 3, 1 },
                    { new Guid("7e263a72-4857-cd62-10a8-8f4c1373f937"), "Kablo ve Kumanda Sistemleri", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo ve Kumanda Sistemleri", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 20, 1 },
                    { new Guid("7e3a27cd-5e57-bf03-0190-b9d5354d24f2"), "Polietilen (PE)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Polietilen (PE)", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 5, 1 },
                    { new Guid("80a30016-970f-0c32-388a-3baa09893046"), "Tırtırlı Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tırtırlı Çelik", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 6, 1 },
                    { new Guid("81453916-b85a-c46b-9ff9-2273d085b611"), "M16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M16", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 8, 1 },
                    { new Guid("81919965-bc85-7542-6de1-c6ad1ce31a53"), "Özel Grup (Süper, EPDM/II)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Özel Grup (Süper, EPDM/II)", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 9, 1 },
                    { new Guid("81add8b2-d088-c2aa-ef20-56ce30066595"), "Sıcak Galvaniz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sıcak Galvaniz", new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), 4, 1 },
                    { new Guid("81f563ca-cfdb-2e23-62e5-0361c4b0ba2c"), "ISO 7089", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 7089", new Guid("74708664-794d-9dea-796f-719c7b164797"), 3, 1 },
                    { new Guid("8384f45f-b8cd-53a3-7769-63d6ce46eb1e"), "Isı Büzüşmeli Makaron", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Isı Büzüşmeli Makaron", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 15, 1 },
                    { new Guid("83c22487-8fe4-b5d5-dcc6-066c75169364"), "TSE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "TSE", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 3, 1 },
                    { new Guid("84402a72-8fb2-369f-7d6d-24bd3c178407"), "Pabuç Terminal", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pabuç Terminal", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 12, 1 },
                    { new Guid("84c6fa65-262f-2d67-1e5e-3805080e4b8b"), "Paslanmaz Çelik AISI 304", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 304", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 3, 1 },
                    { new Guid("84f56193-812b-d40b-2a59-58fa3824f02b"), "60mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "60mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 18, 1 },
                    { new Guid("854c0c96-e66a-c9cf-2a65-60d25f5d5196"), "0.75mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "0.75mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 3, 1 },
                    { new Guid("85f1f062-02d4-8266-b710-eb473015326a"), "Siyah", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Siyah", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 0, 1 },
                    { new Guid("8607dccc-8e33-fce2-5f77-5c1446154f61"), "M10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M10", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 2, 1 },
                    { new Guid("86319a6a-cdb8-2edb-0d05-a304cef2e3cf"), "Kırmızı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kırmızı", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 1, 1 },
                    { new Guid("88228740-9a3b-b79c-abb9-9abc3e4a5469"), "ASTM A105", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ASTM A105", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 5, 1 },
                    { new Guid("883815cb-61d4-492a-9c6c-bbc4acbd409f"), "DN65", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN65", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 7, 1 },
                    { new Guid("887fb481-faf3-9af6-4665-38eb18cae5e5"), "Rekor", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Rekor", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 0, 1 },
                    { new Guid("89204d5e-7673-040e-a326-0dccaae2ada6"), "4.6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "4.6 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 0, 1 },
                    { new Guid("89461ae2-34c8-b02e-f838-9b7fede7e779"), "25mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "25mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 11, 1 },
                    { new Guid("89d5ff0f-6e78-0ce8-6286-b13684569891"), "140mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "140mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 27, 1 },
                    { new Guid("8abf8b35-1210-6ae4-5f71-7ac34944fbc9"), "Pul", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pul", new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), 2, 1 },
                    { new Guid("8b406777-6544-84ff-e8e0-7d3463132acb"), "100A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "100A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 30, 1 },
                    { new Guid("8b6958d9-b0d5-76a5-4f51-9c7359184eeb"), "M24", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M24", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 12, 1 },
                    { new Guid("8c16162b-61ca-5374-b718-6067fc286f95"), "70mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "70 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 11, 1 },
                    { new Guid("8ccef3a1-a885-6b43-ee66-903ff68c40fd"), "30mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "30 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 5, 1 },
                    { new Guid("8d37e681-5779-9f0b-5b55-91bd20e1b8d8"), "DN200", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN200", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 12, 1 },
                    { new Guid("8d46af9b-1d0f-3f72-a9a2-f2feba090beb"), "Tırtırlı Paslanmaz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tırtırlı Paslanmaz", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 11, 1 },
                    { new Guid("8d51ffa2-713e-e6c3-d86e-9ea93c8f2099"), "Cıvata", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Cıvata", new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), 0, 1 },
                    { new Guid("8de30b81-9665-0f00-8d9c-95f55302f196"), "Çanak Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çanak Çelik", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 7, 1 },
                    { new Guid("8df8055b-9ffa-1b9b-21ea-62784acba5f9"), "180mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "180mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 30, 1 },
                    { new Guid("8ebaaccc-b633-0d61-364b-272e20434419"), "10mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 2, 1 },
                    { new Guid("8ede875d-5589-bea9-3f46-54de32eb0aa0"), "DN32", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN32", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 4, 1 },
                    { new Guid("8f559493-0d37-a1f4-69e9-455fce653fcb"), "Pirinç", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pirinç", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 5, 1 },
                    { new Guid("8fc909b1-c6ef-f1aa-0dfe-95353a4cc3d9"), "Bakır", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bakır", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 2, 1 },
                    { new Guid("90124067-0b01-b301-0bfc-96e541a77327"), "DN10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN10", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 0, 1 },
                    { new Guid("905f629c-7da5-9eac-170c-6f5cfe329fdb"), "M27", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M27", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 7, 1 },
                    { new Guid("90d76f02-88e8-557f-0ff5-047d87abef8f"), "PN25", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN25", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 3, 1 },
                    { new Guid("90e082b7-1c51-7813-ca18-2390518413a5"), "Geniş Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Geniş Çelik", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 8, 1 },
                    { new Guid("914e79cf-8a8d-99c6-4a0b-690c6fc7ac2e"), "DN50", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN50", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 19, 1 },
                    { new Guid("917d25f6-d8bf-b940-9d26-23f36f997dbc"), "Düz Bakır", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Düz Bakır", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 2, 1 },
                    { new Guid("923fcfc7-3b93-6ff5-eb2f-477c54788d3d"), "ISO 8434-1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 8434-1", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 1, 1 },
                    { new Guid("92cb30a0-0c2c-3fd8-2d5d-4b046ae264cf"), "18mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "18mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 6, 1 },
                    { new Guid("93135210-3532-53eb-e9c7-6ae0f4aee069"), "Yuvarlak Başlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yuvarlak Başlı", new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), 2, 1 },
                    { new Guid("93c86644-c2a6-b60c-2f06-d98ab44b378d"), "Siyah Oksit", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Siyah Oksit", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 5, 1 },
                    { new Guid("94a860bf-7679-82f6-a38d-97054177f249"), "DIN 6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 6", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 1, 1 },
                    { new Guid("95075295-0726-bb0d-7259-9aa7a8e404eb"), "PN100", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN100", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 6, 1 },
                    { new Guid("96020080-1c40-109d-0d31-933c642247f5"), "PPR", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PPR", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 7, 1 },
                    { new Guid("96919bc6-06ac-365a-2e72-27b9fd5523c2"), "25mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "25 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 4, 1 },
                    { new Guid("96b9ebde-e976-eb0c-cbdf-538ec1bbfdb5"), "M12", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M12", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 3, 1 },
                    { new Guid("96f2bef8-bb50-de79-4b77-7b177be48fed"), "DN50", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN50", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 6, 1 },
                    { new Guid("97725213-5747-0054-ffa4-5bb7c950abb3"), "1.5mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1.5mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 5, 1 },
                    { new Guid("990a12f3-23b5-3b8d-94d6-6d3ee1cbc4af"), "10mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 9, 1 },
                    { new Guid("992a9500-64ee-4790-d2c8-7a1c3c6faeec"), "8.8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "8.8 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 4, 1 },
                    { new Guid("99322bfc-18c3-f126-0e5b-dceed707d605"), "Bakır", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bakır", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 4, 1 },
                    { new Guid("996dbf03-34c9-82a0-576d-9be92a26336a"), "Doğal (Kaplamasız)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Doğal (Kaplamasız)", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 0, 1 },
                    { new Guid("99752941-3f1f-fa73-1993-6c220d47670d"), "Y (Y Bağlantı)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Y (Y Bağlantı)", new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), 4, 1 },
                    { new Guid("99ac5be0-8d37-bce4-8ea5-ac6799c358ed"), "Metrik Tam Dişli", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Metrik Tam Dişli", new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), 0, 1 },
                    { new Guid("99efe1a4-08cc-06df-5536-db9dd4627d28"), "DIN 9021", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 9021", new Guid("74708664-794d-9dea-796f-719c7b164797"), 2, 1 },
                    { new Guid("9a5d3f8d-dacf-d5ce-c264-100f9ee0c409"), "Tabela ve Levhalar", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tabela ve Levhalar", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 32, 1 },
                    { new Guid("9a9f899b-7701-e11f-7fb6-ad7df55e3528"), "Kablo Akü", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Akü", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 1, 1 },
                    { new Guid("9b21f038-2be2-1425-c25c-279a92d56e31"), "12mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 1, 1 },
                    { new Guid("9da7f9f8-3d63-9586-6b39-28644b4875a6"), "120mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "120mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 26, 1 },
                    { new Guid("9ddc27b9-d89d-e227-1c99-c8875b23a96f"), "Redüksiyon", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Redüksiyon", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 3, 1 },
                    { new Guid("9ece16cf-6872-2652-897e-27f1027a7677"), "ISO 4032", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 4032", new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), 2, 1 },
                    { new Guid("9f88dee9-c9e4-8e1b-5dc8-28858ab2ee64"), "M12", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M12", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 23, 1 },
                    { new Guid("9fa04707-f2d2-9a1a-739f-24d3212957cd"), "12.9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12.9 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 6, 1 },
                    { new Guid("9fd1742a-7c64-3172-dad4-55ccac25b805"), "160mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "160mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 29, 1 },
                    { new Guid("a08edc7f-f34e-fc7a-9a92-f36e93cb9354"), "12V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 0, 1 },
                    { new Guid("a0a93d36-d559-5045-7a07-69d9be0fe08b"), "M12", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M12", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 3, 1 },
                    { new Guid("a1f92ff5-1fa4-005e-e9e8-f9655d8b9c75"), "20A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "20A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 24, 1 },
                    { new Guid("a313f3b2-ae38-52f6-ccce-a4e2b73d7458"), "Teflon", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Teflon", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 4, 1 },
                    { new Guid("a31970af-22f0-2670-9208-bd70681b181d"), "80A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "80A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 29, 1 },
                    { new Guid("a344226c-0b4f-a4da-1d09-1e3e4498534c"), "PN160", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN160", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 7, 1 },
                    { new Guid("a3e045c1-d621-ecfb-14b7-1dfd7a254860"), "3\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "3\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 9, 1 },
                    { new Guid("a3f117a2-427c-64ad-9f38-8a1d46313041"), "Kaynak", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kaynak", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 3, 1 },
                    { new Guid("a3f78c46-b0c0-ca9b-e7f4-ca6fcafafd45"), "M30", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M30", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 8, 1 },
                    { new Guid("a419177b-89b9-b3b9-be96-b0ed5765c7c7"), "50mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "50 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 9, 1 },
                    { new Guid("a4292ef5-3a56-1f44-cbe4-741711ac76de"), "Kablo TTR", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo TTR", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 2, 1 },
                    { new Guid("a4d30506-1b81-ee2d-d0e8-996f756308ad"), "DN100", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN100", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 9, 1 },
                    { new Guid("a4dd4029-fcef-dae5-2262-71f9d2c549b1"), "2mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "2mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 2, 1 },
                    { new Guid("a54a1e4e-8250-5844-63a4-5b1ef4bff794"), "7mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "7mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 8, 1 },
                    { new Guid("a5557ceb-0f1b-4964-d4ae-726902b5859e"), "Elektro Galvaniz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektro Galvaniz", new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), 3, 1 },
                    { new Guid("a5648160-9881-2ef6-65cb-23f1579e5e19"), "M8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M8", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 1, 1 },
                    { new Guid("a5d1443f-10e5-89f8-5f34-8c891ecb5c4e"), "Pirinç", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pirinç", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 6, 1 },
                    { new Guid("a6546470-f64f-72f5-0ebf-d76c8a911875"), "5mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 6, 1 },
                    { new Guid("a6914879-4bcc-dec2-1ccb-b3b01748e2cb"), "M22", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M22", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 11, 1 },
                    { new Guid("a6ee6466-aef8-30d1-95c0-07e7c4e9782b"), "Yaylı Crom", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yaylı Crom", new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), 5, 1 },
                    { new Guid("a7d6b47f-70f7-6f84-6739-17fd28a4bb49"), "M20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M20", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 27, 1 },
                    { new Guid("a956dc82-937f-e846-7e29-dfffe001a0a4"), "415V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "415V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 9, 1 },
                    { new Guid("a9e19726-0802-5b00-4082-1de6e5308fda"), "Galvaniz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Galvaniz", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 4, 1 },
                    { new Guid("aa05bd44-4eab-97c4-2040-46c33a4549d7"), "Switch & Button", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Switch & Button", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 11, 1 },
                    { new Guid("aa96f46d-188f-5a8f-ef4e-b7585298b9b9"), "1 1/4\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1 1/4\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 5, 1 },
                    { new Guid("aade6f11-6bec-6b35-d242-704648e77ba3"), "Load Cell", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Load Cell", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 22, 1 },
                    { new Guid("aaf4153f-d16d-d5d9-bf1c-70a28a3eaa79"), "110mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "110mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 25, 1 },
                    { new Guid("abb10652-67a7-ffdc-60f1-c82f5e66f99d"), "Kornalar", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kornalar", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 25, 1 },
                    { new Guid("abc6c909-944d-ad7a-6223-1025a2405c01"), "EN 50525", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "EN 50525", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 8, 1 },
                    { new Guid("acc513f1-f6ef-0e7e-5c83-a28c4097fa34"), "DN8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN8", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 12, 1 },
                    { new Guid("acd6624a-ce2e-cd10-20e4-b3271a655629"), "DN10", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN10", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 13, 1 },
                    { new Guid("ace4b333-54e1-1cea-6aaf-3be51fa90942"), "Kahverengi", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kahverengi", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 8, 1 },
                    { new Guid("ad137458-19b7-616d-b223-1584aa8f96fe"), "10A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 22, 1 },
                    { new Guid("afa4c457-a7f4-ce14-e9e0-e11cd164a46c"), "FF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Flat Face (Düz Yüzey)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 1, 1 },
                    { new Guid("b07a6ae7-8ee6-3f6e-e253-592a434d021e"), "0.5mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "0.5mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 2, 1 },
                    { new Guid("b0f8df36-9a7a-b248-5333-3f769f3fe3d1"), "DN25", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN25", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 3, 1 },
                    { new Guid("b1bd00dc-14aa-3ba7-1187-6524bd1d54bd"), "DIN 933", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 933", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 0, 1 },
                    { new Guid("b1c9e5b3-45b4-d170-837f-d6830a60307a"), "ASTM A194-7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ASTM A194-7", new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), 4, 1 },
                    { new Guid("b24d32c7-ca03-8f5b-2b38-68342d3e4e9b"), "UNF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "UNF", new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), 3, 1 },
                    { new Guid("b25ae52c-6335-df29-73e5-4877cfec1707"), "Hidrolik Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Hidrolik Çelik", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 0, 1 },
                    { new Guid("b268a4be-a117-f03d-af89-59a6b36e4cdd"), "Tee", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tee", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 1, 1 },
                    { new Guid("b2eef77e-cb0b-6b30-d812-f57a4cb70f75"), "M18", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M18", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 9, 1 },
                    { new Guid("b3ca10bd-a4d8-165b-9bc7-bce44e7d0726"), "Çinko Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çinko Kaplama", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 3, 1 },
                    { new Guid("b4ee217e-0ee5-4cd2-ae00-35f8974bb0f5"), "Kablo Kanalı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo Kanalı", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 16, 1 },
                    { new Guid("b6212faf-a305-c476-2531-948c45aba3c9"), "Diğer Kablolar", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer Kablolar", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 23, 1 },
                    { new Guid("b66cf673-4f8a-1b94-b18e-817e2f709d94"), "16mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "16mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 5, 1 },
                    { new Guid("b75ddca8-1f18-698c-a6d9-593d60502163"), "ISO 2338", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 2338", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 4, 1 },
                    { new Guid("b7be0338-b789-4001-e52b-f1b922632691"), "Beyaz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Beyaz", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 6, 1 },
                    { new Guid("b97fdf92-b50f-1c41-575c-92628d4bc91b"), "Flans", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Flans", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 4, 1 },
                    { new Guid("b9a7c593-64f2-e1c4-9d3f-9620bf855cc2"), "5A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 21, 1 },
                    { new Guid("b9fe009a-2a46-8744-bcb8-94427a615792"), "DN40", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN40", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 18, 1 },
                    { new Guid("bb7b5d7b-e54b-8552-25af-16e9129cf3ef"), "Klemens", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Klemens", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 17, 1 },
                    { new Guid("bbf85110-13e8-0722-f3fc-b680fd6b3166"), "AKB", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "AKB", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 0, 1 },
                    { new Guid("bbfe2922-8eac-8a9d-4df0-e6af52f70202"), "35mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "35mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 13, 1 },
                    { new Guid("bc5a3910-ff55-92e8-b9c0-ef85dba30861"), "0.35mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "0.35mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 1, 1 },
                    { new Guid("bc6b98de-d649-9140-71fe-5f3549c7c294"), "Buton Başlı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Buton Başlı", new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), 4, 1 },
                    { new Guid("bc88f4c7-ff3b-6329-bc43-e718179d8769"), "Diğer Bağlantı Elemanları", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer Bağlantı Elemanları", new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), 6, 1 },
                    { new Guid("bcc206cb-6114-1a58-7599-bca66d2631bb"), "M14", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M14", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 24, 1 },
                    { new Guid("be218d4d-5da8-e0cc-ef5c-b8933a5dda91"), "UL", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "UL", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 4, 1 },
                    { new Guid("bf23ce98-8a49-9625-0e34-714e00abdd20"), "Whitworth/UNC/UNF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Whitworth/UNC/UNF", new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), 6, 1 },
                    { new Guid("c02c0fb8-6cb8-74c1-939b-ab04599f717b"), "Pirinç", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pirinç", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 5, 1 },
                    { new Guid("c1c66d57-0241-776a-27c5-8a09a6009145"), "JIS B 1354", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "JIS B 1354", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 8, 1 },
                    { new Guid("c2167943-a127-b6a7-c78c-26f425bb8f3f"), "Siyah Oksit", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Siyah Oksit", new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), 0, 1 },
                    { new Guid("c29b340c-317a-d11c-5f29-ebb5bf3322b6"), "Polyemid", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Polyemid", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 9, 1 },
                    { new Guid("c4f3f26b-8221-81fd-3be3-4d07d5d4ef5e"), "2 1/2\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "2 1/2\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 8, 1 },
                    { new Guid("c55cb504-14e4-5c76-0955-1a1b57003f1f"), "Krom Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Krom Kaplama", new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), 2, 1 },
                    { new Guid("c56fc79b-9c83-816b-c506-4213ae288996"), "1 1/2\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1 1/2\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 6, 1 },
                    { new Guid("c5bd2658-2d84-52c5-dd85-2b4fa1a6f32e"), "Somun", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Somun", new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), 1, 1 },
                    { new Guid("c5e330f2-14b3-4970-91ea-19d8bc499926"), "M16", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M16", new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), 4, 1 },
                    { new Guid("c69edd74-51a5-fdec-85da-70259ac8ec0d"), "3/4\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "3/4\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 3, 1 },
                    { new Guid("c6acea2a-2a88-eaad-7511-1ac36360ebb5"), "13mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "13mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 12, 1 },
                    { new Guid("c6b23eb6-77a0-cad6-5656-39980118d56d"), "20mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "20mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 7, 1 },
                    { new Guid("c732a4b8-3fc9-6a28-e028-6fe598181b64"), "ISO 6722", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 6722", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 6, 1 },
                    { new Guid("c8bd0bd8-017c-8fb4-d277-e5763414a965"), "DIN 7991", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 7991", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 5, 1 },
                    { new Guid("c8c5d3c3-21b1-4a63-f1de-72df63d496f5"), "M3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M3", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 0, 1 },
                    { new Guid("c8f8e11c-ab85-5323-b1d1-7f275bbbe0f8"), "Paslanmaz Çelik AISI 316", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 316", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 4, 1 },
                    { new Guid("c91b9559-8be1-c51b-1330-d50afff648aa"), "Fiberli", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Fiberli", new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), 2, 1 },
                    { new Guid("cabc6b36-b154-fd5b-7162-8a12be2d0784"), "DIN 1481", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 1481", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 3, 1 },
                    { new Guid("cafc5bca-8f5f-9aa7-3186-6a659eb2b212"), "60mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "60 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 10, 1 },
                    { new Guid("cb7f6d33-2588-8b99-f9e2-ef2f720516d6"), "Titanyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Titanyum", new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), 4, 1 },
                    { new Guid("cd67b119-63ee-269c-31c7-0b1c154f56bc"), "0.22mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "0.22mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 0, 1 },
                    { new Guid("ce93186e-6e3d-e661-ffaa-725625ad087c"), "Elektrik Motoru", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrik Motoru", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 21, 1 },
                    { new Guid("ceae6831-a7ba-974c-c8f8-0c53ac585bbe"), "Karbon Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Karbon Çelik", new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), 0, 1 },
                    { new Guid("cf037e3b-f82e-6955-d20c-0be456fcac0a"), "ISO 7090", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 7090", new Guid("74708664-794d-9dea-796f-719c7b164797"), 4, 1 },
                    { new Guid("cf923d19-72b7-1a2f-8327-f24293455c2f"), "5.6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5.6 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 2, 1 },
                    { new Guid("cfd2d4e5-00b8-b60e-f090-197850069a3b"), "30mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "30mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 11, 1 },
                    { new Guid("cfe48e3d-01fd-6ac1-64fd-dd8e39e7df6e"), "Turuncu", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Turuncu", new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), 9, 1 },
                    { new Guid("d13c3810-ff56-20d1-46f6-21a144786ac6"), "Sigorta", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sigorta", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 5, 1 },
                    { new Guid("d1b7ebb9-df8f-d26f-f395-b4b535b9dfd1"), "XLPE (Çapraz Bağlı Polietilen)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "XLPE (Çapraz Bağlı Polietilen)", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 6, 1 },
                    { new Guid("d41e97df-365b-ec38-fded-ea9f99997894"), "Özel", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Özel", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 10, 1 },
                    { new Guid("d4de909f-c9d0-617c-f6e2-fb300e97c2d1"), "DN15", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN15", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 14, 1 },
                    { new Guid("d4f622a1-b60c-e38c-28f3-c6dfa41efdee"), "Kablo", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kablo", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 34, 1 },
                    { new Guid("d5681de0-7e0d-12fd-5a87-3ec35b4c9826"), "Röle", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Röle", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 7, 1 },
                    { new Guid("d58c78e3-e089-09da-c005-7516a157cd2e"), "80mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "80mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 22, 1 },
                    { new Guid("d5919198-7f50-2b4b-2808-608c549fcaf2"), "Teflon (PTFE)", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Teflon (PTFE)", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 8, 1 },
                    { new Guid("d5ca1f2d-52f9-485a-9b10-fc63a421c774"), "DN15", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN15", new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), 1, 1 },
                    { new Guid("d5d9670e-7f5e-bacf-07a4-288025d7cfc5"), "16A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "16A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 23, 1 },
                    { new Guid("d71671ce-24a5-cac2-9840-64953b14bb0f"), "75mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "75mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 21, 1 },
                    { new Guid("d78fe528-f5b6-7d99-32b2-ec3b3c95149c"), "Pirinç", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pirinç", new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), 2, 1 },
                    { new Guid("d7c60bcc-5790-0b5f-d420-791518ab192c"), "DIN 934", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 934", new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), 0, 1 },
                    { new Guid("d92f72dd-7c16-a741-a861-74f69d24cfbd"), "RF", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Raised Face (Kabarık Yüzey)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 0, 1 },
                    { new Guid("d9f4f041-2f59-f494-7f79-5c7ee978b2cc"), "EN 1092-1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "EN 1092-1", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 6, 1 },
                    { new Guid("da421bce-2ff4-2c83-db8e-e5a211fa5cd0"), "14mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "14mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 4, 1 },
                    { new Guid("da4cf198-f6dd-e379-8aae-9f29d00eeb97"), "45mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "45mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 15, 1 },
                    { new Guid("da63a0c6-533e-8547-3069-59a8eeeb009e"), "M24", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M24", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 29, 1 },
                    { new Guid("daa686e3-775b-c75c-8f5f-535f18877a35"), "4mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "4mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 7, 1 },
                    { new Guid("dafc8a24-9abf-0c73-7282-6e2ed1199753"), "Çelik", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çelik", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 0, 1 },
                    { new Guid("db4be0c3-eae1-6fc8-d393-8ada14310ab6"), "20mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "20 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 3, 1 },
                    { new Guid("db60d440-835d-1ea1-3bc0-b6ffca22bf39"), "3/8\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "3/8\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 1, 1 },
                    { new Guid("dd299793-4398-ed2b-fdc3-270c5c9405ff"), "Paslanmaz Çelik AISI 316", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 316", new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), 2, 1 },
                    { new Guid("ddc3aead-951d-a933-70e2-ce2add0c5e91"), "DN6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DN6", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 11, 1 },
                    { new Guid("de047919-831b-6009-c3ca-f2ecfa993d41"), "IEC 60245", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "IEC 60245", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 1, 1 },
                    { new Guid("dea1e51b-caec-f908-2b9c-30e53f47f5e0"), "32mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "32mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 12, 1 },
                    { new Guid("deddd558-f03c-5a48-2a45-048304e97da7"), "25mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "25mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 18, 1 },
                    { new Guid("e0c4f261-082f-9ce8-452b-13948b524b61"), "CE", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CE", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 5, 1 },
                    { new Guid("e11b3b1d-9203-2663-9d6f-f242778c3ff3"), "Elektrik Tesisat Rekorları", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrik Tesisat Rekorları", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 18, 1 },
                    { new Guid("e16ca69a-c343-dd68-ece7-0ec13f261987"), "Çinko Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Çinko Kaplama", new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), 1, 1 },
                    { new Guid("e1dab3bc-4fdd-4f46-89c9-6b158cfbb64b"), "M30", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M30", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 31, 1 },
                    { new Guid("e289fb08-def6-557e-6ca2-00de86c8c0c1"), "Paslanmaz Çelik AISI 316", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 316", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 5, 1 },
                    { new Guid("e3ec4c06-4dfa-27e2-5b20-8eb3ed2a398b"), "TG", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Tongue and Groove (Dil ve Oluk)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 4, 1 },
                    { new Guid("e4b3c57f-1c11-10db-b80f-002ddb22cff4"), "Elektrik Malzemeler", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrik Malzemeler", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 33, 1 },
                    { new Guid("e5b2e10d-b0ec-9fc8-a6c8-d94271308c40"), "2\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "2\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 7, 1 },
                    { new Guid("e61b6269-1fc9-a7cd-e92e-9238b9ade432"), "PN250", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN250", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 8, 1 },
                    { new Guid("e6734936-277e-946d-9feb-e1b45de88784"), "PN6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN6", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 0, 1 },
                    { new Guid("e74ef805-e1b2-3b56-1cbd-430d856b9891"), "12.9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "12.9", new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), 2, 1 },
                    { new Guid("e762969e-ec51-5737-8219-79847fabbab5"), "M6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M6", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 20, 1 },
                    { new Guid("e7c16eed-34d6-abc0-2e50-c659ca4ddea8"), "150mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "150 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 16, 1 },
                    { new Guid("e81a6810-4e0f-8701-4124-3e46f814d938"), "3mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "3mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 4, 1 },
                    { new Guid("e91068fe-5ded-88ac-a6ba-1161a83dd9f3"), "DIN 3863", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 3863", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 3, 1 },
                    { new Guid("e94237a5-0da6-1d3a-96d3-10c3673a4482"), "6mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "6mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 7, 1 },
                    { new Guid("e9802315-8a13-c6bd-f645-7c4732c2986c"), "220V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "220V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 4, 1 },
                    { new Guid("ea2a3ad4-3db4-38c9-29ae-6b243bcb0935"), "4mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "4mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 5, 1 },
                    { new Guid("ea95e616-e1e6-73c4-dd88-5eacd75b1809"), "Paslanmaz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 5, 1 },
                    { new Guid("eb5e9f1e-9e88-e202-b4be-216158b8be98"), "110V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "110V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 3, 1 },
                    { new Guid("ebc40bd2-4229-92f4-9b6f-da548bb4a1b0"), "Sigorta Rayı", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Sigorta Rayı", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 29, 1 },
                    { new Guid("ec0b5946-3fed-1b34-de2c-0b15de74bf02"), "ANSI B18.8.2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ANSI B18.8.2", new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), 7, 1 },
                    { new Guid("ec6f4845-7056-c91a-fbb7-83bad306b744"), "1mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 4, 1 },
                    { new Guid("ecce01f1-e035-1868-dacd-824a56c725b9"), "Nikel Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Nikel Kaplama", new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), 1, 1 },
                    { new Guid("ed1a998a-8f0d-d7dc-917b-5836ea554a46"), "100mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "100 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 14, 1 },
                    { new Guid("ee8e0734-2d4f-3bba-4d79-583aadf9a7f8"), "6mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "6mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 0, 1 },
                    { new Guid("eea52a53-2ca0-edb8-0eb7-94cdefefd66d"), "DIN 931", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 931", new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), 1, 1 },
                    { new Guid("eed7cea7-41fe-5eeb-bfca-ae590885b3cb"), "Krom Kaplama", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Krom Kaplama", new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), 3, 1 },
                    { new Guid("efd09bb7-53d3-a71a-6b94-15f1928c3043"), "M20", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M20", new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), 10, 1 },
                    { new Guid("f04ead28-5b8e-0579-3a0e-9b49bfca7592"), "40mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "40mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 14, 1 },
                    { new Guid("f05a20d9-40a3-2693-91a9-c97cb621ae02"), "LJ", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Lap Joint (Gevşek Flanş)", new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), 3, 1 },
                    { new Guid("f43d081f-48f9-40b6-6cfa-885f9ac71864"), "8mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "8mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 9, 1 },
                    { new Guid("f53ead35-b95c-aa45-d6ec-41a22aa29213"), "ISO 4144", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISO 4144", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 9, 1 },
                    { new Guid("f53eee49-372f-1958-f5ab-b66160362ba8"), "240mm²", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "240mm²", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 19, 1 },
                    { new Guid("f589605c-cb35-77b3-85b7-852b3181bbe5"), "SAE J1128", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SAE J1128", new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), 7, 1 },
                    { new Guid("f594d397-02d2-2aac-2ec6-8e0b25dd00d0"), "16mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "16 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 2, 1 },
                    { new Guid("f5e28d02-2e74-0d03-fac2-dc0a56bdc861"), "1mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 0, 1 },
                    { new Guid("f6433760-4e9c-e660-b58c-f26432ca0b4b"), "PVC", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PVC", new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), 3, 1 },
                    { new Guid("f699f410-e99f-2d1d-236f-4c43604a0b93"), "Elektro Galvaniz", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektro Galvaniz", new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), 4, 1 },
                    { new Guid("f7b34953-03ac-6e96-880b-c54bfa1ce84b"), "PN320", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN320", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 9, 1 },
                    { new Guid("f7c3851c-5b27-8fb1-fdbe-44bd11a9a69c"), "PN40", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PN40", new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), 4, 1 },
                    { new Guid("f7eb66e8-0a3b-84b1-5cbd-88aa930deef6"), "40A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "40A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 26, 1 },
                    { new Guid("f8d567f4-b437-912a-2cc3-c912924187a3"), "M24", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M24", new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), 6, 1 },
                    { new Guid("f950f97f-fe44-7d3d-acc6-544519a4817b"), "28mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "28mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 10, 1 },
                    { new Guid("f9c77657-ab5d-504e-1f92-28846bb1e8db"), "Alüminyum", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Alüminyum", new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), 3, 1 },
                    { new Guid("f9f59ed4-88eb-34cd-0288-955142fd46ae"), "22mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "22mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 17, 1 },
                    { new Guid("fa0598c5-83bb-8fc1-3846-db7d39b2852f"), "1/4\"", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1/4\"", new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), 0, 1 },
                    { new Guid("fa3432d5-b731-0c37-d1f8-60905d3e0780"), "DIN 125", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DIN 125", new Guid("74708664-794d-9dea-796f-719c7b164797"), 0, 1 },
                    { new Guid("fa39714f-2fa5-c816-4380-363e136fd1f9"), "80mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "80 mm", new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), 12, 1 },
                    { new Guid("facc4541-f9da-ce53-f608-b46a07fb2c69"), "1.5mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "1.5mm", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 1, 1 },
                    { new Guid("fb3f87a9-6f44-fdce-0d75-2e036065b043"), "50mm", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "50mm", new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), 16, 1 },
                    { new Guid("fc6c9287-c060-4702-c001-4612156b4f3f"), "Bakır Kalay Kaplı Kablo", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bakır Kalay Kaplı Kablo", new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), 3, 1 },
                    { new Guid("fca0b48e-c42f-7e03-04ca-7a5832eb3dba"), "Perçin", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Perçin", new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), 4, 1 },
                    { new Guid("fcfc4066-e3b9-64ef-962a-924bb91827ea"), "10.9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "10.9 kalite", new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), 5, 1 },
                    { new Guid("fd39317c-d271-76b2-53de-e9fa583af5fb"), "M18", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "M18", new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), 26, 1 },
                    { new Guid("fe5c67bc-d09f-d802-f3c0-994c60650215"), "230V", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "230V", new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), 5, 1 },
                    { new Guid("fead5c9e-2f17-0c35-2856-9ab2a504183c"), "32A", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "32A", new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), 25, 1 },
                    { new Guid("fed9b43c-55a5-16b6-3949-a39477aec05f"), "ASME B16.9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ASME B16.9", new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), 7, 1 },
                    { new Guid("ffdbf4fe-2710-ca08-9d7a-f03ec2bb7447"), "Paslanmaz Çelik AISI 304", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Paslanmaz Çelik AISI 304", new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), 4, 1 },
                    { new Guid("ffee07c8-630b-eddc-4b21-f0b7a4f49b03"), "Krom", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Krom", new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "SProducts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "PrefixIndex", "SProductGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), "SDF9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "POLYEMİD/POLİETİLEN DİRSEK", 36, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("015f9630-a039-886c-04df-2a31915fac1f"), "SEC7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO TAMBUR", 28, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), "SBB5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI CROM", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), "SCA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA YAYLI ÇELİK", 4, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), "SBA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB CROM", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), "SDG1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "POLYEMİD/POLİETİLEN REDÜKSİYON", 37, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), "SDD0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. DİRSEK", 20, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), "SEB7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KLEMENS", 18, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), "SAE2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN CELIK", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), "F9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), "SBB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 12.9", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), "SEG0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "BAĞLANTI KUTUSU", 37, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), "SEC9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SİGORTA RAYI", 30, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), "SAE5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN SOMUN", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), "SBA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 12.9", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("1a359556-069b-5568-517a-710c78025668"), "SGA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİM CENTİKLİ", 5, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), "SAC5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB SAC VİDASI/AKILLI VİDA CROM", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("1beba319-2062-4991-b344-986056beab22"), "SDA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ FİTTİNGS", 6, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), "SBE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN WHITWORTH / UNC / UNF", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), "SDE4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ TEE", 30, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), "SBB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB FIBERLI CROM", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), "SEAA", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO ENDÜSTRİYEL", 10, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), "SDB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PNÖMATİK TEE", 11, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), "SDF1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ FLANS", 32, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), "SGA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİM YAYLI", 6, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), "SBA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI CROM", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), "SAA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB CROM", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), "SDE2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ REDÜKSİYON", 28, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), "F8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), "SGA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERÇİN", 9, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), "SDB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PNÖMATİK REDÜKSİYON", 13, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), "SAA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 12.9", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), "SEA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ŞALTER", 6, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), "SDA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK FİTTİNGS", 5, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("302b444f-98a2-4992-066f-699e031ddd77"), "SGA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİM YAMA KOVANLI", 4, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), "SAA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), "SAD0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A193 B7", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), "SBC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI 10.9", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("387233c8-0a58-19b6-7800-53621c965341"), "SGA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GRESORLUK", 0, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), "SAA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 10.9", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), "SAC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB TORNAVİDA YARIKLI 8.8", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), "SAB8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS CROM", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), "SBA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 8.8 FIBERLI", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), "SEC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DİĞER KABLOLAR", 24, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), "SDD1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. FLANS", 21, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), "SCE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA ÖZEL GRUP (Ör:Süper,EPDM/II)", 9, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), "SDC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK BORU BOĞAZI/BAĞLAYICI", 18, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), "SGA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "YARIKLI PİM", 8, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), "SDF2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ REDÜKSİYON", 33, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("4617b56c-f396-48a8-a725-443879fcab82"), "SGA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİM SİLİNDİRİK", 2, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), "SAB6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB TORNAVİDA YARIKLI 8.8", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), "SEC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO VE KUMANDA SİSTEMLERİ", 21, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), "SAB5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), "SDE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ FLANS", 27, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), "SED1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HABERLEŞME MODÜLLERİ", 32, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), "SEB5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ISI BÜZÜŞMELİ MAKARON", 16, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), "SAA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("589fa795-bd72-0063-4b9b-98261865991a"), "SDA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ FİTTİNGS", 7, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("58d3fb19-554c-688d-a424-9e2722726772"), "SCA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA YAYLI CROM", 5, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), "F5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), "SBC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN HALKALI", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), "SBA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 8.8", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), "SDA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜMİNYUM FİTTİNGS", 9, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), "F7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), "SDB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PNÖMATİK REKOR", 10, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("697cf80a-b06a-c5cf-204c-914210302181"), "F3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), "SEB8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ELEKTRİK TESİSAT REKORLARI", 19, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), "SAC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB SAC VİDASI/AKILLI VİDA CROM", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), "SBD1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB A194-7", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), "SEF1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO ENDÜSTRİYEL", 36, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), "SCA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA SQUARE TAPERED", 10, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), "SBE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN ÖZEL GRUP (Ör: UZATMALI)", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), "SEB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SWITCH & BUTTON", 12, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), "SCA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA ÇANAK ÇELİK", 7, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), "SAB1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB YILDIZ KANALLI 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), "SCA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA DÜZ CROM", 3, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), "SBB2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 8.8", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), "SCA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA DÜZ BAKIR", 2, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), "SDC0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK DİRSEK", 15, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), "SEC6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GÜÇ KAYNAKLARI", 27, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), "SAE4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN KROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), "SAB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB TORNAVİDA YARIKLI 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), "SEC5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KORNALAR", 26, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), "SDD2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. REDÜKSİYON", 22, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("7b9557d4-2459-735f-541a-547553225755"), "SDB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PNÖMATİK DİĞER BAĞLANTI ELEMANLARI", 14, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), "SEE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ELEKTRİK MALZEMELER", 34, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), "SBB7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KAYNAK 10.9", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), "SAE7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SETŞKUR", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), "SDH1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GALVANİZ FİTTİNGS ELEMANLARI", 40, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), "SAD1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A320 L7", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), "SAA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), "SDA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HİDROLİK DİĞER BAĞLANTI ELEMANLARI", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("87aac966-415e-2489-2612-531febe2afe0"), "SDF4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ TEE", 35, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), "SBB6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KAYNAK 8.8", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), "SBA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 12.9", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), "F2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), "SAA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 12.9", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), "SDE3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ BORU BOĞAZI/BAĞLAYICI", 29, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), "SEB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "NR TERMİNAL PİPE", 14, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), "SDA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HİDROLİK DİRSEK", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), "SCA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA GENİŞ ÇELİK", 8, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), "SAA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 10.9", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), "SCA6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA TIRTIRLI ÇELİK", 6, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), "SDD4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. TEE", 24, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), "F6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), "SEA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KONNEKTÖR & SOKET", 8, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), "SBC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI CROM", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), "SAE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA WHITWORTH / UNC / UNF", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), "SEC4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ELEKTRİKLİ ISITICILAR", 25, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("9adcec4b-5181-193d-521b-652c687003e1"), "SEA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "BAKIR KALAY KAPLI KABLO", 3, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), "SEC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ELEKTRİK MOTORU", 22, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), "SAE6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SAPLAMALAR", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), "SDF0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ DİRSEK", 31, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), "SEA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "DİYOT", 9, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), "SDC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK FLANS", 16, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), "SEA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO TESİSAT", 0, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), "SDI1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "BRONZ FLANS", 41, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), "SAA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), "SBA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 10.9", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), "SDE0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PASLANMAZ DİRSEK", 26, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), "SAC6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA KB (KELEBEK BASLI)", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), "SDG3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "POLYEMİD/POLİETİLEN TEE", 38, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), "SAB7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), "SBA9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 10.9 FIBERLI", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), "SEB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SPİRAL MAKARON/KABLO KILIFI", 15, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), "F4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("af64b458-a554-a29d-29c2-654c623332db"), "SEB2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PABUÇ TERMİNAL", 13, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), "SBB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB 12.9 FIBERLI", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), "SAE1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA ÖZEL GRUP (Ör: GÖZLÜ)", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), "SEA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RÖLE", 7, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), "SDF3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİRİNÇ BORU BOĞAZI/BAĞLAYICI", 34, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), "SAB9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI CROM", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), "SBA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 10.9", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), "SAC4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB İNBUS CROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), "SBB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB KONTRALI 10.9", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b82a69be-962a-3af6-374b-60607e483d82"), "SEA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO AKÜ", 1, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), "SGA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GUPİLYA / KOPİLYA", 1, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), "SBC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN KELEBEK", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), "SBB9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB TACLI 8.8", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), "SDB2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PNÖMATİK DİRSEK", 12, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), "SCA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA DÜZ ÇELİK", 0, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), "SEA2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO TTR", 2, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), "SEA4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "AKÜ", 4, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), "F1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 1 },
                    { new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), "SCB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA TIRTIRLI PASLANMAZ", 11, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), "SEF0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO", 35, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), "SAC1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB DUZ 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), "SBD0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB A194 2H", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), "SAB3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), "SDA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HİDROLİK TEE", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), "SEC8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "VERİ OKUMA CİHAZLARI", 29, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), "SDD5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. REKOR", 25, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), "SED0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALGILAYICILAR", 31, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), "SAC3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB YILDIZ KANALLI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), "SBA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SOMUN AKB SAPKALI 8.8", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 1 },
                    { new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), "SEA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SİGORTA", 5, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), "SGA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PİM KONİK", 3, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("e26af581-a307-433e-8564-933baef1ba05"), "SEC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LOAD CELL", 23, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), "SDH0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GALVANİZ FLANSLAR", 39, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), "SAB4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), "SGA7", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SEGMANLAR", 7, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 1 },
                    { new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), "SDC4", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK TEE", 19, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), "SDA8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PPR - PE FİTTİNGS", 8, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), "SDA3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HİDROLİK REDÜKSİYON", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), "SDA0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "HİDROLİK REKOR", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), "SCA1", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "RONDELA DÜZ ALÜMİNYUM", 1, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 1 },
                    { new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), "SEB9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO UÇ YÜKSÜĞÜ", 20, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), "SDD3", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ALÜ. BORU BOĞAZI/BAĞLAYICI", 23, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), "SEB0", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "AMPUL & LAMBA", 11, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), "SED9", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "TABELALR VE LEVHALAR", 33, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
                    { new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), "SAA5", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), "SDC2", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "ÇELİK REDÜKSİYON", 17, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 1 },
                    { new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), "SAE8", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "U-BOLT", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("fb1da561-6749-593e-e27b-404bd128e181"), "SEB6", "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "KABLO KANALI", 17, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 1 },
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
                    { new Guid("0007bf63-f6b4-7809-e568-26e1a52b9fe6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), null, 1 },
                    { new Guid("00c706e0-631c-dbea-dddf-ee903386639c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), null, 1 },
                    { new Guid("014712cc-3091-0565-7598-bc319d4ed5ff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("4617b56c-f396-48a8-a725-443879fcab82"), null, 1 },
                    { new Guid("0152b223-7af2-aed2-4a9c-68cdad68afc0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("01874158-c3a0-55e7-ca58-b5307ff80ba1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("01c4e148-f577-d890-5eb6-a1f22f4c13fd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("02915375-2e5a-349c-6cf6-47746b7aa5d1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("02a91a70-eb6b-35c0-df91-103397b959e5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("031f8a5d-c3c1-318c-4526-ba3288daad9d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("0373acdc-5b73-3165-0bb0-49d48ff76092"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("03aa3289-d204-ffcf-977b-3ac6511cedf2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("03b81bae-a55b-327f-b462-953d7f07711a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("03f305b7-1cf0-83c9-32f3-d25a46c5f95f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("0425720d-ddec-a17f-518e-4eda6297df67"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("0467f9bc-1c90-8c69-3e98-7b062a1766a8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("58d3fb19-554c-688d-a424-9e2722726772"), null, 1 },
                    { new Guid("04912ab6-4fd9-39af-f9f5-1cf281fdb5aa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("04a181f1-5ddf-2147-837a-3fbd85ea796d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("04ef80e8-b1f5-ce36-273e-83793fdc6fbd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("05020b97-8a80-3f71-4b2d-67f86a948734"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("0536e279-b11a-b885-4f15-21c2ef71c32a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("05a79387-db00-3447-5a6e-caf9107f88c6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("05ed487f-e13d-0234-b3d0-8125b07d2cb9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("05f99f22-e01f-dfdf-7008-6dd9ec1716a8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), null, 1 },
                    { new Guid("06005c5d-39d7-c4b2-09ce-170df39277e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("06302d4d-ddd8-e1b0-0efd-49bff515fc82"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("063e9069-1cb8-22fc-efe8-9c27ec38713f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), null, 1 },
                    { new Guid("06f582c9-c710-a392-9bc3-aaf66460ee53"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("0731388f-b134-402b-1e96-cabf72530afb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("07dfa1b0-0e8a-e8f7-616d-527aeb5b59c5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("080dddce-f07e-ac38-93d0-37f80f9ca513"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("0845481d-0e11-1bf5-4e61-05bcc9853a72"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("0859b2cc-697f-ab97-a382-0421adf0c31d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), null, 1 },
                    { new Guid("088ce814-6f15-b09f-51c7-dd6fb403a6d1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("08aa2218-b48d-7ac2-a065-e0204e8a8d98"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("1a359556-069b-5568-517a-710c78025668"), null, 1 },
                    { new Guid("08d6317d-4c28-e6c6-14ef-1ceb50596c2a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), null, 1 },
                    { new Guid("08e0fba1-ad98-1faa-b331-3e4b04e4abdf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("08fcafac-0eb1-ac8a-26c5-024b4d883a1f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("09066e5c-eb21-d59d-bfcd-689fe36519e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("095178c9-2e5a-bfa2-9abc-32591c7f0710"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("0a17246b-9903-a018-cbb4-dd4347780658"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("0ad1f953-209f-3701-20ea-a322dbc2309c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("0adbf041-8350-6a19-30d9-4dbdbdf2c866"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("0af077b7-edd7-47aa-e788-7ac338c63fb9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("0b02f591-710d-5513-1a81-cb9894967df6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("0b384a77-f4cf-df7f-4752-44fb192ab330"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), null, 1 },
                    { new Guid("0b82926b-baf6-7b32-ea0b-d3ac4744de8a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("0b92aac5-40b9-0100-eb4f-93f2b569dbe9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("0bb5b2ea-eccf-d7b8-70d7-64d5bd14f9a9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("0bc0b44d-e8e5-6b0f-0dbb-3b0b3e904d75"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("387233c8-0a58-19b6-7800-53621c965341"), null, 1 },
                    { new Guid("0bdc1a7a-72a3-7c56-0971-1c8a83a21f3c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("0c777032-ede6-58dc-b785-d9cdeef5c6b6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("0ccb61c1-8f48-beee-adae-1aef2458880a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("0cf0dcdd-4057-b322-9224-50a13b8bdab7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("0d35dad1-681a-3947-0fe5-167613e06c4a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("0d589c5c-3fbb-ff66-66bd-83d7e9c7728d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("0db7583a-7cb9-5846-8bcd-008bd34c368c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("0ddfef19-3ce8-dd05-3fab-f7c697aa3c1d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), null, 1 },
                    { new Guid("0e42b1ad-34f5-4ff0-03f8-949b513a13ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("0e9283a4-3256-bf79-5ab6-5c063de33819"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("0eaa1250-80f3-916f-907e-5eedb0ada8ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("0f0204d9-c81d-ecb4-4e1b-b7ecf615428d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("0f18e23e-2621-8c36-e900-6272e111d68d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), null, 1 },
                    { new Guid("0f336aaf-9172-4995-c04e-0fb8913a87e3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), null, 1 },
                    { new Guid("0f9e1184-c459-eb79-2515-8ec2a9dbf429"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("0fdab9f2-3e64-7583-e8bd-fa1feee92132"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("1001a1c6-3640-4f2f-947c-3db5febb599c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("1050c833-93a1-2039-2822-7d9139350d06"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("108685a1-ce53-a086-526f-55fba118cdad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("10c94f97-2fa7-4958-260d-9c8f65913dbb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("10d89793-9bac-8189-f88a-da2e59599db5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("1103a046-4d8a-e6ca-9afc-e1c3dad26a50"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("1159501e-a69e-2653-1810-515bf9d314e2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), null, 1 },
                    { new Guid("11956c53-bd89-634a-24d7-89440818e1a7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("12393a04-9e47-501c-48dc-cda83c291f30"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), null, 1 },
                    { new Guid("125ccbbc-68e8-b941-82f1-91d33c44e0b8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), null, 1 },
                    { new Guid("12879c40-1b00-ccaa-cefb-d2ea73d8318e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("12c866e8-9c0b-9133-2048-005d38e997c8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("12e3114e-465d-8178-22fc-95b698d6d9bf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("12f4fadb-3bf9-2046-e27f-a80c55b3b5fb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("137c6845-ad6b-dd7a-9ab3-2ce5150a5d0a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("13a608b9-7966-d2c8-d3d4-4b4f1e167c2d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), null, 1 },
                    { new Guid("13b01957-7b74-2f40-1b7b-82f4312fd167"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("13b76072-6fc5-7cf4-ad05-65fcc781538b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("13dba426-5470-0bde-e9c0-f95966f6e235"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("13e3fff1-c5e4-e2b9-6d78-db4d850475ce"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("1418d453-93b0-bbd5-8b05-6ac08cf78caa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("141f9af5-e6ca-bda3-c90a-947fad153954"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("1452e0c8-5fcc-b987-451d-4e305fea5136"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), null, 1 },
                    { new Guid("14627f4e-f7cd-cd7d-f3f3-ba0ace5f9ec3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("148ff046-541e-0001-055d-a50290d7b524"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("14a81644-2316-f5c8-29a1-edf75dd275ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("14c9cbba-8579-a7d3-735a-40c62deefa7d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("153e1335-212e-77e2-c813-b0352fdd02ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), null, 1 },
                    { new Guid("158b59fa-6f51-ea27-e299-0fd381f8bbbd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("1a359556-069b-5568-517a-710c78025668"), null, 1 },
                    { new Guid("15c5d68c-b7a5-bc92-41d6-d168b7d39bd9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("164e9516-d50a-fa4d-acdb-f9028ca68770"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("16c3972f-9fa3-fde6-ecf7-e802c98e1341"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("16e6bc2a-3d21-965e-88b2-3e13616cda66"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("16f9a4e1-8620-e29d-eaa7-0644e6febfef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), null, 1 },
                    { new Guid("172fe2a5-27f7-1e84-5252-e2918bb15ec0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("17a8b888-83e3-1aca-5254-9f1b096f060c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("17ab932e-0c8a-f4dd-8d51-0afaae6f13a1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("17b4daf1-7f04-28a9-e52f-bf73d8399106"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("18334b1e-76e7-635e-c33b-aaf76f684e93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), null, 1 },
                    { new Guid("185f9596-304a-4724-f0e0-b8be5b1a07ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("18df49a7-9157-0e56-1d74-10cae93ec0a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("18f0c7f8-5303-3834-4065-64dd8ada8c4a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("1915523b-39a3-7cd3-dbeb-22a8323d2fa6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("197c6dda-dd86-f432-9f20-65cd9d7431dd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), null, 1 },
                    { new Guid("199509e3-6084-8d7e-4672-c91676fb7623"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("19e1ef7c-730b-29d5-a57d-2d0c605007b2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("1a41374e-0e46-201d-9153-32284189a238"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("1a66bd36-684a-2565-b0d0-7411adff2c2d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), null, 1 },
                    { new Guid("1aa9b8b3-3dfb-0b2b-fc5e-ba94d8618bf3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), null, 1 },
                    { new Guid("1afb769a-5a81-c530-a31a-c24d75f7eb38"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("1b3d7fbd-b5b0-ac9c-c0c4-1a341a89d643"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), null, 1 },
                    { new Guid("1b4747c1-915f-d5c0-b979-5c05fc90e9fa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("1bb71c3d-5141-9a79-6194-fd480321833c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("1c882371-9929-1e63-6459-bb569881335b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("1c970f9f-ad27-6ab8-a29a-78caa2e01416"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("1d2cea9d-44e5-a8a7-0682-53353975c97a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("1d4fbd97-b206-a9cc-756f-99f44eebb6d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), null, 1 },
                    { new Guid("1d8d0ade-26c8-a59a-33b7-46be34b1fd94"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("1d94daa5-17b6-e11a-97b6-c8bd48d45558"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("1e1301e5-f82d-28f5-8d68-7379820a8ea5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("1ebba7ef-4376-d4a6-fce6-cb9d1a21e87c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("1fa12507-4060-9dab-5df6-2a6e6fae6e25"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("1fdec052-1901-6b3c-6b98-7c94fec80823"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("201d81c4-1fd8-f1c7-43f4-59c582aa2cb4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), null, 1 },
                    { new Guid("202f7b10-d6a0-e1f6-304e-335a56656f1d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("206bb7f5-658b-d8a8-22c7-1568b0e379c5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), null, 1 },
                    { new Guid("20e92c9c-8cce-6356-d0c9-aedc558b7321"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), null, 1 },
                    { new Guid("211a2d74-c385-61ae-774f-a9e1e4a44730"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("21210ccd-73b6-4a73-30d5-8629a40de78a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("215dd792-86d1-0d2d-3031-bce190fdb78f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), null, 1 },
                    { new Guid("2193cd37-9e3d-46fa-4d13-e675618f25ea"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("21de29b3-08bf-18db-abe1-9b50094f1831"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("22186273-9cde-19e3-e8dd-e2f3cb07b9bc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("22d12952-be6e-05d1-defe-e5ef6f78ba36"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("22e1abc3-28a9-2846-31d9-e0687b69dbad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("22f2dfc6-aee0-9e3d-2f30-d7a902088a73"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), null, 1 },
                    { new Guid("24192b4e-1569-f7af-ddc7-036eaad08753"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), null, 1 },
                    { new Guid("24eff8ca-ca60-6772-2f2a-a6a056ccba95"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("251070ba-946f-dc2f-35e0-a5345f612e6d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("254ff619-02f7-be7c-128c-1d46a729c63f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("302b444f-98a2-4992-066f-699e031ddd77"), null, 1 },
                    { new Guid("25e11cdf-34f8-0a8e-864a-5181eb2f6468"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("25edf5b8-4352-5f27-331a-0283af1e572f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("264760a8-0015-bcce-6895-5d8b852bd049"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("267d75cf-99c4-e14b-8612-368dd1360831"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), null, 1 },
                    { new Guid("268e5111-5682-5b43-654f-531fa0f699c5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("26ea6182-d621-1fc1-eae8-b9bd08c65666"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), null, 1 },
                    { new Guid("2729afef-62bc-4c2f-7a1c-933c673d0dfc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("2820b3dd-5742-e433-2391-f141beadc93e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("2845cca4-d32e-f11a-49d8-caa07a24a204"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), null, 1 },
                    { new Guid("2850ae7e-b785-b134-9d24-dda3821c5828"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), null, 1 },
                    { new Guid("28ca2c1b-e6d2-2974-5412-e61f55fd5f40"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), null, 1 },
                    { new Guid("29afeb60-54f3-7fb3-34d8-f7eaa07a4315"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("29c6670e-f069-126c-5a0a-0bdad1650af2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("2a322624-f56a-647f-02b1-5c9af0cb6109"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("2a44c8a3-e958-3ae8-3cb9-6af3e06b2515"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("2a51aa48-9bf9-74e4-d113-51284c330514"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), null, 1 },
                    { new Guid("2a742eb4-f598-e65f-4a83-f5390efcceda"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("2ac33116-a117-89ed-52e1-ce87ebebb901"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), null, 1 },
                    { new Guid("2ae4e5ef-fbdd-1c86-ec8d-0951c683504f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("2af52c75-e51d-1999-db2a-ed206a1628e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("2b0408f7-194a-776c-8770-974623568134"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("2b406e86-918f-3bfd-f9d6-1f973bcd8790"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("2b502417-dfb3-d1a4-64e3-43de2c940e45"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), null, 1 },
                    { new Guid("2b71c65e-d431-bfa1-6e1c-281e8054597b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("2b74c653-175f-10b1-3f4d-a8c8cf86cdd4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("2b8eb8a7-102b-5bc8-f933-4665856efaeb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), null, 1 },
                    { new Guid("2b9e3bfe-9a53-09b9-5e26-b65f5ef9ac5f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("2bae4283-ca1c-f909-6af6-4719beebb84d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("2c017794-1630-a148-212f-b5ae1214d61f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), null, 1 },
                    { new Guid("2c1a284b-f45e-50e9-8005-089281368b74"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("2c38b046-59d2-82eb-600b-7017a365d3c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), null, 1 },
                    { new Guid("2c3e9584-2ea2-9dc9-0808-244dade94be7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("2c55bb4b-ce35-07a1-0e0c-e3e1d26a2fa1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("2c8234fe-5991-969e-37cb-b18ff79807f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), null, 1 },
                    { new Guid("2c89e19f-b4e6-d14a-dce8-2774819a3273"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), null, 1 },
                    { new Guid("2cba8efe-61e8-7800-2506-ef9e4bf584e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("2d452e4f-23a5-f238-7698-5db1ff09919d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("2d79de3e-f9f3-c77b-a6bc-0d482b96b210"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), null, 1 },
                    { new Guid("2d922c36-6ec0-d2e1-3cc0-11ee5eb2daad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), null, 1 },
                    { new Guid("2dee3dfe-d610-0faf-cf5b-9802079c2faf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("2e397494-3db1-86d0-2d40-a005aaa829b0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), null, 1 },
                    { new Guid("2f6b45c8-8936-b1a1-1a63-0e7e0daac49a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("2f6ef8fd-7716-2429-7a4b-07a7c88ea5e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("2fbf7858-6835-9b14-d9c9-21a3dc1c6f9c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("302b444f-98a2-4992-066f-699e031ddd77"), null, 1 },
                    { new Guid("2fe25da2-13bb-a474-a6c6-69df7a9f2456"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("301c56f8-5243-346e-8d27-2214712d46cb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("3030d900-ab66-5828-3ecf-4f1bac306f38"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("30c1968a-796f-092f-9dc8-369ee52b68e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("58d3fb19-554c-688d-a424-9e2722726772"), null, 1 },
                    { new Guid("313d3064-f6ee-5b17-2bf2-7af0c9d2f0b2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("3160d54c-80a9-93da-0e1e-2f9323e179a8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("31cede39-328d-c380-1d46-a2433872528c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), null, 1 },
                    { new Guid("32156f9e-5d75-b78b-793c-512799d6a7d2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), null, 1 },
                    { new Guid("3243c602-a925-9bb8-8ce8-5a9d53a0dfd9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("324c50a6-f0bb-65b5-ecb4-8e7edb33b63e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("329715e6-f6a1-083e-053f-ad0474960ea0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("32abb0f0-3d98-61cd-d2ec-7b1f3eb319e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("32b2a6f1-a193-765b-5631-15ac5c0974a7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("32cfb05b-2fae-43dd-8852-34115cb9b2c1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("32f656f6-31fb-96a8-21eb-c0f674112460"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), null, 1 },
                    { new Guid("33113fe2-2866-bcf4-424f-8de5043137af"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("333297f5-3847-8fb6-3199-7f016940842b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("3335f403-5f0a-8f8e-5da8-9d10cddd2205"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("3354a02a-1426-6ad8-c428-569abd115b6b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("337897b5-6b44-8dcb-bb74-8f6cdcf3471b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("33a2e3e1-c4e8-4e12-dd5b-54415f2dff7b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), null, 1 },
                    { new Guid("345f7939-a466-dc5c-02da-807ee65e24f6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("348578b8-dc8d-038e-6e2a-50577e155d7e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("34c5781d-187a-eb04-7f4a-d7b56f56aa2b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("34cd58ca-6f86-2db4-b892-641e122282b4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("350795a7-486e-85ab-cdf4-e7c0a7c233f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("3537bb50-7119-ad99-491f-e613286040b3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), null, 1 },
                    { new Guid("35408bf0-e6dc-01e0-c876-272978471ed5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("354679e2-3e2e-1808-39d2-ea7d0976b694"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("361ac27a-db57-6abc-f0d1-10780bfc5041"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("36448cab-5ca7-0c2e-8a83-4ed4e80323fb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), null, 1 },
                    { new Guid("364c6db1-6fa0-4dfd-cf41-20c581939bbc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), null, 1 },
                    { new Guid("36c90e61-5b45-bf7e-1497-9108555cdc76"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("36fdfc7b-336d-e6fc-c653-c97c5cf5e479"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("37c1a2a2-a213-19af-ef91-12e79174dba4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("37e7bd83-39b0-1f5b-8bb9-22304e358be7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("37fe6658-3e58-c10b-022b-eb262eaf80b6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("382274e0-37fb-d259-52a1-41d5b115d97e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("38281207-e4e1-9e87-0c0a-abca1450b84e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), null, 1 },
                    { new Guid("382c8ced-8d4d-5af4-4d9a-b8acf34479d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), null, 1 },
                    { new Guid("38abcd66-9de6-3668-306e-727148d7fbba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("39049b65-667b-acb6-3a1e-949502c1f040"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("390f0ea1-0814-5481-8a3f-3c8f065eec70"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("3982175d-908b-7fdf-7895-62e7c1bedd73"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), null, 1 },
                    { new Guid("39ca828b-6d99-e728-eeb0-f06a3d5506d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), null, 1 },
                    { new Guid("3ab805a3-8b90-0b7b-bedd-611571284f25"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("3accc404-7ad6-61a2-09e0-9ba4aa920ee6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("3b07174d-1682-8a3b-a71b-b0f4080d631d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("3b4d15cb-3e7e-786b-9799-f9399655ef88"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("3b52a944-7214-7f0a-97d7-453492b7ae20"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("3be26439-730b-1285-702b-186032b172d2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("3becedc3-ee4a-9c16-b6ee-b4473af4188b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("3c556755-3b48-da19-a7a2-3ccf5b555e82"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("3c5f7242-2141-3191-d8ad-20d2578da379"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("3c656895-7c32-151a-8e20-2a8e1c4ff6ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("3c9b2f34-d380-fffa-a6aa-afdfbf5dfbe5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("3cd5c9a1-079b-78e8-db58-1392d92c42c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("3cd79458-6d62-0b1f-b47b-dc15cd12aff7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("3d05d665-3365-24f1-ee83-2c2ca4c151ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("3dc8c813-9bba-5d7c-53ba-47c25224c8d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("3dcfc4c9-379f-0104-e905-0260733e21bb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("3def8fc6-3a82-4d39-f013-02e8edea2ae4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), null, 1 },
                    { new Guid("3dfd4f77-32c8-bc79-b242-a508e4566103"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("3e10c779-7b19-ab89-eeb8-7b5912595f2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("3e38ec51-d4cb-cc6a-dd78-362c1625f7e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("3e866d19-746c-9a43-7e57-8ab992f2dede"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("3ec5f216-dba8-e9e2-9ebc-ee97b3a0a506"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("3edc0b20-5c90-ba72-a388-fb7ae0704a7d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), null, 1 },
                    { new Guid("3f21c062-6204-7824-4e65-a8f36cb88b2a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("3f56d67a-a1b2-8ce7-91eb-dea9c561ac1e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("402dab8a-582b-3178-fb10-ca822cc6128a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("40a570c1-2aa1-9712-80d2-e79afd32b731"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("40d270b3-8a81-ec87-6aba-39a49683cf26"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), null, 1 },
                    { new Guid("40d9f28a-c920-cb01-6a98-94624733aade"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("41978c21-aa49-7b1f-0b40-c94190dcebaa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("4199a4d5-1288-5bd4-1ffa-8f0d64625b1e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("41d9810e-af9e-284e-073e-a026e2235e43"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), null, 1 },
                    { new Guid("41eda1d5-c09e-50c3-603f-1f8092de13aa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("42456b9e-dbe7-fd3d-e260-c714a03e6b15"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), null, 1 },
                    { new Guid("428bacad-dbb0-5388-0959-4b8b424bb831"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("4436732b-2989-f262-a2c4-06c15f2ef29d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("443ae83b-e613-0738-c247-245e0fa1c008"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("44d70851-9c60-538e-4139-5329e2d14f38"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), null, 1 },
                    { new Guid("44f1f745-aa22-a6bc-e679-0e17a07028bf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), null, 1 },
                    { new Guid("450d5688-35fd-7d4e-ab1f-ccaec6a77488"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("45144903-7f78-02ce-75a8-0229d42aa9ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), null, 1 },
                    { new Guid("4549f377-1e0e-4600-1727-de85fc493287"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("4597e589-45da-cf36-a010-97e1cdb06fd6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("460925a5-0661-a762-75d6-16c6af18af99"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), null, 1 },
                    { new Guid("461d2e3f-0b3d-9e12-2b3b-cd378c95d6cf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("46b24884-9a91-72e6-ed26-52cd0bc14097"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("46c8444b-3421-a98e-1ba8-3bb91de65aaf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), null, 1 },
                    { new Guid("46cfeba4-75ff-f4e1-ce02-02801c467120"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("470ec250-0cdc-b4ca-8437-a2da786f3467"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("473a2a1c-2b8e-d7c3-0564-cf7ca211b8e0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("475cebc6-634b-e184-7739-39c9cf1a0ae5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("1a359556-069b-5568-517a-710c78025668"), null, 1 },
                    { new Guid("47912d6d-82b9-aa69-3e75-0d7f71bfceb8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), null, 1 },
                    { new Guid("47f565f0-ab9c-192d-afd6-cc5a099a07be"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("48e2f897-508b-c7fe-7f2c-653b6a9d7fd7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("49db7338-1228-7f55-5622-fc7aa4e99de7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("1a359556-069b-5568-517a-710c78025668"), null, 1 },
                    { new Guid("49f85e22-1874-7c61-584a-ed4382c59814"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("4a14e2f4-99c0-c31c-514f-a2d4cc92ec7d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("05444d2d-b737-78c2-e3b2-e6b5bcaf3979"), null, 1 },
                    { new Guid("4a3c36fe-4754-9384-d243-1a9ddd237258"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("4a4d7f4e-f506-b674-0c53-68207650fec5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("4ab4eed9-408b-bbd1-0ac1-21072750d0eb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), null, 1 },
                    { new Guid("4b02b911-e659-2488-da2c-7fd722f107fb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("4b66cf65-9ea9-1b1c-c7e0-13931f677acf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), null, 1 },
                    { new Guid("4b7d061d-60fb-8108-31a7-53504b4f083d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), null, 1 },
                    { new Guid("4b854096-a1c0-b852-8622-029e7f609875"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("4c0d56b9-3cc8-14d9-28e0-5d1b01697361"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), null, 1 },
                    { new Guid("4c0da017-141e-ae55-286c-ea355f84b393"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("4c1a8d59-bf1e-4650-b261-191b530a02c9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("4c74b84b-713b-fbf6-5172-7bec687ea5ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("4c8952c0-3172-3f38-d9cc-8327a5ad651b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("4ca7bca7-e634-7ae4-c7bc-31f373138c00"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("4d4b8066-d282-cb06-22b7-6adc8faa9632"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("4d7275da-06a7-83ea-37d3-a1d87fa98795"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("4d9be874-235a-43ce-973b-f1e4984cfbc9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("4617b56c-f396-48a8-a725-443879fcab82"), null, 1 },
                    { new Guid("4da24f7f-beb2-745a-057a-5871e42e82d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("4dadf62a-4750-3845-55c3-c2dd8c12e274"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("4ddde420-b6c7-0af2-c5f2-481b32d7c3b2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), null, 1 },
                    { new Guid("4de1bb37-3fe3-93a6-4130-5748bdc2a384"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("4de36929-ce3d-c622-6a3b-aa12a2c16bdd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("4e450bbb-0333-f0e9-74ea-40e0cfba0bd6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("4e694c26-e33e-dfb6-cfab-6c206226b843"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("4e8e1950-2cd4-bf23-37ca-f8985caa21ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("4ee0595a-cbf0-41bf-443e-42779f185563"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("4efd6aa0-a190-7e1f-2df0-66971bfc5b00"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("4f63cdc9-2c68-d774-2b48-a2ee5d685d37"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("4f6e92d5-a34c-e8e1-aead-17799afb6fd8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("5025fdf3-1e8a-8a75-b70c-6ab4bef0e1ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("505bf960-97c3-aaf9-6812-deca3350fc22"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("506187d9-41df-ff20-52f1-6b6ed88074bf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("50bd7d35-374d-e3eb-2e9d-ff54e78c4607"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("50e20e18-9041-21bb-0849-9bf3f9fb3a62"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("510d8561-93e0-f6e9-11b0-4a922c85ea05"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("519eb03d-a165-9fa3-af9c-a4aba3356664"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), null, 1 },
                    { new Guid("51c5ff19-c32b-42c3-59d4-bec5b8a82d8c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("520fcfda-1941-89f3-cbae-6d5421da35c4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("521044d6-903c-5d24-434b-8a544d979321"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("526702ab-6dae-ee36-2485-67b4d72c577a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("5275454e-f31c-8bbc-bec4-0c590e8533d6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("52859072-3a3b-ab62-d68c-d188c79e8139"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), null, 1 },
                    { new Guid("52c8f034-1398-0916-f854-aada04e3f9cb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("52cb1902-50e5-4076-883e-7404d8c2f681"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("538268a5-3627-2443-4618-aeda9599ff1f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("54388641-0a2f-1559-2bc4-4de33d05d254"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("387233c8-0a58-19b6-7800-53621c965341"), null, 1 },
                    { new Guid("54d715f6-170b-98ad-0e73-0f16e297c6f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("5575c00b-d6cd-5ac1-2a9e-d2f2549da717"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("558045a6-5ca6-c605-d527-0d74073f4172"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("55d720d9-4f67-cb11-45ed-948ba15c8c0a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("560f5cd4-00b0-b291-c49c-3e2e888ab618"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("568a850f-ca6d-15a0-b3f9-2b465c0ece15"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("56a2e1cf-54b4-1a10-7831-65637589a2aa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("56f48375-ecaa-01b0-1e9c-0e60586ce09d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("56f5f9d9-9cc7-69fe-43d8-6723fd132831"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("5711b465-83e7-c968-97e7-ae119a1ca11d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("576cd948-8882-08be-54e5-42bd86c9ff23"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), null, 1 },
                    { new Guid("576df8b3-3a63-84c2-0471-d5333cf13a0a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("5791ed26-d6ab-d3b3-bdc2-ed8a031bdcc4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("57aafc8b-5232-3be8-341f-97f62fea3d5e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), null, 1 },
                    { new Guid("581bde7b-da0e-b599-645c-4e75ad798baf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("583a7d5f-2c85-5d62-9e87-19b3e9910279"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("58822dbf-1995-6ec4-53d8-a3da883e5bd6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), null, 1 },
                    { new Guid("58a0bbf7-093e-a828-9a3c-d6b178e55eca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("58b1aa8b-7c06-d666-2f26-5aa87c09dbac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("58b695c7-7bae-8651-492e-4911269abded"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("58da2ccd-cc8a-11d4-76bf-65f34433f970"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("592bbb0f-9ffe-81d4-f90a-95000cbe5006"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("593db3b5-c313-6308-baff-5b16ffda6476"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("59b9be7d-d842-4760-766f-69f139efe563"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("5a6406ef-8d7d-b51c-8ebe-e255f758d12b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("5a85a4f9-a908-7d5c-71f2-119de71a0b9b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), null, 1 },
                    { new Guid("5ac11e72-80ac-875d-c3de-c3e3c8c5e0eb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), null, 1 },
                    { new Guid("5ac61179-8ce2-7f34-d4f4-a2858779c571"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("5acd0aeb-565c-21aa-3afc-4df7a6581108"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("5af65917-d05d-f7f7-b9da-8656fe607d46"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("5af6c51e-0d31-3c4f-c7db-fbac0889e49b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("5b08ff94-dc02-01f4-f0aa-546989d0c1d8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), null, 1 },
                    { new Guid("5b4fc561-5d45-12a7-aebc-47ae89c0420e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("5b950b8e-b1c5-8db2-e752-9407679fb31d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("5bb825dd-d835-0eeb-21e7-56436367dc91"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), null, 1 },
                    { new Guid("5bfcaa2b-0658-7812-9a0b-7e9f3f2acbdd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("5c075d8d-f935-79b9-9faa-687eba4fd566"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("5c0faeed-0513-3431-fdb5-a0d1e2e8cc5f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("5c13e06a-09c8-fa2a-eadf-9a3d2295eb6d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("5c3805f4-a72d-7d62-4e42-37c388c1d4ea"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("5cab584f-2f5f-01f3-2e8d-d1a7a56e472c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("5cde058c-b614-f034-067e-6306adce2b4f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("5db774b7-5090-fd4b-0680-9973d4f712b7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("5dbdf3b8-593f-82c2-cc8f-8720a8b569b4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("5dbef9e3-93ad-21ab-fc96-01239060c596"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("5dc01e6a-6403-bcf4-afe4-28271f09c659"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("5df7cfd6-1418-e071-b7f2-f09f1116a1a9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("5e0fca68-e9d0-673c-c193-c4ff93053258"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("5f535620-c3b6-971b-2b28-630d37c38df0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), null, 1 },
                    { new Guid("5fd97482-ed01-be9d-55b0-d8e6a81cc5f2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("6039ba77-5acf-a0bb-8868-91638c98a935"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("6047fd6d-ef97-eb43-a67c-34852f588492"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("604a25bf-bd94-bd4e-f109-21ee12f6e51e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), null, 1 },
                    { new Guid("60586dc7-eb69-1cfa-f253-207f69ba739e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("605d9c68-11e5-fd49-8a38-aa26e8ab02fc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("613a9c36-4829-57a8-413e-b37c2e21c1c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("61595335-c6db-73b6-65e5-423b5bcb9cfe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("62a04b69-2e5a-97ac-571a-e033504bb7ec"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("62bb37df-6b34-4ab8-8a16-c670bbde30cc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), null, 1 },
                    { new Guid("62f64e3c-d85a-41c8-7332-434067993926"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("6340b71c-0692-8496-4562-e04d4813c4b6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("636cdf93-f769-7e4c-6529-eff73cf2f005"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), null, 1 },
                    { new Guid("63710e45-2eb3-bf79-f5d8-7f7bdf331f91"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("63868542-5845-4c15-b8b1-37fc7086e15f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("639a8f9f-4c5b-5e75-8c0f-78bb3b8a6360"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("ed77928e-8379-1adc-db4c-136ce9319159"), null, 1 },
                    { new Guid("63ad56ae-d249-b975-84e5-a6852f9e1982"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("63e5523d-8ae4-4c7e-5dcd-65e60e3a5964"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("63f36783-5571-298d-22b9-fbc38baa2d92"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("63fa42de-c1c8-17c4-37c6-b5f7e429cc16"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("6471b9b4-ee2c-29b1-b78f-256a3a012434"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("64c410ab-52e4-04b3-8270-73014f65f5ce"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("64e7ba0c-f874-8f5a-145d-4cbb1b4a88c5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("65441cce-99cb-9509-82a1-70074170498e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("65483c91-6bcb-fbe8-ade3-7c035da22f5c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), null, 1 },
                    { new Guid("658ee46c-a741-1daf-b2a4-0e51c34dfffa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), null, 1 },
                    { new Guid("65d4ff59-64e9-9fa5-72a7-c462c082994a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("65de38eb-9414-cc07-1caa-03839aab8d77"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), null, 1 },
                    { new Guid("662666db-d70a-3067-ac29-fd681b3e7370"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("6639ce63-7a3b-6c40-b726-ccd0d1a0f1c1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), null, 1 },
                    { new Guid("663b7feb-a8a4-63c3-2004-b3af80a714bd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("664357a3-f427-b1b8-c45c-3b881da9dbc8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("665e6201-49f1-86c1-5bf0-9a10455739ab"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("667ff11b-a883-32a9-1f48-86ee3d070c17"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("67723f34-62e4-2368-ae0d-87009017fa40"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("679273ff-5bb9-ba6a-661c-d6c3ae1a980e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("679dc08e-9842-6323-618d-b9b152f9e20d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("67e90a55-72f0-e27d-6dba-4b4e5f4f8c07"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), null, 1 },
                    { new Guid("67ede579-08d2-da12-5d31-5576ba929132"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("67ef813b-d72f-64de-7b38-8fd69ec0da35"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("680ad41b-607e-662b-4d18-cc402f1a6188"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("302b444f-98a2-4992-066f-699e031ddd77"), null, 1 },
                    { new Guid("6865c38a-a6f5-5fd7-84ce-841db375d924"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), null, 1 },
                    { new Guid("6897db31-f0b1-b2f9-4822-ec4ff4dc6232"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("68a34ccf-ed32-9d64-4b49-b392d6fde36b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("68ae13a0-549b-d35c-aa07-091f4b254c2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), null, 1 },
                    { new Guid("6918bf2b-2ab9-66d1-f054-810585b9a54c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), null, 1 },
                    { new Guid("6974e437-3306-db60-0fae-25fa037edfe1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("6990c757-a936-f9a0-acb3-ff900cd2b07c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("69c759fc-78d8-d99e-cb12-09f62997e67c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("69dac616-6cc2-d75e-6873-1c70c7e5e9be"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("6a160f6a-dfd8-2650-af0f-f80140fa290d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), null, 1 },
                    { new Guid("6a16f0d8-dac8-7a40-f180-2237356af5e9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("6a41499c-01e8-05e9-6952-87f63a00b7d3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("6a460834-922a-9d09-fb52-47f4a3a2f862"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("6a58f1a8-6208-dda8-b7bb-f9185490d8a4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("6aaf83d0-6e10-cd87-61ab-4e51933bf5cf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("6adcdad5-b98f-862c-c538-c638c72ccfbf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("6b0c038c-483f-e556-ed86-98e94587664c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("6b5634aa-1c5d-73d6-d07a-c8edee7b2eb8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("6bb04174-04a5-09be-5906-e17d8870e5ae"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("6bd3a9f0-4ee1-78c7-eb13-a41e9b76494e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("6c1a97ed-5b13-ddb4-8ac6-963eab52bffb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("6c4beed9-4eb7-43cf-9bd7-f81ee7110e10"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("6c50d596-8c4b-3f76-a29c-0658ae975275"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("6c9425d9-a8ea-d672-14db-ccc60ff0b491"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("6c9f1a27-9a8e-734d-7740-40c93d650633"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), null, 1 },
                    { new Guid("6ccf0207-46a1-8366-c949-e3c91c000588"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), null, 1 },
                    { new Guid("6cecbea3-af1f-e464-5e96-bc7ed5c88134"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("6d0c35fb-471b-8d54-8f6a-e4465e39ce9b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("6d55a3e9-d5c8-f4e3-81f4-ec90cf236cd7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("6e03dad9-aabe-efec-e58c-9e747f6a6465"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("6e1769fe-6975-79ee-d8ee-1c7d517cdb7a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("6e6a88dc-d65d-dbf8-13c8-31e144e56621"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("6f594afb-02b5-91a6-1e1d-30e3f87d0741"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("6fc88c4c-6436-7291-67a0-4ed9caa73f25"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("6fd25b02-8122-48b5-4a26-f32819594653"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("70cb5767-116c-ee94-12b3-61aab473ec69"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("71180a83-0551-85d4-91a0-5174dfc0c4c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("7259817e-8559-8197-66bc-645c87b2ee70"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("7276e8fb-9d6b-cc87-c50a-d583bf33a9ee"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("72b6789a-2add-9be1-97ba-4baee1c25794"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("72f85fd6-b511-5564-4ccf-76e8f7379b73"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("72fef746-1640-5652-fa33-9665b25d632c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("731c7f3d-c902-5d28-6f29-cc2033fa1a73"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("7325b513-11a4-855c-0bb5-8f4fb2349cc9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("73420c22-4f74-eb5d-0787-9d3cc562a86a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), null, 1 },
                    { new Guid("7343103b-3075-9874-5766-d26d4176fcd5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("736ba8e5-16c4-144d-7c30-4069fc2198c7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("73a72505-f624-c17f-d0c1-ac8784c9e150"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("73e4d4ac-0c78-cf65-d3eb-18009a28269d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("740f4e95-0afc-269b-33df-902f0f07b614"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("742cd534-f985-9ba8-9154-cce7021200fa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("74589cd4-a0e1-2b59-80d3-17e9c6fd984a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("746e9336-0ba2-29ba-5fed-45b3ab60295c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), null, 1 },
                    { new Guid("74766d2d-a504-492f-e2c1-ca48d369c70b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("58d3fb19-554c-688d-a424-9e2722726772"), null, 1 },
                    { new Guid("74e6f705-7242-5629-0d08-7b050ba5f487"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("750d1db7-17ab-e7c5-221c-b90b80e489ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("75185856-8e66-f000-1dd9-a57890303d46"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("75a0b34d-eace-a953-73c2-b7f3b1e19d6c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), null, 1 },
                    { new Guid("75d4e7d3-e495-ae8d-8b5e-fa05bf3b8432"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("762582c9-b194-b511-c20c-2ecfd10b0fe3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("7651a2c9-26b1-08a4-e2f8-43ee5348988a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("58d3fb19-554c-688d-a424-9e2722726772"), null, 1 },
                    { new Guid("767b9657-083d-66cc-8f0e-28996b301f91"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("76b45daf-dd1e-d413-8270-6b879a30819c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("76b6a63c-c8b5-9cd4-30ce-3488ebcefc93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("77595962-4a35-2a5f-05de-dc5866019c0b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("77df4925-562a-db0e-1951-1b2356c139e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("77e88b05-1010-8b43-6a3a-37f7c0017e57"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("780ff149-76dc-ef94-20bb-c3060540304e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), null, 1 },
                    { new Guid("7887ad31-2b4a-8596-61c2-27e8981a16c6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("78c97da6-da9c-fa08-ee5e-2392bbd41c43"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), null, 1 },
                    { new Guid("7930890c-5442-237f-afef-3ff535ca9c5d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), null, 1 },
                    { new Guid("7a221466-186e-79b2-775d-cdc27e869a04"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), null, 1 },
                    { new Guid("7ae09a1a-2155-f0ac-7786-a0372ebb99fc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("7af4bbf9-e070-b411-867f-e00ec4d5e8bd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), null, 1 },
                    { new Guid("7b7d5a09-994a-5d47-ce17-60ef9d91aa5a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("7bc50965-ea5a-057f-9621-4738878eb19f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("7be520f7-e54d-b527-fe8a-23be2d9dc449"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), null, 1 },
                    { new Guid("7c0398cb-9c40-4756-68f4-75c080e4a309"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("7c4293e3-43c3-fb75-25d6-92b9c2eb3c2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), null, 1 },
                    { new Guid("7c8fd16f-4946-6325-6de3-a3ae9d32bdaa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("7d3027d0-aa0a-45f7-a521-076de3811e19"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("7d3adf7b-471e-fb2e-3c81-82e6c1d5f50e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), null, 1 },
                    { new Guid("7d708c54-ddce-1871-e911-3bb09f806d19"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("7d724f6a-30de-2a0e-c44a-6277a54a4d93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("7d9600f4-75c8-7656-84d4-21cdc7cf21ec"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("7e1456b2-acda-319f-874c-87882faf0b68"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("7e33e107-53ac-9e7f-7449-208f5e3efb7b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("7e8b9bec-7a8c-4571-4a68-43da97506cda"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("7e9c7a2b-78e2-fb14-d739-21b0299a86da"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("7ebaa561-14bc-4760-1f14-d105cf99df06"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("7ed7b3be-a3f2-97dd-a67c-eec07d118692"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("7eefd09c-8519-2db9-bcc6-70d3c505a0a9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("7f15af06-0930-a40f-e46b-75862c763c6a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("7f912c8c-745c-9939-75da-8ff952b4d8d3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), null, 1 },
                    { new Guid("7ffcfb31-2501-ee2d-08ec-9d8724f2da69"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("812834c2-fad9-d69a-3ca8-e77269336e35"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("8155c2ee-05ff-253b-9504-0165c6342bd4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("817af0f2-aa87-9c15-600e-82d14d29e605"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("817f941c-0f72-7d93-2ae8-ae39c0a889ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("81b516b8-6f67-99f9-32ac-cbc962718866"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), null, 1 },
                    { new Guid("81c8f0ce-cb76-c2ab-3fba-1e4b0438a023"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("c26eccac-830a-b723-3250-ec13bde69c60"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 },
                    { new Guid("81e5dba8-2e72-51ee-f8b3-794c734d90de"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("82108b26-99f4-0010-6036-32936c75fcd1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("824e0255-401d-06bf-fe7c-28b6dbec983e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("825003ef-0862-5b1a-3a4c-2d884912d3c2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), null, 1 },
                    { new Guid("82fa5eaf-11ac-b795-4a21-f8c7119f27db"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), null, 1 },
                    { new Guid("83fe309f-2900-ca99-8639-4c3432dffd6d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), null, 1 },
                    { new Guid("8419d9a7-e471-af25-2031-5582a10afe78"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("85bb8add-79ee-545a-7f7c-0cf8241d2198"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("8623ebc0-e507-d127-6c33-1cf36d63f120"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("387233c8-0a58-19b6-7800-53621c965341"), null, 1 },
                    { new Guid("86479830-fe0e-1299-2113-d491bc6c857f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("866b7ec8-3f00-1dd8-cfa1-22a5fbf7c6ac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), null, 1 },
                    { new Guid("86859e0a-7444-fdb0-e7e4-52f8d6fefe3b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), null, 1 },
                    { new Guid("8698f833-cab4-6082-ccaf-a9a38845e739"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("870a4f72-7a37-196a-44cc-2c78d09bef08"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), null, 1 },
                    { new Guid("87402f1d-5056-e871-2f84-5a38c2ef5765"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("886f4b93-bb9c-ebbf-3895-1edab895e52f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("89390dcb-1758-dd94-c4b7-e64ac0e61535"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("894a9593-5788-539c-6fee-18db0423294f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("899401b7-44e2-897e-64c0-e5545b2041c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("89a7de19-0d29-5d98-3eda-21f0c652ea23"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("8a65b5f9-2a0e-dd3c-44cc-2600f98bf354"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("8ab06586-4b03-d72b-22c8-5067da3e89d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), null, 1 },
                    { new Guid("8ac204e5-3c14-c961-e43d-a2dd3cee99b3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("8b1f3ffc-1952-1f44-76f7-88d9131fbe00"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("8b36a47c-6d16-006a-1ad6-5627e5bcb2d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("8b375109-adae-9f71-ba7e-c9c4b80bb898"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), null, 1 },
                    { new Guid("8b41211a-b20f-3cfb-8f34-774c0a5acd4b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("8bbc643d-46d1-b24d-b286-a91823f96b55"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("8c56f9f9-1821-1c3d-a5b0-38544a7a751d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("8c921343-0b88-b694-0e52-9dd8db35d46c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("b8e45ddd-1a77-ea7e-3ad8-bf86317641e7"), null, 1 },
                    { new Guid("8d57b4d8-269e-8b68-7c7c-bacd1013c00f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("8d71c36e-1e2a-586c-a165-6ee041e577a1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), null, 1 },
                    { new Guid("8d89ecec-8ee4-36ab-270d-d6c7b24a1dd2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("8de34974-f12a-6302-aef2-aceff0aef3d3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("8e4b4822-9d52-fccc-8fc0-a1826e348b33"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("8eb542c6-a591-8ef8-422c-bd37d9f7a5df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("8ebd9259-976d-f28f-8054-18f2e7726306"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("8f308014-dee1-ab5f-1631-ea289018ec03"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("8fcbfff6-1e36-7500-c318-1b01ea1ae3df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("9067f32f-d19b-df76-8f1b-840f5e1fdc66"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("9069d4fd-cad1-b725-391f-8262dc802c07"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("b86a2beb-0e7a-8705-36ec-60bd16badb22"), null, 1 },
                    { new Guid("906fb26a-f846-aea0-c7c8-25ac914a9e3a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("9081dfdf-026d-7393-49ae-af1502ff62b0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("58d3fb19-554c-688d-a424-9e2722726772"), null, 1 },
                    { new Guid("910e6e18-069d-707e-e28c-8a8dbfce6c68"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("911459c8-6f2b-236e-c8db-d430b98bf4ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), null, 1 },
                    { new Guid("9117dd22-3275-36ab-a40a-e1d41e95de2d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), null, 1 },
                    { new Guid("91359314-c517-dcbf-e2e6-2035b47fab40"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("91905ed9-15b9-2a3e-60db-5541cd5e7bad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("91b9ede5-66e8-1ed7-6da1-625b1f57bd3a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("9204e5f3-279f-410a-828b-e03b87b8869f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("92051e14-491d-8a68-1c9b-d78e9fe7b101"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), null, 1 },
                    { new Guid("924e414d-e122-7525-8773-eaeecbc16cc7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("92658c7a-9c5a-387b-0e0c-0a54bfc82b89"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("92b308e0-267a-ec26-8270-3d9d717a08f3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("92f2b649-f820-973e-5b48-880943644ca9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("fb1da561-6749-593e-e27b-404bd128e181"), null, 1 },
                    { new Guid("932f6f90-4c45-8b91-70a3-8035e3704bd9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("934337a3-7998-c7d3-57fa-b77f1e9936e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), null, 1 },
                    { new Guid("93822e68-896a-ca76-0444-fb34d8dd1bac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), null, 1 },
                    { new Guid("93b6081e-764d-3491-a146-9123505d3138"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), null, 1 },
                    { new Guid("940552dc-9075-7165-aba8-f71c0510adeb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("942d335e-bd15-f558-90d6-3e90cb0c2045"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("4617b56c-f396-48a8-a725-443879fcab82"), null, 1 },
                    { new Guid("9431c35f-c17f-7dd9-8ae8-f8a9a783ebcf"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("94ce83b4-673f-5f0d-5ba7-dd91f82104e1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), null, 1 },
                    { new Guid("9539574e-2f24-0f39-bd37-02ae03c669fe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("9539eb5a-005e-0767-4066-11c89420e211"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("9540cf5c-338d-c8d4-7946-73d9e4758529"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("955e3363-ede1-9a17-da9f-a55231e6775b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("9575ccce-56be-fa10-f288-37560ae4f4b5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("95d5749d-63a4-49b6-90ce-a923b67184ff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("96236cbf-194e-5c53-36be-ae7fa6107222"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), null, 1 },
                    { new Guid("9650a08f-fabe-8826-e6f1-8ae8143d4a6e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("965a3d33-51a1-bf87-3a4f-60b6db3d73de"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), null, 1 },
                    { new Guid("96dc9843-0aee-5661-c372-41f731bd30ba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("96e9f77c-a772-8c87-41b9-aa6a62218222"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("9700304e-61e2-7c79-44f5-6e0522ffed62"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("97655c4f-de89-2393-bac7-c139b23f89e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("977ebfb9-3ba4-3853-c66f-d3005d100c71"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("97864697-d5f1-f747-c61a-df4bb281ca42"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("97c0845a-e97d-123e-68bf-c782468021c1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("981be888-6f58-4547-c544-d440b4f51b20"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("981c2a8b-1ba1-1bb7-c798-a4e6b836e136"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("983e57ac-6467-ba73-4381-81d5014594cd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("987f43c1-d566-c9e2-2f04-82962585f10f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("9888ca25-5473-5ba2-3362-47b9c7e10f2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("98a3b2f7-a139-f6e0-ac95-db85a41ac6f3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("98c394b5-9442-df05-abae-6ff697670e09"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("98e30470-0380-0a57-1c05-2b7f4a80b5fa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("7b9557d4-2459-735f-541a-547553225755"), null, 1 },
                    { new Guid("990b0d6d-219f-b4c8-2461-41b6e60b00a2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("991cb5b4-766d-af40-54ad-bfcf753b45da"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("995d05cd-4130-ad7d-6e55-4f3df6130caa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("99a26d90-b2e4-d472-4e26-fb648ac37390"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), null, 1 },
                    { new Guid("99d4e58c-3381-1cfa-2c59-fa9fbd55d549"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("9adfa736-49fe-aa85-26f7-6fdfb9a476b7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("9b270034-0504-da40-f08d-b9c78e5487cb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("9b87bac0-523f-6517-fa43-ce18536fa901"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("9c882858-d5ae-d3a2-c072-ecfb37252be5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), null, 1 },
                    { new Guid("9d1ce6f1-9c7d-0a86-27c0-e073ebe79a91"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("9d67cb10-f45f-350a-d53b-e6fe6fe6ef21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("9da2c683-6911-678f-ca7a-52fa289c8f19"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("9dcbe0b2-4824-56b9-0cc2-eccddb9e4abb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("9dddce27-cfab-06fa-8e12-e513edecd870"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("9de425cf-daa2-5035-73c1-279b4b45ffd7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("9f127cb2-fa73-fd7b-799d-b17bd66b5e55"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("9f38e5b9-12ae-7b64-e77b-56fec6dfb448"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("8858e63d-9211-be74-e473-32ad6ff53f0d"), null, 1 },
                    { new Guid("9f3d58ca-735c-4452-cc87-6fcb9df24348"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("9f58ec6d-402d-b29e-851b-b1da8fc89188"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("9fa35cd0-f140-34f5-207f-c4f464a9265b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("9fb1eb1d-baec-675b-dc24-e9fd1da3f951"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("a0228038-d591-7a79-3d9e-0a77c1411a3c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("a05aa598-f9d5-913a-2f86-fc39c1e6d345"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("4617b56c-f396-48a8-a725-443879fcab82"), null, 1 },
                    { new Guid("a0c92d0e-5719-5373-02d2-688173e71825"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("a0d12a4e-1219-25cd-0ccb-5fe165976e2d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("a0dff7c2-6e5b-71a7-65ce-6700f412892f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), null, 1 },
                    { new Guid("a0e1cb61-5a15-9394-5aa4-cd4be3b4f0db"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("a1011b86-5ef3-4fbc-6219-d836580a61f7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), null, 1 },
                    { new Guid("a103f77a-2fb1-1b47-b5d0-00f59bc617fa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("a10baa16-f6f7-3f72-1bbd-5b46606bb81c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("a141725c-10f8-1210-5563-7d099576198d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("aa5b1ee6-353f-cc3c-e23e-12bbfef2c1a2"), null, 1 },
                    { new Guid("a176bfaa-9622-6afc-3567-712652742e6b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("a17ae5f1-2ce6-428d-74c8-b45b27d68d26"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("a2527513-10f7-1e69-1481-b4cc3290b722"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("a281de97-203d-654b-8e03-4823564c856c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("a305755b-559d-0ec3-5438-747e7c7f8f99"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("91cd2606-874a-0ef8-89b2-9a0d1dbb350e"), null, 1 },
                    { new Guid("a3448f9e-9318-c20a-278e-40f8b7477140"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("a38550d4-1d34-b0b1-fd3d-e01b0f94f4b5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("a3900ced-4fb5-b6d7-4c4c-2e17e5e00f4f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("a3cc6a46-3c3c-5eac-857e-71ccae61145e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("a4076d28-e64d-efc4-dea9-c43c60ff02a0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("a428d529-9bf5-80f7-4aa9-5c4af1143c1b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("a4b19848-5438-b5e0-2150-f88f35fe61b3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("a4bbc3ea-75f3-1e2b-cb5f-a3ac8890728a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), null, 1 },
                    { new Guid("a52bdb6f-4d17-c2f3-d517-3f5923a42df1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("a53ce826-6a55-6a39-bc97-c1f4d07f9056"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("4070835b-ad06-2f77-5510-9b6e45ed99f2"), null, 1 },
                    { new Guid("a577d56f-4dd4-6b19-58fd-c1521563341a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("a58cd5b1-8168-34ad-d1ea-74e273b8befe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("a63d1ebc-0404-ffb9-56bb-d15db51f4fe0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("a6600034-c881-94fc-0a8a-2a03bdde8e2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("a666157c-9f48-85d8-70fa-d3a87edb26e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("a6700a2d-cba6-aaf1-a916-a7bd1eb6b8cd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("a6c9496c-8188-e9a2-28e4-47ad2e125465"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), null, 1 },
                    { new Guid("a7253c45-c783-7d20-d450-9874e2c913dc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("a72e6731-4b0d-abfc-66ee-8c9cc62f3fb9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("6fab699e-d944-ce75-db4e-5432cb0d17b1"), null, 1 },
                    { new Guid("a74a22e2-dd56-137c-c495-5b9b773ba620"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("a7a31b53-dd1a-97e5-241a-ffbc7a39892b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), null, 1 },
                    { new Guid("a803710e-0cff-c60b-2443-e69942ece2e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), null, 1 },
                    { new Guid("a8c25dea-7842-64b6-522d-7f5ec7bad4e7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("a8d02e39-c17f-7468-8a15-9ced03267269"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("9a850ba5-8e79-63ae-438a-0ba14ef4d9eb"), null, 1 },
                    { new Guid("a8f6e727-880d-088a-b9df-fb7b3b483566"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("a911e595-b970-4a3e-5977-b341dc596267"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("a94b478c-4fbc-3670-0267-655e9fb06b72"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("a966e1d1-ee6c-8634-f142-f9c242dbaf41"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("a9704c4a-021d-fbe5-d502-ce1a45170c59"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("a9b9cdf0-8b15-55b6-a70d-7cb5b9a662a3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("a9da41f0-a0c9-79a1-f625-b575551ec380"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("a9e72ee9-a7fe-2a97-feca-02da5cf35faa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("a9f5c0e8-b3b2-a221-f39b-19e060b433de"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("aa31cfc1-f406-c30b-bd5e-bd36c37d8d48"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("aa3e94a7-8f01-1e5c-4fae-25b65432829a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("aa422d60-823d-0a37-cfc6-047e42743afd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("aa84b38e-b700-a337-d15e-f981efeac4a9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("aafd2cf9-c53f-e3bd-c393-75e986210941"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("015f9630-a039-886c-04df-2a31915fac1f"), null, 1 },
                    { new Guid("aafe7ba2-a92d-1d3d-0173-2e5ab6f696b5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("ab152518-d4fe-e8bf-fd9c-d82276b30e58"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("ab33d4ce-e867-1598-d904-735c10d44634"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("ab459444-5b8e-0162-46c1-ba08e8215575"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("ab571394-7b1d-6557-9722-2715acda7c2d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("ab590876-b79b-2280-e3ba-0a271b548a3d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("ab59bc4e-647c-901b-2164-dff9339e4eee"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("ab5ee640-99b6-5c39-2d13-78d36a70af93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("f8d918c8-a3d4-4b81-1f91-b05421b36549"), null, 1 },
                    { new Guid("ab96c3ef-8450-2ed7-9336-d1a9b9e591a4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("abda5f65-ba24-3559-dfc2-3569088adf4d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("ac0ac9d9-68df-cdfd-77ed-c819815eeced"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("ac1025bf-3834-0e39-a93e-a7d0217e3801"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("ac229638-e722-45ed-15c5-391af4d6b56b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("ac2b2766-8db6-5e28-6f01-c723a22e42dd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), null, 1 },
                    { new Guid("ac3a440f-8a76-c5f5-7b0a-6432e5efc85f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), null, 1 },
                    { new Guid("ac84b3b1-33d8-e9bb-8c03-f3c933b399dd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("acb4d6ea-c303-9906-59d5-62c9b50f8136"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), null, 1 },
                    { new Guid("acca4b32-00c3-9802-d8bd-26f1609334d6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("ad34f9b5-7b7d-4433-4013-4ae04c5d61c4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("ad4afdc6-3058-5181-a5f3-8c3d185e70ee"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("ad4cc794-1e9f-06f7-e334-6513ecef2b92"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), null, 1 },
                    { new Guid("add01057-0907-d709-0205-e8166400370d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("ae14b8eb-aebe-4236-bb52-d8e7424cb0f1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("ae17c30b-401b-dac7-4546-576853551f07"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("ae30b567-13dd-4e26-b5ee-a5e11697d200"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("ae6d857b-2811-0f45-c844-f6651cefe129"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("ae798344-0a7c-695a-69a7-a469f567a9f7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("aebd1146-6153-10e0-b729-c711ee314ebe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("aec06f84-5bf9-18b0-8d0f-439a21b9497c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("af36904d-dc0f-10cc-6bd8-6dcf37af8faa"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("afb52d57-0d28-c266-3522-c30f9dd19449"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), null, 1 },
                    { new Guid("afc2a411-3791-c52d-5998-442903c2415f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), null, 1 },
                    { new Guid("afdfd133-71df-67a4-4164-6abd5a058e45"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("b05545da-ad74-e79e-f50d-b5be951804d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("387233c8-0a58-19b6-7800-53621c965341"), null, 1 },
                    { new Guid("b05f3790-e921-65d2-10ec-41e6aba71963"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), null, 1 },
                    { new Guid("b0a38637-fc69-0b14-aca7-659d5845e3c2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), null, 1 },
                    { new Guid("b1022f14-a3e2-5f6e-6190-f59c1dca7d42"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("b1617254-d32a-25da-ac45-a86e3503e9c6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("b16a55f8-fadc-1feb-34a5-cd3702d01bdd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("b27731bb-bf72-ad1e-0acc-2037b4eb7376"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("b2d7394f-ed7d-7236-e587-678f1bf05e8f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), null, 1 },
                    { new Guid("b3290059-98c4-92df-6a0f-9949b24dc515"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("b82a69be-962a-3af6-374b-60607e483d82"), null, 1 },
                    { new Guid("b421d380-0f76-d4df-58b5-b918cdfc32ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), null, 1 },
                    { new Guid("b4ea620d-ea72-71b5-f1ce-5fc1135cf9a7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), null, 1 },
                    { new Guid("b5559add-1917-6a9c-504e-0b1027016eff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("b579072e-4d83-1aec-9d9a-6c41586227e3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("b5a681cf-de47-d993-9609-377a0dc71d69"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), null, 1 },
                    { new Guid("b5ab9098-59bf-8bc9-caa7-9f3c1e951935"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), null, 1 },
                    { new Guid("b5d910ba-b8b5-392b-5174-abd9a5c19f44"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), null, 1 },
                    { new Guid("b5db712e-b6fe-0ba3-ea61-aab31a78ad24"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("87eab0d7-5f92-a4af-a785-42136e4cfa58"), null, 1 },
                    { new Guid("b60b9ac0-0a30-ef22-914c-48bd577f6aff"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("0c3654f0-c4b9-49f9-d441-e1da245dabc4"), null, 1 },
                    { new Guid("b614e4f4-ac30-32e7-41d6-fee0b76b3c65"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("b618db53-db67-9361-0b99-de5a019e43dd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("b628e798-30d0-7289-0d8a-eac8c99e5110"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("b6be2b7b-bb7d-fd6f-9c2c-aac42ebd9088"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("6720a790-cbe1-d786-c545-3d8841c253c0"), null, 1 },
                    { new Guid("b6db6bbc-1698-7747-1171-f0f3a1f544c9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), null, 1 },
                    { new Guid("b7369017-c3d0-d491-626d-f924001f2e70"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("909321e8-0e12-6b1b-4ef0-80e1288d263d"), null, 1 },
                    { new Guid("b74e74d0-d419-936a-7cac-ddf0cc977dd7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("b77a1e1c-e937-ff95-f64e-0a4634ee972b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("1eef413a-fce9-fba8-9389-d384e4f146d2"), null, 1 },
                    { new Guid("b7e683e2-0df2-7b95-ae84-99e13e04e078"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("b7fcd40d-f843-18a0-4444-0deaa5783a79"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("b8349de6-56ee-93b4-b383-66899ec73fd9"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), null, 1 },
                    { new Guid("b857594b-3c7e-ac70-fabc-c8f5aa14dec2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("6bea68da-fafd-e65f-933e-9be5726dc45f"), null, 1 },
                    { new Guid("b866cdfa-37c2-39f4-c1a6-0c7f7170a385"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("b88abb4d-e82d-a1e1-3330-04a8ec58cb3a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("b8cfc5fe-227f-bc68-324a-a40d1d9297d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("b8d4ad79-acfd-5025-cf9c-51d11b0088c2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("b8e96381-a069-8b1b-007a-39db75558056"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("b8ef2aac-d1ef-fe81-9ca5-c4712f48677f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("b90b5e97-8e5e-51ea-f3d6-5b247d341bf0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("b94183fd-ebb0-a507-3e7d-8e4c5ab9ee18"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), null, 1 },
                    { new Guid("b9652066-93da-4df3-d9ee-aeb0073b698d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("b97934b6-ecc4-ff74-db46-2258a9ebe39a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("b9fb9ecc-605d-dbc9-5341-d07ecb4b4390"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("ba1ea1f8-6848-3510-adda-e6d93564b81b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("ba3ee34e-a709-47c9-fb35-167e2d56be58"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("ba455fbd-e8a6-188c-07bd-9a2e4a1fe258"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("ba80d53a-8e6a-8cbf-ea2d-25c9d3cdd806"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("bab5e562-40af-fe05-533b-3bb8370dec7a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("bad977a1-9f90-a26d-8297-68c7eac89392"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("bb42231d-218b-212e-469d-c01fec9ff91c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("bb55f49a-6587-6309-92f2-50beafdd35d3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("bb74eb2a-1917-a4c5-5265-5ec464178410"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), null, 1 },
                    { new Guid("bb9f3375-d2f7-22ac-af0f-bb1118c036b5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("bbe168f7-4c61-cec7-38e9-bd08501d6490"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), null, 1 },
                    { new Guid("bc2b0ab2-7038-f1ea-217d-7a66d423fee5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("bc313897-1da0-c8f7-3502-cbe2714081d1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("bcd1813f-4175-39ec-1b38-158bd41fa41b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("bd035d1a-5229-0353-c08e-fb02ea1e703c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("bd1a0b91-64e6-25b8-6ce5-d48a9d57f2c2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("302b444f-98a2-4992-066f-699e031ddd77"), null, 1 },
                    { new Guid("bd3fd7d7-86ec-fd78-dc70-2a060a10adb2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("92bafc00-2cf5-ce12-5d0d-5c804032bfab"), null, 1 },
                    { new Guid("bd5a60ce-7ce9-2d2b-298e-361314b8dd65"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("bd888222-152d-013a-ce83-12fdb31a9962"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), null, 1 },
                    { new Guid("bdb63425-7e85-a59e-508d-2b15b88d5509"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("bdd23829-3ad5-f212-bd33-f3df120ae09e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("bdf72f3a-f675-b82c-4ede-df7af9a84399"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("be12649d-2d27-36a3-1b65-a18b3aac9fba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("be82f566-416c-f373-7f91-db52d60fdebc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cebf4994-d702-7b47-d116-99c34fcdcfbd"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 },
                    { new Guid("be9b8ad7-ed01-7ed1-0067-eda694d1b1e4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("bf2a4e34-207a-5660-b783-74b80e119e89"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("bf306f4c-7cc5-dfc8-d337-99fe7a160d91"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("bf485440-a215-1a38-f051-1479805788c0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("bf9cb3a4-7fe1-9082-020a-017228fc6c69"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("b2594da1-038b-c84d-c8cb-be8a78eb62ac"), null, 1 },
                    { new Guid("bfc69b98-9cc8-4894-ecc6-2bdead263fbe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("bfcf9f4f-ebec-31db-6dab-050cf0bd4658"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("bfdd2e44-6f73-70de-1bf3-8b5022df5a32"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("bfdfdd56-b081-b1f8-e473-c968764e4665"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("c038c293-1d32-ebb1-1cba-c67b7a1c4a0e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), null, 1 },
                    { new Guid("c090fcb0-efb5-97f4-ea9a-572e40d54119"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), null, 1 },
                    { new Guid("c0c1fcfd-4e97-04ef-2f82-5f30b92266a7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("c136c3e3-678b-4e78-3e7a-fbccc6ad58db"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), null, 1 },
                    { new Guid("c146e849-dcd3-45c3-f081-4761ed0acefb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("c15856b9-3616-3dfe-580d-74521341d5ab"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("302b444f-98a2-4992-066f-699e031ddd77"), null, 1 },
                    { new Guid("c166318d-e9d9-cedc-7075-42559f4243e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), null, 1 },
                    { new Guid("c1a03d7c-8726-1135-5d5e-6fe258b151d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), null, 1 },
                    { new Guid("c22b4791-580d-748e-7db8-abaf6b80fdc6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), null, 1 },
                    { new Guid("c23e15d3-8fc3-215a-6537-ec20a79f6508"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("c24e12e2-a93c-de1b-f4c0-7ee41e1a693c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("27dd7554-4cc4-c030-e8cf-d50c01085580"), null, 1 },
                    { new Guid("c28a2e11-cebe-0f69-a3c3-e7e4f4004b2f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("c2ad9890-7ff3-1616-e4a5-4e666c700338"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("41623e1c-d7b7-6331-d89a-e059a7136dc1"), null, 1 },
                    { new Guid("c2b19a53-a574-0ef7-031f-1ba4c79954d5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("c2dbe585-d6e4-a440-2c70-b6c7604d331f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("cbee2854-2108-aabb-08f5-d61ad336f965"), null, 1 },
                    { new Guid("c33e7db2-50de-9ad2-2d08-faa2dd6eb8ed"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), null, 1 },
                    { new Guid("c3b5e6c9-7072-af4c-4992-d81d6b27c963"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), null, 1 },
                    { new Guid("c3ffe713-d2b3-6fc3-0880-2fd62536f387"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("c40c7a7b-e067-21d6-07e5-ea130163c86b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("c438ffd4-4caa-9c57-a465-dd8e37816b87"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), null, 1 },
                    { new Guid("c45bbfed-6b11-14ae-2ba9-bac6c9e9ac04"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("c4c0b15d-5b42-951c-2142-5270b9b87579"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("2cd23057-878c-f5af-168c-b40c3227e9ae"), null, 1 },
                    { new Guid("c4c47ccf-76ee-5f3a-0ad0-5f2852e80f66"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("c5006506-41f1-2cf5-d9eb-7f9062a3f597"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("c5877837-aa53-32e4-3d14-8e0cb241a07f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("c590429b-fede-caad-0000-f3f126901b9a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("c59c8d71-16ba-14cf-e60f-a84151c562d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("4b95d24f-81c9-0c7b-1a4a-71242af30c2b"), null, 1 },
                    { new Guid("c5deebbc-d319-cfad-1b2e-43f1aaf20e2e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("c5e7044d-e757-0547-621b-b60835d6026e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("25e66971-43e7-6cf6-6abc-a2e293c3f3b3"), null, 1 },
                    { new Guid("c5fa4a9c-3736-6861-2065-899030930501"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("0f96fe6b-319d-2d5a-0884-8e070fb04208"), null, 1 },
                    { new Guid("c60068ab-b168-0670-c142-f252cad132d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("a2fe73e7-2fb1-1633-7b0d-deade8778de5"), null, 1 },
                    { new Guid("c6091c1c-d65e-84e7-b34d-26c3d7a1c6b7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("2995f62a-f9c2-695e-0e10-b0811154d216"), null, 1 },
                    { new Guid("c62f5a81-5722-a353-c039-7d0823dae75d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("c66172c1-0146-5fd7-37d9-73f4433f0aba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("11d31d3c-c517-9703-a6b3-aa71675b66bd"), new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), null, 1 },
                    { new Guid("c74c2831-76ce-8e78-f4bb-b6d1b3bfc733"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("c74e562f-1ac5-9ec8-da0b-f546f63e8c0f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("b8a893bb-ce55-7f55-a518-4fbdd1d376db"), null, 1 },
                    { new Guid("c75cdd11-75d8-0c1c-f231-a7d631284214"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("c7651d93-4866-a8d0-e1de-afe7e4590c93"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("c76969db-c78f-dccb-a4f0-fd4300eaab57"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("c76f960f-5635-eb80-d351-67c3e5bc1c37"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), null, 1 },
                    { new Guid("c78d3d7e-980b-ba52-fe0c-d3ac12da2f45"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("c7dc030f-d73d-8da2-67c1-5bb0477009d7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("c7f54f99-d302-4700-9856-b69019404348"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("c7f76eb9-bc92-013c-0865-bc9d415eb6b4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("6fc1b422-84af-a0fc-166f-24d7b39a7261"), null, 1 },
                    { new Guid("c8271e4f-ce6d-459f-4790-b07d80cc61e6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("2192be7f-3b27-0d1e-e9bd-bfeb03183281"), null, 1 },
                    { new Guid("c851be30-06cb-fe40-3575-27fea0fa181a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("c85c6aff-261b-aadd-2247-95f07cb8a3b3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("c8af70dd-871e-c7f4-9d56-d9ba71d27e3f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("856ffc31-6f9f-ece8-ae42-2bf1b9a93e7e"), null, 1 },
                    { new Guid("c8c8cc52-61c0-a61a-b2f8-17cc9ef1d6d0"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("5d0d7291-a24f-b4f1-c366-22a7e8623c7f"), null, 1 },
                    { new Guid("c922e15c-a5b2-8033-662e-f00a9b653e48"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("c92bac86-5b2d-5bfa-57f8-47f2309b6884"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("d6b681b4-4972-abd6-9f90-bdb3ef70f0fb"), new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), null, 1 },
                    { new Guid("c9bcb2a4-0fa0-c9e5-1306-ffe52719687a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("6df58786-f51d-ce92-7037-207868fcbd68"), null, 1 },
                    { new Guid("ca8312b2-cc65-5ffe-00ae-1d7d160e5b28"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("87aac966-415e-2489-2612-531febe2afe0"), null, 1 },
                    { new Guid("cac1cd4e-84f5-2e09-7bce-2fc51d861605"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("efe9c85c-b7a7-d4c6-4204-6fb56ebf1151"), null, 1 },
                    { new Guid("cb65f5b4-379a-fb11-18e8-b33c1d088db2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("cbe4098d-b060-381a-99d4-1a447054ab5e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("cc0bc08c-518e-e453-98a5-c8a8bd2e601d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("cc4ff44a-a564-6448-28ba-1f7d665b90f3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("cc500871-75d7-eb4c-b340-0758e166c608"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("cc53a761-4f70-6097-ad75-9e40bbdd2874"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("cccbdca0-854f-872c-8cb5-cf353a824594"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("0718b653-d8dc-d336-8d4d-22c032c2c51d"), null, 1 },
                    { new Guid("cd71779a-2af4-6009-6e22-2f81238c4978"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), null, 1 },
                    { new Guid("cd8f5631-3a8b-df27-dbe5-6a9fb30889d7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("cdb27a25-b3b8-f570-63ac-ac8697158030"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("cdbd3904-07f7-e7d8-e97d-50d0934d43a1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("4617b56c-f396-48a8-a725-443879fcab82"), null, 1 },
                    { new Guid("ce0d566a-a326-984a-5b7f-b7b37dcb68f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("ce55cffe-3fe2-7761-ce77-9e79fc697440"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("ce60b8d2-df2c-23a6-2e61-4f726b6e80cc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("cec30a92-9d9f-b96f-faf4-8b39d04fa444"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("cf252dfb-4925-6102-cf2e-6e698ea568fc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("cf35eca8-b9d6-7ea5-9bc8-c45343e2032e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("faff482e-42c1-5455-7604-d43c99ff1b03"), null, 1 },
                    { new Guid("cf610d08-71da-4d4a-c7ae-cee82d8c0580"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("1cd64e8b-d446-4dd8-9c7a-3129a0dd6e4c"), null, 1 },
                    { new Guid("cf9452db-ae24-f384-ba30-58c4d3c36d69"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("5ac9ead7-3586-1db0-dda3-4d2a8aa656ac"), null, 1 },
                    { new Guid("cfd4fc1f-0f57-2621-0a24-f49e2e438e6a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("d023e456-a28a-2c19-b5ba-a70517dcb283"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("d0b29eb0-7842-843b-7a6a-7c292c3e08d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), null, 1 },
                    { new Guid("d0f1d8f1-deb3-0e8e-605b-ab7a11f1a155"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("30257dc1-d887-f64b-1d60-9e8aa8f457da"), null, 1 },
                    { new Guid("d14a2195-8a75-d9fe-9e45-a3a3fa630107"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("d174513d-27e9-6667-6140-0aab48509f21"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("d1ec2466-0118-74c6-99e2-c02171bce3a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("d1f7e867-74d4-e23e-05fd-d2193585b15e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("0d7d3b17-6447-ea5a-5ae4-eee7a76fae73"), null, 1 },
                    { new Guid("d21c1b0a-5cc6-c2f8-6fce-8fca37ab26ce"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("d2a26669-3789-f5c6-c6dc-6c8e298e5e60"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("4343f1c4-787c-3361-af5f-db96cd36ca5c"), null, 1 },
                    { new Guid("d2b6f80a-12f9-978f-d7ea-79adaf01eccc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("d2cdcb04-616b-e6a7-6e7e-30f915c7f6de"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("affe908e-e2c7-2cdf-60e9-cc3856709f3b"), null, 1 },
                    { new Guid("d329c47f-ad4d-b3a2-dc46-f047f1c47779"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("131e2891-26a7-948d-b9f1-8e17da20d2db"), new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), null, 1 },
                    { new Guid("d3b74bb3-77e1-1119-473a-4a7b1288b55e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("d3b815e4-e54d-affa-d6f3-370859a68320"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("50ccb61f-6b77-e87e-0deb-920cb2bd7f1f"), null, 1 },
                    { new Guid("d3c9ee13-4a4d-b259-bedc-25b1eac44c41"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("d4108d8d-b1a2-8083-2d4e-bb1037722df7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("e722ffa5-4b8d-b975-6e31-5515e6e92ce5"), null, 1 },
                    { new Guid("d4169803-2345-a444-2ce1-f31cf5c14730"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("acdf41e6-ea36-8bfa-5367-8301ce32c1aa"), null, 1 },
                    { new Guid("d41befa9-6695-cf7f-4cef-b49b439ada0b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("d455e1e6-0260-0059-1c9d-dc9329da861c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("e73b8719-7046-4d0b-2069-005ba6983fe3"), null, 1 },
                    { new Guid("d49f5b2a-4910-9f90-bd25-9e69eba48b1e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("d4a0674e-74d6-1556-4fb5-df02401e2885"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("d4c62951-f270-6e10-6fda-1dd64a474558"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("d51b10f1-21e8-2a11-b5bc-3a3feb228401"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("d52710ed-6c35-69e6-4b9e-486cc8d2df27"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("284f6dda-4d89-e333-e873-c565b0b9ae6f"), null, 1 },
                    { new Guid("d5380752-283a-8b07-ab22-4a11076ac334"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("d4bff7a5-30ed-27d0-602b-271c548ba686"), null, 1 },
                    { new Guid("d582a703-8c86-6cdb-8aeb-c1e8a731cb41"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("d5ada2c5-911a-8474-28c2-ac0282e64e01"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("05b988fa-656a-06bc-8a99-fbe158fdcde8"), null, 1 },
                    { new Guid("d5ce4991-3a65-f247-e3db-016e2e8dca64"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("60cc9ae9-83ea-4a8b-4371-e51f5ed95aca"), null, 1 },
                    { new Guid("d5fe569f-7e28-f794-106f-013e76ee6acb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("ec3512d9-c64f-183f-3e7e-afc6bbcd5314"), null, 1 },
                    { new Guid("d65e65fc-4fd6-93f6-fe94-49ad8f89f477"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("d65f7669-e911-a975-1021-86cf10c399ba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), null, 1 },
                    { new Guid("d67947cf-981b-3fa9-1042-90c0d48d2b6f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("d6b4ec70-9abf-b443-1827-a0b5bd528c33"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("6b97dfc7-d01b-2142-790e-c370172aa226"), null, 1 },
                    { new Guid("d73ced11-2b13-4b65-8d36-a6f5fd904d62"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("faf475ea-ebe9-a8c1-c718-082724e14faa"), null, 1 },
                    { new Guid("d74dd046-36e9-59fd-6de3-03f4312a9121"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), null, 1 },
                    { new Guid("d7852f2d-c7c8-656c-3a7e-2f4a53595b59"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("6aa83af1-74ba-dc59-a1b2-57c284d36c85"), null, 1 },
                    { new Guid("d7dd87bc-8fc6-9086-4e5b-786100d42a52"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("d7fac3d6-2efb-fe27-3b44-fe9e91663315"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("d82d5f63-7670-64b0-5e42-cb31a41cb99c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("d8506e19-bf9c-3a4c-746f-d7346a10a652"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("9ff13ed4-73e0-6121-1e7b-af809b51fc77"), null, 1 },
                    { new Guid("d8a2d370-06d4-2202-d315-4de9d9406f7f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("d8c53e0b-5aee-7a9a-0a1d-dfdc9e89e9ba"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("d8fcb1e4-7526-589f-8a89-6ee2fb7d7b90"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("d934961a-767e-ffee-752e-50d8756967e4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("d94af6a5-3b1b-861b-b96c-b3fb58556db5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("d9957b8b-7b72-95f3-f8fe-464f61606c52"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("460fc379-01c7-818b-28c6-d8d26024adb6"), null, 1 },
                    { new Guid("d9ade817-a344-6008-5597-f1aa5f906e70"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("d9bc4e88-fb92-e9d7-9843-ec8821ae6b23"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), null, 1 },
                    { new Guid("d9e26a8d-0960-ae26-8617-03c56f882197"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("dae05eba-7e72-f9f5-ee22-4929a84ecc34"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("db2adf66-80c4-a48c-7516-df865446fb76"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("db78c91e-9b26-ab57-782c-4aac19ba5305"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), null, 1 },
                    { new Guid("db806e31-5b12-b758-aab9-27b092a333c2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("dbdd4541-50cf-79c5-282b-6651ead5702b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), null, 1 },
                    { new Guid("dc6459fd-6a34-5b88-9a62-4e881e813206"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("93839244-6dce-cb0b-a5ac-87a5a1f17d3d"), null, 1 },
                    { new Guid("dcb79a56-4e44-c402-f861-80c1ca9c6bb1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("dce3bbe2-84c2-da4b-2067-943a7d7ca2f5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("ad36be38-a5a1-fd71-107f-da3d9a636fd2"), null, 1 },
                    { new Guid("dd07023d-a96b-6fb7-9dc7-2cf921656d8d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("10db58b6-bb76-a3c8-15f9-dcb0048e71e4"), null, 1 },
                    { new Guid("dda05ad1-19bf-90e3-1418-213995fb3741"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("4b1a1070-465b-f0dd-0351-96cc0cd3115a"), null, 1 },
                    { new Guid("ddc8e859-d19f-6add-6a13-5acff23f8812"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("ddf95abe-fee0-7803-146d-2c9c88484d6b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), null, 1 },
                    { new Guid("de12db5f-5827-1837-a3b5-b89fa6c85a3a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("daf65dd7-01cb-4a1a-d6df-c9598630f188"), new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), null, 1 },
                    { new Guid("de2e4112-a191-e8ba-51fe-74e7d86e2971"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("f004b747-d8b5-85ad-22c0-6714351ed55e"), null, 1 },
                    { new Guid("de96bd56-1c86-4ce4-e405-0d1eb61cd38b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("3eb064c7-8061-fc09-f665-74dbb592c9aa"), null, 1 },
                    { new Guid("de97d5cc-8944-5919-ade4-d5237f1bbe31"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("deb6f74a-8752-bd28-1bcb-26b5ea3d047b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("fe01fa8c-ed1d-0897-e220-3e3745e170ec"), null, 1 },
                    { new Guid("decb527e-8d26-3c51-4f17-9f33f17d142a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("decbf318-fe2b-95cd-66c6-2ec423db6754"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("2c9d50d3-25a5-16ba-b176-09ff97e49ef2"), null, 1 },
                    { new Guid("ded2e862-39ff-96e7-1127-0230f420574d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("deecbe2d-ae4b-4370-a564-705aa889e8ab"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("99a6ff87-5c33-22a2-ba56-eb8a0bff5e11"), null, 1 },
                    { new Guid("deed3a8d-0131-e5ed-f741-3332a40947df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("df17962c-e096-3f01-0ff6-8612d55fa47b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("aaf798ec-cda6-db11-3c2a-4f7372eae8e5"), null, 1 },
                    { new Guid("df32e7e7-1b20-2631-b61f-e42110d7a114"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("dfa48d1b-fe61-05d2-473f-5c7a21f16b7d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("dfc8d6c8-904a-51ab-3410-bf68118838a4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("6eda53c9-788e-60ea-eb60-428b7bafbed7"), null, 1 },
                    { new Guid("dfd50273-283f-793c-7120-9aa6795163d4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("e00ff699-c2a2-a01e-799e-e022265f59ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("e055aa33-a208-ee8a-8b7d-acefda4d6f07"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("7bcd6138-6f02-06e9-7011-17fbedfe10b4"), null, 1 },
                    { new Guid("e0617cc8-9d19-2135-4b40-889078525de4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("269ee0f2-7d1d-7c20-9542-e4cec7c955ec"), null, 1 },
                    { new Guid("e0d63f5c-a595-6d55-bdb2-1a47743f958a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("3b8cda4b-3b56-fc8d-79f0-0dde2123f203"), null, 1 },
                    { new Guid("e17f0fcb-87aa-7773-d3ab-11e4ce0e5372"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("e1b9f895-4bdf-fdb5-cd9e-a4822fd54f60"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("0b865146-9ec2-1df2-c409-bf48c41c804c"), null, 1 },
                    { new Guid("e1eb54b9-6c9a-9a15-0c45-b0041cd844ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("e1ff8465-f1df-6951-b4bf-bb58194aee04"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("d9be8f82-5ba2-6682-b08a-61787d698969"), null, 1 },
                    { new Guid("e2027001-fb6d-5269-1aa6-e70d8e31d487"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("b800a5f5-362a-c710-aa82-da715ad7d5d4"), null, 1 },
                    { new Guid("e26b510e-8fd8-5940-e5aa-98d8881bec42"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("e274f8f8-ca75-86a3-414f-445cd771ec5a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("3d20d497-e28b-9bf9-50ef-a1ada29935b4"), new Guid("1a359556-069b-5568-517a-710c78025668"), null, 1 },
                    { new Guid("e2d3a05a-6776-668a-949d-4771233d2933"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("8a02f26f-7460-f446-a17a-cb3e6285d379"), null, 1 },
                    { new Guid("e36c8245-5ef4-670c-dd9c-193e5f29ae30"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), null, 1 },
                    { new Guid("e3ec95d2-fae3-d7c7-d779-5a9be00d73f2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("8e9a8636-2aa7-f382-fde8-4b0058baa307"), null, 1 },
                    { new Guid("e3f86d8c-e07d-929e-9f93-2858a7d0377b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("e46c1180-6565-1190-6063-a405a3675ffd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), null, 1 },
                    { new Guid("e48bbd8d-7cc9-1dfc-69f1-bb5b5c2db393"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("e26af581-a307-433e-8564-933baef1ba05"), null, 1 },
                    { new Guid("e4da7b1a-eb5c-c800-d601-3741dda33f54"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("e5092810-9304-a9f8-1ee9-452ad9fabab8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("eb6942c9-047c-919f-8976-7d159175d3c2"), null, 1 },
                    { new Guid("e51df367-dbc2-6868-eb41-d99e337d9f57"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("e585c6e1-170f-13d6-1614-e7ffa898fb67"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("e58f14f4-982d-6e07-f37e-d5c693559c9f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("e5a76bb2-3fad-0934-6682-28540b97583d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("b65964ab-6e0e-7c23-6be6-73530b58a023"), null, 1 },
                    { new Guid("e5e5210e-14a7-85d1-34d7-6fac444a8f06"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("e5fc9335-6719-fed5-64ad-b7fdb2f6ed9f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("dfc12039-de4c-b79b-f5c3-a4d0b4ffa969"), null, 1 },
                    { new Guid("e60eff1e-8ee1-5495-baf9-22c94f29905c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("a03f1a9b-7a15-c7ca-7f5d-8e87ac794c67"), null, 1 },
                    { new Guid("e6230e32-53b3-fce6-17e3-043fa24a9d19"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("e67101ea-cfa4-8abb-784f-e87f529d2c63"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("d0c0e0c5-7480-9f03-07c6-750786cdf649"), null, 1 },
                    { new Guid("e6ce2b2a-ce1e-2ef7-a554-c342ab9bace5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("dfb59c7b-8c5a-29f3-37bc-b6000e5f6a46"), null, 1 },
                    { new Guid("e6d82a08-6ea1-6a94-f7ef-c18137b630c8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("0f6e52a5-4360-6154-c524-0adcdcd673b2"), new Guid("387233c8-0a58-19b6-7800-53621c965341"), null, 1 },
                    { new Guid("e6e634df-f777-8353-8fc6-66f897825f7c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("e6feef65-72f9-28e1-5e1a-dff2cdd945c1"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("e76d9553-d25a-2397-ae8d-13e7f64832e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("ebf7a508-68ab-e709-27fb-61885adb0de1"), null, 1 },
                    { new Guid("e78af79b-226e-80ce-3913-b4864ec2620e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("e7995380-f264-c7ed-45c6-a6c28ebc90ca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("e846cc59-3d0d-7d5e-bb4d-2923a107d8a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("4acfce2b-8898-fce4-8a1e-4cad99b6f72a"), null, 1 },
                    { new Guid("e84af560-974a-2164-f6b0-ee29e1f9f389"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("3083c108-41b0-aecf-5ff5-3e97d2056deb"), null, 1 },
                    { new Guid("e8c67dc5-6817-f985-c298-5f8117e64de5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("e916d05e-60c1-19ae-5993-349137e55bfb"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("e923b3eb-5afd-4346-2a7d-76ba738c3a15"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("dde579cc-607d-888f-f0aa-cc14cd739478"), null, 1 },
                    { new Guid("e977168f-d562-7f63-7e92-d610103af1b8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("729f57fb-657e-45c7-20ce-78bcb7bb85c3"), null, 1 },
                    { new Guid("e977476a-1424-004f-83b7-40120dfc91dc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("760a27e6-730a-7cbc-14d0-de48f75ee7bf"), null, 1 },
                    { new Guid("e98b112f-f671-06b4-dc51-e406db359781"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("0462a3bc-a438-2fef-b18c-be23febc6bc3"), null, 1 },
                    { new Guid("e996131c-a071-8dec-8703-69ae2aa3d156"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("9bdbad19-cd0b-861b-4c0a-3f954fc9b545"), new Guid("7f44fc84-a197-c869-7b9d-2932b43a15be"), null, 1 },
                    { new Guid("e9ced1be-f0fe-9338-7145-66e09c9ccee8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("a0e5fce8-482c-5d95-cedb-307a0dd78ea3"), null, 1 },
                    { new Guid("ea7875cf-5be0-cb39-8eb4-78fc55255850"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("ea9bfae4-6b03-22f5-4a54-1b47c4f4b006"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("b7bf1991-b276-c27f-4244-99f3a2826703"), null, 1 },
                    { new Guid("eb373da5-10f9-6a78-823b-4d03e5faa801"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("c6c8891e-b03b-0536-1228-8a567b18fd26"), null, 1 },
                    { new Guid("ec0376e6-6833-e10e-51d4-4a0aa75803ad"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("ecc592c8-7d07-9e88-a0b0-1bd93833ad5b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("99de9f4d-9b3d-4995-7ef9-9f83518c232a"), null, 1 },
                    { new Guid("ecd1c995-db66-6176-fe20-661ddb737455"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("ed2fb216-4a6e-b66c-f6f0-8ac0125750a2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("ed591bc4-cef8-e3c3-45fc-b450a6699670"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("47ecdf57-58f5-7fa5-f77b-943dfe59a4bc"), null, 1 },
                    { new Guid("edaf44c7-d8c4-08e7-7032-766b825724ce"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("ea584309-02cb-b614-6a86-885e37d3e431"), null, 1 },
                    { new Guid("ee10bc37-f228-2e3a-c204-38c5e9c822c8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("28d60d93-b395-168f-48b6-bbfc748ef89d"), null, 1 },
                    { new Guid("ee6757ba-a7cf-3a96-6a3a-4e07e032f4ae"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("ee80d3d6-84c0-ab60-5ce9-65f697b0d51b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("9adcec4b-5181-193d-521b-652c687003e1"), null, 1 },
                    { new Guid("ef631113-b5e0-05cb-f870-771693ea661e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("3951dc3c-3a60-e9f5-ec9d-a5e9afbf4c34"), null, 1 },
                    { new Guid("ef8d60cf-2177-cbeb-c9ea-92414a145ade"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("c692c04b-2cb7-31d9-07df-85cf4506fb5d"), null, 1 },
                    { new Guid("efcf2848-1379-724e-b112-0b480f6821a5"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("efe06cd8-c224-438e-b404-8251ffbfac86"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("44b24a70-0ed5-f371-7c10-cf3eb35e8ea8"), null, 1 },
                    { new Guid("f02d62a8-56d7-fefa-7c6a-c4073cbfee30"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4a8a1c92-da7f-6fed-fb31-b978cc7ba6f8"), new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), null, 1 },
                    { new Guid("f0307a7b-7619-c05a-fa2f-67c709b95bd3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("44aa9eb3-779d-d3c8-89fc-eb0f48626cf6"), null, 1 },
                    { new Guid("f0586f55-f736-36dc-ef57-dd5fcdac22f8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aea127f1-3999-e38c-4497-7fef3b9fed45"), new Guid("e04a36ca-1175-98c5-8c0b-b58598bf24d3"), null, 1 },
                    { new Guid("f0832de0-a5bd-bb44-b631-972205d1e6c3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("f0b2e035-56ee-7325-f11e-1d326e76514e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("f0d71eb4-813b-4c2b-dd13-7168f65c696b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("e2e3837d-5896-23a9-843e-4d6d9d838085"), null, 1 },
                    { new Guid("f0f4c406-7a65-7a70-a13f-638b8602c11b"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("4aefafa5-6d45-af90-d90e-0a7d1a6f2eaf"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("f135c2ae-2b13-10e4-29eb-9bb38bc3a4df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("d16fe8db-fceb-e90c-3700-5257f0e18dfd"), null, 1 },
                    { new Guid("f14c721b-0c63-feba-584b-b26ac6d3a39c"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("95d883f7-5195-a301-9624-271a3e211f0a"), null, 1 },
                    { new Guid("f1bcf24f-a4d9-e7bd-c5ac-daed05a0c6dc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("f20b2e99-1caf-f99a-b892-9b88dd6be66a"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("a033a342-78af-0366-033e-23bb97e86d8f"), null, 1 },
                    { new Guid("f23a8614-83c4-8cf4-0753-36fd24cb9690"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("74708664-794d-9dea-796f-719c7b164797"), new Guid("c164b597-1578-9c79-4d5a-0b8586c242f1"), null, 1 },
                    { new Guid("f27ed04d-d980-ed50-8f85-5d0610244fdd"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("78c15be1-bc5a-e3b6-aced-ec1765b3749d"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("f2e4e417-2e73-5e49-200c-a9bf947c1366"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("40e47826-46c6-dfeb-7956-228afe66dffc"), null, 1 },
                    { new Guid("f31feb01-4458-3605-11b3-bb96fe405559"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("f661de3b-e440-de57-dce4-74eeb3ac04d7"), null, 1 },
                    { new Guid("f336c45d-b63d-cd86-bb8e-6be54cb475be"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("761f5fa8-3724-e180-22d3-063f163d67d3"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("f34f55eb-d2be-9bac-632f-0840db7972bc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("1b90fd9a-100f-ad31-1829-bc28efd9f540"), null, 1 },
                    { new Guid("f39aee80-8d63-eb27-5496-394620fdfdca"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("00b8eba4-4472-44ae-fa26-7f658acbfaea"), null, 1 },
                    { new Guid("f3c1e13a-e8db-adfd-4a4e-83f7937a9759"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2efab749-d4d6-fed7-fe2d-edcdeec438f0"), new Guid("7071bf9e-3c85-d8e1-ecae-283165d3aa4a"), null, 1 },
                    { new Guid("f3d7318c-2247-c889-410d-180f6a1fc934"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("f418a32d-2f63-5754-78db-0ee752167d55"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("8790e90f-1186-9cba-1dc7-10948ca75b31"), null, 1 },
                    { new Guid("f42bcbdf-1a73-44de-7418-0ac330721676"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("08bf7b1f-191f-a592-d43b-08b57050286f"), null, 1 },
                    { new Guid("f44fc78c-eab3-a895-c872-90094034e81d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("b12dc428-e762-37da-5d9a-97184cf016a0"), null, 1 },
                    { new Guid("f4546253-938e-b088-9aa0-cd3821c77715"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("f47e3113-66e6-e885-dd84-b9f65addf999"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("233497f8-66d3-f8c7-3e45-cade541d613e"), new Guid("6981d0b3-5409-9722-a1ec-4cfe3dc76bfb"), null, 1 },
                    { new Guid("f4ac750f-ea62-512b-b35a-82efaa7463ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("763a3af6-4649-a154-723b-605e3f0c5b45"), null, 1 },
                    { new Guid("f53b849f-ac17-c90b-0d40-d5270d5d4428"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("a2e8742d-0fcf-7662-ee2f-71acbeea139e"), null, 1 },
                    { new Guid("f56d2970-b597-644f-2a75-7ea61d2d03b8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("4dde9c16-851d-98f4-182c-195cb6233520"), null, 1 },
                    { new Guid("f5a51bd5-2950-1f11-c641-6665652204ef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("15c35f60-e441-d1a1-adaa-e02759694488"), null, 1 },
                    { new Guid("f62dbfdc-d256-d63a-5b66-03f14c9440e8"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("fc08ede4-ed91-beed-a2cb-90c511feb49d"), null, 1 },
                    { new Guid("f687f4e9-1f1e-ae5b-83a1-72f408143efe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("4f17e121-eb38-4a22-ea3b-d72bd211d529"), null, 1 },
                    { new Guid("f6ef4cdd-c7dd-914e-08d7-cee47f917469"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("82e083be-339a-2f6c-51b8-3c03ac7d28e0"), new Guid("78b7c3f6-8062-e48d-231b-61a8b9def07f"), null, 1 },
                    { new Guid("f6f20440-b034-2f64-664d-86897a69ddf2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("b7cac5df-bce8-f552-886b-8319c75c0103"), null, 1 },
                    { new Guid("f70e9564-66aa-6919-b74e-82e53ce5374f"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("8c60f436-be96-1642-5ddc-bc2ed254502c"), new Guid("a4ca7f90-ef6d-8d86-aff9-e0661e946004"), null, 1 },
                    { new Guid("f70f41e4-124f-1b58-b57d-c2fb14c44d29"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("1c92e394-c09b-3566-0cad-be123fa6dc4b"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), null, 1 },
                    { new Guid("f755eb07-4778-238b-a610-d06fa5b5cca4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("68bc0c5b-6b33-ee6e-4e96-8eb50f3cd8ae"), new Guid("92a91336-5ca3-a674-8a59-31ab6f0bbac2"), null, 1 },
                    { new Guid("f77da6e2-2b09-d0a3-8567-f5d7bf82f796"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("7a3394c9-d9c5-6624-546f-f7975a574241"), null, 1 },
                    { new Guid("f79bf63e-8f22-fb98-d706-438379cd0991"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("a3c91e74-ec88-d1b9-c70b-91b0aba3e89c"), null, 1 },
                    { new Guid("f823655f-d6d3-9098-841b-e672bd3256ac"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("77235293-bbbc-a110-3a8b-a4493005367a"), null, 1 },
                    { new Guid("f8392973-8acb-8263-3e21-accbd77baf96"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("38ab23f7-f606-67da-ffb9-af7e5872b7b8"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("f893c83f-109e-55b9-a5e4-b0304646bae6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("fb6d743f-dd05-dac8-1cfd-d0d06d1ad727"), null, 1 },
                    { new Guid("f8b5624e-3b01-c989-f823-b2fa47a3b042"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("b989aeb1-636d-cc0f-9372-3e207a773c46"), null, 1 },
                    { new Guid("f8cf8bee-b271-b748-83eb-eac0ddac7941"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c0811b33-fdc0-189d-b103-2bb15a39b358"), new Guid("81cba0fb-da60-2444-d3b6-bef9c6600721"), null, 1 },
                    { new Guid("f90b1f1a-d3e4-7e2b-b0e9-2f8a490d4fef"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("e4b1e0d5-fd23-8951-3e07-518b8d557c49"), null, 1 },
                    { new Guid("f9359ddf-7f21-418d-7153-b3e2528827ab"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("cefcd5a9-e2c9-5e0b-662f-dfc8fa824e4e"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("f9825ea4-4f78-ea8b-b610-68d3af7257a7"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("2de1483b-c90b-c41d-e412-3a0ded5ea041"), null, 1 },
                    { new Guid("f9bc82b3-e6d9-9756-1c72-083d9dd2e120"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("a9d81d48-0ee9-04a0-26ce-5ccf128f79d0"), null, 1 },
                    { new Guid("f9f73187-a3a4-4c08-d1d1-b4d74d569044"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("64bda367-a4fa-018a-56ea-40a5e421e0e9"), new Guid("a4a84dbb-ea54-9677-1d4c-25a90d6514cd"), null, 1 },
                    { new Guid("fa7f4a1a-734a-5c68-de79-d9f1d3b2f5a4"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("dc23dfe1-8a66-ea6f-d8bd-e3b417941cf3"), null, 1 },
                    { new Guid("fa9267bf-bbb4-88a9-a96a-9795f0f84b0e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("838592d3-21a2-88cc-3950-5f9f65b8f433"), null, 1 },
                    { new Guid("fac4cee2-1a78-0c60-85b4-35f7674de239"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("1d7dd614-935a-8214-9fc4-2bd5da8d9973"), null, 1 },
                    { new Guid("faf51e43-05d5-9c39-a510-9bff61ac9e88"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("74ad031e-873c-c282-ddeb-ffdfe3d3753f"), null, 1 },
                    { new Guid("fb65ed14-3bb2-1a94-6b7f-e85c323d4ce6"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2913c2-898a-1b47-b30e-b566c9fd5be9"), new Guid("a4fa1b07-06bb-3dc8-06ba-b250f2a4f729"), null, 1 },
                    { new Guid("fb83c792-2180-e28b-e75c-f9bf0f1ee365"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("fc834e4e-732d-7efd-286c-0c410e86acfe"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("51b1dec4-9517-7f2e-a4ac-c5a30c681db2"), new Guid("1beba319-2062-4991-b344-986056beab22"), null, 1 },
                    { new Guid("fc9f96ea-ef30-3306-0cfc-faf2eb26e8f2"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("842e30be-4fda-2d6b-083c-affe9f508f56"), new Guid("589fa795-bd72-0063-4b9b-98261865991a"), null, 1 },
                    { new Guid("fdbeffda-8592-0774-17bb-30f88b5af4d3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("2dd76916-aed5-0935-52f5-bd62b0be2147"), null, 1 },
                    { new Guid("fdddbfd2-5c61-3d18-df2f-38e30db7b901"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("2021c9ce-87bc-403f-1cf3-66235c705332"), new Guid("36ece74e-5125-517e-2ae7-aaae96008755"), null, 1 },
                    { new Guid("fdef18f4-57f5-9d82-d1c0-69dc1a23ae98"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("d9cfc07d-88cf-0971-fb87-25285fb8085d"), null, 1 },
                    { new Guid("fe3b4a2d-5d10-5771-b8cc-574da0ed181e"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c359e65e-aa2e-c495-5844-88b9c892d180"), new Guid("6edf1082-87b4-58db-6714-99fa676b67b2"), null, 1 },
                    { new Guid("fe54dff8-89d9-ca4a-fe63-34649eb0771d"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("aa2ad24a-67b3-a77d-78e6-04d983abfbc9"), new Guid("18548253-e7e5-4de4-faf6-42ab5581d5c7"), null, 1 },
                    { new Guid("fea30ddf-069b-00e2-7ae4-fc3b434db045"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("48598452-73dc-3333-521a-0ed1d63ffb00"), new Guid("d57d6dff-53f9-1de5-52af-b873dcb90a20"), null, 1 },
                    { new Guid("feb1ed39-ee05-7766-97fd-89b4d1d51a37"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("20b6db26-5133-0f33-0494-3e66f619f57b"), new Guid("8f807b28-3007-c7e6-528c-689605b856c6"), null, 1 },
                    { new Guid("feb6ca0b-91b6-112d-9951-f49878aa07ed"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("61bbb38e-2635-d349-ddb6-f707ecb342bf"), new Guid("af64b458-a554-a29d-29c2-654c623332db"), null, 1 },
                    { new Guid("feca020d-30af-a284-fe88-9d8f0b05d8b3"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("298d93b1-8f50-cb64-aeef-51ec555aa5fd"), new Guid("3821c474-ad90-1b5f-fd01-ab0112963f48"), null, 1 },
                    { new Guid("fed32464-cf39-0736-4507-e3d114675149"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("c6530778-fca9-7393-4c26-2a07690b7521"), new Guid("d66fcb3b-3ffe-ee06-9294-e7a74bfeefc5"), null, 1 },
                    { new Guid("fefae740-6fdd-f3f7-cdca-614815159857"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("50d2740f-8e37-04d5-e50f-02209de8be03"), new Guid("b60d8437-c111-fd68-1bd9-18804d78ed8f"), null, 1 },
                    { new Guid("ff358283-8bb0-c790-0c4e-496363d0b3df"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("f7aa34e9-0125-90f5-ace5-a3bf9198dbd4"), new Guid("838f56ea-2c61-d464-455d-e57e784bc4c8"), null, 1 },
                    { new Guid("ffff467b-8f8c-4959-f4f2-19d7b16f79dc"), "SEED", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, new Guid("fa217c06-74f3-bc47-2794-15609b7e92f0"), new Guid("73d0a7de-bb3f-af32-53ca-0d6e22526683"), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("0376b567-d94d-4839-9a16-ee56eb88b536"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2891), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("069573fa-9ac7-4ae8-9c03-2442302bddfe"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3004), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("06e098c0-6b97-4aa0-9be9-a1bde4bed344"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2880), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("0e77a8bc-4c05-4cd6-bd6c-ec4b91f8be4b"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2975), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("120dcd22-a9fc-462f-a0b7-716e0592f14e"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2888), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("13638e3e-1303-4408-9dcd-194df15305cd"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2955), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("13994034-ffcb-4971-8c72-002d73bdca75"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2923), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("252bf318-e8aa-4ef7-8be6-09ae85c3360d"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2867), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("29e75404-f34f-4cbf-8ea1-f3dd19ab1441"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2929), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("302d4a9a-d29d-43d0-a508-dd6c52f7953a"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2870), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("30667ead-379f-4183-943d-686dd84bda31"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2941), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("329bd2f4-4877-44a6-8afc-da64dbc81970"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2893), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("35a709f5-15d3-43aa-9851-9a0fcdf7aefa"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2861), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("3ce39f99-2011-40f7-9cb9-500fbd2854dc"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2878), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("40ea6a02-d3f1-4a28-b9a0-a112616bf5ad"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2883), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("430679f2-9b23-4879-ab50-efcb24fcb807"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3021), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("460f3157-eed4-457d-84aa-d324ba5df812"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3016), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("4d1c6b6f-6aab-41b6-95f1-74bd42a34ba5"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3010), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("5550b15b-0956-4a95-8600-10af2f56e0a9"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2885), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("588b2147-ccc2-4b0b-917a-c803b376fcac"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2935), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("5cf1e139-5a2f-44da-86cc-f4189599a750"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2959), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("6509eac5-2d16-484b-bc7f-d10a526fffca"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2945), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("65c22627-f30a-4214-9f8f-96a3c0e14203"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3019), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("7375bb97-dfc6-413c-962c-95e2c222917a"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2957), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("744fc379-8ef3-4709-8d20-e50539630acf"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2919), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("7ebddf6f-d705-40c7-a58c-e613b13e33a1"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2903), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("7fa36aed-8176-4ae4-a2fa-9dea4e8bba2d"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2917), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("80cd8bad-6731-40fb-b18e-bdb255032d92"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2912), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("8372c9ca-2c28-4779-b068-ce212ada32b3"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2969), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("861475f9-c12f-48b1-ac47-94a14fd2471b"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2927), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("902bd844-6d2f-49fc-90ad-1f3575e72a55"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2972), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("9b4c65ab-7e4f-4468-ae3d-0d1194f0721d"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2964), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("a05abdab-4a38-4688-8d17-4dfdf4be24d4"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2810), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("a0a7cba2-d3fc-4c86-a8bf-013fd0b0f993"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2907), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("a3ee5d77-10a3-460e-8190-c25ebe5887f2"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2925), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("a68386d7-ff97-4864-8659-74a6b2ff71bc"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2905), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("a7867c85-2efb-4c7b-97c4-f2e51141724d"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3006), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("aea2166c-c236-46a4-be6b-0c35043e9c73"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2865), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("b0e25954-8a94-4c2d-ac3e-8c0f929a79f2"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2961), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("b4348463-c00c-4b1d-aac4-177d8a3df1e7"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2952), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("b5c19bf0-d9cf-431e-bd75-57406cc95dcf"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2814), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("bf7ea422-ecae-41ae-8aef-d7e97e1db832"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2822), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("cc3d7161-729a-44b1-9e4c-f00ccf2b6fba"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2828), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("ce7bda3e-5ef3-40ca-92c6-53707917e9e7"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2900), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("d07422d8-bdd8-4f87-9cd8-1534b85b49a3"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2915), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("d7fd9d9c-aa77-480a-bcef-2ff587cd0c6e"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2897), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("d9695d09-2318-4301-a467-dd5c14908173"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(3014), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("e2741dbe-0ca7-4572-87d0-f675a4af2d49"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2967), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("e5aa2393-9644-4686-b12a-63c19081a5ba"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2873), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("ed0fb011-da1d-4a36-b6f9-f80e92c06df9"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2825), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("ed101b99-e3ce-4381-985c-ec0137479c53"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2949), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("ed30dee4-264e-4893-bb7a-143cb249aa1c"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2947), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("f20de7ed-8bdf-4a90-8845-f50e5cd47606"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2937), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("f587cce5-5fcc-43a9-b6c7-9a05250e2ce5"), "SeedData", new DateTime(2026, 2, 9, 15, 28, 26, 505, DateTimeKind.Utc).AddTicks(2933), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 }
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
