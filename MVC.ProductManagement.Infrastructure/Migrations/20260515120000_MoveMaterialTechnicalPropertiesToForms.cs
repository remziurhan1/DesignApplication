using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveMaterialTechnicalPropertiesToForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ElasticModulus",
                table: "MaterialForms",
                type: "float(10)",
                precision: 10,
                scale: 3,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "YieldFactorK",
                table: "MaterialForms",
                type: "float(10)",
                precision: 10,
                scale: 3,
                nullable: true);

            migrationBuilder.Sql(@"
UPDATE mf
SET
    mf.ColdStretchYieldStrength = COALESCE(mf.ColdStretchYieldStrength, m.ColdStretchYieldStrength),
    mf.ElasticModulus = COALESCE(mf.ElasticModulus, m.ElasticModulus),
    mf.YieldFactorK = COALESCE(mf.YieldFactorK, m.YieldFactorK)
FROM MaterialForms mf
INNER JOIN Materials m ON m.Id = mf.MaterialId;");

            migrationBuilder.DropColumn(
                name: "ColdStretchYieldStrength",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ElasticModulus",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "YieldFactorK",
                table: "Materials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ColdStretchYieldStrength",
                table: "Materials",
                type: "float",
                nullable: true);

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

            migrationBuilder.Sql(@"
UPDATE m
SET
    m.ColdStretchYieldStrength = x.ColdStretchYieldStrength,
    m.ElasticModulus = x.ElasticModulus,
    m.YieldFactorK = x.YieldFactorK
FROM Materials m
OUTER APPLY (
    SELECT TOP (1)
        mf.ColdStretchYieldStrength,
        mf.ElasticModulus,
        mf.YieldFactorK
    FROM MaterialForms mf
    WHERE mf.MaterialId = m.Id
    ORDER BY mf.CreatedDate, mf.Id
) x;");

            migrationBuilder.DropColumn(
                name: "ElasticModulus",
                table: "MaterialForms");

            migrationBuilder.DropColumn(
                name: "YieldFactorK",
                table: "MaterialForms");
        }
    }
}
