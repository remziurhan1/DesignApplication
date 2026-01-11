using MVC.ProductManagement.Domain.Entities;
using MVC.ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.TankCodeService
{
    public class TankCodeService : ITankCodeService
    {
        public string GenerateTankCode(TankCodeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.GasCode))
            {
                throw new ArgumentException("Gaz kodu boş olamaz.", nameof(request.GasCode));
            }

            var usageCode = ResolveUsageCode(request);
            var orientationCode = ResolveOrientationCode(request.Orientation);
            var placementCode = ResolvePlacementCode(request.Placement);
            var capacity = FormatNumber(request.CapacityValue);
            var pressure = FormatNumber(request.OperatingPressure);
            var innerDiameter = FormatNumber(request.InnerDiameter);

            return string.Join("-",
                "CRYO",
                request.GasCode,
                usageCode,
                capacity,
                orientationCode,
                pressure,
                placementCode,
                innerDiameter);
        }

        private static string ResolveUsageCode(TankCodeRequest request)
        {
            return request.UsageType == UsageType.Transport
                ? ResolveTransportType(request.TransportType)
                : "STR";
        }

        private static string ResolveTransportType(string? transportType)
        {
            if (string.IsNullOrWhiteSpace(transportType))
            {
                throw new ArgumentException("Transport tipi boş olamaz.", nameof(transportType));
            }

            return transportType.ToUpperInvariant();
        }

        private static string ResolveOrientationCode(TankOrientation orientation)
        {
            return orientation switch
            {
                TankOrientation.Vertical => "V",
                TankOrientation.Horizontal => "H",
                _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Geçersiz yön.")
            };
        }

        private static string ResolvePlacementCode(PlacementType placement)
        {
            return placement switch
            {
                PlacementType.Aboveground => "A",
                PlacementType.Underground => "U",
                _ => throw new ArgumentOutOfRangeException(nameof(placement), placement, "Geçersiz konum.")
            };
        }

        private static string FormatNumber(double value)
        {
            return value.ToString("0.###", CultureInfo.InvariantCulture);
        }
    }
}
