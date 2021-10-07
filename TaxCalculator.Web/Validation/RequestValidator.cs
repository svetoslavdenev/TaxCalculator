namespace TaxCalculator.Web.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TaxCalculator.Web.Validation.Interfaces;

    public class RequestValidator : IRequestValidator
    {
        private List<Rule> validationRules;
        private List<Exception> exceptions;

        public RequestValidator()
        {
            this.validationRules = new List<Rule>();
            this.exceptions = new List<Exception>();
        }

        public IRequestValidator InRange<T>(object value, object minValue, object maxValue)
            where T : IComparable<T>
        {
            try
            {
                this.validationRules.Add(
               new Rule
               {
                   Name = $"Provided value, must be greather than {minValue} and less than {maxValue}",
                   Validate = () => ((T)value).CompareTo((T)minValue) >= 0 && ((T)value).CompareTo((T)maxValue) <= 0,
               });
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }

            return this;
        }

        public ValidationResult Validate()
        {
            if (exceptions.Any())
            {
                var sb = new StringBuilder();
                foreach (var ex in exceptions)
                {
                    sb.AppendLine(ex.Message);
                }
                return ValidationResult.Error(sb.ToString());
            }

            foreach (var rule in this.validationRules)
            {
                var ok = rule.Validate();
                if (!ok)
                {
                    return ValidationResult.Error(rule.Name);
                }
            }

            return ValidationResult.Success();
        }
    }
}
