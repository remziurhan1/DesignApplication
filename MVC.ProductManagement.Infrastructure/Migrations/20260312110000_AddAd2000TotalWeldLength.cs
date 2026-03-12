using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddAd2000WeldLengthsBySectorWidth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WeldLength1500",
                table: "AD2000Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength2000",
                table: "AD2000Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength3000",
                table: "AD2000Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "WeldLength4000",
                table: "AD2000Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeldLength1500",
                table: "AD2000Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength2000",
                table: "AD2000Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength3000",
                table: "AD2000Calculations");

            migrationBuilder.DropColumn(
                name: "WeldLength4000",
                table: "AD2000Calculations");
        }
    }
}
