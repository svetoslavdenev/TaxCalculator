namespace TaxCalculator.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using TaxCalculator.Domain.Helpers;
    using TaxCalculator.Domain.Models;
    using TaxCalculator.Web.Services.Interfaces;

    public class CountryTaxRulesProvider : ICountryTaxRulesProvider
    {
        public List<TaxRule> GetRulesForCountry(int countryId)
        {
            return countryId switch
            {
                1 => DefaultTaxRules.ImaginariaDefaultTaxRules.ToList(),
                2 => DefaultTaxRules.ImagistanDefaultTaxRules.ToList(),
                3 => DefaultTaxRules.ImaginaryIslandsDefaultTaxRules.ToList(),
                _ => null,
            };
        }
    }
}
