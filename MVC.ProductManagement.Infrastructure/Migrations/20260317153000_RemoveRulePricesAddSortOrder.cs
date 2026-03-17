using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class RemoveRulePricesAddSortOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetPrice",
                table: "StockSubCodeRules");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "StockSubCodeRules");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "StockSubCodeRules",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "StockSubCodeRules");

            migrationBuilder.AddColumn<decimal>(
                name: "TargetPrice",
                table: "StockSubCodeRules",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "StockSubCodeRules",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
