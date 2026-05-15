using MVC.ProductManagement.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AppDbContext))]
    [Migration("20260515120000_add_stock_code_definition_permissions")]
    public partial class add_stock_code_definition_permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanManageStockCodeDefinitions",
                table: "EmployeeProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql(@"
UPDATE [EmployeeProfiles]
SET [CanManageStockCodeDefinitions] = 1
WHERE [CanAccessDesignArea] = 1
  AND ([DepartmentRole] LIKE N'%Müdür%' OR [DepartmentRole] LIKE N'%Mudur%')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanManageStockCodeDefinitions",
                table: "EmployeeProfiles");
        }
    }
}
