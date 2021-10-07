namespace TaxCalculator.Web.Services.Interfaces
{
    using TaxCalculator.Web.Models;

    public interface ISalaryCalculator
    {
        CalculatedSalary Calculate(decimal grossAmount, int coutryId);
    }
}
