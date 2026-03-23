using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class v45_sales_request_cost_links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LinkedCalculationId",
                table: "SalesRequestItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedCalculationName",
                table: "SalesRequestItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkedCalculationType",
                table: "SalesRequestItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LinkedCostAnalysisId",
                table: "SalesRequestItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedCostAnalysisRevisionCode",
                table: "SalesRequestItems",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LinkedCostAnalysisTotal",
                table: "SalesRequestItems",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedCalculationId",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "LinkedCalculationName",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "LinkedCalculationType",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "LinkedCostAnalysisId",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "LinkedCostAnalysisRevisionCode",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "LinkedCostAnalysisTotal",
                table: "SalesRequestItems");
        }
    }
}
