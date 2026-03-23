using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class v44_sales_request_workflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesRequestProductGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedByName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RequestedByEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RequestedByDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SummaryNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    SalesOpenedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricingCompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SalesRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestAttachments_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRequestItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentSalesRequestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CapacityM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumptionCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TankOrientation = table.Column<int>(type: "int", nullable: false),
                    PlacementType = table.Column<int>(type: "int", nullable: false),
                    MinimumTechnicalNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SalesEngineeringNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DesignDetails = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedSalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SalesRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequestItems_ParentSalesRequestItemId",
                        column: x => x.ParentSalesRequestItemId,
                        principalTable: "SalesRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequestProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "SalesRequestProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestItems_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SalesRequestProductGroups",
                columns: new[] { "Id", "Code", "ShortCode", "Name", "DisplayOrder", "IsActive", "CreatedBy", "CreatedDate", "Status" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "01", "LPG", "LPG (LIQUID PETROLEUM GAS)", 1, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "02", "LNG", "LNG (LIQUID NATURAL GAS)", 2, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "03", "LOX", "LOX (LIQUID OXYGEN)", 3, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "04", "LIN", "LIN (LIQUID NITROGEN)", 4, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "05", "LAR", "LAR (LIQUID ARGON)", 5, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "06", "LCO2", "LCO2 / LIC (CARBON DIOXIDE)", 6, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "07", "PROSES", "PROSES VE HAVA TANKLARI", 7, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "08", "H2", "HİDROJEN TANKLARI", 8, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "09", "KIM", "KİMYASAL TANKLAR", 9, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "10", "GOX", "GOX (GAZ OKSİJEN)", 10, true, "SeedData", new DateTime(2026, 3, 23, 0, 0, 0, DateTimeKind.Utc), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestAttachments_SalesRequestId",
                table: "SalesRequestAttachments",
                column: "SalesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_ParentSalesRequestItemId",
                table: "SalesRequestItems",
                column: "ParentSalesRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_ProductGroupId",
                table: "SalesRequestItems",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestItems_SalesRequestId",
                table: "SalesRequestItems",
                column: "SalesRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestProductGroups_Code",
                table: "SalesRequestProductGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequests_CustomerId",
                table: "SalesRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequests_RequestNo",
                table: "SalesRequests",
                column: "RequestNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "SalesRequestAttachments");
            migrationBuilder.DropTable(name: "SalesRequestItems");
            migrationBuilder.DropTable(name: "SalesRequestProductGroups");
            migrationBuilder.DropTable(name: "SalesRequests");
        }
    }
}
