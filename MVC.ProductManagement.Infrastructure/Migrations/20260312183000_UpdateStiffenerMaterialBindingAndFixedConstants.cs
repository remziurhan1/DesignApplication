using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class UpdateStiffenerMaterialBindingAndFixedConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MomentOfInertia",
                table: "MaterialForms",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FixedOutOfRoundnessPercent",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "FixedPoissonRatio",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<double>(
                name: "FixedWeldCoefficient",
                table: "EN13458Calculations",
                type: "float",
                nullable: false,
                defaultValue: 0d);

            migrationBuilder.AddColumn<Guid>(
                name: "StiffenerMaterialFormId",
                table: "EN13458Calculations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StiffenerMaterialId",
                table: "EN13458Calculations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseManualStiffenerValues",
                table: "EN13458Calculations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MomentOfInertia", table: "MaterialForms");
            migrationBuilder.DropColumn(name: "FixedOutOfRoundnessPercent", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "FixedPoissonRatio", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "FixedWeldCoefficient", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerMaterialFormId", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerMaterialId", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "UseManualStiffenerValues", table: "EN13458Calculations");
        }
    }
}
