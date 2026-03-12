using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddMaterialElasticModulusAndYieldFactorK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ElasticModulus",
                table: "Materials",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "YieldFactorK",
                table: "Materials",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ElasticModulus", table: "Materials");
            migrationBuilder.DropColumn(name: "YieldFactorK", table: "Materials");
        }
    }
}
