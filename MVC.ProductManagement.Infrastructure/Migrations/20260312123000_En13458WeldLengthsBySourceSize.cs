using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class En13458WeldLengthsBySourceSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectorWidth",
                table: "EN13458Calculations");

            migrationBuilder.AddColumn<double>(
                name: "WeldLength1500",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength2000",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength2500",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength3000",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeldLength1500",
                table: "EN13458Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength2000",
                table: "EN13458Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength2500",
                table: "EN13458Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength3000",
                table: "EN13458Calculations");

            migrationBuilder.AddColumn<double>(
                name: "SectorWidth",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);
        }
    }
}
