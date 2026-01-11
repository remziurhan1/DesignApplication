using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.ProductCodeServices
{
    public class ProductCodeService : IProductCodeService
    {
        public string GenerateProductCode(string prefix, int sequence)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Prefix boş olamaz.", nameof(prefix));
            }

            if (!prefix.StartsWith("C", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Prefix 'C' ile başlamalıdır.", nameof(prefix));
            }

            if (prefix.Length != 3)
            {
                throw new ArgumentException("Prefix 3 karakter olmalıdır (örn: CAA).", nameof(prefix));
            }

            if (sequence < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sequence), sequence, "Sıra numarası negatif olamaz.");
            }

            var normalizedPrefix = prefix.ToUpperInvariant();
            var sequencePart = sequence.ToString("D5");

            return string.Concat(normalizedPrefix, sequencePart);
        }
    }
}
