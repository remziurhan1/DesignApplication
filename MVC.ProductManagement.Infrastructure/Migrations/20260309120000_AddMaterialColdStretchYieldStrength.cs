using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddMaterialColdStretchYieldStrength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ColdStretchYieldStrength",
                table: "MaterialForms",
                type: "float",
                precision: 10,
                scale: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColdStretchYieldStrength",
                table: "MaterialForms");
        }
    }
}
