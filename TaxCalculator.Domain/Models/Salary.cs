namespace TaxCalculator.Domain.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Salary
    {
        public Salary()
        {
            this.Taxes = new List<Tax>();
        }

        public decimal NetAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public List<Tax> Taxes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
