namespace TaxCalculator.Domain.Models
{
    public class TaxRule
    {
        public string TaxName { get; set; }

        public decimal MinimumValueToApply { get; set; }

        public decimal? MaximumValueToApply { get; set; }

        public double Мultiplier { get; set; }
    }
}
