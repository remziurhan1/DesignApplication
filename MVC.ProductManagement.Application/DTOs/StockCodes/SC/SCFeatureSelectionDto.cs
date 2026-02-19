using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SC
{
    public class SCFeatureSelectionDto
    {
        public Guid FeatureId { get; set; }
        public string FeatureCode { get; set; } = string.Empty;
        public string FeatureName { get; set; } = string.Empty;
        public Guid ValueId { get; set; }
        public string ValueCode { get; set; } = string.Empty;
        public string ValueName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
