namespace TaxCalculator.Web.Services.Interfaces
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    
    public interface ICountryListProvider
    {
        List<SelectListItem> Countries { get; }
    }
}
