namespace TaxCalculator.Web.Validation
{
    using System;

    public class Rule
    {
        public string Name { get; set; }

        public Func<bool> Validate { get; set; }
    }
}
