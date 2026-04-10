using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class materialoriginclassnormstockcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Norm",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "Materials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SymbolicName",
                table: "Materials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Group", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Carbon Steel", "EN10028-3", "Plate", "P355NH" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Group", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Stainless Steel", "EN10028-7", "Plate", "X5CrNi18-10" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Group", "Norm", "Origin", "SymbolicName" },
                values: new object[] { "Carbon Steel", "EN10025", "Bar", "S235JR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Norm",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SymbolicName",
                table: "Materials");
        }
    }
}
