using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v9_EN13458HeadPulDiameterAndWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('EN13458Calculations', 'InnerTankHeadPulDiameter') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerTankHeadPulDiameter] float NOT NULL CONSTRAINT [DF_EN13458_InnerTankHeadPulDiameter] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterTankHeadPulDiameter') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterTankHeadPulDiameter] float NOT NULL CONSTRAINT [DF_EN13458_OuterTankHeadPulDiameter] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerTankHeadWeight') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerTankHeadWeight] float NOT NULL CONSTRAINT [DF_EN13458_InnerTankHeadWeight] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterTankHeadWeight') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterTankHeadWeight] float NOT NULL CONSTRAINT [DF_EN13458_OuterTankHeadWeight] DEFAULT(0);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // no-op defensive migration
        }
    }
}
