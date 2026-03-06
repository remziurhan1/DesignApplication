using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFluidCompletely : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop FK and indexes from SGroupFilterRules
            migrationBuilder.DropForeignKey(
                name: "FK_SGroupFilterRules_Fluids_FluidId",
                table: "SGroupFilterRules");

            migrationBuilder.DropIndex(
                name: "IX_SGroupFilterRules_CategoryId_FluidId_SProductGroupId",
                table: "SGroupFilterRules");

            migrationBuilder.DropIndex(
                name: "IX_SGroupFilterRules_FluidId",
                table: "SGroupFilterRules");

            migrationBuilder.DropColumn(
                name: "FluidId",
                table: "SGroupFilterRules");

            // Drop FK and indexes from SPrefixRules
            migrationBuilder.DropForeignKey(
                name: "FK_SPrefixRules_Fluids_FluidId",
                table: "SPrefixRules");

            migrationBuilder.DropIndex(
                name: "IX_SPrefixRules_SProductGroupId_FluidId_SProductId",
                table: "SPrefixRules");

            migrationBuilder.DropIndex(
                name: "IX_SPrefixRules_FluidId",
                table: "SPrefixRules");

            migrationBuilder.DropColumn(
                name: "FluidId",
                table: "SPrefixRules");

            // Drop FK and indexes from PrefixRules
            migrationBuilder.DropForeignKey(
                name: "FK_PrefixRules_Fluids_FluidId",
                table: "PrefixRules");

            migrationBuilder.DropIndex(
                name: "IX_PrefixRules_FluidId_SProductGroupId_SProductId",
                table: "PrefixRules");

            migrationBuilder.DropColumn(
                name: "FluidId",
                table: "PrefixRules");

            // Add new unique indexes without FluidId
            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_CategoryId_SProductGroupId",
                table: "SGroupFilterRules",
                columns: new[] { "CategoryId", "SProductGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_SProductGroupId_SProductId",
                table: "SPrefixRules",
                columns: new[] { "SProductGroupId", "SProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_SProductGroupId_SProductId",
                table: "PrefixRules",
                columns: new[] { "SProductGroupId", "SProductId" },
                unique: true);

            // Drop the Fluids table
            migrationBuilder.DropTable(
                name: "Fluids");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Re-create Fluids table
            migrationBuilder.CreateTable(
                name: "Fluids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluids", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluids_Code",
                table: "Fluids",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluids_Name",
                table: "Fluids",
                column: "Name");

            // Drop new indexes
            migrationBuilder.DropIndex(
                name: "IX_SGroupFilterRules_CategoryId_SProductGroupId",
                table: "SGroupFilterRules");

            migrationBuilder.DropIndex(
                name: "IX_SPrefixRules_SProductGroupId_SProductId",
                table: "SPrefixRules");

            migrationBuilder.DropIndex(
                name: "IX_PrefixRules_SProductGroupId_SProductId",
                table: "PrefixRules");

            // Restore FluidId columns
            migrationBuilder.AddColumn<Guid>(
                name: "FluidId",
                table: "SGroupFilterRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FluidId",
                table: "SPrefixRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FluidId",
                table: "PrefixRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            // Restore indexes
            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_CategoryId_FluidId_SProductGroupId",
                table: "SGroupFilterRules",
                columns: new[] { "CategoryId", "FluidId", "SProductGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SGroupFilterRules_FluidId",
                table: "SGroupFilterRules",
                column: "FluidId");

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_SProductGroupId_FluidId_SProductId",
                table: "SPrefixRules",
                columns: new[] { "SProductGroupId", "FluidId", "SProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPrefixRules_FluidId",
                table: "SPrefixRules",
                column: "FluidId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefixRules_FluidId_SProductGroupId_SProductId",
                table: "PrefixRules",
                columns: new[] { "FluidId", "SProductGroupId", "SProductId" },
                unique: true);

            // Restore FKs
            migrationBuilder.AddForeignKey(
                name: "FK_SGroupFilterRules_Fluids_FluidId",
                table: "SGroupFilterRules",
                column: "FluidId",
                principalTable: "Fluids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SPrefixRules_Fluids_FluidId",
                table: "SPrefixRules",
                column: "FluidId",
                principalTable: "Fluids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrefixRules_Fluids_FluidId",
                table: "PrefixRules",
                column: "FluidId",
                principalTable: "Fluids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
