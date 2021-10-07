namespace TaxCalculator.Web.Models
{
    using Newtonsoft.Json;

    public class ApiResult
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
