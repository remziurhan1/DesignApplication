using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Application.Services.StockCodes.S.Features
{
    public class FeatureWithValuesDto
    {
        public Guid FeatureId { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsRequired { get; set; }
        public int SortOrder { get; set; }

        public List<FeatureValueDto> Values { get; set; } = new();
    }
}
