namespace TaxCalculator.Web.Services
{
    using System.Collections.Generic;

    using TaxCalculator.Core.Services.Interfaces;
    using TaxCalculator.Domain.Models;
    using TaxCalculator.Web.Models;
    using TaxCalculator.Web.Services.Interfaces;

    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly ICurrencyProvider currencyProvider;
        private readonly ITaxCalculatorService taxCalculatorService;
        private readonly ICountryTaxRulesProvider countryTaxRulesProvider;

        public SalaryCalculator(
            ICurrencyProvider currencyProvider,
            ITaxCalculatorService taxCalculatorService,
            ICountryTaxRulesProvider countryTaxRulesProvider)
        {
            this.currencyProvider = currencyProvider;
            this.taxCalculatorService = taxCalculatorService;
            this.countryTaxRulesProvider = countryTaxRulesProvider;
        }

        public CalculatedSalary Calculate(decimal grossAmount, int coutryId)
        {
            var currency = this.currencyProvider.GetByCountryId(coutryId);

            var taxRules = this.countryTaxRulesProvider.GetRulesForCountry(coutryId);

            if (taxRules == null)
            {
                return null;
            }

            var innerRequest = new CalculateSalaryTaxRequest
            {
                GrossAmount = grossAmount,
                TaxRules = taxRules,
            };

            var salary = this.taxCalculatorService.CalculateSalaryAfterTaxes(innerRequest);
            return new CalculatedSalary
            {
                GrossAmount = new Amount(salary.GrossAmount, currency.ISOCode),
                NetAmount = new Amount(salary.NetAmount, currency.ISOCode),
                Taxes = BuildTaxesWithCurrency(salary.Taxes, currency),
            };
        }

        private List<TaxWithCurrency> BuildTaxesWithCurrency(List<Tax> taxes, Currency currency)
        {
            var result = new List<TaxWithCurrency>();

            foreach (var tx in taxes)
            {
                result.Add(new TaxWithCurrency(tx.Name, new Amount(tx.Amount, currency.ISOCode)));
            }

            return result;
        }
    }
}
