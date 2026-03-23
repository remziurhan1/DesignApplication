using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class v46_sales_price_visibility_updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MinimumSalesPrice",
                table: "AD2000SalesPrices",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "MinimumSalesPrice",
                table: "EN13458SalesPrices",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumSalesPrice",
                table: "SalesRequestItems",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumSalesPrice",
                table: "AD2000SalesPrices");

            migrationBuilder.DropColumn(
                name: "MinimumSalesPrice",
                table: "EN13458SalesPrices");

            migrationBuilder.DropColumn(
                name: "MinimumSalesPrice",
                table: "SalesRequestItems");
        }
    }
}
