namespace TaxCalculator.Core.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using TaxCalculator.Core.Services;
    using TaxCalculator.Core.Services.Interfaces;

    public static class IoCRegistrator
    {
        public static IServiceCollection AddTaxCalculation(this IServiceCollection services)
        {
            services.AddTransient<ITaxCalculatorService, TaxCalculatorService>();

            return services;
        }
    }
}
