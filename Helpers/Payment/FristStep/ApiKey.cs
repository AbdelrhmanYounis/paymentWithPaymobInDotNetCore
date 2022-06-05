using Newtonsoft.Json;

namespace paymentWithPaymob.Helpers.Payment.FristStep
{
    public class ApiKey
    {
        [JsonProperty("api-key")]
        public string Key { set; get; }
    }
}