using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddProfileMetricsToEn13458Calculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProfileWeldLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "TotalProfileLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileWeldLength",
                table: "EN13458Calculations");

            migrationBuilder.DropColumn(
                name: "TotalProfileLength",
                table: "EN13458Calculations");
        }
    }
}
