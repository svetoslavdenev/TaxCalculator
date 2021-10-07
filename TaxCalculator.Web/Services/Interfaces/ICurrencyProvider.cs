namespace TaxCalculator.Web.Services.Interfaces
{
    using TaxCalculator.Web.Models;

    public interface ICurrencyProvider
    {
        Currency GetByCountryId(int countryId);

        bool ExistsByCountry(int countryId);
    }
}
