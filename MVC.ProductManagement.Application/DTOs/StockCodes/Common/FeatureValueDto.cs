using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.Common
{ /// <summary>
  /// Feature değeri (PN40, DN50, RF)
  /// </summary>
    public class FeatureValueDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int SortOrder { get; set; }
    }
}
