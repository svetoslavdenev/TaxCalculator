namespace TaxCalculator.Web.Validation
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public static ValidationResult Success() 
            => new ValidationResult { IsSuccess = true };

        public static ValidationResult Error(string errorMessage)
            => new ValidationResult { IsSuccess = false, ErrorMessage = errorMessage };
    }
}
