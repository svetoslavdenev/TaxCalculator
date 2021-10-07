namespace TaxCalculator.Web.Config
{
    public class ApplicationConfig
    {
        public decimal MinimumSalaryValueToCalculate { get; set; }

        public decimal MaximumalaryValueToCalculate { get; set; }

        public int MinCountryId { get; set; }

        public int MaxCountryId { get; set; }
    }
}
