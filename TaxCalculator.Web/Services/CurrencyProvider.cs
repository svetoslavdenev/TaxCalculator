namespace TaxCalculator.Web.Services
{
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;
    using TaxCalculator.Web.Data;
    using TaxCalculator.Web.Models;
    using TaxCalculator.Web.Services.Interfaces;

    public class CurrencyProvider : ICurrencyProvider
    {
        private readonly Dictionary<int, Currency> currencies;

        public CurrencyProvider()
        {
            var currenciesJson = File.ReadAllText("Data/currencies.json");

            var data = JsonConvert.DeserializeObject<List<CurrencyData>>(currenciesJson);

            currencies = new Dictionary<int, Currency>();

            foreach (var c in data)
            {
                currencies.Add(c.CountryId, new Currency
                {
                    Country = c.Country,
                    ISOCode = c.ISOCode,
                });
            }
        }

        public bool ExistsByCountry(int countryId)
        {
            return this.currencies.ContainsKey(countryId);
        }

        public Currency GetByCountryId(int countryId)
        {
            if (!this.currencies.ContainsKey(countryId))
            {
                return null;
            }

            return this.currencies[countryId];
        }
    }
}
