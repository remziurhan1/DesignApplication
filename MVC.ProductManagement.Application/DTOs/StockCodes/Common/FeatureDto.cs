using MVC.ProductManagement.Application.Services.StockCodes.S.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{
    // <summary>
    /// Feature bilgisi (PN, DN, SURFACE)
    /// </summary>
    public class FeatureDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsRequired { get; set; }
        public int SortOrder { get; set; }
        public List<FeatureValueDto> Values { get; set; } = new();
    }
}
