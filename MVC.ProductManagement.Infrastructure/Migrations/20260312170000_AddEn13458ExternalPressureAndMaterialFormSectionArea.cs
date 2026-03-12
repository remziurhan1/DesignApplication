using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddEn13458ExternalPressureAndMaterialFormSectionArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(name: "AllowableExternalPressure", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "BucklingLength", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "CorrosionAllowance", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "DOverT", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "DaOverLb", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "EffectiveOuterThickness", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "ElasticBucklingPressure", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "ElasticModulus", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "ExternalDesignPressure", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<bool>(name: "ExternalPressureDesignOk", table: "EN13458Calculations", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "HasStiffener", table: "EN13458Calculations", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<double>(name: "LOverD", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "PlasticDeformationPressure", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "PoissonRatio", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "RequiredStiffenerArea", table: "EN13458Calculations", type: "float", nullable: true);
            migrationBuilder.AddColumn<double>(name: "RequiredStiffenerInertia", table: "EN13458Calculations", type: "float", nullable: true);
            migrationBuilder.AddColumn<double>(name: "RoundnessErrorPercent", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);
            migrationBuilder.AddColumn<double>(name: "StiffenerArea", table: "EN13458Calculations", type: "float", nullable: true);
            migrationBuilder.AddColumn<bool>(name: "StiffenerAreaOk", table: "EN13458Calculations", type: "bit", nullable: true);
            migrationBuilder.AddColumn<double>(name: "StiffenerInertia", table: "EN13458Calculations", type: "float", nullable: true);
            migrationBuilder.AddColumn<bool>(name: "StiffenerInertiaOk", table: "EN13458Calculations", type: "bit", nullable: true);
            migrationBuilder.AddColumn<bool>(name: "UseGeneralElasticFormula", table: "EN13458Calculations", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<double>(name: "YieldFactorK", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 0d);

            migrationBuilder.AddColumn<double>(name: "SectionArea", table: "MaterialForms", type: "float", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "AllowableExternalPressure", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "BucklingLength", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "CorrosionAllowance", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "DOverT", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "DaOverLb", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "EffectiveOuterThickness", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "ElasticBucklingPressure", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "ElasticModulus", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "ExternalDesignPressure", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "ExternalPressureDesignOk", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "HasStiffener", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "LOverD", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "PlasticDeformationPressure", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "PoissonRatio", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "RequiredStiffenerArea", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "RequiredStiffenerInertia", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "RoundnessErrorPercent", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerArea", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerAreaOk", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerInertia", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "StiffenerInertiaOk", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "UseGeneralElasticFormula", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "YieldFactorK", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "SectionArea", table: "MaterialForms");
        }
    }
}
