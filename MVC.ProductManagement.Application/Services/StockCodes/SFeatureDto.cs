using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// SA Feature DTO (Generate ve Edit için)
    /// </summary>
    public class SFeatureDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Bu feature için izinli değerler
        /// </summary>
        public List<FeatureValueDto> AllowedValues { get; set; } = new();
    }
}