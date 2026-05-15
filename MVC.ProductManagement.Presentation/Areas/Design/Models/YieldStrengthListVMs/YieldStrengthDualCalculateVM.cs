namespace MVC.ProductManagement.Presentation.Areas.Design.Models.YieldStrengthListVMs
{
    public class YieldStrengthDualCalculateVM
    {
        public Guid MaterialFormId { get; set; }
        public double Temperature { get; set; }

        public double ThicknessShell { get; set; }
        public double ThicknessHead { get; set; }
    }
}
