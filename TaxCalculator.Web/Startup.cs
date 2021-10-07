namespace TaxCalculator.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TaxCalculator.Core.IoC;
    using TaxCalculator.Web.Config;
    using TaxCalculator.Web.Services;
    using TaxCalculator.Web.Services.Interfaces;
    using TaxCalculator.Web.Validation;
    using TaxCalculator.Web.Validation.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTaxCalculation();

            services.AddTransient<ISalaryCalculator, SalaryCalculator>();
            services.AddTransient<IRequestValidator, RequestValidator>();
            services.AddTransient<ICountryTaxRulesProvider, CountryTaxRulesProvider>();
            services.AddTransient<ICountryListProvider, CountryListProvider>();

            services.AddSingleton<ICurrencyProvider, CurrencyProvider>();

            services.Configure<ApplicationConfig>(Configuration.GetSection("ApplicationConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Index");
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Index";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
