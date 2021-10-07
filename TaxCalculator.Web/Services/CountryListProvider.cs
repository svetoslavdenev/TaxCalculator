namespace TaxCalculator.Web.Services
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using TaxCalculator.Web.Services.Interfaces;

    public class CountryListProvider : ICountryListProvider
    {
        private List<SelectListItem> countries;

        public CountryListProvider()
        {
            this.countries = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "Imaginaria",
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "Imagistan",
                },
                new SelectListItem
                {
                    Value = "3",
                    Text = "Imaginary Islands",
                },
            };
        }


        public List<SelectListItem> Countries => this.countries;
    }
}
