using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v7_EN13458WeldPerliteBreakdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GasNitrogenVolume",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "InnerSurfaceArea",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "InnerTankCircumferenceWeldLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "InnerTankHeadWeldLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "InnerTankWeight",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "InnerVolume",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "LiquidNitrogenVolume",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterSurfaceArea",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterTankCircumferenceWeldLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterTankHeadWeldLength",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterTankWeight",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "OuterVolume",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "PerliteVolume",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "PerliteWeight",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "GasNitrogenVolume", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerSurfaceArea", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerTankCircumferenceWeldLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerTankHeadWeldLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerTankWeight", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerVolume", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "LiquidNitrogenVolume", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterSurfaceArea", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterTankCircumferenceWeldLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterTankHeadWeldLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterTankWeight", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterVolume", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "PerliteVolume", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "PerliteWeight", table: "EN13458Calculations");
        }
    }
}
