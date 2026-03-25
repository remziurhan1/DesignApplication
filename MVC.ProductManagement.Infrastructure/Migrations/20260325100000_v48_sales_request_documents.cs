using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    public partial class v48_sales_request_documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesRequestDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRequestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    RevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    LinkedCostAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkedCostAnalysisRevisionCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRequestDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRequestDocuments_SalesRequestItems_SalesRequestItemId",
                        column: x => x.SalesRequestItemId,
                        principalTable: "SalesRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesRequestDocuments_SalesRequests_SalesRequestId",
                        column: x => x.SalesRequestId,
                        principalTable: "SalesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestDocuments_SalesRequestId_DocumentType_RevisionCode",
                table: "SalesRequestDocuments",
                columns: new[] { "SalesRequestId", "DocumentType", "RevisionCode" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRequestDocuments_SalesRequestItemId",
                table: "SalesRequestDocuments",
                column: "SalesRequestItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRequestDocuments");
        }
    }
}
