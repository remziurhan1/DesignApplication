using MVC.ProductManagement.Application.DTOs.StockCodes.Common;
using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Application.DTOs.StockCodes.SA
{
    /// <summary>
    /// Form'da gösterilecek feature bilgisi
    /// </summary>
    public class StockCodeSaFormFeatureDto
    {
        /// <summary>
        /// Feature ID
        /// </summary>
        public Guid FeatureId { get; set; }

        /// <summary>
        /// Feature kodu (MATERIAL, STRENGTH, THREAD_SYSTEM, vs.)
        /// </summary>
        public string FeatureCode { get; set; } = string.Empty;

        /// <summary>
        /// Feature adı (Malzeme, Mukavemet, Diş Sistemi, vs.)
        /// </summary>
        public string FeatureName { get; set; } = string.Empty;

        /// <summary>
        /// Sabit mi? (true ise kullanıcı değiştiremez, readonly gösterilir)
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// Sabit değer ID (IsFixed=true ise dolu)
        /// </summary>
        public Guid? FixedValueId { get; set; }

        /// <summary>
        /// Sabit değer kodu (IsFixed=true ise dolu, örnek: "8.8", "METRIK")
        /// </summary>
        public string? FixedValueCode { get; set; }

        /// <summary>
        /// Sabit değer adı (IsFixed=true ise dolu, örnek: "8.8 Sınıf", "Metrik Tam Dişli")
        /// </summary>
        public string? FixedValueName { get; set; }

        /// <summary>
        /// İzinli değerler (IsFixed=false ise dolu, dropdown için)
        /// </summary>
        public List<FeatureValueDto> AvailableValues { get; set; } = new();
    }
}