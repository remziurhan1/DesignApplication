using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v8_EN13458EnsureBreakdownColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('EN13458Calculations', 'GasNitrogenVolume') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [GasNitrogenVolume] float NOT NULL CONSTRAINT [DF_EN13458_GasNitrogenVolume] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerSurfaceArea') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerSurfaceArea] float NOT NULL CONSTRAINT [DF_EN13458_InnerSurfaceArea] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerTankCircumferenceWeldLength') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerTankCircumferenceWeldLength] float NOT NULL CONSTRAINT [DF_EN13458_InnerTankCircWeld] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerTankHeadWeldLength') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerTankHeadWeldLength] float NOT NULL CONSTRAINT [DF_EN13458_InnerTankHeadWeld] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerTankWeight') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerTankWeight] float NOT NULL CONSTRAINT [DF_EN13458_InnerTankWeight] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'InnerVolume') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [InnerVolume] float NOT NULL CONSTRAINT [DF_EN13458_InnerVolume] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'LiquidNitrogenVolume') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [LiquidNitrogenVolume] float NOT NULL CONSTRAINT [DF_EN13458_LiquidNitrogenVolume] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterSurfaceArea') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterSurfaceArea] float NOT NULL CONSTRAINT [DF_EN13458_OuterSurfaceArea] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterTankCircumferenceWeldLength') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterTankCircumferenceWeldLength] float NOT NULL CONSTRAINT [DF_EN13458_OuterTankCircWeld] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterTankHeadWeldLength') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterTankHeadWeldLength] float NOT NULL CONSTRAINT [DF_EN13458_OuterTankHeadWeld] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterTankWeight') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterTankWeight] float NOT NULL CONSTRAINT [DF_EN13458_OuterTankWeight] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'OuterVolume') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [OuterVolume] float NOT NULL CONSTRAINT [DF_EN13458_OuterVolume] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'PerliteVolume') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [PerliteVolume] float NOT NULL CONSTRAINT [DF_EN13458_PerliteVolume] DEFAULT(0);
IF COL_LENGTH('EN13458Calculations', 'PerliteWeight') IS NULL
    ALTER TABLE [EN13458Calculations] ADD [PerliteWeight] float NOT NULL CONSTRAINT [DF_EN13458_PerliteWeight] DEFAULT(0);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No-op: defensive migration to reconcile drifted databases safely.
        }
    }
}
