using MVC.ProductManagement.Application.Services.EN13458.Engines;
using MVC.ProductManagement.Application.Services.EN13458.Interfaces;
using System;

namespace MVC.ProductManagement.Application.Services.EN13458.CalculationSteps
{
    internal static class EN13458MaterialRules
    {
        public static double GetDesignYield(double interpolatedYield, double? coldStretchYield, bool isColdStretch)
        {
            if (isColdStretch && coldStretchYield.HasValue)
                return coldStretchYield.Value;

            return interpolatedYield;
        }

        public static double GetAllowableStress(double yield)
        {
            return yield / 1.5d;
        }
    }

    internal static class EN13458OuterTankRules
    {
        internal sealed class OuterVesselExternalPressureResult
        {
            public double EffectiveThickness { get; set; }
            public double DOverT { get; set; }
            public double LOverD { get; set; }
            public double DaOverLb { get; set; }
            public double ElasticBucklingPressure { get; set; }
            public double PlasticDeformationPressure { get; set; }
            public double AllowableExternalPressure { get; set; }
            public double ExternalDesignPressure { get; set; }
            public bool ExternalPressureDesignOk { get; set; }
            public double? RequiredStiffenerInertia { get; set; }
            public double? RequiredStiffenerArea { get; set; }
            public bool? StiffenerInertiaOk { get; set; }
            public bool? StiffenerAreaOk { get; set; }
        }

        public static OuterVesselExternalPressureResult CalculateExternalPressure(
            double da,
            double s,
            double c,
            double lb,
            double e,
            double nu,
            double k,
            double u,
            bool useGeneralElasticFormula,
            bool hasStiffener,
            double? stiffenerInertia,
            double? stiffenerArea)
        {
            const double sk = 2d;
            const double sp = 1.1d;
            const double pDesign = 0.1d; // MPa

            var t = Math.Max(s - c, 0.0001d);
            var safeLb = Math.Max(lb, 0.0001d);
            var safeK = Math.Max(k, 0.0001d);
            var safeE = Math.Max(e, 0.0001d);
            var daOverLb = da / safeLb;

            var peFactor = useGeneralElasticFormula
                ? (1d / (12d * (1d - (nu * nu))))
                : (1d / 1.2d);

            var pe = (safeE / sk) * Math.Pow(t / da, 3) * peFactor;

            double pp;
            if (daOverLb <= 5d)
            {
                pp = (safeK / sp)
                     * (t / da)
                     * (1d / (1d + (0.2d * daOverLb)))
                     * (1d / (1d - (u / 100d)));
            }
            else
            {
                var pp1 = (safeK / sp) * (t / da);
                var pp2 = (safeK / sp) * 30d * Math.Pow(t / safeLb, 2);
                pp = Math.Min(pp1, pp2);
            }

            var pAllow = Math.Min(pe, pp);
            var output = new OuterVesselExternalPressureResult
            {
                EffectiveThickness = Math.Round(t, 3),
                DOverT = Math.Round(da / t, 3),
                LOverD = Math.Round(lb / da, 3),
                DaOverLb = Math.Round(daOverLb, 3),
                ElasticBucklingPressure = Math.Round(pe, 5),
                PlasticDeformationPressure = Math.Round(pp, 5),
                AllowableExternalPressure = Math.Round(pAllow, 5),
                ExternalDesignPressure = pDesign,
                ExternalPressureDesignOk = pAllow >= pDesign
            };

            if (hasStiffener)
            {
                var iRequired = ((0.124d * pDesign * Math.Pow(da, 3) / safeE) * 10d * (da - t));
                var aRequired = ((0.75d * pDesign * da / safeK) * 10d * (da - t));

                output.RequiredStiffenerInertia = Math.Round(iRequired, 4);
                output.RequiredStiffenerArea = Math.Round(aRequired, 4);
                output.StiffenerInertiaOk = stiffenerInertia.HasValue && stiffenerInertia.Value >= iRequired;
                output.StiffenerAreaOk = stiffenerArea.HasValue && stiffenerArea.Value >= aRequired;
            }

            return output;
        }

        public static double GetEstimatedInnerVolume(double innerDiameter, double shellLength)
        {
            var cylindricalVolume = Math.PI / 4d * Math.Pow(innerDiameter, 2) * shellLength;
            var headVolume = 2d * 0.1298d * Math.Pow(innerDiameter, 3);
            return (cylindricalVolume + headVolume) / 1_000_000_000d;
        }

        public static double GetOuterDiameter(double innerDiameter, double shellLength, double? enteredOuterDiameter)
        {
            if (enteredOuterDiameter.HasValue && enteredOuterDiameter.Value > 0d)
                return enteredOuterDiameter.Value;

            var estimatedInnerVolume = GetEstimatedInnerVolume(innerDiameter, shellLength);
            var diameterOffset = estimatedInnerVolume < 100d ? 500d : 700d;
            return innerDiameter + diameterOffset;
        }

        public static double GetOuterShellLength(double innerDiameter, double shellLength)
        {
            var estimatedInnerVolume = GetEstimatedInnerVolume(innerDiameter, shellLength);
            var lengthOffset = estimatedInnerVolume < 100d ? 500d : 700d;
            return shellLength + lengthOffset;
        }

        public static (double OuterTankShellThickness, double OuterTankHeadThickness) DetermineTankThickness(double outerDiameter)
        {
            if (outerDiameter <= 2400d)
                return (4d, 6d);

            if (outerDiameter <= 3050d)
                return (6d, 8d);

            return (10d, 10d);
        }
    }

    public class PressureStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            const double gravity = 9.81d;
            const double testFactor = 1.5d;
            const double headFactorInner = 0.26d;

            var headLengthInner = headFactorInner * context.Input.OuterDiameter;

            var effectiveHeight =
                context.Input.TankOrientation == Domain.Enums.TankOrientation.Vertical
                ? context.Input.ShellLength + (2d * headLengthInner)
                : context.Input.OuterDiameter;

            var staticPressure =
                (context.Input.LiquidDensity * gravity * (effectiveHeight / 1000d)) / 100000d;

            staticPressure = Math.Round(staticPressure, 2);

            var ignoredPart = Math.Round(context.Input.Pressure * 0.05d, 2);

            var designPressure =
                staticPressure > ignoredPart
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
            var p = context.Result.DesignPressure;

            var yield = EN13458MaterialRules.GetDesignYield(
                context.Result.InnerShellMaterialStrength,
                context.Result.InnerShellMaterialForm?.ColdStretchYieldStrength,
                context.Input.IsColdStretchApplied);

            var allowableStress = EN13458MaterialRules.GetAllowableStress(yield);

            var thickness = (d * p) / ((20d * allowableStress) + p);

            context.Result.InnerShellThickness = Math.Round(thickness, 2);
            context.Result.RoundedInnerShellThickness = Math.Ceiling(thickness);

            var outerDiameter = EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var thicknessOuter = EN13458OuterTankRules.DetermineTankThickness(outerDiameter);

            var externalPressure = EN13458OuterTankRules.CalculateExternalPressure(
                outerDiameter,
                thicknessOuter.OuterTankShellThickness,
                context.Input.CorrosionAllowance,
                context.Input.BucklingLength,
                context.Input.ElasticModulus,
                context.Input.PoissonRatio,
                context.Input.YieldFactorK,
                context.Input.RoundnessErrorPercent,
                context.Input.UseGeneralElasticFormula,
                context.Input.HasStiffener,
                context.Input.StiffenerInertia,
                context.Input.StiffenerArea);

            if (!externalPressure.ExternalPressureDesignOk)
            {
                var trialThickness = thicknessOuter.OuterTankShellThickness;
                for (var i = 0; i < 500 && !externalPressure.ExternalPressureDesignOk; i++)
                {
                    trialThickness += 1d;
                    externalPressure = EN13458OuterTankRules.CalculateExternalPressure(
                        outerDiameter,
                        trialThickness,
                        context.Input.CorrosionAllowance,
                        context.Input.BucklingLength,
                        context.Input.ElasticModulus,
                        context.Input.PoissonRatio,
                        context.Input.YieldFactorK,
                        context.Input.RoundnessErrorPercent,
                        context.Input.UseGeneralElasticFormula,
                        context.Input.HasStiffener,
                        context.Input.StiffenerInertia,
                        context.Input.StiffenerArea);
                }

                context.Result.OuterShellThickness = Math.Round(trialThickness, 2);
            }
            else
            {
                context.Result.OuterShellThickness = thicknessOuter.OuterTankShellThickness;
            }

            context.Result.RoundedOuterShellThickness = Math.Ceiling(context.Result.OuterShellThickness);
            context.Result.EffectiveOuterThickness = externalPressure.EffectiveThickness;
            context.Result.DOverT = externalPressure.DOverT;
            context.Result.LOverD = externalPressure.LOverD;
            context.Result.DaOverLb = externalPressure.DaOverLb;
            context.Result.ElasticBucklingPressure = externalPressure.ElasticBucklingPressure;
            context.Result.PlasticDeformationPressure = externalPressure.PlasticDeformationPressure;
            context.Result.AllowableExternalPressure = externalPressure.AllowableExternalPressure;
            context.Result.ExternalDesignPressure = externalPressure.ExternalDesignPressure;
            context.Result.ExternalPressureDesignOk = externalPressure.ExternalPressureDesignOk;
            context.Result.RequiredStiffenerInertia = externalPressure.RequiredStiffenerInertia;
            context.Result.RequiredStiffenerArea = externalPressure.RequiredStiffenerArea;
            context.Result.StiffenerInertiaOk = externalPressure.StiffenerInertiaOk;
            context.Result.StiffenerAreaOk = externalPressure.StiffenerAreaOk;
        }
    }

    public class HeadThicknessStep : IEN13458CalculationStep
    {
        public void Execute(EN13458DesignContext context)
        {
            var d = context.Input.OuterDiameter;
            var p = context.Result.DesignPressure;

            var yield = EN13458MaterialRules.GetDesignYield(
                context.Result.InnerHeadMaterialStrength,
                context.Result.InnerHeadMaterialForm?.ColdStretchYieldStrength,
                context.Input.IsColdStretchApplied);

            var allowableStress = EN13458MaterialRules.GetAllowableStress(yield);

            var thickness = (d * p * 1.91d) / (40d * allowableStress);

            context.Result.InnerHeadThickness = Math.Round(thickness, 2);
            context.Result.RoundedInnerHeadThickness = Math.Ceiling(thickness);

            var outerDiameter = EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var thicknessOuter =
                EN13458OuterTankRules.DetermineTankThickness(outerDiameter);

            context.Result.OuterHeadThickness = thicknessOuter.OuterTankHeadThickness;
            context.Result.RoundedOuterHeadThickness = thicknessOuter.OuterTankHeadThickness;
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

            context.Result.InnerVolume =
                Math.Round((innerCylinder + innerHeadVol) / 1_000_000_000d, 2);

            var outerDiameter =
                EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var outerShellLength =
                EN13458OuterTankRules.GetOuterShellLength(diameter, shellLength);

            var netOuterDiameter = outerDiameter - (2d * outerShellT);
            var outerBombeDiameter = outerDiameter - (2d * outerHeadT);

            var outerCylinder =
                Math.PI / 4d * Math.Pow(netOuterDiameter, 2) * outerShellLength;

            var outerHeadVol =
                2d * 0.1298d * Math.Pow(outerBombeDiameter, 3);

            context.Result.OuterVolume =
                Math.Round((outerCylinder + outerHeadVol) / 1_000_000_000d, 2);
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

            var innerBodyArea =
                Math.PI * (diameter - (2d * context.Result.RoundedInnerShellThickness))
                * shellLength / 1000d;

            var innerBombePulDiameter =
                (BombeCoefficient * diameter)
                + (BombeFactor * context.Result.RoundedInnerHeadThickness);

            var innerHeadArea =
                Math.PI * Math.Pow(innerBombePulDiameter / 2d / 1000d, 2);

            context.Result.InnerSurfaceArea =
                Math.Round(innerBodyArea + (2d * innerHeadArea), 2);

            var outerDiameter =
                EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var outerShellLength =
                EN13458OuterTankRules.GetOuterShellLength(diameter, shellLength);

            var outerBodyArea =
                Math.PI * outerDiameter / 1000d * outerShellLength / 1000d;

            var outerBombePulDiameter =
                (BombeCoefficient * outerDiameter)
                + (BombeFactor * context.Result.RoundedOuterHeadThickness);

            var outerHeadArea =
                Math.PI * Math.Pow(outerBombePulDiameter / 2d / 1000d, 2);

            context.Result.OuterSurfaceArea =
                Math.Round(outerBodyArea + (2d * outerHeadArea), 2);
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

            var innerEffectiveDiameter =
                (diameter - innerShellT) * Math.PI / 1000d;

            var innerShellVolume =
                innerEffectiveDiameter * (shellLength / 1000d) * (innerShellT / 1000d);

            var innerShellWeight = innerShellVolume * SteelDensity;

            var innerBombePulDiameter =
                (BombeCoefficient * diameter) + (BombeFactor * innerHeadT);

            context.Result.InnerTankHeadPulDiameter = Math.Round(innerBombePulDiameter, 2);

            var innerBombeVolume =
                (Math.PI / 4d) * Math.Pow(innerBombePulDiameter / 1000d, 2)
                * (innerHeadT / 1000d);

            var innerBombeWeight = innerBombeVolume * SteelDensity;
            context.Result.InnerTankHeadWeight = Math.Round(innerBombeWeight, 2);

            context.Result.InnerTankWeight =
                Math.Round((innerShellWeight + (2d * innerBombeWeight)) * 1.03d, 2);

            var outerDiameter =
                EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var outerShellLength =
                EN13458OuterTankRules.GetOuterShellLength(diameter, shellLength);

            var outerShellT = context.Result.RoundedOuterShellThickness;
            var outerHeadT = context.Result.RoundedOuterHeadThickness;

            var outerEffectiveDiameter =
                (outerDiameter - (2d * outerShellT)) * Math.PI / 1000d;

            var outerShellVolume =
                outerEffectiveDiameter * (outerShellLength / 1000d) * (outerShellT / 1000d);

            var outerShellWeight = outerShellVolume * SteelDensity;

            var outerBombePulDiameter =
                (BombeCoefficient * outerDiameter) + (BombeFactor * outerHeadT);

            context.Result.OuterTankHeadPulDiameter = Math.Round(outerBombePulDiameter, 2);

            var outerBombeVolume =
                (Math.PI / 4d) * Math.Pow(outerBombePulDiameter / 1000d, 2)
                * (outerHeadT / 1000d);

            var outerBombeWeight = outerBombeVolume * SteelDensity;
            context.Result.OuterTankHeadWeight = Math.Round(outerBombeWeight, 2);

            context.Result.OuterTankWeight =
                Math.Round((outerShellWeight + (2d * outerBombeWeight)) * 1.03d, 2);
        }
    }

    public class WeldFilmPerliteStep : IEN13458CalculationStep
    {
        private const double HeadPulDiameterCoefficient = 1.17d;
        private const double PerliteDensity = 120d; // kg/m3

        public void Execute(EN13458DesignContext context)
        {
            var innerDiameter = context.Input.OuterDiameter;
            var outerDiameter = EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            double shellLength = context.Input.ShellLength;

            context.Result.WeldLength1500 = CalculateWeldLengthForSource(shellLength, innerDiameter, outerDiameter, 1500d);
            context.Result.WeldLength2000 = CalculateWeldLengthForSource(shellLength, innerDiameter, outerDiameter, 2000d);
            context.Result.WeldLength2500 = CalculateWeldLengthForSource(shellLength, innerDiameter, outerDiameter, 2500d);
            context.Result.WeldLength3000 = CalculateWeldLengthForSource(shellLength, innerDiameter, outerDiameter, 3000d);

            var sectorWidth = 2000d;
            var sectorQty = shellLength / sectorWidth;
            var oneSectorWeld = sectorQty * innerDiameter * Math.PI;
            var oneHeadCircularWeld = Math.PI * innerDiameter;

            var outerTankShellLength = EN13458OuterTankRules.GetOuterShellLength(innerDiameter, shellLength);
            var outerTankSectorQty = outerTankShellLength / sectorWidth;
            var outerTankSectorWeld = outerTankSectorQty * outerDiameter * Math.PI;
            var outerTankCircularWeld = Math.PI * outerDiameter;

            context.Result.InnerTankCircumferenceWeldLength = Math.Round(oneSectorWeld + oneHeadCircularWeld);
            context.Result.OuterTankCircumferenceWeldLength = Math.Round(outerTankSectorWeld + outerTankCircularWeld);

            var innerHeadPulDiameter = HeadPulDiameterCoefficient * innerDiameter;
            var outerHeadPulDiameter = HeadPulDiameterCoefficient * outerDiameter;

            context.Result.InnerTankHeadWeldLength =
                Math.Round(((innerHeadPulDiameter / sectorWidth) * (innerHeadPulDiameter / 1.15d) * 2d), 2);

            context.Result.OuterTankHeadWeldLength =
                Math.Round(((outerHeadPulDiameter / sectorWidth) * (outerHeadPulDiameter / 1.15d) * 2d), 2);

            context.Result.TotalWeldLength =
                Math.Round(
                    context.Result.InnerTankHeadWeldLength
                    + context.Result.InnerTankCircumferenceWeldLength
                    + context.Result.OuterTankHeadWeldLength
                    + context.Result.OuterTankCircumferenceWeldLength,
                    2);

            context.Result.TotalFilmCost = 0d;

            context.Result.PerliteVolume =
                Math.Round(Math.Max(context.Result.OuterVolume - context.Result.InnerVolume, 0d), 2);

            context.Result.PerliteWeight =
                Math.Round(context.Result.PerliteVolume * PerliteDensity, 2);
        }
        private static double CalculateWeldLengthForSource(double shellLength, double innerDiameter, double outerDiameter, double sourceLength)
        {
            var innerSectionCount = shellLength / sourceLength;
            var innerCircumferenceWeld = (innerSectionCount * innerDiameter * Math.PI) + (Math.PI * innerDiameter);
            var innerHeadPulDiameter = HeadPulDiameterCoefficient * innerDiameter;
            var innerHeadWeld = ((innerHeadPulDiameter / sourceLength) * (innerHeadPulDiameter / 1.15d) * 2d);

            var outerShellLength = EN13458OuterTankRules.GetOuterShellLength(innerDiameter, shellLength);
            var outerSectionCount = outerShellLength / sourceLength;
            var outerCircumferenceWeld = (outerSectionCount * outerDiameter * Math.PI) + (Math.PI * outerDiameter);
            var outerHeadPulDiameter = HeadPulDiameterCoefficient * outerDiameter;
            var outerHeadWeld = ((outerHeadPulDiameter / sourceLength) * (outerHeadPulDiameter / 1.15d) * 2d);

            return Math.Round(innerCircumferenceWeld + innerHeadWeld + outerCircumferenceWeld + outerHeadWeld, 2);
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

            context.Result.InnerTankTotalLength =
                Math.Round((headLength * 2d) + context.Input.ShellLength, 2);

            var outerDiameter =
                EN13458OuterTankRules.GetOuterDiameter(context.Input.OuterDiameter, context.Input.ShellLength, context.Input.OuterTankDiameter);

            var outerShellLength =
                EN13458OuterTankRules.GetOuterShellLength(
                    context.Input.OuterDiameter,
                    context.Input.ShellLength);

            var outerHeadLength = outerDiameter * 0.2d;

            context.Result.OuterTankTotalLength =
                Math.Round((outerHeadLength * 2d) + outerShellLength + 100d, 2);
        }
    }
}
