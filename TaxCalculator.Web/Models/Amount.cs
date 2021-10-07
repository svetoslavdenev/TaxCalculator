namespace TaxCalculator.Web.Models
{
    public class Amount
    {
        public Amount(decimal value, string currencyISOCode)
        {
            this.TotalValue = value;
            this.CurrencyISOCode = currencyISOCode;
        }

        public decimal TotalValue { get; set; }

        public string CurrencyISOCode { get; set; }
    }
}
