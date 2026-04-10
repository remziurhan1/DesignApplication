using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removematerialformmetadatafrommaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Norm",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SymbolicName",
                table: "Materials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Norm",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SymbolicName",
                table: "Materials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
