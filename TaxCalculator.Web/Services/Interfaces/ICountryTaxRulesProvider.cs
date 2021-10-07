namespace TaxCalculator.Web.Services.Interfaces
{
    using System.Collections.Generic;

    using TaxCalculator.Domain.Models;

    public interface ICountryTaxRulesProvider
    {
        List<TaxRule> GetRulesForCountry(int countryId);
    }
}
