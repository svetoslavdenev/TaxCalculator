namespace TaxCalculator.Tests.Core.Services
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using TaxCalculator.Core.Services;
    using TaxCalculator.Domain.Models;

    public class TaxCalculatorServiceTests
    {
        [Test]
        [TestCase(980, 980)]
        [TestCase(3400, 2860)]
        public void TestCorrectAmountsCalculation(decimal grossAmount, decimal expectedNetAmount)
        {
            var subject = new TaxCalculatorService();

            var request = new CalculateSalaryTaxRequest
            {
                GrossAmount = grossAmount,
                TaxRules = new List<TaxRule>
                {
                    new TaxRule
                    {
                        TaxName = "test1",
                        MinimumValueToApply = 1000,
                        Мultiplier = 0.1,
                    },
                    new TaxRule
                    {
                        TaxName = "test2",
                        MinimumValueToApply = 1000,
                        MaximumValueToApply = 3000,
                        Мultiplier = 0.15,
                    },
                },
            };

            var salary = subject.CalculateSalaryAfterTaxes(request);

            Assert.AreEqual(expectedNetAmount, salary.NetAmount);
        }
    }
}
