using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class saseeddd : Migration
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
                name: "StockCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCode8 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Prefix4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Serial4 = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Fluids",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), "H", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CNG", 0 },
                    { new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), "C", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LOX", 0 },
                    { new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), "D", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LIN", 0 },
                    { new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), "B", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LNG", 0 },
                    { new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), "F", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "FUEL", 0 },
                    { new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), "G", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "GOX", 0 },
                    { new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), "E", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CO2", 0 },
                    { new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), "A", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "LPG", 0 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "Group", "MaterialNumber", "ModifiedBy", "ModifiedDate", "Name", "Notes", "Standard", "Status" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9389), null, null, 7850.0, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0 });

            migrationBuilder.InsertData(
                table: "SProductGroups",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), "G", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pim, Gresörlük, Gupilya", 0 },
                    { new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), "E", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Elektrik Malzemeleri", 0 },
                    { new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), "B", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Somunlar", 0 },
                    { new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), "A", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Cıvatalar, Perçinler", 0 },
                    { new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), "D", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Rekorlar ve Dirsekler", 0 },
                    { new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), "C", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Pul ve Rondelalar", 0 },
                    { new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), "H", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Hortumlar, Kelepçeler, Klipsler", 0 },
                    { new Guid("e36337f1-7967-db93-2e0d-242546697931"), "F", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Aksesuarlar (Vana, Termometre vs.)", 0 },
                    { new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), "Z", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Gruplanmamış Standart Parçalar", 0 }
                });

            migrationBuilder.InsertData(
                table: "StockSequences",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "LastNumber", "ModifiedBy", "ModifiedDate", "Prefix4", "StartNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("01016317-a4e0-e483-e2a4-2ceb7fa8f1ac"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA3", 1000, 0 },
                    { new Guid("026ff68f-8b91-d336-7bd8-408e2eac676e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB4", 1000, 0 },
                    { new Guid("033cd817-2d1c-02c3-eb9e-33449dadc1ec"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA7", 1000, 0 },
                    { new Guid("047c2958-e3b2-8809-efa0-c833c3fb3cfb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE0", 1000, 0 },
                    { new Guid("04b46eea-2124-7e22-841f-18923c928c0f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE0", 1000, 0 },
                    { new Guid("07618501-16f5-3853-6df1-bc7f5150766b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA2", 1000, 0 },
                    { new Guid("07c30f21-da46-546e-493c-fe6f567c4561"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB9", 1000, 0 },
                    { new Guid("0850a96e-4557-b6d5-26a6-3ba4eb76ef05"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB1", 1000, 0 },
                    { new Guid("0a9c14fe-fc4b-f925-0453-bd51b98b681b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA4", 1000, 0 },
                    { new Guid("0b9e68d8-e8bb-7345-f141-92c305e1e816"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC6", 1000, 0 },
                    { new Guid("0bbca75c-b6b1-5f3f-2126-ae11325aa6ae"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA3", 1000, 0 },
                    { new Guid("0e152dff-4c00-8e5c-a4d2-55b54960206f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA2", 1000, 0 },
                    { new Guid("0ffce261-8b1e-1783-3131-fc6880ea7360"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB3", 1000, 0 },
                    { new Guid("108b32b0-7276-cbfe-b980-e3a8a9b3100e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA6", 1000, 0 },
                    { new Guid("1401adb3-3e29-b8ac-2941-b2bbcc2f8668"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB8", 1000, 0 },
                    { new Guid("14f0c4bc-b7c8-c675-613f-602b7a2884bb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA1", 1000, 0 },
                    { new Guid("15c7507a-9f9b-20fd-6ec0-e39cacc0e59e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE5", 1000, 0 },
                    { new Guid("16359c70-042f-9e42-85a9-0c4aa4c56d21"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC7", 1000, 0 },
                    { new Guid("1651d064-8636-6a2e-fe51-2b568d92c9b0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA8", 1000, 0 },
                    { new Guid("168a8095-3cc6-c69c-a0bd-ebb53caeafa7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB0", 1000, 0 },
                    { new Guid("1692528e-624a-89c7-65a3-be284d6a673d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA0", 1000, 0 },
                    { new Guid("16ac98eb-93a8-e0e4-4a85-9ea02377c18f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG0", 1000, 0 },
                    { new Guid("1834f459-e64d-e88d-fc90-59f2dd1d98cd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG1", 1000, 0 },
                    { new Guid("1a92d47f-f539-6409-17bc-7aad707b6c20"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHC1", 1000, 0 },
                    { new Guid("1ab1da7d-715c-a5ce-5787-526010badd51"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB3", 1000, 0 },
                    { new Guid("1ba6f76b-7ab3-4c0b-f750-eb707113adad"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA4", 1000, 0 },
                    { new Guid("1c313c8d-33d3-f18c-5bfa-114bcb62a55e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA0", 1000, 0 },
                    { new Guid("1e7f8749-39bf-9828-b6c8-f0b4885201a0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC0", 1000, 0 },
                    { new Guid("1eeb6a1f-931a-e0a5-f4a6-f8ad3580a219"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE3", 1000, 0 },
                    { new Guid("2049c50b-fb75-3712-5acc-a7b44705ff62"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF3", 1000, 0 },
                    { new Guid("24647e99-46dc-6a79-e589-0bd97659aea4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA5", 1000, 0 },
                    { new Guid("257bd970-05c4-751f-8180-fdb0233d77e1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA5", 1000, 0 },
                    { new Guid("25bed300-11ac-8798-e35b-99ff8a9cc130"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB4", 1000, 0 },
                    { new Guid("27a4669d-51b4-6aff-3f89-8afe3021291d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC3", 1000, 0 },
                    { new Guid("2947ec74-c544-cbb4-dc6f-ab077e6c9b1e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA1", 1000, 0 },
                    { new Guid("2a7e5b70-d953-e686-4d16-b8dbdec08c3e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC4", 1000, 0 },
                    { new Guid("2a99ea51-9817-8290-2567-2212bc022ff3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA0", 1000, 0 },
                    { new Guid("2ad12443-bc53-c844-eb53-2434f761a351"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA6", 1000, 0 },
                    { new Guid("2ad2b3c7-d999-080b-c743-e66c58458a46"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB9", 1000, 0 },
                    { new Guid("2b2074cd-dbd0-5f20-c6bb-fa36013ee4cd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE1", 1000, 0 },
                    { new Guid("2b42df79-8ebd-4d8f-a582-b09b22da3451"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA3", 1000, 0 },
                    { new Guid("2bae01fc-51b6-e4a0-1e1e-1e2d7632ca52"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAD0", 1000, 0 },
                    { new Guid("2f6dfa2b-8f7f-7e4e-b0d6-8fd5c39cc3b8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBD0", 1000, 0 },
                    { new Guid("2fbf1894-a8ae-2edb-5a77-4c2fd63e25aa"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA1", 1000, 0 },
                    { new Guid("302ac8ae-1132-043b-fd25-5fc33b8f71b0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC2", 1000, 0 },
                    { new Guid("33aac10b-421b-4644-58ab-a0b2207dd006"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA4", 1000, 0 },
                    { new Guid("34d9cc2d-feec-edfe-3a15-296f01769dd9"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB9", 1000, 0 },
                    { new Guid("35dc9616-c0b6-f384-0da8-c20f8a866ce9"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF7", 1000, 0 },
                    { new Guid("3673972d-0beb-5ae6-2109-c3e0606f0d61"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA7", 1000, 0 },
                    { new Guid("381a7564-293f-e5fe-86d0-a70c17983bce"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF1", 1000, 0 },
                    { new Guid("38cb1d14-d4d0-c02e-3f17-14797270a8ba"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA8", 1000, 0 },
                    { new Guid("3bb55cc5-fe82-75ca-abec-b0798d295939"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB0", 1000, 0 },
                    { new Guid("4084f42b-47ee-5e7a-bcd9-00ec7e7458eb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC3", 1000, 0 },
                    { new Guid("40933366-a230-60ef-ed1b-8dfe6bb95cdc"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA4", 1000, 0 },
                    { new Guid("41a4f38a-3c2e-f05a-304a-0fc3b14e2b09"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA1", 1000, 0 },
                    { new Guid("42053fca-9c80-ed5c-a554-b4cd8b778a8b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE4", 1000, 0 },
                    { new Guid("4382d52a-173e-a191-81c2-5ced16b2407c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBC0", 1000, 0 },
                    { new Guid("446aed7c-61ff-62f6-f34a-90f3471964e6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA7", 1000, 0 },
                    { new Guid("450d5b11-4a42-d898-63dd-7ae0227b29e9"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA8", 1000, 0 },
                    { new Guid("47c38e85-b440-3303-fa91-a4e54b16722b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG6", 1000, 0 },
                    { new Guid("481b5bab-8979-baa5-32f3-e3fdb0ba44b5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFH1", 1000, 0 },
                    { new Guid("49d63223-95aa-dbc2-6c4a-94658a969eb1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC0", 1000, 0 },
                    { new Guid("4aa75aba-ea91-14ea-2139-5992dbc367e4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA4", 1000, 0 },
                    { new Guid("4c2d1dae-aea9-f36f-01df-0c3d29e18136"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB2", 1000, 0 },
                    { new Guid("4d366856-c4f4-5783-32da-bba6ec7a0981"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC8", 1000, 0 },
                    { new Guid("4f5e667b-07e6-cdeb-0de4-a936f2b00e79"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG4", 1000, 0 },
                    { new Guid("4f695a4c-db8f-56ed-8b48-b04a04138844"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE2", 1000, 0 },
                    { new Guid("512d794b-1e3a-3ac4-f6fb-572a68e073a2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA6", 1000, 0 },
                    { new Guid("516d4a63-72bd-bc79-a964-b5695fc5c16a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE4", 1000, 0 },
                    { new Guid("52ff9dec-e03a-7b3a-5ccb-5bedd50678e2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAD1", 1000, 0 },
                    { new Guid("54b68a8c-52a8-a0b8-6e9f-9474d6c9f338"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF6", 1000, 0 },
                    { new Guid("568dc66c-34cf-ad28-fd92-06eea4de1ef2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA5", 1000, 0 },
                    { new Guid("58524f7a-45e8-8bcc-4ce3-9dda977200ec"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA5", 1000, 0 },
                    { new Guid("5894bd46-0272-1c11-5340-4f3b8a4808f4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB8", 1000, 0 },
                    { new Guid("5971ee4a-2baa-aa54-b533-d9fcec909249"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB1", 1000, 0 },
                    { new Guid("59fd2e1f-ef7d-895e-1b09-7550c7cdc02d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF3", 1000, 0 },
                    { new Guid("5c79bd1f-a61f-712a-2d8c-b25cff7d50b1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA5", 1000, 0 },
                    { new Guid("5d9179b2-b817-c059-2948-819f539dfcde"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA6", 1000, 0 },
                    { new Guid("5eaf082c-951d-02e1-1106-d96879ff7e21"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF8", 1000, 0 },
                    { new Guid("5fc1f762-9b00-aa70-021e-200ecfb9362d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBD1", 1000, 0 },
                    { new Guid("62a3a33d-bcfd-d26d-3370-e5aa4f1a874d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA0", 1000, 0 },
                    { new Guid("63e2f7ac-2277-8a35-ef30-859b79381d74"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB7", 1000, 0 },
                    { new Guid("63efac71-abd9-09e3-ba04-9bb3aab352f5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF2", 1000, 0 },
                    { new Guid("6588efc8-40c2-3c85-c069-3e8a2d2400a1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA6", 1000, 0 },
                    { new Guid("661ec3a1-aab2-c08d-222a-4f7661c9ec76"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC1", 1000, 0 },
                    { new Guid("66b0ce40-3eae-dbdb-9fbb-32c0e7d2fe1b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD1", 1000, 0 },
                    { new Guid("67da5134-fb6a-97d5-b623-2c752cd8cf9a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB2", 1000, 0 },
                    { new Guid("6bf7293e-6d93-57ee-6baf-a4fc88ae187c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA7", 1000, 0 },
                    { new Guid("6c4fc270-699a-a103-6678-9771a29672ff"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB3", 1000, 0 },
                    { new Guid("6ce5b980-58dd-4d23-97e3-89a49788f264"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD4", 1000, 0 },
                    { new Guid("6e9184c7-db20-fb4b-1fb6-0c494b13a7f2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB6", 1000, 0 },
                    { new Guid("6f1467f9-f6b0-d017-184c-f1ba8bb8d23d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB1", 1000, 0 },
                    { new Guid("6f30aff2-10dc-778e-09ec-7a5f2ab1f752"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD2", 1000, 0 },
                    { new Guid("70e7b39b-5fb1-860d-1179-7941308024ed"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA3", 1000, 0 },
                    { new Guid("7291b6e6-bd74-ad49-5d47-1e634cd50c95"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC1", 1000, 0 },
                    { new Guid("73c7ab1a-023b-829b-3512-a7ae8cbc9a90"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC2", 1000, 0 },
                    { new Guid("74580410-8ef2-2bc3-0982-efcae6c1c6e7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA2", 1000, 0 },
                    { new Guid("75a71400-e49e-ebca-b206-b09024e3ee83"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF9", 1000, 0 },
                    { new Guid("76f609bb-e88f-ce9f-4012-4df1064e502d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA1", 1000, 0 },
                    { new Guid("78d46a40-0dc1-b48e-0fc3-ee5871cf71f1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF4", 1000, 0 },
                    { new Guid("7b28731a-c4c5-e59d-1e8a-825237ab36fc"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB7", 1000, 0 },
                    { new Guid("7c2b25b3-d160-7949-fd8c-a682e5fd3b0a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB5", 1000, 0 },
                    { new Guid("7c47ba34-0281-cbf8-d305-1f6431d2ff30"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF0", 1000, 0 },
                    { new Guid("83da4f95-2247-a1d3-484c-d11a7b55879b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC1", 1000, 0 },
                    { new Guid("85c836c6-9327-a681-34a2-a9cfe15298da"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB4", 1000, 0 },
                    { new Guid("88aab533-0b82-a2ea-7280-d2da776c6173"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA7", 1000, 0 },
                    { new Guid("88e424db-ad8c-5ced-1d8c-6951705b3039"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB7", 1000, 0 },
                    { new Guid("89c00860-6b37-aa9e-b1cf-cd7dca094cf7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA2", 1000, 0 },
                    { new Guid("8a052553-c2ed-9701-d346-5be964ff764c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA3", 1000, 0 },
                    { new Guid("8beffd20-396e-a055-d5a3-67f5469b4826"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA1", 1000, 0 },
                    { new Guid("8cb063c8-b5d7-1667-4b4e-6b0dc8bc8ed3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB3", 1000, 0 },
                    { new Guid("93047b51-4c62-fecb-0295-194fdbe9e9d7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBE1", 1000, 0 },
                    { new Guid("937b88be-cbbc-e1bf-ffa5-a04499d06579"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA3", 1000, 0 },
                    { new Guid("93a9c8f0-b4e2-2b7a-9899-d38aa4e97989"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE1", 1000, 0 },
                    { new Guid("954a9b87-1112-896e-2da5-1021dc3e92a5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB4", 1000, 0 },
                    { new Guid("98267808-32bb-684e-9e23-4e1af135b155"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA6", 1000, 0 },
                    { new Guid("987934f7-622e-9b77-1a7c-68187ac287b2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB0", 1000, 0 },
                    { new Guid("9bbfbde8-5399-b302-f435-90f865304bc6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB5", 1000, 0 },
                    { new Guid("9c066750-d0fa-909c-849b-1ccbabefc72d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG5", 1000, 0 },
                    { new Guid("9d2f0012-6fff-9f61-9baf-d132817a797a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA0", 1000, 0 },
                    { new Guid("9ea57885-a3d7-87e3-0188-e5721d680e38"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB5", 1000, 0 },
                    { new Guid("9f76636d-46fd-baed-ba76-d95b34fe2562"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA9", 1000, 0 },
                    { new Guid("a0a9d0b6-235f-ab93-8bd0-560fa3817283"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC0", 1000, 0 },
                    { new Guid("a12f6d5b-ef10-c238-78ed-9fcd906056c3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA6", 1000, 0 },
                    { new Guid("a1340f00-e620-466a-2dab-253915b62123"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE6", 1000, 0 },
                    { new Guid("a2eb0676-290d-f924-452e-d49d9a9b1006"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA2", 1000, 0 },
                    { new Guid("a4141846-5dc9-4824-baff-c9c87e444c1b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA9", 1000, 0 },
                    { new Guid("a61dbce8-c966-34d7-d1b2-5947ff8fdbf6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA4", 1000, 0 },
                    { new Guid("a6de6da8-154e-04f2-382c-28b6283900dc"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFH3", 1000, 0 },
                    { new Guid("a8a21162-31b8-7049-3bf3-811294d88422"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB2", 1000, 0 },
                    { new Guid("a91c7959-db11-10f5-bd76-0280bde2e27e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA8", 1000, 0 },
                    { new Guid("ac9ea1f0-238d-0be4-3b45-f4933a8d300c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBC1", 1000, 0 },
                    { new Guid("aea33ed8-d596-b8a9-849b-a932a322bc2e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SZA2", 1000, 0 },
                    { new Guid("b0a4edc9-f77a-2684-21a5-2067dc1a884e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDE2", 1000, 0 },
                    { new Guid("b4519f06-565e-4fbd-574c-b6a09e8aeecf"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA5", 1000, 0 },
                    { new Guid("b4658e35-5eff-673d-e715-3326439adb3d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SZA4", 1000, 0 },
                    { new Guid("b582257e-1b5c-5964-4631-20547ba44592"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD0", 1000, 0 },
                    { new Guid("b8a956d6-3815-42ef-c54c-3b71c39e66e1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF5", 1000, 0 },
                    { new Guid("bac90f00-80b6-2703-f447-e3819d07f044"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA2", 1000, 0 },
                    { new Guid("bc39e87b-0266-21fb-225d-1ca23f7b61a6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA2", 1000, 0 },
                    { new Guid("bce72a21-7ad0-6ce7-2456-83e896acd05d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA0", 1000, 0 },
                    { new Guid("bdb9c62b-87cb-5114-7749-ddb0729541c3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFH0", 1000, 0 },
                    { new Guid("bdd0c721-a225-bc8f-a811-0e3aeb17c79c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBC3", 1000, 0 },
                    { new Guid("be609388-2af8-5387-4c8c-9f4a750284df"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA8", 1000, 0 },
                    { new Guid("be8207cf-2545-1c28-b048-e21a3f19c5c7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBC2", 1000, 0 },
                    { new Guid("bf50ae35-7ae6-48ba-d91a-7a86c20da203"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA7", 1000, 0 },
                    { new Guid("bfd2f5af-07e7-a2da-f90d-81af14e90920"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC5", 1000, 0 },
                    { new Guid("c17016ba-69b6-f4fa-d6d8-cdd3efa9f740"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDD3", 1000, 0 },
                    { new Guid("c3e8d964-26f7-6389-bb31-f90716c8016a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDC4", 1000, 0 },
                    { new Guid("c57d23cc-6821-713c-ceda-84f56c6e9439"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC4", 1000, 0 },
                    { new Guid("c59277f4-d054-f341-14d3-d14cb1f79c60"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SZA0", 1000, 0 },
                    { new Guid("c8583115-6b55-731a-2b2a-2d0eb382fc06"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA2", 1000, 0 },
                    { new Guid("c8d3dc25-582a-4125-cc02-5de10f69a562"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SZA3", 1000, 0 },
                    { new Guid("c9072b3f-8f91-1fdc-c100-db4d882feec1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB6", 1000, 0 },
                    { new Guid("cac01515-f504-becb-0f75-7d183d246fd1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFA8", 1000, 0 },
                    { new Guid("ce52ef9f-93a9-c315-8020-beeb7c788166"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEB1", 1000, 0 },
                    { new Guid("d1199c79-94d8-1902-e0a5-d905dc8729c0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF1", 1000, 0 },
                    { new Guid("d2747ea3-4527-4dec-5d48-19f9cb86f4d5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAB6", 1000, 0 },
                    { new Guid("d2cbcf8c-1d36-0a28-5ac1-c985d79243d2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC6", 1000, 0 },
                    { new Guid("d4c3cb4b-f24f-120c-2af8-9d2723c44fa4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG2", 1000, 0 },
                    { new Guid("d63acd7f-1016-9dfa-bc31-b7f8e19ff3e1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAE3", 1000, 0 },
                    { new Guid("d685a442-7ad5-25fc-d906-d4432cb0cf6a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA0", 1000, 0 },
                    { new Guid("d98b8232-4691-7fbd-ff92-ff0789a26392"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB0", 1000, 0 },
                    { new Guid("da9e8ef3-83ad-985a-bf4a-0636c1d49e6b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA9", 1000, 0 },
                    { new Guid("db31f507-351c-ca53-2b55-b7dfca6b3a9a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFF4", 1000, 0 },
                    { new Guid("dbcd451e-e187-31f5-67a4-07a6b68d9770"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA0", 1000, 0 },
                    { new Guid("dc7fb47b-c77a-0242-3d4e-e78fc89b16e7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDB2", 1000, 0 },
                    { new Guid("dfebc11f-4b48-2226-5cbe-ee78206f7520"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC5", 1000, 0 },
                    { new Guid("e2bac1a2-c0d7-795d-f0fd-31837fbb6fab"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDA5", 1000, 0 },
                    { new Guid("e317c334-8932-667f-8f47-39c10efa0a5a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHC5", 1000, 0 },
                    { new Guid("e59c4f35-cac4-2ae4-aeb6-809d035489bd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFH2", 1000, 0 },
                    { new Guid("e699ca25-e08c-ecf0-5ee2-cfde3649093b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA7", 1000, 0 },
                    { new Guid("e82626da-cb3e-58c5-e940-95ddd2a8c5f0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBE0", 1000, 0 },
                    { new Guid("e925807e-38b2-20cc-2171-1aeb1c7a1624"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBA6", 1000, 0 },
                    { new Guid("e9b7da90-238b-0b70-cff5-3d4663ad8f55"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA9", 1000, 0 },
                    { new Guid("ea8443d3-005a-dd34-006d-26e743dc92d0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA5", 1000, 0 },
                    { new Guid("eea332da-4c6c-0e1d-cccf-608e79670f40"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SBB8", 1000, 0 },
                    { new Guid("ef4b768d-cf6e-6f2c-6ad7-5455d36a8b09"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SGA4", 1000, 0 },
                    { new Guid("f02185ee-de2e-1ea1-8d97-ce46ac24db9e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA1", 1000, 0 },
                    { new Guid("f0ac6813-aace-e0ac-64df-a64d6b73eb95"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFG3", 1000, 0 },
                    { new Guid("f1945380-4ca0-6571-e051-93eef64fbb5b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SZA1", 1000, 0 },
                    { new Guid("f2c1b37e-9021-99de-0ad7-5055a2a94734"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF2", 1000, 0 },
                    { new Guid("f4233558-4090-5239-b767-e190a532efac"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAC2", 1000, 0 },
                    { new Guid("f434663d-f33e-790d-a100-e3a0c9743891"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SHA1", 1000, 0 },
                    { new Guid("f58714c8-8314-a1c2-5363-ed189d83b7bf"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SEA3", 1000, 0 },
                    { new Guid("f628aa1d-3760-a37f-909a-9ebd0d83094a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SDF0", 1000, 0 },
                    { new Guid("f70dcab0-81cc-a0ce-374f-0111822d91db"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCE1", 1000, 0 },
                    { new Guid("f8347ba4-dede-4271-c5e0-f1d7dc323f83"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SCA3", 1000, 0 },
                    { new Guid("f9bac86b-1090-67e4-4ef8-af587ee5c44c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SFC3", 1000, 0 },
                    { new Guid("fb04a072-8da4-f2de-5089-00f2a9526cd0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, null, null, "SAA4", 1000, 0 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "Notes", "ProductStandard", "Status", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9420), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Standard plate form for P355NH", "EN 10028-3", 0, 250.0, 1.0, 1.5, null });

            migrationBuilder.InsertData(
                table: "SProducts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "PrefixIndex", "SProductGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("00f359f8-f909-6e41-8199-107dab592d28"), "SAB7", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("0409cab9-f4df-6455-3219-207ed5cb7500"), "SAA2", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 12.9", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("04bcf5e1-610b-3bd3-cdd1-5fecac31070b"), "SAA0", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("07296a28-d928-a2fe-8963-f1d197db6c8d"), "SAC2", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB TORNAVİDA YARIKLI 8.8", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("0a4eb10a-9be7-022c-0161-f447da601c0d"), "SAC5", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB SAC VİDASI/AKILLI VİDA CROM", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), "F9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("18544984-e22e-ba94-1793-bbdeb7077dc1"), "SAC3", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB YILDIZ KANALLI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("189f0a7e-f8cc-9eb9-9c97-5a2f896c8f11"), "SAA3", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("19de7aa0-f01e-7cc5-986f-0312e9725df0"), "SAE4", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN KROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("1c67a48e-5605-01b2-f7fa-c3c329dfb1fd"), "SAB4", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("1cbbe91b-83db-7235-f6c4-503acc567781"), "SAE8", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "U-BOLT", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), "F8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("2e77ec30-edf3-1106-6ad2-cbed09d21340"), "SAE2", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN CELIK", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("46039844-5ec8-f886-1122-e5cc57a251e2"), "SAB1", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB YILDIZ KANALLI 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("49664db8-c818-1487-a167-98cfbc0aa49a"), "SAB5", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("5136e62d-85ad-61d6-c6b1-7d7e40bbd264"), "SAA7", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 8.8", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("51fdf347-dc24-52f3-90ec-8f24ef4c6a61"), "SAE3", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN ALUMINYUM", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), "F5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("5e772c5b-1018-297d-f5e2-43b7b83f5a83"), "SAC6", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA KB (KELEBEK BASLI)", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), "F7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("6501ad7d-02ff-064d-9028-af5309e8adee"), "SAD0", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A193 B7", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("66a828dc-1a3d-50c8-ab9a-3f03482c3f33"), "SAB2", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS CROM", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("697cf80a-b06a-c5cf-204c-914210302181"), "F3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("702b7d59-97ef-5cd3-121f-a0a44d662ae9"), "SAA8", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 10.9", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7768d271-f5c2-5adb-4378-d76423e6d36c"), "SAA1", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB 10.9", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7910a9e2-7729-72e1-6706-466be3504025"), "SAE1", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA ÖZEL GRUP", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7bda3e77-53b3-bcea-6947-07f89c1c4079"), "SAE7", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SETŞKUR", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7dc6a4cd-dee6-7589-081a-242765e86591"), "SAD1", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB A320 L7", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("7eb9e490-2b9b-4d3f-81e0-50e4d50b8215"), "SAA4", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 10.9", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("80b9d5c8-d750-4551-b52b-3e7deb7e7d57"), "SAB3", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS 8.8", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), "F2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("88d20b0d-6a11-9a22-0fa5-cdb42f9baa19"), "SAA6", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB CROM", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), "F6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("9a85af55-3bdf-0352-6504-013c174cf772"), "SAE0", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA WHITWORTH / UNC / UNF", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("a5794d46-cc52-f4cf-a405-e4421a230f83"), "SAC4", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB İNBUS CROM", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("adb99942-c0b7-5d41-15ed-31d8b095b313"), "SAB9", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB YILDIZ KANALLI CROM", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), "F4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("c60d528b-fdd2-9126-0b59-0a7c38e6436d"), "SAE5", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "PERCIN SOMUN", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("c80f6791-daef-b541-dbda-d33e7e262744"), "SAE6", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SAPLAMALAR", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), "F1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("cd3cef44-b779-bde1-a6b3-64c71f51740a"), "SAC0", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB SAC VİDASI/AKILLI VİDA CROM", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("d26a1eda-0156-ea1d-4ccc-54dcbcada052"), "SAB8", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB İNBUS CROM", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("ddb1fd59-13f8-a331-91f5-64e88513bac9"), "SAC1", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA MB DUZ 8.8", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("f052e6f1-db3c-ddee-01d9-50d4f464a86e"), "SAB6", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA HB TORNAVİDA YARIKLI 8.8", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("f124c5f8-2216-e46a-c282-a4c9e7ea3ee8"), "SAA9", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB İNBUS 12.9", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("f216c606-cf03-3719-ebab-e8e076b30342"), "SAB0", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA SB TORNAVİDA YARIKLI 8.8", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("f3e684e0-3327-7e78-0877-f97e78c4c802"), "SAA5", "SEED", new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "CİVATA AKB SAPKALI 12.9", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 1 },
                    { new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), "F0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 }
                });

            migrationBuilder.InsertData(
                table: "SPrefixRules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FluidId", "ModifiedBy", "ModifiedDate", "Prefix", "SProductGroupId", "SProductId", "Status" },
                values: new object[,]
                {
                    { new Guid("09bca16d-618c-1f36-a4b4-08c452a4e2e2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("0d27e762-6758-cbce-49cc-852c44436c54"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("14ddbcf4-c820-201f-17e2-01dcefe0f4b6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("175362d3-b45f-cb5b-a3e2-21c7e186dae0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("1b019ef8-3079-d437-5640-00b4117ea08f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("1cb09bdc-dff1-3000-8ac2-8af33cd3282f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("299949d5-be36-8c6e-470f-faa28fb7e5af"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("2b375a53-07bf-ffe4-9c21-a482bf77be8c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("2e568aa1-f9db-5848-7d98-582d5b5357c8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("31e59bf6-5de3-0750-10fe-39615ef71ff5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("33594ffd-4ded-1466-93d1-800ebe82b0b0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("36cebe7d-dcd2-3089-2033-d3e6ec4b850d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("3cd700fb-ae47-30b9-b441-bc78c1a2c9f0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("4b707bf9-ef53-3625-dfe4-647bbf55625a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("4d88655d-5386-2d8b-90a4-75563bf95b90"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("53a7c554-32fc-968a-04e3-dcf680a3c79f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("58b6f4b2-633f-8531-b71e-2ea1a78b4c71"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("5c3cc8f9-cc84-9ae7-7d9a-89183ee9704e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("60a073db-7557-32eb-854d-280833eacd77"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("62fb66d4-7d9c-6712-38d8-e97d499980f6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("6a895009-83fc-600f-0b0b-54ac4730544a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("6fdc4b46-4f76-df0e-ba02-66a04b1eeac3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("70f23f5a-ce75-1382-901f-8f160ef5fdc0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("719f2cc5-44df-4f94-759b-e0b3ddd8917b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("730d4c3a-b37c-ec1f-8865-36e7399b5787"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("73e9e267-69c4-1957-f2d8-0edfe36fcde3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("76dfa081-e967-949d-4c70-ee51c242b58a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("777c1470-dab3-e66d-7a57-4569a02b086f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("7c24ea52-93b5-0ca0-23db-35879d4482fe"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("7d1b1307-76db-97a7-bd95-1e0d134f349c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("7e2038c7-653a-9d23-9f8b-91d5a8a4dead"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("7fabe1cc-25b8-4c60-04b0-afb2928b2664"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("82a971b5-42af-16a5-a22f-1ece9e8741ea"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("9bb78401-11ed-b5e6-40ea-8ee8cf633241"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("9d34aaac-acb0-1168-624d-c86293435a23"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("a21d6956-84d3-daf6-d55a-2c0dcfb88202"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("a85523df-5b7b-3442-8c63-ff117b76ba4d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("b078e392-c5d1-e408-61e8-eabc0c26fa96"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF9", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), 0 },
                    { new Guid("c0caf8c0-fc14-9d22-e349-263b17e4f092"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("ca046319-441a-c8d9-84fa-461c31dbbed7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("cadfa220-8767-f769-9f7f-270c497bc80d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("cae0e0a2-7343-0045-5cab-b6291a23930f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("d781f29c-19d5-550e-5ebf-d292a2c0663b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("d78f180a-7f6d-75bf-7f2d-5dc4560c8854"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("db55bd8a-9ce4-136b-3c9a-c4e9a599397b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("e521982b-e38d-08bc-8733-709206009e73"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("ecbffe18-76ec-3663-83f0-17a91c850d93"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("ee3184f7-ad60-6d13-ffe1-00dfde6401ad"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("ee50326a-e5ab-445a-2a5d-81342060452d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("f1cc7f4a-c2de-f90a-693e-62f881173b08"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("f1ea3b4b-68d6-19df-391b-5ee511364c54"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("f331d41a-0601-9f4c-5545-09a3e1b1ad63"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("f6926b04-61a2-e553-aa01-1fc50f063237"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("f758b8d5-3efb-a9a0-ab27-5035792caaa4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("f7c52295-50da-8a53-f40e-b8be15ebbec8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("0062692a-40d6-44a8-bcb4-785ed67f0f55"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9529), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("00f52db5-ebf0-4db1-9437-530f2356de16"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9520), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("04493b76-0275-4949-9395-62e446338abf"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9536), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("06893024-3402-4c1e-9d82-8b3dbef5f00c"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9508), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("08b0602c-0d36-4b09-aaeb-e330e308f97d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9538), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("121996b2-43c4-4d45-a198-23f188bca446"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9453), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("25515cfb-c205-438c-92fd-83d1a082c8fa"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9574), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("30c31dc7-5db5-46f3-802b-c57e614ab0b7"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9579), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("3532060c-3c88-4ad3-b3c1-c3f406c3349d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9524), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("432ce09c-3861-43f3-bae8-96f1b36d7197"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9471), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("43bf74bd-9587-4410-8c98-690a7437e349"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9464), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("442b9414-54d1-4c64-b4ef-0328f70c1423"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9583), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("471dcde6-2bc4-4769-ade0-d2b972d81a2d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9546), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("4a3d083a-03db-4e42-a4f7-f0ac88f683ab"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9548), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("4d80beb4-3788-440e-98d5-bcb043749109"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9539), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("5d7b0d21-d0d2-4669-bb90-a972a433a9f7"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9589), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("5e1e2ac8-c101-42cd-9c50-dfe13ea4ec57"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9572), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("5efaedae-a5d1-4737-8142-d9e8e6dfebb3"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9570), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("600f2b8d-b781-4b13-8f80-e32a531ededa"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9544), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("673ca2ed-d8fd-4f1a-88bb-051bcbce941b"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9568), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("68650454-857d-45aa-8da6-82785906bf43"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9466), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("6a17c742-3a31-463c-bce1-0eb7ce9c4045"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9532), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("6ceca8d3-859b-489b-bc78-97bd513e4c4b"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9566), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("733b84ed-4eb2-4027-9844-0e0faeffc243"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9462), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("7da88bce-d1a8-4d21-be77-3ceb96530691"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9442), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("80b8f2e7-5004-45e2-8b2b-10daa196c1ed"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9455), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("84486234-9471-4031-aa90-7f2ca3e32b96"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9557), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("8d1f9cb1-38a9-42b5-a8cc-3b8975c7b78e"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9581), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("910a3b1e-7c3c-4eb3-9558-7ac0260f38e7"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9445), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("9e75c7cb-05bb-43c8-ab3d-0735423a36e2"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9468), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("9eac8df0-d305-4a12-9c4e-a8525e5a85b0"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9593), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("9fb95b36-dbda-4061-8432-2b3f528df651"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9584), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("a77b09e1-db87-4ae3-826e-172f004d31dc"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9564), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("ac1fdb4b-5051-46d2-8db8-7145b29fde19"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9518), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("acbf3f4c-8c3c-4bff-9b6d-33322a6772ee"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9562), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("ad8a8216-a66a-47d9-b460-28a262619d93"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9554), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("ad8bf7f1-5eaf-4fe6-ae8c-c8ec746f1a9d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9505), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("becf0816-dbf4-4793-acd6-6ec2c032f28b"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9451), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("bf5a623b-6448-4d05-a3fa-9837848f4ecb"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9591), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("c6526d77-5d79-407a-9ac0-a70c30f90fc6"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9459), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("c70829a6-245c-4392-a2a3-4e88164503b3"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9512), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("c87cae89-1256-4fec-ad6b-d2f02b1bbdcc"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9551), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("c9041d4c-72e1-463d-81f4-afb8f417d90f"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9559), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("cba876a6-4472-451e-8bb1-ec2769cdc71d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9473), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("ce1aa245-ab38-4a0e-adb0-5cb125b7132d"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9541), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("d46a7f1b-04f7-4c13-8bbf-748847b01892"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9576), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("dbdf26e9-1abb-4fc1-9a61-353b9c4fd9a7"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9527), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("ddb58ebe-7c49-47b3-81a6-5f4c2fc67374"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9587), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("e6802c0f-8944-4027-a981-50843f31bbf0"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9515), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("e6b72fd0-d966-4b2e-863d-57e0f1f3df3c"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9475), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("ef2db162-88aa-41fb-9e5c-61165edfe087"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9530), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("f6baceda-c366-436f-89a9-d996bc8b4241"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9510), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("fa41ff85-0e60-4245-a721-09fa348feaef"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9556), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("fd5d7f44-d6a3-4103-9fb5-2b1afbf4bede"), "SeedData", new DateTime(2026, 2, 4, 11, 34, 45, 616, DateTimeKind.Utc).AddTicks(9522), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 }
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
                name: "IX_StockCards_FluidId_SProductGroupId_SProductId",
                table: "StockCards",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId" },
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
                name: "StockCards");

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
                name: "Fluids");

            migrationBuilder.DropTable(
                name: "SAssemblyGroups");

            migrationBuilder.DropTable(
                name: "SProducts");

            migrationBuilder.DropTable(
                name: "StockSequences");

            migrationBuilder.DropTable(
                name: "StorageTypes");

            migrationBuilder.DropTable(
                name: "GasTypes");

            migrationBuilder.DropTable(
                name: "MaterialForms");

            migrationBuilder.DropTable(
                name: "SProductGroups");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
