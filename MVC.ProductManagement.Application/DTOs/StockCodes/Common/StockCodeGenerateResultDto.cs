using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    /// <summary>
    /// Tüm gruplar için ortak result DTO
    /// </summary>
    public class StockCodeGenerateResultDto
    {
        public bool AlreadyExists { get; set; }
        public Guid StockCardId { get; set; }
        public string StockCode8 { get; set; } = default!;
        public string Prefix4 { get; set; } = default!;
        public int Serial4 { get; set; }
        public string Description { get; set; } = default!;
    }
}
