using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refreshmaterialandformseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Name", "Norm", "Notes", "StockCode", "SymbolicName" },
                values: new object[] { "P355GH", "EN10028-2", "Pressure vessel plate according to EN10028-2", null, "P355GH" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "StockCode",
                value: "STK-SS-4301");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "StockCode",
                value: "STK-CS-S235JR");

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Density", "ElasticModulus", "Group", "MaterialNumber", "ModifiedBy", "ModifiedDate", "Name", "Norm", "Notes", "Origin", "Standard", "Status", "StockCode", "SymbolicName", "YieldFactorK" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), null, "SeedData", DateTime.UtcNow, null, null, 7850.0, null, "Carbon Steel", "1.0565", null, null, "P355NH", "EN10028-3", "Normalized pressure vessel steel EN10028-3", "Plate", 0, 0, null, "P355NH", null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), null, "SeedData", DateTime.UtcNow, null, null, 8000.0, null, "Stainless Steel", "1.4307", null, null, "X2CrNi18-9", "EN10028-7", "Austenitic stainless steel plate EN10028-7", "Plate", 0, 0, null, "X2CrNi18-9", null }
                });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Norm", "Notes", "ProductStandard", "SymbolicName" },
                values: new object[] { "EN10028-2", "Standard plate form for P355GH", "EN 10028-2", "P355GH" });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                columns: new[] { "Norm", "StockCode", "SymbolicName" },
                values: new object[] { "EN10028-2", "STK-CS-P355GH-SP", "P355GH" });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444441"),
                column: "StockCode",
                value: "STK-SS-4301-PL");

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666661"),
                column: "StockCode",
                value: "STK-CS-S235JR-PROF");

            migrationBuilder.InsertData(
                table: "MaterialForms",
                columns: new[] { "Id", "ColdStretchYieldStrength", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FormType", "MaterialClass", "MaterialId", "ModifiedBy", "ModifiedDate", "MomentOfInertia", "Norm", "Notes", "Origin", "ProductStandard", "SectionArea", "SectionModulus", "Status", "StockCode", "SymbolicName", "TargetPrice", "ThicknessMax", "ThicknessMin", "UnitPrice", "WeldingFactor" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777771"), null, "SeedData", DateTime.UtcNow, null, null, 2, "Carbon Steel", new Guid("77777777-7777-7777-7777-777777777777"), null, null, null, "EN10028-3", "Forged part seed for P355NH", "Forging", "EN 10028-3", null, null, 0, null, "P355NH", null, 300.0, 20.0, 2.8, null },
                    { new Guid("88888888-8888-8888-8888-888888888881"), null, "SeedData", DateTime.UtcNow, null, null, 0, "Stainless Steel", new Guid("88888888-8888-8888-8888-888888888888"), null, null, null, "EN10028-7", "Plate seed for X2CrNi18-9", "Plate", "EN 10028-7", null, null, 0, null, "X2CrNi18-9", null, 120.0, 1.0, 4.9, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"));

            migrationBuilder.DeleteData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888881"));

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));
        }
    }
}
