using Newtonsoft.Json;
using paymentWithPaymob.Helpers.Payment.secondStep;

namespace paymentWithPaymob.Helpers.Payment
{
    public class OrderRegistrationitem
    {

        [JsonProperty("auth_token")]
        public string? AuthToken { get; set; }
        [JsonProperty("delivery_needed")]
        public bool DeliveryNeeded { get; set; }
        [JsonProperty("amount_cents")]
        public decimal AmountCents { get; set; }
        [JsonProperty("currency")]
        public string? Currency { get; set; }
        [JsonProperty("items")]
        public List<OrderItem> ?Items { get; set; }
    }
}
