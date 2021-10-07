namespace TaxCalculator.Web.Validation.Interfaces
{
    using System;

    public interface IRequestValidator
    {
        IRequestValidator InRange<T>(object value, object minValue, object maxValue)
            where T : IComparable<T>;

        ValidationResult Validate();
    }
}
