using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    [Migration("20260318123000_v44")]
    public partial class v44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BombeLaborRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RatePerKg = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_BombeLaborRates", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "GugHourlyRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_GugHourlyRates", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "LaborRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_LaborRates", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "OverheadRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OverheadType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_OverheadRates", x => x.Id); });

            migrationBuilder.AddColumn<Guid>(name: "InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses", type: "uniqueidentifier", nullable: true);
            migrationBuilder.AddColumn<Guid>(name: "OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses", type: "uniqueidentifier", nullable: true);

            migrationBuilder.CreateTable(
                name: "EN13458SalesPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GugHourlyRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinanceOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralManagementOverheadRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaborHours = table.Column<double>(type: "float", nullable: false),
                    ProfitPercentage = table.Column<double>(type: "float", nullable: false),
                    LaborCost = table.Column<double>(type: "float", nullable: false),
                    GugCost = table.Column<double>(type: "float", nullable: false),
                    ImmCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam1 = table.Column<double>(type: "float", nullable: false),
                    FinanceCost = table.Column<double>(type: "float", nullable: false),
                    GeneralManagementCost = table.Column<double>(type: "float", nullable: false),
                    AraToplam2 = table.Column<double>(type: "float", nullable: false),
                    SalesPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EN13458SalesPrices", x => x.Id);
                });

            migrationBuilder.CreateIndex(name: "IX_EN13458CostAnalyses_InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses", column: "InnerHeadBombeLaborRateId");
            migrationBuilder.CreateIndex(name: "IX_EN13458CostAnalyses_OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses", column: "OuterHeadBombeLaborRateId");
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_EN13458CostAnalysisId", table: "EN13458SalesPrices", column: "EN13458CostAnalysisId", unique: true);
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_EN13458CalculationId", table: "EN13458SalesPrices", column: "EN13458CalculationId");
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_LaborRateId", table: "EN13458SalesPrices", column: "LaborRateId");
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_GugHourlyRateId", table: "EN13458SalesPrices", column: "GugHourlyRateId");
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_FinanceOverheadRateId", table: "EN13458SalesPrices", column: "FinanceOverheadRateId");
            migrationBuilder.CreateIndex(name: "IX_EN13458SalesPrices_GeneralManagementOverheadRateId", table: "EN13458SalesPrices", column: "GeneralManagementOverheadRateId");

            migrationBuilder.AddForeignKey(name: "FK_EN13458CostAnalyses_BombeLaborRates_InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses", column: "InnerHeadBombeLaborRateId", principalTable: "BombeLaborRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458CostAnalyses_BombeLaborRates_OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses", column: "OuterHeadBombeLaborRateId", principalTable: "BombeLaborRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_EN13458Calculations_EN13458CalculationId", table: "EN13458SalesPrices", column: "EN13458CalculationId", principalTable: "EN13458Calculations", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_EN13458CostAnalyses_EN13458CostAnalysisId", table: "EN13458SalesPrices", column: "EN13458CostAnalysisId", principalTable: "EN13458CostAnalyses", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_GugHourlyRates_GugHourlyRateId", table: "EN13458SalesPrices", column: "GugHourlyRateId", principalTable: "GugHourlyRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_LaborRates_LaborRateId", table: "EN13458SalesPrices", column: "LaborRateId", principalTable: "LaborRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_OverheadRates_FinanceOverheadRateId", table: "EN13458SalesPrices", column: "FinanceOverheadRateId", principalTable: "OverheadRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(name: "FK_EN13458SalesPrices_OverheadRates_GeneralManagementOverheadRateId", table: "EN13458SalesPrices", column: "GeneralManagementOverheadRateId", principalTable: "OverheadRates", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EN13458CostAnalyses_BombeLaborRates_InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses");
            migrationBuilder.DropForeignKey(name: "FK_EN13458CostAnalyses_BombeLaborRates_OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses");
            migrationBuilder.DropTable(name: "EN13458SalesPrices");
            migrationBuilder.DropTable(name: "BombeLaborRates");
            migrationBuilder.DropTable(name: "GugHourlyRates");
            migrationBuilder.DropTable(name: "LaborRates");
            migrationBuilder.DropTable(name: "OverheadRates");
            migrationBuilder.DropIndex(name: "IX_EN13458CostAnalyses_InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses");
            migrationBuilder.DropIndex(name: "IX_EN13458CostAnalyses_OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses");
            migrationBuilder.DropColumn(name: "InnerHeadBombeLaborRateId", table: "EN13458CostAnalyses");
            migrationBuilder.DropColumn(name: "OuterHeadBombeLaborRateId", table: "EN13458CostAnalyses");
        }
    }
}
