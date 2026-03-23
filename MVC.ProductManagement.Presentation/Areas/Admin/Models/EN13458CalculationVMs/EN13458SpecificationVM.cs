using System;
using System.Collections.Generic;

namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.EN13458CalculationVMs
{
    public class EN13458SpecificationVM
    {
        public Guid Id { get; set; }
        public Guid? SelectedCostAnalysisId { get; set; }
        public string DocumentTitle { get; set; } = string.Empty;
        public DateTime GeneratedAtUtc { get; set; }
        public string FluidDisplay { get; set; } = string.Empty;
        public string PressureDisplay { get; set; } = string.Empty;

        public List<EN13458SpecificationLineVM> HeaderItems { get; set; } = new();
        public List<string> IntroParagraphs { get; set; } = new();
        public List<EN13458SpecificationLineVM> GeneralItems { get; set; } = new();
        public List<EN13458SpecificationLineVM> InnerVesselItems { get; set; } = new();
        public List<EN13458SpecificationLineVM> OuterVesselItems { get; set; } = new();
        public List<EN13458SpecificationLineVM> InsulationItems { get; set; } = new();
        public List<EN13458SpecificationLineVM> PipeworkItems { get; set; } = new();
        public List<EN13458AccessoryItemVM> AccessoryItems { get; set; } = new();
        public List<EN13458SpecificationLineVM> SurfaceApplicationItems { get; set; } = new();
        public List<string> VesselDocumentationItems { get; set; } = new();
        public List<string> InspectionItems { get; set; } = new();
        public List<string> CommercialParagraphs { get; set; } = new();
        public List<EN13458QuotationRowVM> QuotationRows { get; set; } = new();
        public List<string> Notes { get; set; } = new();
        public List<string> PaymentTerms { get; set; } = new();
        public List<string> DeliveryTerms { get; set; } = new();
        public List<string> WarrantyTerms { get; set; } = new();
        public List<string> StorageTerms { get; set; } = new();
        public List<string> ValidityTerms { get; set; } = new();
        public List<string> FooterTechnicalNotes { get; set; } = new();
    }

    public class EN13458SpecificationLineVM
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class EN13458AccessoryItemVM
    {
        public string GroupName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string StockCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }

    public class EN13458QuotationRowVM
    {
        public string No { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string UnitPrice { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string TotalPrice { get; set; } = string.Empty;
    }
}
