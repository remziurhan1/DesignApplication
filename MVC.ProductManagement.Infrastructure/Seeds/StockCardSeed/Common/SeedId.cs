using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Infrastructure.Seeds.StockCardSeed.Common
{
    /// <summary>
    /// Deterministik GUID üretimi için helper
    /// Aynı string her zaman aynı GUID'i üretir
    /// </summary>
    public static class SeedId
    {
        public static Guid From(string key)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
            return new Guid(hash);
        }
    }
}
