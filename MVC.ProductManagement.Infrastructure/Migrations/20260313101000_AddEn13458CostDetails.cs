using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class AddEn13458CostDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EN13458CostDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EN13458CalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostGroupCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CostGroupName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MaterialFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CalculatedThickness = table.Column<double>(type: "float", nullable: false),
                    UsedThickness = table.Column<double>(type: "float", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TheoreticalWeight = table.Column<double>(type: "float", nullable: false),
                    ItemCost = table.Column<double>(type: "float", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EN13458CostDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EN13458CostDetails_EN13458Calculations_EN13458CalculationId",
                        column: x => x.EN13458CalculationId,
                        principalTable: "EN13458Calculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EN13458CostDetails_EN13458CalculationId",
                table: "EN13458CostDetails",
                column: "EN13458CalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EN13458CostDetails");
        }
    }
}
