using Newtonsoft.Json;

namespace paymentWithPaymob.Helpers.Payment.thirdStep
{
    public class PaymentKeyRequestResopns
    {
        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
