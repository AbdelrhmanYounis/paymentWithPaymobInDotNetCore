using Newtonsoft.Json;

namespace paymentWithPaymob.Helpers.Payment.secondStep
{
    public class OrderRegistrationResponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }  
    }
}
