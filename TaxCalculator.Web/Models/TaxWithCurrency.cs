namespace TaxCalculator.Web.Models
{
    using Newtonsoft.Json;

    public class TaxWithCurrency
    {
        public TaxWithCurrency(string name, Amount amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public string Name { get; set; }

        public Amount Amount { get; set; }
    }
}
