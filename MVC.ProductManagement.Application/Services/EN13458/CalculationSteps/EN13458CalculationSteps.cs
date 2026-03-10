using MVC.ProductManagement.Application.Services.EN13458.Engines;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using System;

namespace MVC.ProductManagement.Application.Services.EN13458.CalculationSteps
{
    public class PressureStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            const double gravity = 9.81d;
            const double testFactor = 1.5d;
            // StorageType bilgisi DTO'da henüz olmadığı için bu fazda yatay tank varsayımıyla devam edilir.
            var effectiveHeight = context.Input.OuterDiameter;

            var staticPressure = (context.Input.LiquidDensity * gravity * (effectiveHeight / 1000d)) / 100000d;
            staticPressure = Math.Round(staticPressure, 2);

            var ignoredPart = Math.Round(context.Input.Pressure * 0.05d, 2);
            var designPressure = staticPressure > ignoredPart
                ? context.Input.Pressure + (staticPressure - ignoredPart) + 1d
                : context.Input.Pressure + 1d;
            designPressure = Math.Round(designPressure, 2);

            var testPressure = Math.Round(designPressure * testFactor, 2);

            context.Result.StaticPressure = staticPressure;
            context.Result.DesignPressure = designPressure;
            context.Result.TestPressure = testPressure;
        }
    }

    public class ShellThicknessStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var p = context.Result.DesignPressure * 0.1d; // bar -> MPa
            var d = context.Input.OuterDiameter;
            context.Result.InnerShellThickness = (p * d) / ((2d * context.Result.InnerShellMaterialStrength * 0.9d) - p);
            context.Result.OuterShellThickness = (p * d) / ((2d * context.Result.OuterShellMaterialStrength * 0.85d) - p);
            context.Result.RoundedInnerShellThickness = Math.Ceiling(context.Result.InnerShellThickness);
            context.Result.RoundedOuterShellThickness = Math.Ceiling(context.Result.OuterShellThickness);
        }
    }

    public class HeadThicknessStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var p = context.Result.DesignPressure * 0.1d;
            var d = context.Input.OuterDiameter;
            context.Result.InnerHeadThickness = (p * d) / ((2d * context.Result.InnerHeadMaterialStrength * 0.9d) - (0.2d * p));
            context.Result.OuterHeadThickness = (p * d) / ((2d * context.Result.OuterHeadMaterialStrength * 0.85d) - (0.2d * p));
            context.Result.RoundedInnerHeadThickness = Math.Ceiling(context.Result.InnerHeadThickness);
            context.Result.RoundedOuterHeadThickness = Math.Ceiling(context.Result.OuterHeadThickness);
        }
    }

    public class VolumeStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var r = context.Input.OuterDiameter / 2d;
            var cylinderMm3 = Math.PI * r * r * context.Input.ShellLength;
            var headMm3 = (4d / 3d) * Math.PI * Math.Pow(r, 3) * 0.5d;
            context.Result.InnerVolume = (cylinderMm3 + (2d * headMm3)) * 1e-9;
            context.Result.OuterVolume = context.Result.InnerVolume * 1.12d;
        }
    }

    public class SurfaceAreaStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var r = context.Input.OuterDiameter / 2d;
            var shellArea = 2d * Math.PI * r * context.Input.ShellLength;
            var headsArea = 4d * Math.PI * r * r;
            context.Result.InnerSurfaceArea = (shellArea + headsArea) * 1e-6;
            context.Result.OuterSurfaceArea = context.Result.InnerSurfaceArea * 1.08d;
        }
    }

    public class WeightStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var density = 7850d;
            var innerVolumeSteel = context.Result.InnerSurfaceArea * (context.Result.RoundedInnerShellThickness / 1000d);
            var outerVolumeSteel = context.Result.OuterSurfaceArea * (context.Result.RoundedOuterShellThickness / 1000d);
            context.Result.InnerTankWeight = innerVolumeSteel * density;
            context.Result.OuterTankWeight = outerVolumeSteel * density;
        }
    }

    public class WeldFilmPerliteStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            context.Result.TotalWeldLength = (4d * Math.PI * context.Input.OuterDiameter + (2d * context.Input.ShellLength)) / 1000d;
            context.Result.TotalFilmCost = context.Result.OuterSurfaceArea * 12.5d;
            context.Result.PerliteVolume = Math.Max(context.Result.OuterVolume - context.Result.InnerVolume, 0d);
        }
    }

    public class GasAndLiquidNitrogenStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            context.Result.LiquidNitrogenVolume = context.Result.InnerVolume * 0.9d;
            context.Result.GasNitrogenVolume = context.Result.LiquidNitrogenVolume * 0.694d;
        }
    }

    public class TankLengthStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            context.Result.InnerTankTotalLength = context.Input.ShellLength + context.Input.OuterDiameter;
            context.Result.OuterTankTotalLength = context.Result.InnerTankTotalLength + 2d * (context.Result.RoundedOuterHeadThickness + context.Result.RoundedOuterShellThickness);
        }
    }
}
