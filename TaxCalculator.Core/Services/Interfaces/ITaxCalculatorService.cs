namespace TaxCalculator.Core.Services.Interfaces
{
    using TaxCalculator.Domain.Models;

    public interface ITaxCalculatorService
    {
        Salary CalculateSalaryAfterTaxes(CalculateSalaryTaxRequest request);
    }
}
