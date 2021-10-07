namespace TaxCalculator.Web.Models
{
    using System.Collections.Generic;

    public class CalculatedSalary
    {
        public Amount NetAmount { get; set; }

        public Amount GrossAmount { get; set; }

        public List<TaxWithCurrency> Taxes { get; set; }
    }
}
