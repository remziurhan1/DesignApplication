using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v34 : Migration
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
                name: "DesignPlanningEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DailyCapacityHours = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 8m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignPlanningProjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningProjectTypes", x => x.Id);
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
                    CanAccessDesignArea = table.Column<bool>(type: "bit", nullable: false),
                    CanManageDesignCalculations = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateStockCodes = table.Column<bool>(type: "bit", nullable: false),
                    CanEditStockCodes = table.Column<bool>(type: "bit", nullable: false),
                    CanAccessMaterialGroups = table.Column<bool>(type: "bit", nullable: false),
                    CanManageMaterials = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    FinalSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryLeadTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "DesignPlanningEmployeeExpertises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpertiseName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningEmployeeExpertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignPlanningEmployeeExpertises_DesignPlanningEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "DesignPlanningEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesignPlanningProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignPlanningProjects_DesignPlanningProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "DesignPlanningProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesignPlanningTaskTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    ResponsibleRole = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DurationValue = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    DurationUnit = table.Column<int>(type: "int", nullable: false),
                    IsPassive = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningTaskTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignPlanningTaskTemplates_DesignPlanningProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "DesignPlanningProjectTypes",
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
                    MaterialClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialFamily = table.Column<int>(type: "int", nullable: false),
                    Norm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SymbolicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "DesignPlanningProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    ResponsibleRole = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DurationValue = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    DurationUnit = table.Column<int>(type: "int", nullable: false),
                    IsPassive = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPlanningProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignPlanningProjectTasks_DesignPlanningEmployees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "DesignPlanningEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DesignPlanningProjectTasks_DesignPlanningProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DesignPlanningProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignPlanningProjectTasks_DesignPlanningTaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalTable: "DesignPlanningTaskTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ShellYieldStrengthRp02 = table.Column<double>(type: "float", nullable: false),
                    HeadYieldStrengthRp02 = table.Column<double>(type: "float", nullable: false),
                    ShellDesignStress = table.Column<double>(type: "float", nullable: false),
                    HeadDesignStress = table.Column<double>(type: "float", nullable: false),
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
                    ShellWeldLength = table.Column<double>(type: "float", nullable: false),
                    HeadWeldLength = table.Column<double>(type: "float", nullable: false),
                    CircumferenceWeldLength = table.Column<double>(type: "float", nullable: false),
                    TotalWeldLength = table.Column<double>(type: "float", nullable: false),
                    StiffenerRingWeldLength = table.Column<double>(type: "float", nullable: false),
                    WeldConsumableCost = table.Column<double>(type: "float", nullable: false),
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
                    DesignTemperature = table.Column<double>(type: "float", nullable: false),
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
                    InnerShellMaterialDensity = table.Column<double>(type: "float", nullable: false),
                    InnerHeadMaterialDensity = table.Column<double>(type: "float", nullable: false),
                    OuterShellMaterialDensity = table.Column<double>(type: "float", nullable: false),
                    OuterHeadMaterialDensity = table.Column<double>(type: "float", nullable: false),
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
                    InnerTankShellWeldLength = table.Column<double>(type: "float", nullable: false),
                    InnerTankBombeWeldLength = table.Column<double>(type: "float", nullable: false),
                    InnerTankTotalWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankHeadWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankCircumferenceWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankShellWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankBombeWeldLength = table.Column<double>(type: "float", nullable: false),
                    OuterTankTotalWeldLength = table.Column<double>(type: "float", nullable: false),
                    StiffenerRingWeldLength = table.Column<double>(type: "float", nullable: false),
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
                    PrimaryUnitType = table.Column<int>(type: "int", nullable: false),
                    KgEquivalentPerPrimaryUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Step3DFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DxfFilePath1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DxfFilePath2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DatasheetFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    MaterialNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MaterialClass = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MaterialFamily = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Norm = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProductStandard = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SymbolicName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StockCodeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CalculatedThickness = table.Column<double>(type: "float", nullable: false),
                    UsedThickness = table.Column<double>(type: "float", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    TheoreticalWeight = table.Column<double>(type: "float", nullable: false),
                    UsedYieldStrength = table.Column<double>(type: "float", nullable: false),
                    UsedDesignStress = table.Column<double>(type: "float", nullable: false),
                    UsedTemperature = table.Column<double>(type: "float", nullable: false),
                    UsedThicknessBandMin = table.Column<double>(type: "float", nullable: false),
                    UsedThicknessBandMax = table.Column<double>(type: "float", nullable: false),
                    DensitySource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PriceSource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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
                    MaterialNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MaterialClass = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MaterialFamily = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Norm = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProductStandard = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SymbolicName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StockCodeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CalculatedThickness = table.Column<double>(type: "float", nullable: false),
                    UsedThickness = table.Column<double>(type: "float", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    TheoreticalWeight = table.Column<double>(type: "float", nullable: false),
                    UsedYieldStrength = table.Column<double>(type: "float", nullable: false),
                    UsedDesignStress = table.Column<double>(type: "float", nullable: false),
                    UsedTemperature = table.Column<double>(type: "float", nullable: false),
                    UsedThicknessBandMin = table.Column<double>(type: "float", nullable: false),
                    UsedThicknessBandMax = table.Column<double>(type: "float", nullable: false),
                    DensitySource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PriceSource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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
                name: "GeneratedStockCodeInventoryMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockBefore = table.Column<int>(type: "int", nullable: false),
                    StockAfter = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenceDocument = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedStockCodeInventoryMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodeInventoryMovements_GeneratedStockCodes_GeneratedStockCodeId",
                        column: x => x.GeneratedStockCodeId,
                        principalTable: "GeneratedStockCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodeInventoryMovements_StockProductGroups_StockProductGroupId",
                        column: x => x.StockProductGroupId,
                        principalTable: "StockProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedStockCodeRuleSelections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedStockCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSubCodeRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedStockCodeRuleSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodeRuleSelections_GeneratedStockCodes_GeneratedStockCodeId",
                        column: x => x.GeneratedStockCodeId,
                        principalTable: "GeneratedStockCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedStockCodeRuleSelections_StockSubCodeRules_StockSubCodeRuleId",
                        column: x => x.StockSubCodeRuleId,
                        principalTable: "StockSubCodeRules",
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
                table: "DesignPlanningEmployees",
                columns: new[] { "Id", "DailyCapacityHours", "FullName", "IsActive" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 8m, "Remzi Urhan", true },
                    { new Guid("11111111-1111-1111-1111-111111111112"), 8m, "Büşra Ateş", true },
                    { new Guid("11111111-1111-1111-1111-111111111113"), 8m, "Erdoğan Elgin", true },
                    { new Guid("11111111-1111-1111-1111-111111111114"), 8m, "Muhammed Şimşek", true },
                    { new Guid("11111111-1111-1111-1111-111111111115"), 8m, "Ayhan Şahin", true },
                    { new Guid("11111111-1111-1111-1111-111111111116"), 8m, "Mustafa Çakal", true }
                });

            migrationBuilder.InsertData(
                table: "DesignPlanningProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), "Tek Cidarlı Depolama" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Çift Cidarlı Depolama" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), "Tek Cidarlı Transport" },
                    { new Guid("22222222-2222-2222-2222-222222222224"), "Çift Cidarlı Transport" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "ElasticModulus", "MaterialNumber", "ModifiedBy", "ModifiedDate", "Name", "Notes", "Status", "YieldFactorK" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2472), null, null, 7850.0, null, "1.0565", null, null, "P355GH", "Pressure vessel plate according to EN10028-2", 0, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2504), null, null, 8000.0, null, "1.4301", null, null, "X5CrNi18-10", "EN 10028-7 stainless pressure vessel steel", 0, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2536), null, null, 7850.0, 206000.0, "1.0038", null, null, "S235JR", "Profile material for supports/rings", 0, 235.0 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2542), null, null, 7850.0, null, "1.0565", null, null, "P355NH", "Normalized pressure vessel steel EN10028-3", 0, null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2546), null, null, 8000.0, null, "1.4307", null, null, "X2CrNi18-9", "Austenitic stainless steel plate EN10028-7", 0, null }
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
                    { new Guid("10000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3159), null, null, 460.0, "Liquefied Natural Gas", null, null, "Methane / LNG", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3169), null, null, 808.0, "Liquid Nitrogen", null, null, "Nitrogen / LIN", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3194), null, null, 1141.0, "Liquid Oxygen", null, null, "Oxygen / LOX", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3199), null, null, 1395.0, "Liquid Argon", null, null, "Argon / LAR", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3201), null, null, 1070.0, "Liquid Carbon Dioxide", null, null, "Carbon Dioxide / LCO2", 0 }
                });

            migrationBuilder.InsertData(
                table: "DesignPlanningEmployeeExpertises",
                columns: new[] { "Id", "EmployeeId", "ExpertiseName", "Priority" },
                values: new object[,]
                {
                    { new Guid("31111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "Teklif Hazırlama", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111112"), "Tek Cidarlı Depolama", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111112"), "Tek Cidarlı Transport", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111113"), "Çift Cidarlı Depolama", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111113"), "Çift Cidarlı Transport", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111116"), new Guid("11111111-1111-1111-1111-111111111114"), "Tek Cidarlı Depolama", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111114"), "Çift Cidarlı Depolama", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111118"), new Guid("11111111-1111-1111-1111-111111111115"), "Teknik Ressam", 1 },
                    { new Guid("31111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111116"), "Teknik Ressam", 1 }
                });

            migrationBuilder.InsertData(
                table: "DesignPlanningTaskTemplates",
                columns: new[] { "Id", "DurationUnit", "DurationValue", "IsActive", "IsPassive", "ProjectTypeId", "ResponsibleRole", "SequenceNo", "TaskName" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-2221-000000000001"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Teklif Hazırlama", 1, "GAD RESMİ ÇİZİMİ" },
                    { new Guid("40000000-0000-0000-2221-000000000002"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Teklif Hazırlama", 2, "GAD RESMİ ÇİZİM ONAYI" },
                    { new Guid("40000000-0000-0000-2221-000000000003"), 1, 1m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Teklif Hazırlama", 3, "Hesaplamalar" },
                    { new Guid("40000000-0000-0000-2221-000000000004"), 3, 1m, true, true, new Guid("22222222-2222-2222-2222-222222222221"), "Dizayn Mühendisi", 4, "TUV Tip Onay Süreci" },
                    { new Guid("40000000-0000-0000-2221-000000000005"), 1, 6m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Dizayn Mühendisi", 5, "Genel Tip Onay Resmi" },
                    { new Guid("40000000-0000-0000-2221-000000000006"), 1, 4m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Dizayn Mühendisi", 6, "TANK MONTAJ TASARIMI" },
                    { new Guid("40000000-0000-0000-2221-000000000007"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222221"), "Teknik Ressam", 7, "TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI" },
                    { new Guid("40000000-0000-0000-2222-000000000001"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 1, "Hesaplamalar" },
                    { new Guid("40000000-0000-0000-2222-000000000002"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 2, "GÖVDE BOMBE ORYANTASYON HAZIRLAMA" },
                    { new Guid("40000000-0000-0000-2222-000000000003"), 1, 1m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 3, "KRİTİK AKSESUAR LİSTESİ YAYINLAMA" },
                    { new Guid("40000000-0000-0000-2222-000000000004"), 1, 1m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 4, "P&ID HAZIRLAMA" },
                    { new Guid("40000000-0000-0000-2222-000000000005"), 1, 1m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 5, "GAD RESMİ ÇİZİMİ" },
                    { new Guid("40000000-0000-0000-2222-000000000006"), 3, 1m, true, true, new Guid("22222222-2222-2222-2222-222222222222"), "Teklif Hazırlama", 6, "GAD RESMİ ÇİZİM ONAYI" },
                    { new Guid("40000000-0000-0000-2222-000000000007"), 1, 6m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Dizayn Mühendisi", 7, "Genel Tip Onay Resmi" },
                    { new Guid("40000000-0000-0000-2222-000000000008"), 3, 1m, true, true, new Guid("22222222-2222-2222-2222-222222222222"), "Dizayn Mühendisi", 8, "TUV Tip Onay Süreci" },
                    { new Guid("40000000-0000-0000-2222-000000000009"), 1, 4m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Dizayn Mühendisi", 9, "İÇ TANK MONTAJ TASARIMI" },
                    { new Guid("40000000-0000-0000-2222-000000000010"), 1, 4m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Dizayn Mühendisi", 10, "DIŞ TANK MONTAJ TASARIMI" },
                    { new Guid("40000000-0000-0000-2222-000000000011"), 1, 2m, true, false, new Guid("22222222-2222-2222-2222-222222222222"), "Teknik Ressam", 11, "DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI" }
                });

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialClass", "MaterialFamily", "MaterialId", "ModifiedBy", "ModifiedDate", "MomentOfInertia", "Norm", "Notes", "ProductStandard", "SectionArea", "SectionModulus", "Status", "StockCode", "SymbolicName", "TargetPrice", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2617), null, null, 0, "Carbon Steel", 1, new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, "EN10028-2", "Standard plate form for P355GH", "EN 10028-2", null, null, 0, null, "P355GH", null, 250.0, 1.0, 1.5, null },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2639), null, null, 1, "Carbon Steel", 1, new Guid("77777777-7777-7777-7777-777777777777"), null, null, null, "EN10216-3", "Seamless pipe form for P355NH", "EN 10216-3", null, null, 0, null, "P355NH", null, 40.0, 2.0, 2.2999999999999998, 1.0 },
                    { new Guid("44444444-4444-4444-4444-444444444441"), 400.0, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2631), null, null, 0, "Stainless Steel", 2, new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, "EN10028-7", "Plate form for X5CrNi18-10 (Cold stretch optional)", "EN 10028-7", null, null, 0, null, "X5CrNi18-10", null, 200.0, 1.0, 4.5, null },
                    { new Guid("66666666-6666-6666-6666-666666666661"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2648), null, null, 4, "Carbon Steel", 1, new Guid("55555555-5555-5555-5555-555555555555"), null, null, 101700.0, "EN10025", "S235JR kutu profil 40x40x3 mm", "EN 10025-2", 444.0, 5080.0, 0, null, "S235JR", null, 30.0, 3.0, 1.2, null },
                    { new Guid("77777777-7777-7777-7777-777777777771"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2656), null, null, 2, "Carbon Steel", 1, new Guid("77777777-7777-7777-7777-777777777777"), null, null, null, "EN10028-3", "Forged part seed for P355NH", "EN 10028-3", null, null, 0, null, "P355NH", null, 300.0, 20.0, 2.7999999999999998, null },
                    { new Guid("88888888-8888-8888-8888-888888888881"), null, "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2665), null, null, 0, "Stainless Steel", 2, new Guid("88888888-8888-8888-8888-888888888888"), null, null, null, "EN10028-7", "Plate seed for X2CrNi18-9", "EN 10028-7", null, null, 0, null, "X2CrNi18-9", null, 120.0, 1.0, 4.9000000000000004, null }
                });

            migrationBuilder.InsertData(
                table: "StorageTypeProperties",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Enthalpy_Gas_kJkg", "Enthalpy_Liquid_kJkg", "Entropy_Gas_kJkgK", "Entropy_Liquid_kJkgK", "GasConstant_kJkgK", "ModifiedBy", "ModifiedDate", "Pressure_bar", "SpecificVolume_Gas_m3kg", "SpecificVolume_Liquid_dm3kg", "Status", "StorageTypeId", "Temperature_C" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3245), null, null, 688.0, 200.0, 4.9626999999999999, 1.0, 488.0, null, null, 2.3839999999999999, 0.25041999999999998, 2.4674, 0, new Guid("10000000-0000-0000-0000-000000000001"), -150.0 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3256), null, null, 281.19, 81.790000000000006, 2.4571000000000001, -0.1275, 199.40000000000001, null, null, 0.98999999999999999, 0.2215, 1.2352000000000001, 0, new Guid("10000000-0000-0000-0000-000000000002"), -196.0 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3265), null, null, 367.88, 200.0, 2.3632, 1.0, 167.88, null, null, 12.214, 0.02129, 1.0495000000000001, 0, new Guid("10000000-0000-0000-0000-000000000003"), -150.0 }
                });

            migrationBuilder.InsertData(
                table: "YieldStrengths",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "MaterialFormId", "ModifiedBy", "ModifiedDate", "Rm", "Rp02", "Status", "Temperature", "ThicknessMax", "ThicknessMin" },
                values: new object[,]
                {
                    { new Guid("00ec7d54-e1a2-4dce-9874-41f17d4d3e44"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2820), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 238.0, 0, 250.0, 60.0, 40.0 },
                    { new Guid("01258fab-a66f-4db5-9e0d-01271c63a1e9"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2844), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 287.0, 0, 100.0, 100.0, 60.0 },
                    { new Guid("018b29fc-d7a1-4474-8b74-f03a19784726"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2719), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 299.0, 0, 150.0, 16.0, 1.0 },
                    { new Guid("019a3328-6fc0-4593-b80a-0606496e34f9"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2807), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 305.0, 0, 100.0, 60.0, 40.0 },
                    { new Guid("0926b63f-547c-49ab-b55a-8b3389105427"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2723), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 275.0, 0, 200.0, 16.0, 1.0 },
                    { new Guid("0d6c9951-df9b-4aed-8fc5-a8cc057683cb"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2974), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 170.0, 0, 200.0, 200.0, 1.0 },
                    { new Guid("0db82d37-4b0a-4d0f-82c3-4efdce21ecbb"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2962), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 205.0, 0, 50.0, 200.0, 1.0 },
                    { new Guid("0e8ee4b6-737c-48f7-848e-554cf3abb969"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3043), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 185.0, 0, 150.0, 120.0, 1.0 },
                    { new Guid("19505255-bb41-4393-808b-650e9f8a0672"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2874), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 295.0, 0, 50.0, 150.0, 100.0 },
                    { new Guid("2162179a-6cf0-4554-8efe-45b3f3c718c0"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2852), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 244.0, 0, 200.0, 100.0, 60.0 },
                    { new Guid("23eac266-ec38-49d8-b679-10a2cb756c5c"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2929), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 192.0, 0, 300.0, 250.0, 150.0 },
                    { new Guid("3015cae3-ff67-4ef5-b53e-bdd32d00fb79"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2933), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 178.0, 0, 350.0, 250.0, 150.0 },
                    { new Guid("329faea9-f599-469a-b4f0-5eda4b2e2d20"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3068), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 355.0, 0, 20.0, 40.0, 2.0 },
                    { new Guid("393cef79-e724-4261-af29-68a46e920348"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2893), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 199.0, 0, 300.0, 150.0, 100.0 },
                    { new Guid("39c6b5f3-03a6-4e4d-9ada-f112436ca634"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2738), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 202.0, 0, 400.0, 16.0, 1.0 },
                    { new Guid("3a3c97cb-84ed-4a18-a988-046d32a4222d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3016), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 350.0, 0, -196.0, 120.0, 1.0 },
                    { new Guid("3bb1730b-2007-4b91-9bcf-857c83d31d5a"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2886), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 236.0, 0, 200.0, 150.0, 100.0 },
                    { new Guid("3c1bcf7d-81d8-4296-8c6a-71a3ce0c0794"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2867), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 179.0, 0, 400.0, 100.0, 60.0 },
                    { new Guid("3e3cad2d-aa35-4b00-b105-206539e4ac0e"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3080), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 299.0, 0, 150.0, 40.0, 2.0 },
                    { new Guid("4273d051-7abe-4225-8c9e-b54fc494b352"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2731), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 232.0, 0, 300.0, 16.0, 1.0 },
                    { new Guid("44ba50cb-84e8-4415-a45d-d52c2629a3f5"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3099), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 202.0, 0, 400.0, 40.0, 2.0 },
                    { new Guid("454e336a-1d55-4dce-8299-3b53ed5f192d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3102), null, null, new Guid("66666666-6666-6666-6666-666666666661"), null, null, 360.0, 235.0, 0, 20.0, 30.0, 3.0 },
                    { new Guid("4711a79b-7b85-4421-bdf8-ebd21723823d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3028), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 260.0, 0, -50.0, 120.0, 1.0 },
                    { new Guid("522dd31d-f6bf-4ef1-adfb-90ba9a5e9926"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2828), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 202.0, 0, 350.0, 60.0, 40.0 },
                    { new Guid("52983553-6dc5-4aa2-bb77-78ec4bc58f47"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2811), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 282.0, 0, 150.0, 60.0, 40.0 },
                    { new Guid("56c81dc9-a086-4645-b89c-5c90d45b7308"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3072), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 343.0, 0, 50.0, 40.0, 2.0 },
                    { new Guid("5cefee97-e8d5-463e-b730-5eddc2db1bfc"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2714), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 323.0, 0, 100.0, 16.0, 1.0 },
                    { new Guid("5cfc86d1-0696-41bf-805e-d8ac4c87f03d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3075), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 323.0, 0, 100.0, 40.0, 2.0 },
                    { new Guid("5fb9cbd0-b5ef-41b8-80d1-cc262df233c7"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3060), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 140.0, 0, 350.0, 120.0, 1.0 },
                    { new Guid("60d97f38-668c-4b26-b52e-123d69002007"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3033), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 210.0, 0, 20.0, 120.0, 1.0 },
                    { new Guid("6b72ff28-d5aa-435d-b85e-f5d38eed79c3"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2889), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 216.0, 0, 250.0, 150.0, 100.0 },
                    { new Guid("719de316-539c-4c62-9292-dd889f669cf7"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2921), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 228.0, 0, 200.0, 250.0, 150.0 },
                    { new Guid("73a19c41-1ba9-42dc-83aa-2f085b55e6ae"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2877), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 277.0, 0, 100.0, 150.0, 100.0 },
                    { new Guid("74bea40a-8ec8-442d-8069-49db9b3c859c"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2909), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 285.0, 0, 50.0, 250.0, 150.0 },
                    { new Guid("79f97f0f-d27e-4cfc-aa38-8c92863e3927"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2862), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 190.0, 0, 350.0, 100.0, 60.0 },
                    { new Guid("7db23f95-db63-4dd3-9272-7f804aaeaf5a"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2753), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 314.0, 0, 100.0, 40.0, 16.0 },
                    { new Guid("7e84f58b-45c5-4f83-92ad-573c23683385"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2949), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 300.0, 0, -100.0, 200.0, 1.0 },
                    { new Guid("82ce8360-5526-46e8-8cca-cef61d68518f"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2771), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 208.0, 0, 350.0, 40.0, 16.0 },
                    { new Guid("8a9a7719-b84f-416d-a41e-d97a59a25674"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2918), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 249.0, 0, 150.0, 250.0, 150.0 },
                    { new Guid("8b1cab38-1378-4942-90cd-c9202e9c314d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2710), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 343.0, 0, 50.0, 16.0, 1.0 },
                    { new Guid("8c7c3257-6779-41b4-8ddd-a0eed39f2859"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2915), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 268.0, 0, 100.0, 250.0, 150.0 },
                    { new Guid("9060790d-d3bb-4894-b36c-4e19709ff8cf"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2966), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 195.0, 0, 100.0, 200.0, 1.0 },
                    { new Guid("92f0d21b-31b1-48a1-9927-dbeff1791197"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3052), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 160.0, 0, 250.0, 120.0, 1.0 },
                    { new Guid("938bff3c-49eb-4df6-933e-3e28d55480d0"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3048), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 170.0, 0, 200.0, 120.0, 1.0 },
                    { new Guid("9a3d8832-6e6f-4007-88f3-05330e036edc"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2837), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 315.0, 0, 20.0, 100.0, 60.0 },
                    { new Guid("9b4d2b02-c155-4f94-86a4-4132ab02ee69"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2735), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 214.0, 0, 350.0, 16.0, 1.0 },
                    { new Guid("9c63f3d5-6759-42f3-928a-2b4c5cfa0451"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2763), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 245.0, 0, 250.0, 40.0, 16.0 },
                    { new Guid("9d102c9a-f55d-4e71-93e4-abdd182af8fc"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3083), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 275.0, 0, 200.0, 40.0, 2.0 },
                    { new Guid("9d46d5a9-4ace-407f-bef3-1b4898fc5fb5"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2940), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 350.0, 0, -196.0, 200.0, 1.0 },
                    { new Guid("a0c9d02f-0402-4b6b-9268-8313266832a6"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2859), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 206.0, 0, 300.0, 100.0, 60.0 },
                    { new Guid("a30ae343-ae2a-48cf-8df2-f3f425421fe8"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2756), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 291.0, 0, 150.0, 40.0, 16.0 },
                    { new Guid("a3408ed3-5189-42c0-a5e1-b156381711ad"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3024), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 300.0, 0, -100.0, 120.0, 1.0 },
                    { new Guid("a4a0ffa7-5ea6-43b6-85c4-8106d6c8ad5f"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2882), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 257.0, 0, 150.0, 150.0, 100.0 },
                    { new Guid("a9a06976-722e-43f9-b146-ba818044a99f"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2841), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 50.0, 100.0, 60.0 },
                    { new Guid("aa783f47-d238-4515-822e-9ec47f42f5cb"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2970), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 185.0, 0, 150.0, 200.0, 1.0 },
                    { new Guid("ac241384-2685-4a8a-96d8-e28c4996f9b4"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2726), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 252.0, 0, 250.0, 16.0, 1.0 },
                    { new Guid("ad017a68-7cb5-4b4c-b4b5-0e461a29ec67"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3036), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 205.0, 0, 50.0, 120.0, 1.0 },
                    { new Guid("af441865-602f-452a-acea-0bf92a3b667d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2774), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 196.0, 0, 400.0, 40.0, 16.0 },
                    { new Guid("b0d8704a-a42b-4837-96d7-86045b338216"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3091), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 232.0, 0, 300.0, 40.0, 2.0 },
                    { new Guid("b243ce93-50b9-4439-924e-e55435deb187"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2701), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 355.0, 0, 20.0, 16.0, 1.0 },
                    { new Guid("bdfa5d0c-7225-4663-9173-6c9621bd73d9"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2848), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 265.0, 0, 150.0, 100.0, 60.0 },
                    { new Guid("c0da5526-539d-43a8-93a2-5d050e57182d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3055), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 150.0, 0, 300.0, 120.0, 1.0 },
                    { new Guid("c9f10fe7-4d4e-4f24-a224-227c0981cf2b"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2945), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 330.0, 0, -150.0, 200.0, 1.0 },
                    { new Guid("d1b59846-e0ac-4882-a6fb-b5b5f3f8b9d3"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2978), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 160.0, 0, 250.0, 200.0, 1.0 },
                    { new Guid("d1fd2ece-a3e9-4840-8ee9-4e6e07352b61"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2760), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 267.0, 0, 200.0, 40.0, 16.0 },
                    { new Guid("d3ff2887-1dc7-4d7a-a9db-2c3edc36e93d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2855), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 224.0, 0, 250.0, 100.0, 60.0 },
                    { new Guid("d6341f0b-51c3-404b-b81e-6230209a4d5d"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2906), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 295.0, 0, 20.0, 250.0, 150.0 },
                    { new Guid("d66857a2-5015-469f-8348-15714599fc04"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2824), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 219.0, 0, 300.0, 60.0, 40.0 },
                    { new Guid("d7d20542-dfef-4def-bb53-09bf33d31b4e"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3064), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 130.0, 0, 400.0, 120.0, 1.0 },
                    { new Guid("db4129f8-f3ea-40cb-a83e-352a3420ed3a"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2902), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 173.0, 0, 400.0, 150.0, 100.0 },
                    { new Guid("dc3d814b-b666-4c7f-8b08-b22f7744dd8e"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3011), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 130.0, 0, 400.0, 200.0, 1.0 },
                    { new Guid("de3c9e80-e267-4a42-9c12-2d9bef1e5400"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3007), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 140.0, 0, 350.0, 200.0, 1.0 },
                    { new Guid("de45e5ed-6ffc-49e8-a735-7fa2359193b0"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2899), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 184.0, 0, 350.0, 150.0, 100.0 },
                    { new Guid("def2b280-9c4b-4f52-ba02-e8815c3d290b"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2743), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 345.0, 0, 20.0, 40.0, 16.0 },
                    { new Guid("e02b04a5-4e13-411f-a53d-bb7a44776f2b"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2956), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 210.0, 0, 20.0, 200.0, 1.0 },
                    { new Guid("e08b8faf-ea94-4afd-8f10-3d803f0e2420"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2832), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 190.0, 0, 400.0, 60.0, 40.0 },
                    { new Guid("e129558b-9578-4d32-b4a7-e14e9c3cba9a"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3040), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 195.0, 0, 100.0, 120.0, 1.0 },
                    { new Guid("e7ae654a-16f9-4a14-8d2c-274d1d727d3e"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3087), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 252.0, 0, 250.0, 40.0, 2.0 },
                    { new Guid("e9d90e79-4ffc-4624-86c3-d5bb18b121a2"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2924), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 209.0, 0, 250.0, 250.0, 150.0 },
                    { new Guid("e9dded9d-86f5-417d-8663-5910bf6889e2"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3096), null, null, new Guid("22222222-2222-2222-2222-222222222223"), null, null, 490.0, 214.0, 0, 350.0, 40.0, 2.0 },
                    { new Guid("ea9bdd49-627e-4c8d-8676-6f23a3fb680c"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2937), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 450.0, 167.0, 0, 400.0, 250.0, 150.0 },
                    { new Guid("ed4ebc90-77c7-4280-b5c7-34a995fa2498"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2778), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 335.0, 0, 20.0, 60.0, 40.0 },
                    { new Guid("ef0aadd2-16cb-46ab-95a8-3418b13b5744"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2748), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 334.0, 0, 50.0, 40.0, 16.0 },
                    { new Guid("f26cb9f1-8025-49a4-b66d-b58ddb83ebfd"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(3020), null, null, new Guid("88888888-8888-8888-8888-888888888881"), null, null, 650.0, 330.0, 0, -150.0, 120.0, 1.0 },
                    { new Guid("f4027b04-274d-4644-92c7-849e4e79f407"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2953), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 260.0, 0, -50.0, 200.0, 1.0 },
                    { new Guid("f7ee6bb2-d364-417d-a516-24922aa2e701"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2782), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 324.0, 0, 50.0, 60.0, 40.0 },
                    { new Guid("f80363fd-cf13-4651-9412-877196e9a245"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2768), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 490.0, 225.0, 0, 300.0, 40.0, 16.0 },
                    { new Guid("fbe8aec2-1a62-4015-874b-6861468e0515"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2871), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 460.0, 305.0, 0, 20.0, 150.0, 100.0 },
                    { new Guid("fd54d39e-7c04-419a-be74-8e5163346438"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2815), null, null, new Guid("22222222-2222-2222-2222-222222222222"), null, null, 470.0, 259.0, 0, 200.0, 60.0, 40.0 },
                    { new Guid("fe6f09f1-72dc-4326-8cef-b42e23dcb385"), "SeedData", new DateTime(2026, 5, 12, 19, 9, 21, 689, DateTimeKind.Utc).AddTicks(2982), null, null, new Guid("44444444-4444-4444-4444-444444444441"), null, null, 650.0, 150.0, 0, 300.0, 200.0, 1.0 }
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
                name: "IX_DesignPlanningEmployeeExpertises_EmployeeId_ExpertiseName",
                table: "DesignPlanningEmployeeExpertises",
                columns: new[] { "EmployeeId", "ExpertiseName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjects_ProjectCode",
                table: "DesignPlanningProjects",
                column: "ProjectCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjects_ProjectTypeId",
                table: "DesignPlanningProjects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjectTasks_AssignedEmployeeId",
                table: "DesignPlanningProjectTasks",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjectTasks_ProjectId_SequenceNo",
                table: "DesignPlanningProjectTasks",
                columns: new[] { "ProjectId", "SequenceNo" });

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjectTasks_TaskTemplateId",
                table: "DesignPlanningProjectTasks",
                column: "TaskTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningProjectTypes_Name",
                table: "DesignPlanningProjectTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignPlanningTaskTemplates_ProjectTypeId_SequenceNo",
                table: "DesignPlanningTaskTemplates",
                columns: new[] { "ProjectTypeId", "SequenceNo" });

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
                name: "IX_GeneratedStockCodeInventoryMovements_GeneratedStockCodeId_MovementDate",
                table: "GeneratedStockCodeInventoryMovements",
                columns: new[] { "GeneratedStockCodeId", "MovementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodeInventoryMovements_StockProductGroupId",
                table: "GeneratedStockCodeInventoryMovements",
                column: "StockProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodeRuleSelections_GeneratedStockCodeId_StockSubCodeRuleId",
                table: "GeneratedStockCodeRuleSelections",
                columns: new[] { "GeneratedStockCodeId", "StockSubCodeRuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodeRuleSelections_StockSubCodeRuleId",
                table: "GeneratedStockCodeRuleSelections",
                column: "StockSubCodeRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodes_StockSubCodeGroupId",
                table: "GeneratedStockCodes",
                column: "StockSubCodeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStockCodes_StockSubCodeRuleId",
                table: "GeneratedStockCodes",
                column: "StockSubCodeRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialForms_MaterialId_FormType_Norm_ProductStandard_ThicknessMin_ThicknessMax",
                table: "MaterialForms",
                columns: new[] { "MaterialId", "FormType", "Norm", "ProductStandard", "ThicknessMin", "ThicknessMax" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialNumber_Name",
                table: "Materials",
                columns: new[] { "MaterialNumber", "Name" },
                unique: true);

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
                columns: new[] { "StockSubCodeGroupId", "RuleCode" });

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
                name: "DesignPlanningEmployeeExpertises");

            migrationBuilder.DropTable(
                name: "DesignPlanningProjectTasks");

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
                name: "GeneratedStockCodeInventoryMovements");

            migrationBuilder.DropTable(
                name: "GeneratedStockCodeRuleSelections");

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
                name: "DesignPlanningEmployees");

            migrationBuilder.DropTable(
                name: "DesignPlanningProjects");

            migrationBuilder.DropTable(
                name: "DesignPlanningTaskTemplates");

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
                name: "DesignPlanningProjectTypes");

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
