using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v33 : Migration
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
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4293), null, null, 7850.0, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0 });

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
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4314), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Standard plate form for P355NH", "EN 10028-3", 0, 250.0, 1.0, 1.5, null });

            migrationBuilder.InsertData(
                table: "SProducts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "PrefixIndex", "SProductGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("07869504-adf4-2e9c-a77c-1392271719c6"), "C8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("0a562b70-f1ef-5bb6-0e5b-072ec5646ada"), "C9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("0bf19af3-89e8-a449-1711-e469dfe45171"), "E1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("0c7c8c5e-ba44-87d2-e68c-c29b874741b1"), "F9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("0cebb1d1-3687-2696-0453-36816e1ef6b1"), "E4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("0d7c5031-91bf-0803-d4b2-fad9cfa48922"), "Z1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("112bfab2-e126-35ef-9746-9b4cc53d0fad"), "H6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("117e023c-61a0-9e16-ab8c-4abc262f756a"), "B4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("136ccea1-4997-9653-5e42-1ee394b28827"), "B9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("15965458-2450-9a6a-db03-90adc5e4cd2c"), "Z4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("174a2516-dd50-e5ac-684c-64dbd56a60d1"), "H5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("1778dc56-8f34-b9d8-861a-126b4c623ce5"), "D5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("177e44a6-40d3-a37c-01d6-556565feb02d"), "B1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("18905295-d4f1-92cf-159a-0584871092eb"), "B0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("18d60e82-7c26-e97c-5ccb-47e4bd390f22"), "Z3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("1d73997a-c7ef-14dd-1924-c0a15fe3a84d"), "C1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("20c181aa-1e2c-23ee-456c-71c48889419f"), "G2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("2bdeeeb4-881c-60e3-eaf6-785f58f9581d"), "F8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("2c726f47-6c5e-5b26-7c54-e5243b1d3cb2"), "B3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("367c27df-38a5-07ff-fbd4-58f47fccb93d"), "A3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("3a8b39a1-3516-eb74-c13d-1407ea38d286"), "C4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("3badcf1e-9eee-c4a5-84f0-767a1c7708fd"), "C5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("3da5522d-7c31-14d3-f0f0-768df252e92f"), "A7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("438f68a2-8bdd-9be7-9b69-5fd4b4a68875"), "B6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("49254e06-8a1f-369d-9554-89c3710780c0"), "A5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("49a451e6-dc19-d6ef-2427-9cb1af599635"), "G6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("4ac370ab-76bb-6ac6-2fbc-483cca51e34e"), "A9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("4f333fdc-4333-4914-6a0d-9b9abdf304a4"), "D7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("501e2963-96f2-64f2-36b9-3695459b74ad"), "G3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("50fea148-89c7-30c6-b9f4-1ef6b75e1546"), "E6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("541b451a-a990-338a-8bfb-1dbce7a10125"), "A1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("58ee14e9-0ad8-eceb-0b70-fd7ec56dcb5b"), "C7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("5969b997-be8e-7379-49f2-29e50c47214a"), "F5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("5b511e3f-7b80-2153-d900-56f6f6bae46a"), "D2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("60e327c2-5e10-fda5-97df-1eefd0e631cd"), "H1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("630620f8-22dd-2d86-1e64-01917e2a3d5e"), "F7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("63886412-0c68-3b65-a4b7-59c82c286c7a"), "G1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("65c7b15a-fc48-fc25-fcd5-05cfd6c83ccc"), "Z2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("697cf80a-b06a-c5cf-204c-914210302181"), "F3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("6e6ea87c-c14c-28a0-6c17-34537a6401c2"), "A8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("704a9881-4365-e5af-1012-67faac58fdec"), "H0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("7b3ac40f-6fb1-9108-6079-8ee98558ebcc"), "B2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("7fae0826-2b18-2218-a9e7-50dfaf6e43c8"), "G0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("828baa99-21bc-afe0-b5c4-d8e9f562cbaa"), "D0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("844f9b63-72b7-f634-3f6d-33eb46b4cd74"), "D1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("88cb5d5a-4124-86f0-8d8e-6a99927f6387"), "F2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("8db6c73e-9763-7e83-509e-07a08dbff7d2"), "E5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("8e133ac0-47b3-64c8-5a57-979025e331bf"), "A0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("8e4b467b-e11b-84b8-2765-a4e130670c50"), "E8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("8f5ad3f6-b48f-3c18-b581-3c3b9f08dd4a"), "H4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("908f658b-1d87-bf50-e065-2456f6eb1847"), "A4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("93f0410e-4d2a-91ee-ae47-3521cf19469e"), "F6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("98d273fd-61c5-4a9c-ddbc-b54fd53a8338"), "G5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("9a7cbb4b-a582-5a24-22f4-67ff8806a726"), "C6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("9e58a97d-6755-595b-d239-539aaef05ce9"), "G4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("2a21da1e-4ead-f7ba-ae7a-da4a7302bfb5"), 0 },
                    { new Guid("a28c2b2a-ed47-c459-fdd2-a747693bf999"), "H3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("ab4e24b7-788e-de5f-e7b9-cf34ef51753d"), "H7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("abce0c5d-01ca-afdc-f53d-8f858d4481ed"), "E7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("ad5f341a-f2dd-f5b2-5188-93f9239a3231"), "E0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("addc1b17-517b-327d-c5c7-9de15e5741b0"), "F4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("af33897a-ae25-a1bb-986e-e40cd4d8db95"), "C3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("afd1908a-73b3-679e-3901-94b15e4970f4"), "A6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("c2ba78dd-4f60-c7a1-ab68-fc31ae06f99d"), "E2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("c4451f2a-1b24-ce27-8ec1-f1b34078961b"), "Z0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("ebef5bc7-149c-df51-376b-5a741c7944c6"), 0 },
                    { new Guid("c8593c41-39af-f7c8-6647-36814c6f63e4"), "H2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("cb7f7456-8a37-e22b-e356-15d3c28b965b"), "F1", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Emniyet / Relief Valfleri", 1, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 },
                    { new Guid("ce94aa75-f4b3-8529-7e92-77f4325e1900"), "C0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("d5d4c070-86e1-40d7-2b48-787b4327e185"), "C2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("a64be34f-a9e9-807d-5a36-98d9cba07f0e"), 0 },
                    { new Guid("de414254-687f-71b9-cd00-043f805c78d3"), "E9", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Diğer", 9, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("dee2cc29-abed-6701-7d6f-f6e77e70c946"), "B8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("e3cc2b0c-589d-3721-7999-286b250e97e5"), "E3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("60264c1a-09bf-78bb-c79a-d22015d5a889"), 0 },
                    { new Guid("ee23ec5e-db4c-6bbf-5fbd-532f82c0fe99"), "H8", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Bağlantı Elemanları / Fittings", 8, new Guid("b43750d3-04ec-8f05-4b24-189e79142179"), 0 },
                    { new Guid("efa50840-b929-33a3-b3a2-d0cefa2edb4c"), "B5", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Filtre / Strainer", 5, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("f17d0e4f-443e-41ee-1e2d-b334b53a0647"), "A2", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Regülatör", 2, new Guid("87dc6bec-5d3d-6f46-ac7a-0e37de723335"), 0 },
                    { new Guid("f1ad1052-860a-83a4-09eb-e80a768e9646"), "D6", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Manometre / Basınç Göstergesi", 6, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("f21a548f-cce9-df44-f320-5176fe4b478d"), "D3", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Seviye / Gösterge", 3, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("f4b123da-b8a6-3b97-a001-693b0266114e"), "D4", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Check / Excess Flow", 4, new Guid("9fc398c5-6d04-4186-6e11-e48d26aba256"), 0 },
                    { new Guid("f7cb1073-9761-3a61-94f9-da0f2a35fafc"), "B7", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Termometre / Sıcaklık Göstergesi", 7, new Guid("7589ae70-1766-4a48-83b8-03edb7807ac6"), 0 },
                    { new Guid("fb3fb765-6013-41a4-e0f8-f46bff05077a"), "F0", "SEED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Vana / Valfler (Globe vb.)", 0, new Guid("e36337f1-7967-db93-2e0d-242546697931"), 0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("00936626-acb5-4ed6-afa5-bb52df68715a"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4380), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("06575926-f44d-4c1a-a4b5-b36913012197"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4431), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("07c085c3-af08-4a8a-8159-60e88737b5d2"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4414), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("093541ea-818d-4bbb-b400-66f93ad67c99"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4408), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("09c750a2-f656-4922-ac32-ed8619d0f12a"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4472), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("1aa5b62e-47a1-4c32-8598-38d4caa2e358"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4389), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("1b12f380-2152-4cbf-a25f-e9d3dbd44ca9"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4374), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("1f0f29d3-7881-47fa-8a63-41e101d42906"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4426), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("1fb15df1-2943-45f4-93af-6ece003d290c"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4385), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("203bb889-ba1c-4f2d-b3ce-f3ba190688b1"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4489), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("2823384a-bea9-4ff8-850c-f2310e3080f6"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4480), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("2929ae09-2697-4b84-93be-55d8077a5bd2"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4372), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("298f2ff3-bc49-4d03-ae4c-65a5036414f5"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4394), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("301ed8ef-41ff-47db-bab8-6246ed105306"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4440), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("3048108c-5164-4ed8-9f86-c82695d7e0dc"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4363), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("349ee51e-0655-43ce-8bfa-5b38b3fd09a5"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4381), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("3aa9a8ec-b7d5-4763-9b3c-8eed8fbfa808"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4424), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("4247c01f-f55e-4552-aa66-2766fe7001e8"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4420), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("45dd9de5-5797-4b9a-8dd1-ebde58bf68c6"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4416), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("48179f7e-a282-4e16-b3a9-add6caa0e439"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4475), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("4ec7003e-2f51-4bf0-abca-075287726189"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4405), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("591f6adb-45b6-49cb-ae67-440f3d35952f"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4400), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("5fdf53af-95c0-4c38-b62d-27ab3b0b1105"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4418), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("602f2c17-15ac-4d0b-986b-74e307392b24"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4406), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("608897e0-7a6d-4216-a0e3-bcd465de2761"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4439), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("62d84253-25bb-487a-9677-a0c34aba72fa"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4468), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("694ec5ac-a183-40ed-beef-07deb61bd856"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4371), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("716a778c-c7a6-461e-bab3-3fce83c55896"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4437), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("73914074-98b4-4f9a-afd6-85fdba8f99d3"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4485), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("759b3be7-215a-45d4-b735-c5a62d805589"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4383), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("776f6865-af0a-42a3-9f53-38fc449ea436"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4350), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("78b9551a-8829-4694-a18b-e0b0ea7d7797"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4410), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("7fbe7cde-fad5-434b-8796-1bc0680ba950"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4429), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("85549c41-f177-4595-986c-866ef486a0ac"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4398), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("95da8362-b496-4ac9-8182-17568bc97019"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4487), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("96eea502-15a5-4c95-aca1-58b2c56400c3"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4353), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("a06ca5be-25e6-4d95-ad61-3e906df6c5b1"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4377), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("a2806160-952b-4793-ae41-6938903203c0"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4470), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("a6c548d4-3b76-4b1b-ad22-b0d8d3e73840"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4402), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("a9bce915-632f-4238-9325-dc4f2e597211"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4397), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("b056b9e8-e59c-48ea-bdfb-a68c2193b441"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4361), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("b2ca4063-98c4-4990-b26f-c4d96d1b1b2a"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4434), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("c4c7db89-7cc5-426e-ae36-3f92ae71bb91"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4467), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("c58e8169-f0e5-4c7a-8f56-299837825450"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4391), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("c6b1e7d4-b4bc-4ebb-be0b-467575eebea9"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4483), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("c710e01d-b114-4403-9e9d-2b216f8cf4a2"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4433), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("c874c363-19ba-4486-9dd3-1eb8d143e755"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4413), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("c9731deb-6d4c-43b0-82f7-4692c8e79b57"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4477), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("d634060d-576f-4ebd-974f-38c9d748f2cf"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4365), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("d676f2ac-71e2-410a-9c1c-6aa6c3ecf171"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4442), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("dba86ad9-417d-4e84-a3ae-ffe99485cc64"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4479), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("ecb0cbab-8cba-4a60-bff6-975cf42fad91"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4367), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("ed8c1f28-ada8-4bf4-9879-749eec8d36fb"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4388), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("f526071d-95e3-45e6-82e9-5a82f32c80e0"), "SeedData", new DateTime(2026, 2, 3, 16, 53, 8, 484, DateTimeKind.Utc).AddTicks(4422), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 }
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
