using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class movematerialmetadatatomaterialforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialClass",
                table: "MaterialForms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Norm",
                table: "MaterialForms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "MaterialForms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "MaterialForms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SymbolicName",
                table: "MaterialForms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.Sql(@"
UPDATE mf
SET
    mf.Origin = COALESCE(m.Origin, ''),
    mf.MaterialClass = COALESCE(m.[Group], ''),
    mf.Norm = COALESCE(m.Norm, ''),
    mf.SymbolicName = m.SymbolicName,
    mf.StockCode = m.StockCode
FROM MaterialForms mf
INNER JOIN Materials m ON m.Id = mf.MaterialId;
");

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "MaterialClass", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Carbon Steel", "EN10028-3", "Plate", "P355NH" });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                columns: new[] { "MaterialClass", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Carbon Steel", "EN10028-3", "Seamless Pipe", "P355NH" });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444441"),
                columns: new[] { "MaterialClass", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Stainless Steel", "EN10028-7", "Plate", "X5CrNi18-10" });

            migrationBuilder.UpdateData(
                table: "MaterialForms",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666661"),
                columns: new[] { "MaterialClass", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Carbon Steel", "EN10025", "Bar", "S235JR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialClass",
                table: "MaterialForms");

            migrationBuilder.DropColumn(
                name: "Norm",
                table: "MaterialForms");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "MaterialForms");

            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "MaterialForms");

            migrationBuilder.DropColumn(
                name: "SymbolicName",
                table: "MaterialForms");
        }
    }
}
