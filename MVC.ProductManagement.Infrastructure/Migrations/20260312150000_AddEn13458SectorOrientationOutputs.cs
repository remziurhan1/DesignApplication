using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddEn13458SectorOrientationOutputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InnerDevelopedLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterDevelopedLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<string>(
                name: "InnerSectorPlan1500",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InnerSectorPlan2000",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InnerSectorPlan2500",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InnerSectorPlan3000",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OuterSectorPlan1500",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OuterSectorPlan2000",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OuterSectorPlan2500",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OuterSectorPlan3000",
                table: "EN13458Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "InnerDevelopedLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterDevelopedLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerSectorPlan1500", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerSectorPlan2000", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerSectorPlan2500", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerSectorPlan3000", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterSectorPlan1500", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterSectorPlan2000", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterSectorPlan2500", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterSectorPlan3000", table: "EN13458Calculations");
        }
    }
}
