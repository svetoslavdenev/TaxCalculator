namespace TaxCalculator.Domain.Helpers
{
    using System.Collections.Generic;

    using TaxCalculator.Domain.Models;

    public static class DefaultTaxRules
    {
        public static readonly IEnumerable<TaxRule> ImaginariaDefaultTaxRules =
            new List<TaxRule> 
            {
                new TaxRule
                {
                    TaxName = "Income tax",
                    MinimumValueToApply = 1000,
                    MaximumValueToApply = null,
                    Мultiplier = 0.1,
                },
                new TaxRule
                {
                    TaxName = "Social contributions",
                    MinimumValueToApply = 1000,
                    MaximumValueToApply = 3000,
                    Мultiplier = 0.15,
                },
            };

        public static readonly IEnumerable<TaxRule> ImagistanDefaultTaxRules =
            new List<TaxRule>
            {
                new TaxRule
                {
                    TaxName = "Income tax",
                    MinimumValueToApply = 1000,
                    MaximumValueToApply = null,
                    Мultiplier = 0.05,
                },
                new TaxRule
                {
                    TaxName = "Social contributions",
                    MinimumValueToApply = 500,
                    MaximumValueToApply = 3500,
                    Мultiplier = 0.20,
                },
                 new TaxRule
                {
                    TaxName = "Tax for the King",
                    MinimumValueToApply = 0,
                    Мultiplier = 0.05,
                },
            };

        public static readonly IEnumerable<TaxRule> ImaginaryIslandsDefaultTaxRules =
          new List<TaxRule>
          {
                new TaxRule
                {
                    TaxName = "Income tax",
                    MinimumValueToApply = 1000,
                    MaximumValueToApply = 10_000,
                    Мultiplier = 0.01,
                },
          };
    }
}
