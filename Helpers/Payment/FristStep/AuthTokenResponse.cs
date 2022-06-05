using Newtonsoft.Json;

namespace paymentWithPaymob.Helpers.Payment.FristStep
{
    public class AuthTokenResponse
    {
        [JsonProperty("token")]
        public string ?Token { get; set; }
    }
}
