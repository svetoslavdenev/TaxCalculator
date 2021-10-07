namespace TaxCalculator.ConsoleApp.Services.Interfaces
{
    using TaxCalculator.Domain.Models;

    public interface ISalaryCalculator
    {
        Salary CalculateSalary(decimal grossAmount);
    }
}
