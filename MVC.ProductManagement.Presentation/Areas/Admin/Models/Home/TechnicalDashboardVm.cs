namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.Home
{
    public class TechnicalDashboardVm
    {
        public int En13458CalculationCount { get; set; }
        public int Ad2000CalculationCount { get; set; }
        public int MaterialCount { get; set; }
        public int MaterialFormCount { get; set; }
        public int YieldStrengthCount { get; set; }
        public int AllowableStressCount { get; set; }
        public int StorageTypeCount { get; set; }
        public int ThermodynamicPropertyCount { get; set; }

        public int TotalTechnicalRecordCount => En13458CalculationCount
                                                + Ad2000CalculationCount
                                                + MaterialCount
                                                + MaterialFormCount
                                                + YieldStrengthCount
                                                + AllowableStressCount
                                                + StorageTypeCount
                                                + ThermodynamicPropertyCount;
    }
}
