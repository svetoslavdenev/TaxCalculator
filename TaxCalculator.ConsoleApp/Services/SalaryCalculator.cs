namespace TaxCalculator.ConsoleApp.Services
{
    using TaxCalculator.ConsoleApp.Services.Interfaces;
    using TaxCalculator.Core.Services.Interfaces;
    using TaxCalculator.Domain.Helpers;
    using TaxCalculator.Domain.Models;

    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly ITaxCalculatorService taxCalculatorService;

        public SalaryCalculator(ITaxCalculatorService taxCalculatorService)
        {
            this.taxCalculatorService = taxCalculatorService;
        }

        public Salary CalculateSalary(decimal grossAmount)
        {
            var request = new CalculateSalaryTaxRequest
            {
                GrossAmount = grossAmount,
                TaxRules = DefaultTaxRules.ImaginariaDefaultTaxRules,
            };
            return this.taxCalculatorService.CalculateSalaryAfterTaxes(request);
        }
    }
}
