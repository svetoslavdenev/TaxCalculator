namespace TaxCalculator.Core.Services
{
    using TaxCalculator.Core.Services.Interfaces;
    using TaxCalculator.Domain.Models;
    
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public Salary CalculateSalaryAfterTaxes(CalculateSalaryTaxRequest request)
        {
            var result = new Salary
            {
                GrossAmount = request.GrossAmount
            };
            var netSalary = request.GrossAmount;

            foreach (var rule in request.TaxRules)
            {
                var taxCost = ApplyRule(netSalary, rule);
                result.Taxes.Add(new Tax 
                {
                    Name = rule.TaxName,
                    Amount = taxCost,
                });

                netSalary -= taxCost;
            }

            result.NetAmount = netSalary;

            return result;
        }

        private decimal ApplyRule(decimal amount, TaxRule rule)
        {
            if (amount <= rule.MinimumValueToApply)
            {
                return 0;
            }

            if (rule.MaximumValueToApply != null && rule.MaximumValueToApply < amount)
            {
                amount = (decimal)rule.MaximumValueToApply;
            }

            var taxableAmount = amount - rule.MinimumValueToApply;

            return taxableAmount * (decimal)rule.Мultiplier;
        }
    }
}
