using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class v24_add_shared_sold_sales_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SharedSalesPrice",
                table: "SalesRequestItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoldSalesPrice",
                table: "SalesRequestItems",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharedSalesPrice",
                table: "SalesRequestItems");

            migrationBuilder.DropColumn(
                name: "SoldSalesPrice",
                table: "SalesRequestItems");
        }
    }
}
