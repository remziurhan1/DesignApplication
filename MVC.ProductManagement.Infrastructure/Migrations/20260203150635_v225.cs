using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v225 : Migration
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
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(1965), null, null, 7850.0, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0 });

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
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(1996), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Standard plate form for P355NH", "EN 10028-3", 0, 250.0, 1.0, 1.5, null });

            migrationBuilder.InsertData(
                table: "SProducts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "PrefixIndex", "SProductGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("083eba27-3a25-7389-1b8a-eeff10ddf639"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A7", 7, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("08dd5865-e3eb-fa8b-1662-9944f53921cb"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SZ-A4", 4, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("0a6a04bf-9c03-18ab-8f39-6c41840bc2de"), "G0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G0", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), "F9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F9", 9, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("100fad06-16c8-4414-c174-e13fea8cb2fc"), "C4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-C4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("117e023c-61a0-9e16-ab8c-4abc262f756a"), "B4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B4", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("136ccea1-4997-9653-5e42-1ee394b28827"), "B9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B9", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("177e44a6-40d3-a37c-01d6-556565feb02d"), "B1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B1", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("17e2b098-e7de-e4c0-3723-8f70ede97bb2"), "C7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C7", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("18905295-d4f1-92cf-159a-0584871092eb"), "B0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B0", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("193dc2da-1cc4-3db0-47f8-c2c78f876b3c"), "B8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B8", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("1be39a27-60e4-d037-2a23-cd4dfa988c0f"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A1", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("1c73ede1-179c-302e-fc82-c61de1625846"), "B6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B6", 6, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("1dd17fc4-e071-d717-1391-87ddd01d1777"), "B4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B4", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("1e2739b9-cd2d-3574-9582-8cf07bb57270"), "G5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G5", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("1f262548-96c4-d5f1-e82f-e678a67172a6"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A0", 0, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("258c712d-c17c-f1ed-f1fb-fd4d5c2c7546"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A6", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("25a8d9b0-3fe8-1416-4583-9a18ead97eb5"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A6", 6, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("262ea4f1-b339-87cd-5678-17386e2dc307"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A5", 5, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("27920a3f-6cd2-127e-84ea-967c011cbefb"), "B3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B3", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("2908ac5c-6372-2fd4-c167-e1155ca2f3f4"), "C0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-C0", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("29a588c2-3a6c-1687-a119-0d00bb55d666"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), "F8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F8", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("2c0ae9ec-19e8-3419-761c-c9b387aa3d88"), "E3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-E3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("2c64fd17-18a8-960d-d692-7d5320ee55b5"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A6", 6, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("2c726f47-6c5e-5b26-7c54-e5243b1d3cb2"), "B3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B3", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("2cdc3a70-5ed6-d8e4-68b5-c4ee4346746c"), "C4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C4", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("2dd22f28-43c7-6e77-6304-df8d14929c06"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A7", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("3206db36-1787-d97a-a714-757234bdbf92"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A4", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("367c27df-38a5-07ff-fbd4-58f47fccb93d"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A3", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("37287800-6c34-87d9-7d60-a15dca9565c4"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A0", 0, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("38f2b63e-81cc-9512-23c6-82680d089a8e"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SZ-A2", 2, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("3a25f7f1-814f-d789-5a9a-b3bff5bd2272"), "E1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E1", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("3add035a-50fc-2772-a03c-9bd7229ff36a"), "B8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B8", 8, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("3d0d6e4e-acd9-ac84-f3ff-d59bb8b20ee5"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A1", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("3da5522d-7c31-14d3-f0f0-768df252e92f"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A7", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("3de991f3-d7bb-c3d2-fdca-1e6dad2ee7a0"), "C5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C5", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("3e38965d-1a9d-ac3f-9c76-c86dd28c5c24"), "E6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E6", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("3e83df23-855c-c82a-7f41-23d6b93d896f"), "E4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-E4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("4002de4b-f848-8d1f-b8d4-4e682c60149a"), "F2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-F2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("438f68a2-8bdd-9be7-9b69-5fd4b4a68875"), "B6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B6", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("444d8544-a569-5b88-c0a6-fc16359fdb43"), "B5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B5", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("465c56c4-e656-4ac8-de58-8fded8ef62e7"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("47b0f560-3284-b088-5956-6331a97f4eb7"), "C0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C0", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("48b04758-97fc-9057-c7a1-43412a41c69e"), "E2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-E2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("49254e06-8a1f-369d-9554-89c3710780c0"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A5", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("4ac370ab-76bb-6ac6-2fbc-483cca51e34e"), "A9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A9", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("4ddd6819-463a-a7c4-de10-5bd7acd77e74"), "E2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E2", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("4e41e0a5-8d2c-073e-d49a-0bb91b9bd5d6"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A3", 3, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("4eb2faba-0ab9-5673-7297-4706d5349f7c"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A5", 5, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("52d95acc-15cf-8721-6bed-2ba2c5e72d1e"), "B0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-B0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("532fadc7-59d1-96ac-d141-de146d7d7d0c"), "C2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C2", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("541b451a-a990-338a-8bfb-1dbce7a10125"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A1", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("54bdebcf-d3a6-226f-397a-0e73886b7b1b"), "D1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-D1", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("55b1763d-3c45-b72e-019b-af0abc7d07fb"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A6", 6, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("571e9442-a582-15e7-6930-0b368371747a"), "C3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C3", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("5726f870-9a3b-ee9a-b8ec-8a095f470af9"), "B1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B1", 1, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("585a1c97-80cd-d0b3-2c79-fa31582ec03c"), "B7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B7", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("592d3718-cfeb-0a1d-ee63-c372dcebd1f2"), "B3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-B3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), "F5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F5", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("5b46ee40-f7c4-bce5-63d6-8cb456b369a6"), "H1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-H1", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("5b511e3f-7b80-2153-d900-56f6f6bae46a"), "D2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-D2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("5f9c44af-9bbe-2e0d-6581-e7fefbe3e157"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A2", 2, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("615d695a-3458-0503-f49b-6c083afe4c53"), "B2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B2", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("61e49e59-d8a7-73cc-2af6-2752ac681a07"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A0", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("6223813a-0668-c81b-b474-b30d32cad4fa"), "B9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B9", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("62f37cd6-18d1-151d-5fb7-42bd0e61bbe9"), "C0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C0", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), "F7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F7", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("635445a7-6d44-bc8a-8e2f-c89783cee567"), "E4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E4", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("6437eeb2-65a3-7ebe-9c80-f4e6d9268f4b"), "B0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B0", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("64d5cc82-851f-5bb9-e975-06ec20ac2f29"), "D0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-D0", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("65f92078-8492-e11d-83a4-e3d8e1f85aa4"), "E5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E5", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("667126e6-1cf1-4a67-4adb-ee90acbec830"), "B4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-B4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("67227357-f705-12fd-4564-e6a705633557"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A4", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("68ee2149-3ae8-ff6b-bdf6-8b48cd327e7c"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A8", 8, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("697cf80a-b06a-c5cf-204c-914210302181"), "F3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F3", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("6ac23e54-f8f0-45b0-e6da-54ed5f166bf6"), "C8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C8", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("6c0c54d1-80b4-cc2a-82e8-6eec3c9a5fbf"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A7", 7, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("6e6ea87c-c14c-28a0-6c17-34537a6401c2"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A8", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("6f1c3257-65bc-3fc2-0d96-f2270818c243"), "F1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-F1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("75196f3b-7291-a0fa-6c1a-658c0af7103e"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A1", 1, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("766adbf4-3f36-6af7-22ae-bffa913d3731"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A8", 8, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("7690031c-e3f4-43d4-33e7-3d51d50cb401"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C1", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("792acc1f-9742-04a2-41fa-341783567d10"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A3", 3, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("7b3ac40f-6fb1-9108-6079-8ee98558ebcc"), "B2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B2", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("7bf730b4-7ea4-d90e-1a19-afb8b3049e05"), "H2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-H2", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("7caf4232-348d-c985-0af1-b7b1d2d73061"), "C0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-C0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("7e2d6028-1900-52cb-aed1-bac83bbc177b"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A2", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("82269baa-6b44-394b-3ba8-2c1bd4fd3bce"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A4", 4, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("828baa99-21bc-afe0-b5c4-d8e9f562cbaa"), "D0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-D0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("844f9b63-72b7-f634-3f6d-33eb46b4cd74"), "D1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-D1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("862fa6a4-15d8-98b1-1b22-99f8299cd2c5"), "C3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C3", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("87835c53-2cee-b471-b33a-471317f55734"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A2", 2, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("87ed6cf3-abb2-9db7-f086-eb1f41694af5"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A4", 4, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), "F2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F2", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("89cbde07-756d-354e-d772-c8c82350872f"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A5", 5, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("8b3d4ad1-02c9-ad37-a7f1-27bd455de3e7"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SZ-A1", 1, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("8e133ac0-47b3-64c8-5a57-979025e331bf"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A0", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("908f658b-1d87-bf50-e065-2456f6eb1847"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A4", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("92e7ad68-7247-6da1-78df-b4914eab9885"), "B3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B3", 3, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("92ea00b7-204e-2dc5-d455-1205f9a31884"), "C4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C4", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("93e18894-972f-31cd-bf26-c9180f70ddc3"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A4", 4, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), "F6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F6", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("96001da6-037c-1fa0-c31e-2a5070fbe98d"), "B4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B4", 4, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("9645156e-419f-6528-b768-7c38d2323742"), "C3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-C3", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("96b16666-a698-a13a-48fd-f6aebab51466"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A7", 7, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("97189e8d-7248-e7ff-be48-c990b45467d2"), "B7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B7", 7, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("979f35a3-7d45-2a14-8d7b-68e4916362b1"), "G4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G4", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("992eb55b-c0b1-5370-4b7f-ab6175e620d0"), "C2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C2", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("9a13ed9d-382b-d4a2-b686-042ca0483c6a"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A8", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("9a3b035f-2599-4083-472d-91cb6d4f00dc"), "F4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-F4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("9a452b31-3daf-735a-cfd3-2597c4de7789"), "H3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-H3", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("9d6105ae-8aa5-6641-87c8-777da55ea29d"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SZ-A0", 0, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("9e2d4566-10c6-650c-79f6-07b49908430a"), "G1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G1", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("a0f09874-28c9-5d1b-2e46-c61e4c715d55"), "B5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B5", 5, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("a3255bde-c016-e7bd-dfd5-ece3d268f4b6"), "G6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G6", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("a7d22f27-9c19-76c7-3abc-0bbc5273945e"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("a87a3b44-044d-5e71-b124-c0d744923397"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SZ-A3", 3, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("ace7a4b2-7998-b24d-e00e-bff81e26b515"), "E0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E0", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("ad076f71-79d9-6e79-9868-64d942a4b87f"), "B1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-B1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("ad4d4137-8e46-f9d8-1b13-6523439d4c6d"), "C2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-C2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), "F4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F4", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("afd1908a-73b3-679e-3901-94b15e4970f4"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A6", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("b17feeff-4c72-f522-f518-8a9d9e9cfeb7"), "C5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C5", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("b1e39e11-4f26-76bb-14d0-8a95fc5bf8ce"), "B1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B1", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("b70654ee-5d45-e415-8239-722ed94d51c2"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A3", 3, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("b7e590b0-a70b-13f1-e787-e8e4b08f3a17"), "E1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-E1", 1, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("b859dd59-d99c-6ada-19f2-18c47c535e12"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A3", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("bc36b67f-0c9d-e8b7-c996-e07c64606816"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A3", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("bc67cdb5-076a-ce40-5b3d-a6bc8d2822ef"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A1", 1, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("bc79ede0-e381-d441-322d-110d2d9d895b"), "B6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-B6", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("bd168e79-34ef-defb-67b9-addf99a2ed61"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("bd592e1a-54e9-bd97-41b1-dc52f4c9e467"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A4", 4, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("be64b9b9-1333-f83c-292c-cc8bb4e92a50"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A5", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("c11902ff-0016-a41f-f70c-bd7c609b21a9"), "A9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A9", 9, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("c271d9e0-9837-d150-d135-8fd2e88fbd73"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A1", 1, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("c2bab010-83b7-07e0-5ea6-7f81ba4897a7"), "A9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A9", 9, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("c5842ce7-b3a3-e01d-e2b8-28e94a06c94a"), "D1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-D1", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("c5a044fc-fcd7-3b40-cbb8-8479134e2166"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SC-A2", 2, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("c5b925cb-3cb3-3139-17a1-1f6751e7f4d2"), "B9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B9", 9, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("c806c7b1-3a57-2582-2337-e071223e4de3"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A1", 1, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("c9ac25bc-5c80-3fd6-2874-a743bc3c5308"), "B2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-B2", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("ca307db9-14a7-047a-1c54-a2532686b6b7"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A6", 6, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("cb6d9684-857c-1abc-9d6f-677b91279863"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C1", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("cb76d211-8000-c24f-6436-1fda0a7a72c6"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-C1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), "F1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F1", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("ccccede8-01a0-7c98-1cc6-7988bcb97eca"), "C6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-C6", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("ccd15e05-5340-f6b0-273a-353cd2f7becc"), "A9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A9", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("cf3a1d7c-f5c6-275b-ad3f-8a29d82dd50d"), "G2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G2", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("cf955176-4ea3-f079-4b33-16ed123ad8ef"), "F0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-F0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("d05d2203-7950-471d-3c33-c2f6e15fa8ae"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A2", 2, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("d15a1b67-23ec-9555-56d7-9f908dab6e9b"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A0", 0, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("d4159429-1001-086c-e775-0f446429455b"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A5", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("d4e9b96a-0faa-8673-f085-dccb8045d87e"), "C3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-C3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("d853256f-f806-027b-6a6e-f88e4cd6934d"), "G3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-G3", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("d8b4af9d-acb1-e176-a669-a25f528d66f7"), "B0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B0", 0, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("da086b67-3204-7b55-07d2-251d61c87aaa"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("dac9fd2c-2e60-e3cc-2db4-19abf0581afb"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A8", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("ddef3f12-bc30-1271-8c14-e85d250a2e61"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A5", 5, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("ddf7789d-18ff-a09f-919b-9a0b13356b0b"), "D0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-D0", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("dec1f540-3b36-ea22-6606-6445c84d94bf"), "B2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-B2", 2, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("dee2cc29-abed-6701-7d6f-f6e77e70c946"), "B8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B8", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("e1195f29-da5e-3200-b821-7d6c3dfd2e05"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A6", 6, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("e1f8dc6a-a55d-f8ba-76a0-3945196e517d"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-A5", 5, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("e6d4631e-41fb-e5c5-f023-25d3fedc32d6"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-C1", 1, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("e6fe0727-2c8a-cfc8-36c0-091ca71ffefd"), "E3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-E3", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("ea3f2984-915d-9dad-b49c-9bb2ab690518"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A7", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("eb197acc-0080-782a-224b-981ca7ea89c1"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-C1", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("ebf2a06d-d68d-16ae-55eb-f026b0133ee3"), "C6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-C6", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("ed4cb447-7817-f884-ed14-92a3d5f1133b"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A0", 0, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("ed59512f-6538-0cc0-bccf-e46e4133dd41"), "C5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-C5", 5, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("ef085ee9-ed78-1dfa-9422-ba734c96f4ce"), "E0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-E0", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("efa50840-b929-33a3-b3a2-d0cefa2edb4c"), "B5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B5", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("f0a0d69d-89e4-9e49-e13f-8a5d19251040"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SH-A8", 8, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("f17d0e4f-443e-41ee-1e2d-b334b53a0647"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SA-A2", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("f21a548f-cce9-df44-f320-5176fe4b478d"), "D3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-D3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("f37491e8-cf8e-7efb-2481-5cacb51d08db"), "E1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-E1", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("f3855ed6-b7c5-dab2-aa9b-0b42e388f967"), "H0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-H0", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("f490ecef-b800-0316-c8a0-c1894eb036f8"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SG-A3", 3, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("f4b123da-b8a6-3b97-a001-693b0266114e"), "D4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-D4", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("f4d254e4-f5ad-07e5-a901-ae0f2a5668e5"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SE-A7", 7, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("f67188f8-6ed2-ccac-19cd-e2ef04a6ec57"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A0", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("f7cb1073-9761-3a61-94f9-da0f2a35fafc"), "B7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-B7", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("f9c99ecf-6041-020a-18e9-e53e6d5567b5"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-A2", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), "F0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SF-F0", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("fb5f859f-122b-777b-c0ba-a7c76b3eb7bc"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-A6", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("fb6ddd6a-23bf-17d2-7231-716f781284ac"), "C2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SB-C2", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("fdabb0d6-ca0f-f7b5-b140-c0bf7fa6e457"), "F3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-F3", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("fde7644e-232a-d093-0cd5-7d3ce625c09d"), "E0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-E0", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("ff2b3b00-bf23-fc01-c5c3-8b65b777dad3"), "E1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "SD-E1", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 }
                });

            migrationBuilder.InsertData(
                table: "PrefixRules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FluidId", "ModifiedBy", "ModifiedDate", "Prefix4", "SProductGroupId", "SProductId", "Status" },
                values: new object[,]
                {
                    { new Guid("01b8f010-6ffe-642f-5c47-bd9a712d4951"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("1be39a27-60e4-d037-2a23-cd4dfa988c0f"), 0 },
                    { new Guid("022d806d-870b-301d-aace-8d8cfe084620"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("465c56c4-e656-4ac8-de58-8fded8ef62e7"), 0 },
                    { new Guid("03513c14-e9ac-ab50-f70d-a8393e92e9d3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("ebf2a06d-d68d-16ae-55eb-f026b0133ee3"), 0 },
                    { new Guid("03eddbe5-d44d-eb18-003d-00a257c40b6a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SBC0", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("2908ac5c-6372-2fd4-c167-e1155ca2f3f4"), 0 },
                    { new Guid("04661f93-be40-ca4a-370e-a8ff8792154d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2dd22f28-43c7-6e77-6304-df8d14929c06"), 0 },
                    { new Guid("068a57bd-cf88-3520-452a-e7e1beda1d88"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA0", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("ed4cb447-7817-f884-ed14-92a3d5f1133b"), 0 },
                    { new Guid("06e20553-3063-030b-4177-e8dae130ab10"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA6", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("55b1763d-3c45-b72e-019b-af0abc7d07fb"), 0 },
                    { new Guid("0990be6d-325d-6e3c-2954-06eeba2a5008"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA2", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("7e2d6028-1900-52cb-aed1-bac83bbc177b"), 0 },
                    { new Guid("0ba18a27-7a2a-ea26-3a1a-b504901c1173"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SDF0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("cf955176-4ea3-f079-4b33-16ed123ad8ef"), 0 },
                    { new Guid("0cae6d80-9cb6-c348-460c-c57eb6f85d67"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("9a13ed9d-382b-d4a2-b686-042ca0483c6a"), 0 },
                    { new Guid("0d10b95c-e960-8ed2-f3b9-4bbad5c11445"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA4", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("93e18894-972f-31cd-bf26-c9180f70ddc3"), 0 },
                    { new Guid("0d5c4559-5d6e-d758-70e5-7538b5e71d7c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA4", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("908f658b-1d87-bf50-e065-2456f6eb1847"), 0 },
                    { new Guid("0e6918b8-5b87-4293-ea14-06de72200375"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SZA4", new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), new Guid("08dd5865-e3eb-fa8b-1662-9944f53921cb"), 0 },
                    { new Guid("1119d95c-75a1-35b9-7c0e-8ab8d9e1efbf"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA6", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("afd1908a-73b3-679e-3901-94b15e4970f4"), 0 },
                    { new Guid("11e3bd3e-cf18-258e-c029-9dda68e8c03c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC2", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("992eb55b-c0b1-5370-4b7f-ab6175e620d0"), 0 },
                    { new Guid("135e4e1c-de9a-a262-a43b-4b5b19525012"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB3", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("2c726f47-6c5e-5b26-7c54-e5243b1d3cb2"), 0 },
                    { new Guid("14f43099-87e9-5f85-e4ed-99c043aebaa5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA7", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("96b16666-a698-a13a-48fd-f6aebab51466"), 0 },
                    { new Guid("16667cff-f7d0-d6be-a7c9-54022fb8abb6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SBD1", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("c5842ce7-b3a3-e01d-e2b8-28e94a06c94a"), 0 },
                    { new Guid("16b54f53-1a2a-b80b-ca45-6a08b89500eb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("a7d22f27-9c19-76c7-3abc-0bbc5273945e"), 0 },
                    { new Guid("17b75d48-ee7b-6aa8-fdb2-08e23822348c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB8", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("3add035a-50fc-2772-a03c-9bd7229ff36a"), 0 },
                    { new Guid("18dd315e-9a02-a4dd-a19a-e2d4931ad900"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SAD1", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("54bdebcf-d3a6-226f-397a-0e73886b7b1b"), 0 },
                    { new Guid("1ae4fe52-5143-d49e-9fe1-93b3ba9e61d6"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC4", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("92ea00b7-204e-2dc5-d455-1205f9a31884"), 0 },
                    { new Guid("1ae95b5b-3706-70e8-1b7c-33bd4148d95e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA7", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("3da5522d-7c31-14d3-f0f0-768df252e92f"), 0 },
                    { new Guid("1b5c1010-ad89-24c6-853c-482a0af589c8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA5", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("be64b9b9-1333-f83c-292c-cc8bb4e92a50"), 0 },
                    { new Guid("1b5e51de-a74e-1824-53ad-fa881e10b3a1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA6", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("25a8d9b0-3fe8-1416-4583-9a18ead97eb5"), 0 },
                    { new Guid("1d0a4a53-b410-981b-a641-15e512d0d13e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cf3a1d7c-f5c6-275b-ad3f-8a29d82dd50d"), 0 },
                    { new Guid("2108aaa4-c31c-d397-34be-110b9a1b3515"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SDD0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("828baa99-21bc-afe0-b5c4-d8e9f562cbaa"), 0 },
                    { new Guid("2123b32c-d716-3d1a-3016-f6e3a99811bb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA2", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("5f9c44af-9bbe-2e0d-6581-e7fefbe3e157"), 0 },
                    { new Guid("22dda7d8-92e8-b88f-9f06-6299d81739b7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), 0 },
                    { new Guid("237b93a2-2203-73e7-e42f-d3b2f5c5b791"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB5", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("efa50840-b929-33a3-b3a2-d0cefa2edb4c"), 0 },
                    { new Guid("23b69688-a169-92c5-4bd4-a6e69313a2ff"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("7690031c-e3f4-43d4-33e7-3d51d50cb401"), 0 },
                    { new Guid("241713b3-6f37-9fcb-4239-842d3541b8ff"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SDD2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("5b511e3f-7b80-2153-d900-56f6f6bae46a"), 0 },
                    { new Guid("24838499-9216-c0ad-2a32-515bb9f1c230"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA2", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("87835c53-2cee-b471-b33a-471317f55734"), 0 },
                    { new Guid("252518f0-a6bb-1ba3-1007-3764420eb074"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SDB3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("592d3718-cfeb-0a1d-ee63-c372dcebd1f2"), 0 },
                    { new Guid("258910d3-c6e5-6723-3519-d6e6f4dc3954"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SZA0", new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), new Guid("9d6105ae-8aa5-6641-87c8-777da55ea29d"), 0 },
                    { new Guid("25a5263a-ffc1-d06d-76f4-8a74c0594b29"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), null, null, "SFH0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("f3855ed6-b7c5-dab2-aa9b-0b42e388f967"), 0 },
                    { new Guid("271f20f8-f5a0-8f2b-891a-8ba472b1aecd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA5", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("89cbde07-756d-354e-d772-c8c82350872f"), 0 },
                    { new Guid("28558c33-9f12-1e28-e139-2291656be548"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB2", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("7b3ac40f-6fb1-9108-6079-8ee98558ebcc"), 0 },
                    { new Guid("29330e99-5bf2-dfac-2256-1d905b0c6e4a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SDE3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("2c0ae9ec-19e8-3419-761c-c9b387aa3d88"), 0 },
                    { new Guid("2cc3c98a-fb7a-e101-5091-18abca6a1147"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB3", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("92e7ad68-7247-6da1-78df-b4914eab9885"), 0 },
                    { new Guid("2d008b0f-0720-d44d-bd63-3b1c4c7922f0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), null, null, "SFH3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("9a452b31-3daf-735a-cfd3-2597c4de7789"), 0 },
                    { new Guid("2ea3b1bc-73d5-c946-64de-175aef801fdd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA4", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("67227357-f705-12fd-4564-e6a705633557"), 0 },
                    { new Guid("2fa553fc-e5da-f30d-14ab-bbc9a7e54ba4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SDB2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("c9ac25bc-5c80-3fd6-2874-a743bc3c5308"), 0 },
                    { new Guid("304f0446-d560-6bd2-30ac-472b38aac67d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SDC2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("ad4d4137-8e46-f9d8-1b13-6523439d4c6d"), 0 },
                    { new Guid("318615c1-8acd-d184-ded5-46a8ffac9d14"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("29a588c2-3a6c-1687-a119-0d00bb55d666"), 0 },
                    { new Guid("325091d8-da5a-fc34-4937-fe09e7f506bc"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB6", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("bc79ede0-e381-d441-322d-110d2d9d895b"), 0 },
                    { new Guid("32acb30a-f52f-a755-1eeb-01a053117f96"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA5", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("262ea4f1-b339-87cd-5678-17386e2dc307"), 0 },
                    { new Guid("3b953109-ac39-c13b-909a-ced6f84455bf"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("697cf80a-b06a-c5cf-204c-914210302181"), 0 },
                    { new Guid("3c48e54d-5437-c451-2dc5-e2fd5aded77c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA3", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("b859dd59-d99c-6ada-19f2-18c47c535e12"), 0 },
                    { new Guid("3d2835ae-ed46-93bf-9f25-3583a227122c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SBC3", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("9645156e-419f-6528-b768-7c38d2323742"), 0 },
                    { new Guid("3db213dc-6652-ed2a-98d5-516a2836fa0b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB0", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("18905295-d4f1-92cf-159a-0584871092eb"), 0 },
                    { new Guid("3dc939d1-c40d-aa7b-216f-f3e362e276b0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA0", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("37287800-6c34-87d9-7d60-a15dca9565c4"), 0 },
                    { new Guid("3ebe679b-8854-81c3-c7f8-9848e71e6003"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA8", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("68ee2149-3ae8-ff6b-bdf6-8b48cd327e7c"), 0 },
                    { new Guid("3f69196b-4034-1e05-58f6-e7a4de48b82d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC1", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("cb6d9684-857c-1abc-9d6f-677b91279863"), 0 },
                    { new Guid("406c9059-3dae-4d5b-dbe9-0253343d9d28"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), null, null, "SFH2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("7bf730b4-7ea4-d90e-1a19-afb8b3049e05"), 0 },
                    { new Guid("434f30bd-cf5d-fecd-e9f7-754ebaac4a09"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SDE1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("ff2b3b00-bf23-fc01-c5c3-8b65b777dad3"), 0 },
                    { new Guid("438612e4-1967-3ae1-1e05-8e36788ed9e0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB2", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("615d695a-3458-0503-f49b-6c083afe4c53"), 0 },
                    { new Guid("44648e6f-7845-c86b-67e3-dd00032b842f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SDE2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("48b04758-97fc-9057-c7a1-43412a41c69e"), 0 },
                    { new Guid("46b76809-6c44-b690-40b6-0707d3f92a55"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE6", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("3e38965d-1a9d-ac3f-9c76-c86dd28c5c24"), 0 },
                    { new Guid("46da0024-675e-bab3-ef90-6d1c8adb4513"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB9", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("136ccea1-4997-9653-5e42-1ee394b28827"), 0 },
                    { new Guid("4718d47f-9156-5344-91f0-ad42b2af2272"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SDF2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("4002de4b-f848-8d1f-b8d4-4e682c60149a"), 0 },
                    { new Guid("4768c17c-27a5-c4f5-c156-12300d72f1ac"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA3", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("b70654ee-5d45-e415-8239-722ed94d51c2"), 0 },
                    { new Guid("49871f71-cb22-fed9-f386-1bf066addbd5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("571e9442-a582-15e7-6930-0b368371747a"), 0 },
                    { new Guid("4b87de5f-de55-195e-3148-c9b861bc4c2a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB6", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("438f68a2-8bdd-9be7-9b69-5fd4b4a68875"), 0 },
                    { new Guid("4ba0a480-6885-6e40-3bec-8739299ecc90"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF9", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), 0 },
                    { new Guid("4d0205a4-fd18-b6d0-f35d-c19f74f5a2db"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA7", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("f4d254e4-f5ad-07e5-a901-ae0f2a5668e5"), 0 },
                    { new Guid("4d269525-3e57-3349-c8fc-045ad72ff5d1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SBD0", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("ddf7789d-18ff-a09f-919b-9a0b13356b0b"), 0 },
                    { new Guid("4d332af5-a217-ca4c-04fd-d11c1677abf3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("17e2b098-e7de-e4c0-3723-8f70ede97bb2"), 0 },
                    { new Guid("528bd0e4-7fda-e420-ffc8-37235693ac53"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE4", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("635445a7-6d44-bc8a-8e2f-c89783cee567"), 0 },
                    { new Guid("5b67c223-5af8-daa0-103e-7a1936d8cc4d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("62f37cd6-18d1-151d-5fb7-42bd0e61bbe9"), 0 },
                    { new Guid("5b896bfa-ee8d-feb9-03e0-7dae660acb64"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA2", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("f17d0e4f-443e-41ee-1e2d-b334b53a0647"), 0 },
                    { new Guid("5bcb3b4d-5fb3-9d85-6786-d704c973c553"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA5", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("4eb2faba-0ab9-5673-7297-4706d5349f7c"), 0 },
                    { new Guid("5f5b895e-f892-8476-0247-7faf3c2990af"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC3", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("862fa6a4-15d8-98b1-1b22-99f8299cd2c5"), 0 },
                    { new Guid("6083eed4-3802-852f-0437-ed2acd0027ee"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB9", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("c5b925cb-3cb3-3139-17a1-1f6751e7f4d2"), 0 },
                    { new Guid("60e34e0f-a240-785d-47d0-9685b8e94bb8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB1", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("5726f870-9a3b-ee9a-b8ec-8a095f470af9"), 0 },
                    { new Guid("62ae8b45-e027-eb0b-b8d3-ec20e67bccda"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SDC3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("d4e9b96a-0faa-8673-f085-dccb8045d87e"), 0 },
                    { new Guid("66179822-6f74-cb9b-d406-deb8fd9b15a7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE5", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("65f92078-8492-e11d-83a4-e3d8e1f85aa4"), 0 },
                    { new Guid("6629a2b1-9275-31d6-e544-26421da92d54"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("2658013c-c697-d461-8ade-d7d1b0bdf25f"), null, null, "SFH1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5b46ee40-f7c4-bce5-63d6-8cb456b369a6"), 0 },
                    { new Guid("66aaf93a-6325-66bc-81eb-cad609f4be86"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA4", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("bd592e1a-54e9-bd97-41b1-dc52f4c9e467"), 0 },
                    { new Guid("66fad78c-be3d-f3e1-c24d-4ebb3445bb43"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA5", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("e1f8dc6a-a55d-f8ba-76a0-3945196e517d"), 0 },
                    { new Guid("68cd7e97-4581-db46-0ac8-ada9bab4149a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SDB1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("ad076f71-79d9-6e79-9868-64d942a4b87f"), 0 },
                    { new Guid("69847d85-4e19-c417-b388-baa9a42a0740"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("9e2d4566-10c6-650c-79f6-07b49908430a"), 0 },
                    { new Guid("6a2ab93f-e5b7-14da-8e27-ba7a3a1715f4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA3", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("f490ecef-b800-0316-c8a0-c1894eb036f8"), 0 },
                    { new Guid("6a590029-a9e3-2a6b-baa5-322fba94ddba"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA1", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("c806c7b1-3a57-2582-2337-e071223e4de3"), 0 },
                    { new Guid("6a951ac3-3907-458f-8106-996e1ecee74e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA1", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("541b451a-a990-338a-8bfb-1dbce7a10125"), 0 },
                    { new Guid("6beabcbe-f8f0-fb90-62b0-65b927783184"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA0", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("1f262548-96c4-d5f1-e82f-e678a67172a6"), 0 },
                    { new Guid("6c811952-7817-7777-4c69-296dd9a0dfd5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("6ac23e54-f8f0-45b0-e6da-54ed5f166bf6"), 0 },
                    { new Guid("6d2ad01b-5766-ec3d-0962-bbac1ea0e2de"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA6", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("fb5f859f-122b-777b-c0ba-a7c76b3eb7bc"), 0 },
                    { new Guid("7480118b-7056-3e0c-dfa5-7ee90617d87a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA1", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("75196f3b-7291-a0fa-6c1a-658c0af7103e"), 0 },
                    { new Guid("75cba3b3-4261-01c4-b1f8-1d77f85d33be"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("1e2739b9-cd2d-3574-9582-8cf07bb57270"), 0 },
                    { new Guid("764084e7-9d3f-a517-7201-774bbcbfdfb0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("f67188f8-6ed2-ccac-19cd-e2ef04a6ec57"), 0 },
                    { new Guid("7643da1e-0c9a-5798-f8eb-ea64b545b8d3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA1", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("c271d9e0-9837-d150-d135-8fd2e88fbd73"), 0 },
                    { new Guid("77e63b06-2a9b-d69d-e7be-ad38aba57a8e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA3", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("792acc1f-9742-04a2-41fa-341783567d10"), 0 },
                    { new Guid("7a6d55bb-5e32-9f11-2ea8-ec9f19e62161"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA8", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("dac9fd2c-2e60-e3cc-2db4-19abf0581afb"), 0 },
                    { new Guid("7b3d2c25-525d-eeba-b511-03ed7364cf24"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("258c712d-c17c-f1ed-f1fb-fd4d5c2c7546"), 0 },
                    { new Guid("7c619632-4d85-779a-64d9-8b77028d8ef7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA6", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("ca307db9-14a7-047a-1c54-a2532686b6b7"), 0 },
                    { new Guid("7fa21956-8c89-62fe-5221-2815bb784f04"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE0", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("ace7a4b2-7998-b24d-e00e-bff81e26b515"), 0 },
                    { new Guid("7fdbac77-d4c8-559e-93df-ac02606cbeca"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB4", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("1dd17fc4-e071-d717-1391-87ddd01d1777"), 0 },
                    { new Guid("805acbb9-73a6-e597-53c0-93c37c44ed8b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SDE0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("fde7644e-232a-d093-0cd5-7d3ce625c09d"), 0 },
                    { new Guid("81986b1e-718e-c2d8-2efb-ad51e498095e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG0", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("0a6a04bf-9c03-18ab-8f39-6c41840bc2de"), 0 },
                    { new Guid("82007bda-0043-8a2d-b3c6-19100b37f304"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB7", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("585a1c97-80cd-d0b3-2c79-fa31582ec03c"), 0 },
                    { new Guid("820ab6d0-148a-5a0d-1c28-69e03106050e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB1", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("b1e39e11-4f26-76bb-14d0-8a95fc5bf8ce"), 0 },
                    { new Guid("82ad8a5b-da08-983a-8a67-1044db817026"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2cdc3a70-5ed6-d8e4-68b5-c4ee4346746c"), 0 },
                    { new Guid("83a6d6f2-175c-09e7-2f25-77ae4fd82b95"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SDD1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("844f9b63-72b7-f634-3f6d-33eb46b4cd74"), 0 },
                    { new Guid("841bcf0a-34bb-0d6c-4bb9-3aeaf7fcf2e3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA6", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("e1195f29-da5e-3200-b821-7d6c3dfd2e05"), 0 },
                    { new Guid("847b35d3-1afb-c285-9462-c282d26acd4d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), 0 },
                    { new Guid("84a5212e-a78e-37d3-06d5-a9508bf0fb6c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA0", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("8e133ac0-47b3-64c8-5a57-979025e331bf"), 0 },
                    { new Guid("85f0035f-1b2f-619d-c4eb-7cb7c28d7a17"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB3", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("27920a3f-6cd2-127e-84ea-967c011cbefb"), 0 },
                    { new Guid("869db84d-64a4-b885-5ff9-d1fc28140ad1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SDD3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("f21a548f-cce9-df44-f320-5176fe4b478d"), 0 },
                    { new Guid("88cc99e9-5d08-2cbb-fa6e-c2276188ce9a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB6", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("1c73ede1-179c-302e-fc82-c61de1625846"), 0 },
                    { new Guid("8d68fdb4-b3e3-9e5c-c931-8baed1b607ba"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA9", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("c2bab010-83b7-07e0-5ea6-7f81ba4897a7"), 0 },
                    { new Guid("8e316500-2fbb-abdf-3127-038ca699672f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SDF4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("9a3b035f-2599-4083-472d-91cb6d4f00dc"), 0 },
                    { new Guid("8fc1c1e4-c205-705d-b920-e7e69ce8d46e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SHC1", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("e6d4631e-41fb-e5c5-f023-25d3fedc32d6"), 0 },
                    { new Guid("918f9414-83e7-93aa-6bc9-d3cc3a39591b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SDD4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("f4b123da-b8a6-3b97-a001-693b0266114e"), 0 },
                    { new Guid("94c751b8-5c80-5291-57de-d50760972bcd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA4", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("82269baa-6b44-394b-3ba8-2c1bd4fd3bce"), 0 },
                    { new Guid("950ce8c7-f5fd-cb8a-11e1-9cc604087df1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), 0 },
                    { new Guid("959a9ff1-65a4-e687-4fc5-d483be6f3de2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF7", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), 0 },
                    { new Guid("9751c64d-8cc0-4b45-e0cb-c54ed4c3ea09"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("da086b67-3204-7b55-07d2-251d61c87aaa"), 0 },
                    { new Guid("98da81a6-77a6-3ac5-0fd4-6eed3d574574"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA3", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("4e41e0a5-8d2c-073e-d49a-0bb91b9bd5d6"), 0 },
                    { new Guid("9aa4ce32-1e6c-d65a-1ec4-61c6cb1eca9f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA9", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("c11902ff-0016-a41f-f70c-bd7c609b21a9"), 0 },
                    { new Guid("9b0f13bb-da79-4eb0-ab21-31e9c8758582"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SDC4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("100fad06-16c8-4414-c174-e13fea8cb2fc"), 0 },
                    { new Guid("9b499e6e-3d81-3f0b-9d33-6b539ec64c05"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("d853256f-f806-027b-6a6e-f88e4cd6934d"), 0 },
                    { new Guid("9cb4d1c5-2d2d-575c-cef5-908a1143a23e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA0", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("61e49e59-d8a7-73cc-2af6-2752ac681a07"), 0 },
                    { new Guid("9e810441-b0e2-95b2-48c0-b3b83f3c7efe"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), 0 },
                    { new Guid("9ecddf88-5854-19c6-941b-a3656a35309c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB7", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("f7cb1073-9761-3a61-94f9-da0f2a35fafc"), 0 },
                    { new Guid("9f75746d-055a-80de-ba93-4c501cfdddc8"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA1", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("3d0d6e4e-acd9-ac84-f3ff-d59bb8b20ee5"), 0 },
                    { new Guid("a07e3eb9-9d2f-87b2-8922-a37fd5e87096"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC5", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("b17feeff-4c72-f522-f518-8a9d9e9cfeb7"), 0 },
                    { new Guid("a19316b8-b4a9-893a-df2b-20fb321b0ae7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA4", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("87ed6cf3-abb2-9db7-f086-eb1f41694af5"), 0 },
                    { new Guid("a1e7d651-184a-469e-5423-f0a0277a1613"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SEA6", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("2c64fd17-18a8-960d-d692-7d5320ee55b5"), 0 },
                    { new Guid("a2283fed-c506-2469-d28f-2cf0722621a0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA3", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("367c27df-38a5-07ff-fbd4-58f47fccb93d"), 0 },
                    { new Guid("a4113579-8c20-c008-7716-77df06446783"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA8", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("766adbf4-3f36-6af7-22ae-bffa913d3731"), 0 },
                    { new Guid("a49d7958-dd66-f796-31aa-3505d663d211"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF8", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), 0 },
                    { new Guid("a5462fbc-3d47-f70b-fe72-8b3655610640"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SZA1", new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), new Guid("8b3d4ad1-02c9-ad37-a7f1-27bd455de3e7"), 0 },
                    { new Guid("a582d67b-ff57-8772-47e0-1c07b74fbb58"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB4", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("96001da6-037c-1fa0-c31e-2a5070fbe98d"), 0 },
                    { new Guid("a7ee0964-13a3-268c-af10-22956a5d1a5f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA7", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("6c0c54d1-80b4-cc2a-82e8-6eec3c9a5fbf"), 0 },
                    { new Guid("a93d9adf-decb-3125-e672-1d5817be920b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB9", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("6223813a-0668-c81b-b474-b30d32cad4fa"), 0 },
                    { new Guid("aa115d52-e335-ca81-3a3c-288ccc0996ba"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SDC0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("7caf4232-348d-c985-0af1-b7b1d2d73061"), 0 },
                    { new Guid("abfeb91f-84d4-e427-fbb4-616d2e22d52b"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SBE0", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("ef085ee9-ed78-1dfa-9422-ba734c96f4ce"), 0 },
                    { new Guid("ad1fed7f-eb57-61fa-0456-9ea878e203c0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB0", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("6437eeb2-65a3-7ebe-9c80-f4e6d9268f4b"), 0 },
                    { new Guid("ad7c024f-773e-11dd-e04a-d06b4b687bd4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("979f35a3-7d45-2a14-8d7b-68e4916362b1"), 0 },
                    { new Guid("adf4cb53-73e9-b516-068a-76b83c8123a3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SDB4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("667126e6-1cf1-4a67-4adb-ee90acbec830"), 0 },
                    { new Guid("ae107f4a-9871-4bb1-e9ea-02ef087b5a8c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SCE1", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("b7e590b0-a70b-13f1-e787-e8e4b08f3a17"), 0 },
                    { new Guid("ae504275-0996-472f-9399-7006a4aa3334"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SDC1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("cb76d211-8000-c24f-6436-1fda0a7a72c6"), 0 },
                    { new Guid("b07723de-a3b7-fc43-43b2-6ea7dfd33d30"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SBC1", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("eb197acc-0080-782a-224b-981ca7ea89c1"), 0 },
                    { new Guid("b25fc872-6ead-1911-29be-30d40619da23"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SDE4", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("3e83df23-855c-c82a-7f41-23d6b93d896f"), 0 },
                    { new Guid("b44894a0-54d4-a0af-f728-9eef9f5865d1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB1", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("177e44a6-40d3-a37c-01d6-556565feb02d"), 0 },
                    { new Guid("b7add85b-5f70-8a5f-6e54-ea0cca3c7f3d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC0", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("47b0f560-3284-b088-5956-6331a97f4eb7"), 0 },
                    { new Guid("ba1dad4d-3053-a600-cd64-29f10c586c2d"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SZA2", new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), new Guid("38f2b63e-81cc-9512-23c6-82680d089a8e"), 0 },
                    { new Guid("ba82e7ca-04b6-6f82-c07d-76a8e22713c0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("f9c99ecf-6041-020a-18e9-e53e6d5567b5"), 0 },
                    { new Guid("bda99ce1-d2bf-ada5-0624-cd0ac74ebfdb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF1", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), 0 },
                    { new Guid("bdb50edb-65f8-1ee6-5501-c0d21675db91"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("532fadc7-59d1-96ac-d141-de146d7d7d0c"), 0 },
                    { new Guid("bf94e218-2a7e-311b-53b6-11a75df863d4"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA9", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("4ac370ab-76bb-6ac6-2fbc-483cca51e34e"), 0 },
                    { new Guid("c0fd3294-1769-6cf7-6683-9fbd35f50dd7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE2", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("4ddd6819-463a-a7c4-de10-5bd7acd77e74"), 0 },
                    { new Guid("c16158c7-ac32-05b1-81ea-3613d776d54e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA7", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("083eba27-3a25-7389-1b8a-eeff10ddf639"), 0 },
                    { new Guid("c1c0c81e-4c16-5c2f-049e-8662d151f861"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("d4159429-1001-086c-e775-0f446429455b"), 0 },
                    { new Guid("c1cd8e47-1e11-97d9-c69e-eedfa71c0527"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SDF3", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("fdabb0d6-ca0f-f7b5-b140-c0bf7fa6e457"), 0 },
                    { new Guid("c2b129b1-2c7c-1bca-ae65-4bd5e5883a40"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE1", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("3a25f7f1-814f-d789-5a9a-b3bff5bd2272"), 0 },
                    { new Guid("c502a360-08ed-ead5-bd4b-624d2b6d3bc9"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB5", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("444d8544-a569-5b88-c0a6-fc16359fdb43"), 0 },
                    { new Guid("c5915262-4520-1ae9-f5ab-8ff59b5b84e2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SDA2", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("bd168e79-34ef-defb-67b9-addf99a2ed61"), 0 },
                    { new Guid("c6518ff6-b22e-0cf2-bbfd-5cadd48626b3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SDF1", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("6f1c3257-65bc-3fc2-0d96-f2270818c243"), 0 },
                    { new Guid("c66a3903-0142-6e89-d34f-ae11d133e52c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA5", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("49254e06-8a1f-369d-9554-89c3710780c0"), 0 },
                    { new Guid("c7e7e58f-16ef-40f3-295f-a6b57935b70a"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b6c65425-5384-77e4-2ae5-8eabfab10acc"), null, null, "SFF2", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), 0 },
                    { new Guid("c8830411-dd8c-729c-bace-560de46e6ab7"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB7", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("97189e8d-7248-e7ff-be48-c990b45467d2"), 0 },
                    { new Guid("cb896f3a-7a91-607b-d1e8-f00732790f19"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SAA8", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("6e6ea87c-c14c-28a0-6c17-34537a6401c2"), 0 },
                    { new Guid("cbf47abf-61e2-87c7-29e4-4dcd51851c58"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6e446396-13b7-a81e-ab4d-29f9575f8a02"), null, null, "SAD0", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("64d5cc82-851f-5bb9-e975-06ec20ac2f29"), 0 },
                    { new Guid("cd6ad330-1058-dc56-054d-7e742ba51688"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA3", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("bc36b67f-0c9d-e8b7-c996-e07c64606816"), 0 },
                    { new Guid("cd78f850-0988-602e-c214-aab5bf8841a1"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SAE3", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("e6fe0727-2c8a-cfc8-36c0-091ca71ffefd"), 0 },
                    { new Guid("d048de56-cd26-ccfc-f4c9-802461deadac"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SFA4", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("3206db36-1787-d97a-a714-757234bdbf92"), 0 },
                    { new Guid("d1c1b035-36ac-25fb-26ad-7c9887614f03"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SCA2", new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), new Guid("c5a044fc-fcd7-3b40-cbb8-8479134e2166"), 0 },
                    { new Guid("d1e60832-3382-d5df-6b2a-5d9c980aa314"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB8", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("dee2cc29-abed-6701-7d6f-f6e77e70c946"), 0 },
                    { new Guid("d5022f7e-92a7-a456-49a1-44b39a866059"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SAB8", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("193dc2da-1cc4-3db0-47f8-c2c78f876b3c"), 0 },
                    { new Guid("d8893298-33b5-7d67-aad4-61081c50a8ca"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f8c5cafe-ab0f-03d9-2474-d560a4c4fd0d"), null, null, "SBE1", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("f37491e8-cf8e-7efb-2481-5cacb51d08db"), 0 },
                    { new Guid("d961b082-5a81-338c-3242-a5ab9d8669ae"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SBC2", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("fb6ddd6a-23bf-17d2-7231-716f781284ac"), 0 },
                    { new Guid("dc98347f-605e-2894-f61c-76b66eb2f5b3"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("cce2e4bc-9165-9a86-8cfd-b9d9a1a156ad"), null, null, "SFG6", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("a3255bde-c016-e7bd-dfd5-ece3d268f4b6"), 0 },
                    { new Guid("e286a025-71a9-e428-01d2-ea6ea600bcdd"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB2", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("dec1f540-3b36-ea22-6606-6445c84d94bf"), 0 },
                    { new Guid("e2fae906-9eea-1441-9991-bfa44a75deaa"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA2", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("d05d2203-7950-471d-3c33-c2f6e15fa8ae"), 0 },
                    { new Guid("e5b01f0e-9744-4385-1a24-1defa642eac2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB0", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("d8b4af9d-acb1-e176-a669-a25f528d66f7"), 0 },
                    { new Guid("e76589d8-fc8b-3335-c0c0-c1541a51e99c"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SFC5", new Guid("e36337f1-7967-db93-2e0d-242546697931"), new Guid("3de991f3-d7bb-c3d2-fdca-1e6dad2ee7a0"), 0 },
                    { new Guid("e93f58cd-b9b8-37f6-42cf-7f6dd8725f93"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SEB5", new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), new Guid("a0f09874-28c9-5d1b-2e46-c61e4c715d55"), 0 },
                    { new Guid("ebecf69e-4239-8f50-6f23-9e8d45d455c2"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SAC6", new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), new Guid("ccccede8-01a0-7c98-1cc6-7988bcb97eca"), 0 },
                    { new Guid("edb801d5-ce25-247d-bbf3-1bbd4a07f795"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA5", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("ddef3f12-bc30-1271-8c14-e85d250a2e61"), 0 },
                    { new Guid("eeed91d7-2d7d-5eea-0357-966a6c66dcf5"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SBB4", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("117e023c-61a0-9e16-ab8c-4abc262f756a"), 0 },
                    { new Guid("f0ff8a3c-895e-6696-51c1-0ea6206f0637"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8d9a8c60-96f0-8397-d386-d28a4227af6b"), null, null, "SDB0", new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), new Guid("52d95acc-15cf-8721-6bed-2ba2c5e72d1e"), 0 },
                    { new Guid("f1243469-9331-e4d6-5c4e-32845118f4ce"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SGA0", new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), new Guid("d15a1b67-23ec-9555-56d7-9f908dab6e9b"), 0 },
                    { new Guid("f269d282-ef7d-2f17-bdad-d2c2ced5364e"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SZA3", new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), new Guid("a87a3b44-044d-5e71-b124-c0d744923397"), 0 },
                    { new Guid("f6cc930b-e329-4437-7d5a-819ce239f6bb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA7", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("ea3f2984-915d-9dad-b49c-9bb2ab690518"), 0 },
                    { new Guid("f8cb0523-24e5-7a5e-baac-ca6ff00194fb"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SBA9", new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), new Guid("ccd15e05-5340-f6b0-273a-353cd2f7becc"), 0 },
                    { new Guid("f9908473-edd3-4672-62a6-628f2c12aa98"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("340bada6-6b5b-b564-9a22-7e0fdfefa847"), null, null, "SHC5", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("ed59512f-6538-0cc0-bccf-e46e4133dd41"), 0 },
                    { new Guid("fe9af540-2cde-8f09-b591-a75037673ba0"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA8", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("f0a0d69d-89e4-9e49-e13f-8a5d19251040"), 0 },
                    { new Guid("fec3d7ac-9fb9-8b80-7049-facb4138751f"), "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("fad96a11-7e74-b43f-cf73-05634c562ed4"), null, null, "SHA1", new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), new Guid("bc67cdb5-076a-ce40-5b3d-a6bc8d2822ef"), 0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("021a75cd-6761-4a71-b947-d58a2b78b6ea"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2167), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("03f45fc5-b15a-4d38-99a4-794c69bd6f07"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2063), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("0413bee2-bc1a-4cbe-968f-872906c2c3a4"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2169), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("0db2f3ce-f13b-460b-95d0-cd4956e708d8"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2071), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("16b4380d-8ac4-41cc-adee-54667d04bb4f"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2097), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("1a01a921-bdb4-4a6a-8524-aafccc5ec78f"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2038), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("289c9377-8225-4c3b-9b98-7165109b79aa"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2144), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("37b4ed67-63c6-41bd-94eb-1ffd4819002a"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2142), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("3ce62f0f-a506-42c3-a633-a3f6e5a6b0a9"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2152), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("3ebc33f7-6cf4-4e1f-9273-8b0344b17853"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2163), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("51e671f9-4e99-4266-b96c-bda0a9652d1f"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2083), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("54922285-a9df-4338-816f-8dd56972da22"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2055), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("69709db0-ea11-4ce4-bf01-2f2ca390972a"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2080), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("6b06f745-7e1a-4906-bf3a-c68c705b0e80"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2150), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("6e20ec76-db10-4c13-98d6-34b2eab48f0c"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2106), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("6fc8d99a-cb83-49e4-b2e3-bdb24050a15f"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2155), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("6fdec7c1-2f0d-42b3-83d0-2dce2436c90d"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2095), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("7861635b-1c70-4a7f-bba6-cb481d1869e8"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2060), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("7a0ecbc1-d2d6-4957-8adc-76e686762609"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2165), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("7c793072-47e1-4825-937b-402a8bc2e8c8"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2065), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("813c076b-395a-44cd-87f6-9a45c5637dba"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2091), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("85f7a489-fcac-4f67-ac5e-3d27ef7f1ab8"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2162), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("8740e56e-3c1b-4e9f-a5c7-5154ba6f1164"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2093), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("8a54d229-53f8-4461-9c83-240c73fb2675"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2076), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("9285ad1d-ea9d-47ed-b6fc-2f8907628c76"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2045), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("9baefe3a-0c06-4fa0-aa97-2441bf2d2720"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2081), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("9d94fd6b-ee10-47a0-88f3-84210dcd06ea"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2069), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("a115e1eb-9d76-4b9c-a7b8-5984f1d9423a"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2075), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("a90fe17b-f01e-45ec-badb-4c5d6af39b88"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2159), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("a9404229-0fd6-482e-be94-731e16ed4ee7"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2049), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("ae02543e-5cdd-46b4-a72a-5d9ec08db7c4"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2088), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("b5f83e94-8cff-4121-a96c-0124db0eece2"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2113), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("bdf383d0-0469-4d1a-9fe4-cef8502099eb"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2051), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("bf6ac95e-cc78-40e6-93f5-aa9a406677a9"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2115), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("bfbfc486-5d27-441f-9302-524f69c91ce3"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2149), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("c2c73245-b604-4dbb-a34a-8bbf24a4dfd4"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2084), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("c3413022-c7f9-45a8-a2bf-7ee912d10115"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2098), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("c472bf6f-cba2-4526-9dc1-3deea6794203"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2047), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("c74f8440-0686-40de-bc9a-a7414687ffbb"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2116), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("c8d2a15c-35ba-4a44-9c82-2a80d5cd2093"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2057), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("d0f83ce9-5518-4c83-888e-cf3bcc90b09c"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2156), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("d1dbcb89-9dee-4f8b-b93a-dc838efd5f28"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2058), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("d3205e38-8090-4c26-ad85-bf2bc7f1f128"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2100), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("d832d73d-5c06-46b6-8986-93f1f9b22032"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2073), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("e7747136-efa6-4cb0-9077-c62a54bdab95"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2147), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("e992bdb5-b6f5-4930-9bc3-db2b34c88908"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2067), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("e9f11a77-3500-4106-a91b-b10e9f244e68"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2111), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("f0303a05-9de9-40fe-8c0a-fd5718d9a5c3"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2103), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("f438cb0c-17c3-475c-90e2-813e76d99771"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2104), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("f8df3720-008f-42ef-bdfd-99cc0e79b06c"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2087), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("fa66ac44-65a0-48a6-aff3-3efad6490069"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2107), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("fb4b75e3-4e67-4ab6-affe-850a3c93e988"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2119), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("fbff15bd-21c0-42cb-a089-163dd047fe10"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2120), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("fc1ecf9d-21a7-4507-999b-bd68dc36533a"), "SeedData", new DateTime(2026, 2, 3, 15, 6, 34, 813, DateTimeKind.Utc).AddTicks(2158), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 }
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
                name: "IX_StockCards_FluidId_SProductGroupId_SProductId_Prefix4",
                table: "StockCards",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId", "Prefix4" },
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
