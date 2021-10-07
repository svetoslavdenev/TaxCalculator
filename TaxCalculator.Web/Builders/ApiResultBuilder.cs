namespace TaxCalculator.Web.Builders
{
    using TaxCalculator.Web.Models;

    public class ApiResultBuilder
    {
        private object data;
        private bool isSuccess;
        private string errorMessage;

        private ApiResultBuilder(object data) 
        {
            this.data = data;
            isSuccess = true;
        }

        private ApiResultBuilder(string errorMessage)
        {
            this.errorMessage = errorMessage;
            isSuccess = false;
        }


        public static ApiResultBuilder Success(object data)
        {
            return new ApiResultBuilder(data);
        }

        public static ApiResultBuilder Error(string errorMessage)
        {
            return new ApiResultBuilder(errorMessage);
        }

        public ApiResult Build()
        {
            return new ApiResult
            {
                Data = this.data,
                IsSuccess = this.isSuccess,
                ErrorMessage = this.errorMessage,
            };
        }
    }
}
