namespace TaxCalculator.Web.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using TaxCalculator.Web.Config;
    using TaxCalculator.Web.Services.Interfaces;
    using TaxCalculator.Web.Validation.Interfaces;

    using static TaxCalculator.Web.Builders.ApiResultBuilder;

    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCalculatorController : ControllerBase
    {
        private readonly ISalaryCalculator salaryCalculator;
        private readonly IRequestValidator requestValidator;

        private readonly IOptions<ApplicationConfig> config;

        public SalaryCalculatorController(
            ISalaryCalculator salaryCalculator,
            IRequestValidator requestValidator,
            IOptions<ApplicationConfig> config)
        {
            this.salaryCalculator = salaryCalculator;
            this.requestValidator = requestValidator;
            this.config = config;
        }

        [HttpGet(nameof(Calculate))]
        public IActionResult Calculate(decimal grossAmount, int coutryId)
        {
            var validationResult = this.requestValidator
                .InRange<decimal>(grossAmount, 
                this.config.Value.MinimumSalaryValueToCalculate, 
                this.config.Value.MaximumalaryValueToCalculate)
                .InRange<int>(coutryId, 
                this.config.Value.MinCountryId, 
                this.config.Value.MaxCountryId)
                .Validate();

            if (!validationResult.IsSuccess)
            {
                return Ok(Error(validationResult.ErrorMessage).Build());
            }

            var calculatedSalary = this.salaryCalculator.Calculate(grossAmount, coutryId);

            var apiResult = calculatedSalary == null ?
                Error("Unexpected error").Build() :
                Success(calculatedSalary).Build();

            return Ok(apiResult);
        }
    }
}
