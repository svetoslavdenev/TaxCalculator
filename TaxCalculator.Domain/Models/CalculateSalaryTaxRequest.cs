namespace TaxCalculator.Domain.Models
{
    using System.Collections.Generic;

    public class CalculateSalaryTaxRequest
    {
        public decimal GrossAmount { get; set; }

        public IEnumerable<TaxRule> TaxRules { get; set; }
    }
}
