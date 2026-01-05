namespace MVC.ProductManagement.Presentation.Areas.Admin.Models.YieldStrengthListVMs
{
    public class YieldStrengthDualResultVM
    {
        public double Temperature { get; set; }

        public double Rp02_Shell { get; set; }
        public double Rm_Shell { get; set; }

        public double Rp02_Head { get; set; }
        public double Rm_Head { get; set; }
        public string MaterialName { get; set; }
        public string MaterialFormName { get; set; }
    }
}
