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
                name: "BombeLaborRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RatePerKg = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_BombeLaborRates", x => x.Id);
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
                    ContactPersons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainDealerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "EmployeeProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CanAccessSalesArea = table.Column<bool>(type: "bit", nullable: false),
                    CanManageSalesCustomers = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateSalesRequests = table.Column<bool>(type: "bit", nullable: false),
                    CanViewSalesPricing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeProfiles", x => x.Id);
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
                name: "GugHourlyRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_GugHourlyRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_LaborRates", x => x.Id);
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
                name: "OverheadRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OverheadType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_OverheadRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestProductGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestProductGroups", x => x.Id);
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
                name: "SalesRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedByName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RequestedByEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RequestedByDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequestReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeededByDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestSource = table.Column<int>(type: "int", nullable: false),
                    ShipmentCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallationCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTransportByCustomer = table.Column<bool>(type: "bit", nullable: false),
                    SummaryNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    CustomerQuoteStatus = table.Column<int>(type: "int", nullable: false),
                    OfferStatus = table.Column<int>(type: "int", nullable: false),
                    RevisionNo = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SalesOpenedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricingCompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SalesRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "SalesRequestAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestAttachments_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CommentedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestComments_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentSalesRequestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CapacityM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumptionCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequestCategory = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignStandardCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignPressureBar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TankType = table.Column<int>(type: "int", nullable: true),
                    StorageOption = table.Column<int>(type: "int", nullable: true),
                    TransportOption = table.Column<int>(type: "int", nullable: true),
                    StdOpsSelection = table.Column<int>(type: "int", nullable: true),
                    SpcTechnicalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmbientTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmbientTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityInletPressureBar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacilityOutletPressureBar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacilityInletTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacilityOutletTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacilityCapacityNm3h = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HasPump = table.Column<bool>(type: "bit", nullable: false),
                    PumpDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasElectricHeater = table.Column<bool>(type: "bit", nullable: false),
                    ElectricHeaterDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTankConsumptionCapacity = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalQuestionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankOrientation = table.Column<int>(type: "int", nullable: false),
                    PlacementType = table.Column<int>(type: "int", nullable: false),
                    MinimumTechnicalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SalesEngineeringNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DesignDetails = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    LinkedCalculationType = table.Column<int>(type: "int", nullable: true),
                    LinkedCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkedCostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkedCalculationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LinkedCostAnalysisRevisionCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LinkedCostAnalysisTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinimumSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SharedSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoldSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequestItems_ParentSalesRequestItemId",
                        column: x => x.ParentSalesRequestItemId,
                        principalTable: "SalesRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequestProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "SalesRequestProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestRevisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionNo = table.Column<int>(type: "int", nullable: false),
                    RevisionReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SnapshotJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevisedByName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RevisedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestRevisions_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
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
                name: "SalesRequestDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    RevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    LinkedCostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkedCostAnalysisRevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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
                    table.PrimaryKey("PK_SalesRequestDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestDocuments_SalesRequestItems_SalesRequestItemId",
                        column: x => x.SalesRequestItemId,
                        principalTable: "SalesRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestDocuments_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD2000CostAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD2000CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionNo = table.Column<int>(type: "int", nullable: false),
                    RevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    HeadBombeLaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AD2000CostAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AD2000CostAnalyses_AD2000Calculations_AD2000CalculationId",
                        column: x => x.AD2000CalculationId,
                        principalTable: "AD2000Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD2000CostAnalyses_BombeLaborRates_HeadBombeLaborRateId",
                        column: x => x.HeadBombeLaborRateId,
                        principalTable: "BombeLaborRates",
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
                    InnerHeadBombeLaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OuterHeadBombeLaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_EN13458CostAnalyses_BombeLaborRates_InnerHeadBombeLaborRateId",
                        column: x => x.InnerHeadBombeLaborRateId,
                        principalTable: "BombeLaborRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458CostAnalyses_BombeLaborRates_OuterHeadBombeLaborRateId",
                        column: x => x.OuterHeadBombeLaborRateId,
                        principalTable: "BombeLaborRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AD2000CostAnalysisItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD2000CostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AD2000CostAnalysisItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AD2000CostAnalysisItems_AD2000CostAnalyses_AD2000CostAnalysisId",
                        column: x => x.AD2000CostAnalysisId,
                        principalTable: "AD2000CostAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD2000SalesPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD2000CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD2000CostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GugHourlyRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinanceOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralManagementOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborHours = table.Column<double>(type: "float", nullable: false),
                    ProfitPercentage = table.Column<double>(type: "float", nullable: false),
                    LaborCost = table.Column<double>(type: "float", nullable: false),
                    GugCost = table.Column<double>(type: "float", nullable: false),
                    ImmCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam1 = table.Column<double>(type: "float", nullable: false),
                    FinanceCost = table.Column<double>(type: "float", nullable: false),
                    GeneralManagementCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam2 = table.Column<double>(type: "float", nullable: false),
                    MinimumSalesPrice = table.Column<double>(type: "float", nullable: false),
                    SalesPrice = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_AD2000SalesPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_AD2000Calculations_AD2000CalculationId",
                        column: x => x.AD2000CalculationId,
                        principalTable: "AD2000Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_AD2000CostAnalyses_AD2000CostAnalysisId",
                        column: x => x.AD2000CostAnalysisId,
                        principalTable: "AD2000CostAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_GugHourlyRates_GugHourlyRateId",
                        column: x => x.GugHourlyRateId,
                        principalTable: "GugHourlyRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_LaborRates_LaborRateId",
                        column: x => x.LaborRateId,
                        principalTable: "LaborRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_OverheadRates_FinanceOverheadRateId",
                        column: x => x.FinanceOverheadRateId,
                        principalTable: "OverheadRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD2000SalesPrices_OverheadRates_GeneralManagementOverheadRateId",
                        column: x => x.GeneralManagementOverheadRateId,
                        principalTable: "OverheadRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "EN13458SalesPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GugHourlyRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinanceOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralManagementOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborHours = table.Column<double>(type: "float", nullable: false),
                    ProfitPercentage = table.Column<double>(type: "float", nullable: false),
                    LaborCost = table.Column<double>(type: "float", nullable: false),
                    GugCost = table.Column<double>(type: "float", nullable: false),
                    ImmCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam1 = table.Column<double>(type: "float", nullable: false),
                    FinanceCost = table.Column<double>(type: "float", nullable: false),
                    GeneralManagementCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam2 = table.Column<double>(type: "float", nullable: false),
                    MinimumSalesPrice = table.Column<double>(type: "float", nullable: false),
                    SalesPrice = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_EN13458SalesPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_EN13458Calculations_EN13458CalculationId",
                        column: x => x.EN13458CalculationId,
                        principalTable: "EN13458Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_EN13458CostAnalyses_EN13458CostAnalysisId",
                        column: x => x.EN13458CostAnalysisId,
                        principalTable: "EN13458CostAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_GugHourlyRates_GugHourlyRateId",
                        column: x => x.GugHourlyRateId,
                        principalTable: "GugHourlyRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_LaborRates_LaborRateId",
                        column: x => x.LaborRateId,
                        principalTable: "LaborRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_OverheadRates_FinanceOverheadRateId",
                        column: x => x.FinanceOverheadRateId,
                        principalTable: "OverheadRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EN13458SalesPrices_OverheadRates_GeneralManagementOverheadRateId",
                        column: x => x.GeneralManagementOverheadRateId,
                        principalTable: "OverheadRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7847), null, null, 7850.0, null, "Fine grain pressure vessel steel", "1.0565", null, null, "P355NH", "Normalized delivery condition according to EN 10028-3", 0, 0, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7851), null, null, 8000.0, null, "Austenitic stainless steel", "1.4301", null, null, "X5CrNi18-10", "EN 10028-7 stainless pressure vessel steel", 0, 0, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7866), null, null, 7850.0, 206000.0, "Structural steel", "1.0038", null, null, "S235JR", "Profile material for supports/rings", 0, 0, 235.0 }
                });

            migrationBuilder.InsertData(
                table: "SalesRequestProductGroups",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "ShortCode", "Status" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "01", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, true, null, null, "LPG (LIQUID PETROLEUM GAS)", "LPG", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "02", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 2, true, null, null, "LNG (LIQUID NATURAL GAS)", "LNG", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "03", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 3, true, null, null, "LOX (LIQUID OXYGEN)", "LOX", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "04", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, true, null, null, "LIN (LIQUID NITROGEN)", "LIN", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "05", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 5, true, null, null, "LAR (LIQUID ARGON)", "LAR", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "06", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 6, true, null, null, "LCO2 / LIC (CARBON DIOXIDE)", "LCO2", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "07", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 7, true, null, null, "PROSES VE HAVA TANKLARI", "PROSES", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "08", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 8, true, null, null, "HİDROJEN TANKLARI", "H2", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "09", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 9, true, null, null, "KİMYASAL TANKLAR", "KIM", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "10", "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 10, true, null, null, "GOX (GAZ OKSİJEN)", "GOX", 0 }
                });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "Description", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8236), null, null, 460.0, "Liquefied Natural Gas", null, null, "Methane / LNG", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8240), null, null, 808.0, "Liquid Nitrogen", null, null, "Nitrogen / LIN", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8243), null, null, 1141.0, "Liquid Oxygen", null, null, "Oxygen / LOX", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8244), null, null, 1395.0, "Liquid Argon", null, null, "Argon / LAR", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8246), null, null, 1070.0, "Liquid Carbon Dioxide", null, null, "Carbon Dioxide / LCO2", 0 }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialId", "ModifiedBy", "ModifiedDate", "MomentOfInertia", "Notes", "ProductStandard", "SectionArea", "SectionModulus", "Status", "TargetPrice", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7919), null, null, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Standard plate form for P355NH", "EN 10028-3", null, null, 0, null, 250.0, 1.0, 1.5, null },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7926), null, null, 1, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "Seamless pipe form for P355NH", "EN 10216-3", null, null, 0, null, 40.0, 2.0, 2.2999999999999998, 1.0 },
                    { new Guid("44444444-4444-4444-4444-444444444441"), 400.0, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7923), null, null, 0, new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, "Plate form for X5CrNi18-10 (Cold stretch optional)", "EN 10028-7", null, null, 0, null, 200.0, 1.0, 4.5, null },
                    { new Guid("66666666-6666-6666-6666-666666666661"), null, "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7965), null, null, 4, new Guid("55555555-5555-5555-5555-555555555555"), null, null, 101700.0, "S235JR kutu profil 40x40x3 mm", "EN 10025-2", 444.0, 5080.0, 0, null, 30.0, 3.0, 1.2, null }
                });

            migrationBuilder.InsertData(
                table: "StorageTypeProperties",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Enthalpy_Gas_kJkg", "Enthalpy_Liquid_kJkg", "Entropy_Gas_kJkgK", "Entropy_Liquid_kJkgK", "GasConstant_kJkgK", "ModifiedBy", "ModifiedDate", "Pressure_bar", "SpecificVolume_Gas_m3kg", "SpecificVolume_Liquid_dm3kg", "Status", "StorageTypeId", "Temperature_C" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8267), null, null, 688.0, 200.0, 4.9626999999999999, 1.0, 488.0, null, null, 2.3839999999999999, 0.25041999999999998, 2.4674, 0, new Guid("10000000-0000-0000-0000-000000000001"), -150.0 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8270), null, null, 281.19, 81.790000000000006, 2.4571000000000001, -0.1275, 199.40000000000001, null, null, 0.98999999999999999, 0.2215, 1.2352000000000001, 0, new Guid("10000000-0000-0000-0000-000000000002"), -196.0 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8272), null, null, 367.88, 200.0, 2.3632, 1.0, 167.88, null, null, 12.214, 0.02129, 1.0495000000000001, 0, new Guid("10000000-0000-0000-0000-000000000003"), -150.0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("01568df9-de9d-4dd9-a0cc-19f64a1b5038"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8125), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("06437c5e-adef-4d04-96bc-313fd8444ce0"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8040), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("0b23637c-96ee-40a7-8589-5815c79c5736"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8171), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 214.0, 0, 350.0, 40.0, 2.0 },
                    { new Guid("0ea436c5-3637-41ea-8c63-2d64422da07d"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8015), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("1337feaf-0933-48d4-9df1-7b4a6e7d2c5e"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8052), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("1bd04685-a3c1-4c71-a0a2-ffdb9bd7fe18"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8119), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("1bd431e0-1782-4c21-a833-a7fa86493522"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8006), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("1dcc56ad-50d3-484c-8304-0f55aa9ed14f"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8156), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 355.0, 0, 20.0, 40.0, 2.0 },
                    { new Guid("20616265-89ea-41b4-9948-06125b4eb1f8"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8107), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("249ca84c-6d42-412b-a499-4715398c1446"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8056), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("25be19c1-868f-4f04-a04c-e1c5995dd3aa"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8153), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 140.0, 0, 350.0, 200.0, 1.0 },
                    { new Guid("2a230ed8-70f1-46a2-9a87-3ce970bd9346"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7999), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("2beb3e2c-23be-4edb-b554-79908ae6f671"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8150), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 150.0, 0, 300.0, 200.0, 1.0 },
                    { new Guid("2e206626-f3b6-4386-9711-9d6e1c8108d9"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8032), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("324cd6d0-ba65-454d-849e-ee6909a8a4eb"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8030), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("398d1be4-3e20-4bba-9172-f463cdc8a035"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8046), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("3de9a558-2cfa-4c9f-84cb-82ee218d0e6c"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8013), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("4198655e-875b-46d0-8bac-f05893d3f706"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8131), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 330.0, 0, -150.0, 200.0, 1.0 },
                    { new Guid("44b806ff-9a01-4c71-9b38-58c72d8aecca"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7997), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("47c7cec7-2cf7-4d5f-b66f-4ac79237e2b0"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8128), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("525ade33-2c6a-4fe0-80e4-94eabc858bce"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7996), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("536892c7-c2f7-4e3f-8123-f991ff887b0c"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8162), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 323.0, 0, 100.0, 40.0, 2.0 },
                    { new Guid("551a8bb1-fac6-40d1-93b9-6868d93251ac"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8109), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("55e39ffe-abfd-4849-a5a3-b68f5c9e99af"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8016), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("5648f5a6-ed4d-4b2e-a734-adfdaf5fa5d9"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8158), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 343.0, 0, 50.0, 40.0, 2.0 },
                    { new Guid("5919c6ae-2d35-4551-9650-4d810d36fe31"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8141), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 195.0, 0, 100.0, 200.0, 1.0 },
                    { new Guid("5daf5169-ae01-4fdd-a154-d1ef85264d9b"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8136), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 260.0, 0, -50.0, 200.0, 1.0 },
                    { new Guid("61f2269f-4567-419a-9fed-85bacaa804fe"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8170), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 232.0, 0, 300.0, 40.0, 2.0 },
                    { new Guid("6a29fbab-bed2-4870-9a10-2f14f4fac5c5"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8067), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("6cdf63cd-bbaa-4a6c-adb5-ec0522bb2268"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8070), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("6d441071-a19b-4864-854d-e7a3121a1fe1"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8101), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("70301a17-420e-4a89-8e04-5840961e6f57"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8124), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("732a68dc-3f63-4895-a340-a055d2a8df5a"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8165), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 275.0, 0, 200.0, 40.0, 2.0 },
                    { new Guid("76e1614e-9b7c-4a24-9323-e9bcdc60c74e"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8024), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("77040bd1-90b0-4333-b1c7-98511bcfede3"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8059), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("772de825-199a-4900-83ba-91bdc5fc3d0f"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8007), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("82018083-859e-4040-93b0-4fe0b856b05a"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8035), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("8361307f-6197-42cf-a66d-d3c46b0694f5"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8041), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("83d77825-a716-491f-bbfb-6c4e31d05a89"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8105), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("8913ab48-fcfb-4ae9-af1f-a3aa690e94a5"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8130), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 350.0, 0, -196.0, 200.0, 1.0 },
                    { new Guid("8c21f2fb-0785-4e95-9b33-7dc5391d21fe"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7989), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("92db33ea-3ff1-4f76-9e18-475087602edc"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8023), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("993570cc-67cc-41be-a15a-08d68e1d8ff1"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8111), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("9c217b31-b925-40b0-aaca-85a28f5ac0e1"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8064), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("9dc12a7f-b243-4aef-a0cd-79a2e265c115"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8144), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 185.0, 0, 150.0, 200.0, 1.0 },
                    { new Guid("9e258bc6-a3df-4ea5-baa0-b7ac58991977"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8133), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 300.0, 0, -100.0, 200.0, 1.0 },
                    { new Guid("9f6b52d1-4de5-4b2a-bd0a-ffd62238365f"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8097), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("a06b21f0-e54a-4334-933f-25989452af19"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8154), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 130.0, 0, 400.0, 200.0, 1.0 },
                    { new Guid("a6baa074-6f3c-4a23-9039-ab59e7726d7a"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8027), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("a8b0d0eb-834d-4166-b2a6-f625c23a3dfe"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8117), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("a94ef475-8774-477e-adcf-60606232a9b9"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8115), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("ad83b906-d019-4d6f-a6b1-a6e37db059d5"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8173), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 202.0, 0, 400.0, 40.0, 2.0 },
                    { new Guid("b01c2d59-40f2-4a8c-aa1c-44df4befd118"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8050), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("b2da220a-8396-4513-b79d-628b9079441a"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8148), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 160.0, 0, 250.0, 200.0, 1.0 },
                    { new Guid("b5f3aca6-d939-4ce9-a1f3-5d4972eb27f1"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8038), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("bf1f8b2d-c78f-4cfc-9533-aef54ad42369"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8137), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 210.0, 0, 20.0, 200.0, 1.0 },
                    { new Guid("c0cdab2a-c71f-469b-bcd2-c55f10bd8f53"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8043), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("c136fad0-fe37-42fd-addb-f7e4acf9ef8f"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8113), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("c4f9edc4-e8c6-40ab-880c-137eadc578c7"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(7994), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("c72f3246-e06d-4ff7-8232-3d98c6df518b"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8062), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("c83cb3b1-a0f2-4aad-883f-e661e7a14b82"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8163), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 299.0, 0, 150.0, 40.0, 2.0 },
                    { new Guid("c93e4e56-b9da-4dda-a60f-9e9c9cbb4312"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8054), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("cd10c63e-7b2c-4209-ac9f-ae0087a4569d"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8009), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("d3130c9e-e8fe-4954-81df-e9d7bd8e1900"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8047), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("d55f80a2-6b55-455f-9147-c701aadc7c0b"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8104), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("d7c4e62a-0b58-4b44-8368-830f97d4b03c"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8139), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 205.0, 0, 50.0, 200.0, 1.0 },
                    { new Guid("db81f721-7614-46a2-97a3-15f606e347c7"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8066), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("e1b7e0b7-0548-4237-ac60-7c0d0a68a499"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8033), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("e26dc2ae-d53b-4310-9b1f-238aad86a4b4"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8099), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("e464f5f8-268d-4408-b787-25aa0ec70339"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8018), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("eb3b0771-c5c5-4dd1-956b-929cb431f75e"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8174), null, null, new Guid("66666666-6666-6666-6666-666666666661"), null, null, 360.0, 235.0, 0, 20.0, 30.0, 3.0 },
                    { new Guid("eb91752e-adbc-472b-84fa-02968bc93335"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8021), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("efa3c58d-516c-47ec-a94f-435f77ad4e37"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8004), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("f21d98a4-7c99-4ab6-b030-874cedc16299"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8122), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("f4c3ec8e-1911-4294-8ce1-90dad872e89c"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8058), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("fc3823b2-836b-4e89-ae32-3f0613ba92a6"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8167), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 252.0, 0, 250.0, 40.0, 2.0 },
                    { new Guid("fe2ac67d-295e-44c9-b3d9-2dddc0ddd26a"), "SeedData", new DateTime(2026, 3, 27, 14, 40, 0, 984, DateTimeKind.Utc).AddTicks(8146), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 170.0, 0, 200.0, 200.0, 1.0 }
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
                name: "IX_AD2000CostAnalyses_AD2000CalculationId_RevisionNo",
                table: "AD2000CostAnalyses",
                columns: new[] { "AD2000CalculationId", "RevisionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AD2000CostAnalyses_HeadBombeLaborRateId",
                table: "AD2000CostAnalyses",
                column: "HeadBombeLaborRateId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000CostAnalysisItems_AD2000CostAnalysisId",
                table: "AD2000CostAnalysisItems",
                column: "AD2000CostAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000CostAnalysisItems_AD2000CostAnalysisId_ItemKey",
                table: "AD2000CostAnalysisItems",
                columns: new[] { "AD2000CostAnalysisId", "ItemKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_AD2000CalculationId",
                table: "AD2000SalesPrices",
                column: "AD2000CalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_AD2000CostAnalysisId",
                table: "AD2000SalesPrices",
                column: "AD2000CostAnalysisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_FinanceOverheadRateId",
                table: "AD2000SalesPrices",
                column: "FinanceOverheadRateId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_GeneralManagementOverheadRateId",
                table: "AD2000SalesPrices",
                column: "GeneralManagementOverheadRateId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_GugHourlyRateId",
                table: "AD2000SalesPrices",
                column: "GugHourlyRateId");

            migrationBuilder.CreateIndex(
                name: "IX_AD2000SalesPrices_LaborRateId",
                table: "AD2000SalesPrices",
                column: "LaborRateId");

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
                name: "IX_EmployeeProfiles_UserId",
                table: "EmployeeProfiles",
                column: "UserId",
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
                name: "IX_EN13458CostAnalyses_InnerHeadBombeLaborRateId",
                table: "EN13458CostAnalyses",
                column: "InnerHeadBombeLaborRateId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458CostAnalyses_OuterHeadBombeLaborRateId",
                table: "EN13458CostAnalyses",
                column: "OuterHeadBombeLaborRateId");

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
                name: "IX_EN13458SalesPrices_EN13458CalculationId",
                table: "EN13458SalesPrices",
                column: "EN13458CalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458SalesPrices_EN13458CostAnalysisId",
                table: "EN13458SalesPrices",
                column: "EN13458CostAnalysisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EN13458SalesPrices_FinanceOverheadRateId",
                table: "EN13458SalesPrices",
                column: "FinanceOverheadRateId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458SalesPrices_GeneralManagementOverheadRateId",
                table: "EN13458SalesPrices",
                column: "GeneralManagementOverheadRateId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458SalesPrices_GugHourlyRateId",
                table: "EN13458SalesPrices",
                column: "GugHourlyRateId");

            migrationBuilder.CreateIndex(
                name: "IX_EN13458SalesPrices_LaborRateId",
                table: "EN13458SalesPrices",
                column: "LaborRateId");

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
                name: "IX_SalesRequestAttachments_SalesRequestId",
                table: "SalesRequestAttachments",
                column: "SalesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestComments_SalesRequestId",
                table: "SalesRequestComments",
                column: "SalesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestDocuments_SalesRequestId_DocumentType_RevisionCode",
                table: "SalesRequestDocuments",
                columns: new[] { "SalesRequestId", "DocumentType", "RevisionCode" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestDocuments_SalesRequestItemId",
                table: "SalesRequestDocuments",
                column: "SalesRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_ParentSalesRequestItemId",
                table: "SalesRequestItems",
                column: "ParentSalesRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_ProductGroupId",
                table: "SalesRequestItems",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_SalesRequestId",
                table: "SalesRequestItems",
                column: "SalesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestProductGroups_Code",
                table: "SalesRequestProductGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestRevisions_SalesRequestId_RevisionNo",
                table: "SalesRequestRevisions",
                columns: new[] { "SalesRequestId", "RevisionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequests_CustomerId",
                table: "SalesRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequests_RequestNo",
                table: "SalesRequests",
                column: "RequestNo",
                unique: true);

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
                name: "AD2000CostAnalysisItems");

            migrationBuilder.DropTable(
                name: "AD2000SalesPrices");

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
                name: "EmployeeProfiles");

            migrationBuilder.DropTable(
                name: "EN13458CostAnalysisItems");

            migrationBuilder.DropTable(
                name: "EN13458CostDetails");

            migrationBuilder.DropTable(
                name: "EN13458SalesPrices");

            migrationBuilder.DropTable(
                name: "GasTypeDesignStandards");

            migrationBuilder.DropTable(
                name: "GasTypePressures");

            migrationBuilder.DropTable(
                name: "PrefixRules");

            migrationBuilder.DropTable(
                name: "SalesRequestAttachments");

            migrationBuilder.DropTable(
                name: "SalesRequestComments");

            migrationBuilder.DropTable(
                name: "SalesRequestDocuments");

            migrationBuilder.DropTable(
                name: "SalesRequestRevisions");

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
                name: "AD2000CostAnalyses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CapacityGroups");

            migrationBuilder.DropTable(
                name: "EN13458CostAnalyses");

            migrationBuilder.DropTable(
                name: "GugHourlyRates");

            migrationBuilder.DropTable(
                name: "LaborRates");

            migrationBuilder.DropTable(
                name: "OverheadRates");

            migrationBuilder.DropTable(
                name: "DesignStandards");

            migrationBuilder.DropTable(
                name: "SalesRequestItems");

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
                name: "AD2000Calculations");

            migrationBuilder.DropTable(
                name: "BombeLaborRates");

            migrationBuilder.DropTable(
                name: "EN13458Calculations");

            migrationBuilder.DropTable(
                name: "SalesRequestProductGroups");

            migrationBuilder.DropTable(
                name: "SalesRequests");

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
                name: "Customers");

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
