using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedx2crni189yieldstrengths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DECLARE @MaterialFormId uniqueidentifier = '88888888-8888-8888-8888-888888888881';

INSERT INTO YieldStrengths
    (Id, MaterialFormId, Temperature, ThicknessMin, ThicknessMax, Rp02, Rm, ModifiedBy, ModifiedDate, CreatedBy, CreatedDate, Status, DeletedBy, DeletedDate)
SELECT v.Id, @MaterialFormId, v.Temperature, 1.0, 120.0, v.Rp02, 650.0, NULL, NULL, 'SeedData', SYSUTCDATETIME(), 0, NULL, NULL
FROM (VALUES
    ('90000000-0000-0000-0000-000000000001', -196.0, 350.0),
    ('90000000-0000-0000-0000-000000000002', -150.0, 330.0),
    ('90000000-0000-0000-0000-000000000003', -100.0, 300.0),
    ('90000000-0000-0000-0000-000000000004',  -50.0, 260.0),
    ('90000000-0000-0000-0000-000000000005',   20.0, 210.0),
    ('90000000-0000-0000-0000-000000000006',   50.0, 205.0),
    ('90000000-0000-0000-0000-000000000007',  100.0, 195.0),
    ('90000000-0000-0000-0000-000000000008',  150.0, 185.0),
    ('90000000-0000-0000-0000-000000000009',  200.0, 170.0),
    ('90000000-0000-0000-0000-000000000010',  250.0, 160.0),
    ('90000000-0000-0000-0000-000000000011',  300.0, 150.0),
    ('90000000-0000-0000-0000-000000000012',  350.0, 140.0),
    ('90000000-0000-0000-0000-000000000013',  400.0, 130.0)
) AS v(Id, Temperature, Rp02)
WHERE NOT EXISTS
(
    SELECT 1
    FROM YieldStrengths y
    WHERE y.MaterialFormId = @MaterialFormId
      AND y.ThicknessMin = 1.0
      AND y.ThicknessMax = 120.0
      AND y.Temperature = v.Temperature
);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM YieldStrengths
WHERE Id IN
(
    '90000000-0000-0000-0000-000000000001',
    '90000000-0000-0000-0000-000000000002',
    '90000000-0000-0000-0000-000000000003',
    '90000000-0000-0000-0000-000000000004',
    '90000000-0000-0000-0000-000000000005',
    '90000000-0000-0000-0000-000000000006',
    '90000000-0000-0000-0000-000000000007',
    '90000000-0000-0000-0000-000000000008',
    '90000000-0000-0000-0000-000000000009',
    '90000000-0000-0000-0000-000000000010',
    '90000000-0000-0000-0000-000000000011',
    '90000000-0000-0000-0000-000000000012',
    '90000000-0000-0000-0000-000000000013'
);
");
        }
    }
}
