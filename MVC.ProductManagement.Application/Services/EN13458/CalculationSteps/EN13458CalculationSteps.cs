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
            const double headFactorInner = 0.26d;

            var headLengthInner = headFactorInner * context.Input.OuterDiameter;
            var effectiveHeight = context.Input.TankOrientation == Domain.Enums.TankOrientation.Vertical
                ? context.Input.ShellLength + (2d * headLengthInner)
                : context.Input.OuterDiameter;

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
            var d = context.Input.OuterDiameter;
            var designPressure = context.Result.DesignPressure;

            var innerYield = context.Result.InnerShellMaterialStrength;
            var outerYield = context.Result.OuterShellMaterialStrength;

            context.Result.InnerShellThickness = Math.Round((d * designPressure) / ((20d * (innerYield / 1.5d)) + designPressure), 2);
            context.Result.OuterShellThickness = Math.Round((d * designPressure) / ((20d * (outerYield / 1.5d)) + designPressure), 2);

            context.Result.RoundedInnerShellThickness = Math.Ceiling(context.Result.InnerShellThickness);
            context.Result.RoundedOuterShellThickness = Math.Ceiling(context.Result.OuterShellThickness);
        }
    }

    public class HeadThicknessStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var d = context.Input.OuterDiameter;
            var designPressure = context.Result.DesignPressure;

            var innerYield = context.Result.InnerHeadMaterialStrength;
            var outerYield = context.Result.OuterHeadMaterialStrength;

            context.Result.InnerHeadThickness = Math.Round((d * designPressure * 1.91d) / (40d * (innerYield / 1.5d)), 2);
            context.Result.OuterHeadThickness = Math.Round((d * designPressure * 1.91d) / (40d * (outerYield / 1.5d)), 2);

            context.Result.RoundedInnerHeadThickness = Math.Ceiling(context.Result.InnerHeadThickness);
            context.Result.RoundedOuterHeadThickness = Math.Ceiling(context.Result.OuterHeadThickness);
        }
    }

    public class VolumeStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var shellLength = context.Input.ShellLength;
            var diameter = context.Input.OuterDiameter;

            var innerShellT = context.Result.RoundedInnerShellThickness;
            var innerHeadT = context.Result.RoundedInnerHeadThickness;
            var outerShellT = context.Result.RoundedOuterShellThickness;
            var outerHeadT = context.Result.RoundedOuterHeadThickness;

            var netInnerDiameter = diameter - (2d * innerShellT);
            var innerBombeDiameter = diameter - (2d * innerHeadT);
            var innerCylinder = Math.PI / 4d * Math.Pow(netInnerDiameter, 2) * shellLength;
            var innerHeadVol = 2d * 0.1298d * Math.Pow(innerBombeDiameter, 3);
            context.Result.InnerVolume = Math.Round((innerCylinder + innerHeadVol) / 1_000_000_000d, 2);

            var outerDiameter = diameter + 500d;
            var outerShellLength = shellLength + 500d;
            var netOuterDiameter = outerDiameter - (2d * outerShellT);
            var outerBombeDiameter = outerDiameter - (2d * outerHeadT);
            var outerCylinder = Math.PI / 4d * Math.Pow(netOuterDiameter, 2) * outerShellLength;
            var outerHeadVol = 2d * 0.1298d * Math.Pow(outerBombeDiameter, 3);
            context.Result.OuterVolume = Math.Round((outerCylinder + outerHeadVol) / 1_000_000_000d, 2);
        }
    }

    public class SurfaceAreaStep : IEN13458CalculationStep
    {
        private const double BombeCoefficient = 1.174d;
        private const double BombeFactor = 1.7d * 3.5d;

        public void Execute(EN13458DesignContext context)
        {
            var shellLength = context.Input.ShellLength;
            var diameter = context.Input.OuterDiameter;

            var innerBodyArea = Math.PI * (diameter - (2d * context.Result.RoundedInnerShellThickness)) * shellLength / 1000d;
            var innerBombePulDiameter = (BombeCoefficient * diameter) + (BombeFactor * context.Result.RoundedInnerHeadThickness);
            var innerHeadArea = Math.PI * Math.Pow(innerBombePulDiameter / 2d / 1000d, 2);
            context.Result.InnerSurfaceArea = Math.Round(innerBodyArea + (2d * innerHeadArea), 2);

            var outerDiameter = diameter + 500d;
            var outerShellLength = shellLength + 500d;
            var outerBodyArea = Math.PI * outerDiameter / 1000d * outerShellLength / 1000d;
            var outerBombePulDiameter = (BombeCoefficient * outerDiameter) + (BombeFactor * context.Result.RoundedOuterHeadThickness);
            var outerHeadArea = Math.PI * Math.Pow(outerBombePulDiameter / 2d / 1000d, 2);
            context.Result.OuterSurfaceArea = Math.Round(outerBodyArea + (2d * outerHeadArea), 2);
        }
    }

    public class WeightStep : IEN13458CalculationStep
    {
        private const double SteelDensity = 7850d;
        private const double BombeCoefficient = 1.174d;
        private const double BombeFactor = 1.7d * 3.5d;

        public void Execute(EN13458DesignContext context)
        {
            var shellLength = context.Input.ShellLength;
            var diameter = context.Input.OuterDiameter;

            var innerShellT = context.Result.RoundedInnerShellThickness;
            var innerHeadT = context.Result.RoundedInnerHeadThickness;

            var innerEffectiveDiameter = (diameter - innerShellT) * Math.PI / 1000d;
            var innerShellVolume = innerEffectiveDiameter * (shellLength / 1000d) * (innerShellT / 1000d);
            var innerShellWeight = innerShellVolume * SteelDensity;
            var innerBombePulDiameter = (BombeCoefficient * diameter) + (BombeFactor * innerHeadT);
            var innerBombeVolume = (Math.PI / 4d) * Math.Pow(innerBombePulDiameter / 1000d, 2) * (innerHeadT / 1000d);
            var innerBombeWeight = innerBombeVolume * SteelDensity;
            context.Result.InnerTankWeight = Math.Round((innerShellWeight + (2d * innerBombeWeight)) * 1.03d, 2);

            var outerDiameter = diameter + 500d;
            var outerShellLength = shellLength + 500d;
            var outerShellT = context.Result.RoundedOuterShellThickness;
            var outerHeadT = context.Result.RoundedOuterHeadThickness;

            var outerEffectiveDiameter = (outerDiameter - (2d * outerShellT)) * Math.PI / 1000d;
            var outerShellVolume = outerEffectiveDiameter * (outerShellLength / 1000d) * (outerShellT / 1000d);
            var outerShellWeight = outerShellVolume * SteelDensity;
            var outerBombePulDiameter = (BombeCoefficient * outerDiameter) + (BombeFactor * outerHeadT);
            var outerBombeVolume = (Math.PI / 4d) * Math.Pow(outerBombePulDiameter / 1000d, 2) * (outerHeadT / 1000d);
            var outerBombeWeight = outerBombeVolume * SteelDensity;
            context.Result.OuterTankWeight = Math.Round((outerShellWeight + (2d * outerBombeWeight)) * 1.03d, 2);
        }
    }

    public class WeldFilmPerliteStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            context.Result.TotalWeldLength = (4d * Math.PI * context.Input.OuterDiameter + (2d * context.Input.ShellLength)) / 1000d;
            context.Result.TotalFilmCost = context.Result.OuterSurfaceArea * 12.5d;
            context.Result.PerliteVolume = Math.Round(Math.Max(context.Result.OuterVolume - context.Result.InnerVolume, 0d), 2);
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
            var headLength = context.Input.OuterDiameter * 0.26d;
            context.Result.InnerTankTotalLength = Math.Round((headLength * 2d) + context.Input.ShellLength, 2);

            var outerHeadLength = (context.Input.OuterDiameter + 500d) * 0.2d;
            context.Result.OuterTankTotalLength = Math.Round((outerHeadLength * 2d) + (context.Input.ShellLength + 500d) + 100d, 2);
        }
    }
}
