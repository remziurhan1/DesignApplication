using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class allowduplicaterulecodepersubgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockSubCodeRules_StockSubCodeGroupId_RuleCode",
                table: "StockSubCodeRules");

            migrationBuilder.CreateIndex(
                name: "IX_StockSubCodeRules_StockSubCodeGroupId_RuleCode",
                table: "StockSubCodeRules",
                columns: new[] { "StockSubCodeGroupId", "RuleCode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockSubCodeRules_StockSubCodeGroupId_RuleCode",
                table: "StockSubCodeRules");

            migrationBuilder.CreateIndex(
                name: "IX_StockSubCodeRules_StockSubCodeGroupId_RuleCode",
                table: "StockSubCodeRules",
                columns: new[] { "StockSubCodeGroupId", "RuleCode" },
                unique: true);
        }
    }
}
