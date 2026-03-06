using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFluidFromStockCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockCards_Fluids_FluidId",
                table: "StockCards");

            migrationBuilder.DropIndex(
                name: "IX_StockCards_FluidId_SProductGroupId_SProductId_OptionKey",
                table: "StockCards");

            migrationBuilder.DropColumn(
                name: "FluidId",
                table: "StockCards");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_SProductGroupId_SProductId_OptionKey",
                table: "StockCards",
                columns: new[] { "SProductGroupId", "SProductId", "OptionKey" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockCards_SProductGroupId_SProductId_OptionKey",
                table: "StockCards");

            migrationBuilder.AddColumn<Guid>(
                name: "FluidId",
                table: "StockCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_FluidId_SProductGroupId_SProductId_OptionKey",
                table: "StockCards",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId", "OptionKey" },
                unique: true,
                filter: "[FluidId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StockCards_Fluids_FluidId",
                table: "StockCards",
                column: "FluidId",
                principalTable: "Fluids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
