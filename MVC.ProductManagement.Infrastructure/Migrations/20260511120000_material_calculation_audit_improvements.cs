using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class materialcalculationauditimprovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(name: "MaterialFamily", table: "MaterialForms", type: "int", nullable: false, defaultValue: 0);

            migrationBuilder.Sql(@"
UPDATE MaterialForms
SET MaterialFamily = CASE
    WHEN LOWER(COALESCE(MaterialClass, '')) LIKE '%stainless%' OR LOWER(COALESCE(MaterialClass, '')) LIKE '%paslanmaz%' THEN 2
    WHEN LOWER(COALESCE(MaterialClass, '')) LIKE '%carbon%' OR LOWER(COALESCE(MaterialClass, '')) LIKE '%karbon%' THEN 1
    ELSE 0
END");

            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("22222222-2222-2222-2222-222222222222"), column: "MaterialFamily", value: 1);
            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("22222222-2222-2222-2222-222222222223"), columns: new[] { "MaterialFamily", "MaterialId", "Norm", "StockCode", "SymbolicName" }, values: new object[] { 1, new System.Guid("77777777-7777-7777-7777-777777777777"), "EN10216-3", "STK-CS-P355NH-SP", "P355NH" });
            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("44444444-4444-4444-4444-444444444441"), column: "MaterialFamily", value: 2);
            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("66666666-6666-6666-6666-666666666661"), column: "MaterialFamily", value: 1);
            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("77777777-7777-7777-7777-777777777771"), column: "MaterialFamily", value: 1);
            migrationBuilder.UpdateData(table: "MaterialForms", keyColumn: "Id", keyValue: new System.Guid("88888888-8888-8888-8888-888888888881"), column: "MaterialFamily", value: 2);

            migrationBuilder.AddColumn<double>(name: "DesignTemperature", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 20.0);
            migrationBuilder.AddColumn<double>(name: "InnerShellMaterialDensity", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 7850.0);
            migrationBuilder.AddColumn<double>(name: "InnerHeadMaterialDensity", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 7850.0);
            migrationBuilder.AddColumn<double>(name: "OuterShellMaterialDensity", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 7850.0);
            migrationBuilder.AddColumn<double>(name: "OuterHeadMaterialDensity", table: "EN13458Calculations", type: "float", nullable: false, defaultValue: 7850.0);

            migrationBuilder.AddColumn<double>(name: "ShellYieldStrengthRp02", table: "AD2000Calculations", type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "HeadYieldStrengthRp02", table: "AD2000Calculations", type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "ShellDesignStress", table: "AD2000Calculations", type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "HeadDesignStress", table: "AD2000Calculations", type: "float", nullable: false, defaultValue: 0.0);

            AddCostAuditColumns(migrationBuilder, "EN13458CostAnalysisItems");
            AddCostAuditColumns(migrationBuilder, "AD2000CostAnalysisItems");

            migrationBuilder.Sql("UPDATE EN13458CostAnalysisItems SET PriceSource = CASE WHEN UseManualUnitPrice = 1 THEN 'ManualUnitPrice' WHEN GeneratedStockCodeId IS NOT NULL THEN 'GeneratedStockCode.UnitPrice' WHEN StockUnitPrice > 0 THEN 'StoredStockUnitPrice' ELSE 'None' END, DensitySource = CASE WHEN Density > 0 THEN 'Material.Density' ELSE 'Unknown' END");
            migrationBuilder.Sql("UPDATE AD2000CostAnalysisItems SET PriceSource = CASE WHEN UseManualUnitPrice = 1 THEN 'ManualUnitPrice' WHEN GeneratedStockCodeId IS NOT NULL THEN 'GeneratedStockCode.UnitPrice' WHEN StockUnitPrice > 0 THEN 'StoredStockUnitPrice' ELSE 'None' END, DensitySource = CASE WHEN Density > 0 THEN 'Material.Density' ELSE 'Unknown' END");

            migrationBuilder.CreateIndex(name: "IX_Materials_MaterialNumber_Name", table: "Materials", columns: new[] { "MaterialNumber", "Name" }, unique: true);
            migrationBuilder.CreateIndex(name: "IX_MaterialForms_MaterialId_FormType_Norm_ProductStandard_ThicknessMin_ThicknessMax", table: "MaterialForms", columns: new[] { "MaterialId", "FormType", "Norm", "ProductStandard", "ThicknessMin", "ThicknessMax" }, unique: true);
            migrationBuilder.CreateIndex(name: "IX_YieldStrengths_MaterialFormId_ThicknessMin_ThicknessMax_Temperature", table: "YieldStrengths", columns: new[] { "MaterialFormId", "ThicknessMin", "ThicknessMax", "Temperature" }, unique: true);
            migrationBuilder.CreateIndex(name: "IX_AllowableStresses_MaterialFormId_Temperature", table: "AllowableStresses", columns: new[] { "MaterialFormId", "Temperature" }, unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Materials_MaterialNumber_Name", table: "Materials");
            migrationBuilder.DropIndex(name: "IX_MaterialForms_MaterialId_FormType_Norm_ProductStandard_ThicknessMin_ThicknessMax", table: "MaterialForms");
            migrationBuilder.DropIndex(name: "IX_YieldStrengths_MaterialFormId_ThicknessMin_ThicknessMax_Temperature", table: "YieldStrengths");
            migrationBuilder.DropIndex(name: "IX_AllowableStresses_MaterialFormId_Temperature", table: "AllowableStresses");

            DropCostAuditColumns(migrationBuilder, "EN13458CostAnalysisItems");
            DropCostAuditColumns(migrationBuilder, "AD2000CostAnalysisItems");

            migrationBuilder.DropColumn(name: "ShellYieldStrengthRp02", table: "AD2000Calculations");
            migrationBuilder.DropColumn(name: "HeadYieldStrengthRp02", table: "AD2000Calculations");
            migrationBuilder.DropColumn(name: "ShellDesignStress", table: "AD2000Calculations");
            migrationBuilder.DropColumn(name: "HeadDesignStress", table: "AD2000Calculations");

            migrationBuilder.DropColumn(name: "DesignTemperature", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerShellMaterialDensity", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "InnerHeadMaterialDensity", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterShellMaterialDensity", table: "EN13458Calculations");
            migrationBuilder.DropColumn(name: "OuterHeadMaterialDensity", table: "EN13458Calculations");

            migrationBuilder.DropColumn(name: "MaterialFamily", table: "MaterialForms");
        }

        private static void AddCostAuditColumns(MigrationBuilder migrationBuilder, string table)
        {
            migrationBuilder.AddColumn<string>(name: "MaterialNumber", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "MaterialClass", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "MaterialFamily", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "Norm", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "ProductStandard", table: table, type: "nvarchar(128)", maxLength: 128, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "SymbolicName", table: table, type: "nvarchar(128)", maxLength: 128, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<double>(name: "UsedYieldStrength", table: table, type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "UsedDesignStress", table: table, type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "UsedTemperature", table: table, type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "UsedThicknessBandMin", table: table, type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<double>(name: "UsedThicknessBandMax", table: table, type: "float", nullable: false, defaultValue: 0.0);
            migrationBuilder.AddColumn<string>(name: "DensitySource", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "PriceSource", table: table, type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
        }

        private static void DropCostAuditColumns(MigrationBuilder migrationBuilder, string table)
        {
            migrationBuilder.DropColumn(name: "MaterialNumber", table: table);
            migrationBuilder.DropColumn(name: "MaterialClass", table: table);
            migrationBuilder.DropColumn(name: "MaterialFamily", table: table);
            migrationBuilder.DropColumn(name: "Norm", table: table);
            migrationBuilder.DropColumn(name: "ProductStandard", table: table);
            migrationBuilder.DropColumn(name: "SymbolicName", table: table);
            migrationBuilder.DropColumn(name: "UsedYieldStrength", table: table);
            migrationBuilder.DropColumn(name: "UsedDesignStress", table: table);
            migrationBuilder.DropColumn(name: "UsedTemperature", table: table);
            migrationBuilder.DropColumn(name: "UsedThicknessBandMin", table: table);
            migrationBuilder.DropColumn(name: "UsedThicknessBandMax", table: table);
            migrationBuilder.DropColumn(name: "DensitySource", table: table);
            migrationBuilder.DropColumn(name: "PriceSource", table: table);
        }
    }
}
