using Newtonsoft.Json;
using paymentWithPaymob.Interfaces;
using paymentWithPaymob.Helpers.Payment;
using paymentWithPaymob.Helpers.Payment.FristStep;
using paymentWithPaymob.Helpers.Payment.secondStep;
using paymentWithPaymob.Helpers.Payment.thirdStep;
using System.Text;

namespace paymentWithPaymob.Services
{   
    public class PaymentService :  IPaymentService

    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client=new HttpClient();
        }
        public async Task<string> GetToken()
        {
            try
            {
                string URL = "https://accept.paymob.com/api/auth/tokens";
                var keyobject = new { api_key = 
                                        "ZXlKMGVYQWlPaUpLVjFRaUxDSmhiR2NpT2lKSVV6VXhNaUo5LmV5SmpiR0Z6Y3lJNklrMWxjbU5vWVc1MElpd2libUZ0WlNJNkltbHVhWFJwWVd3aUxDSndjbTltYVd4bFgzQnJJam94T0RjeU1UWjkub0VITDQ3cThpdUs1V0tLUUJKS0VPYVVwT0x6V2d3VWFkSi1zSklOaGw5RlAtQXR6UjRDVlR3WWRZa2NQTnkzX3ZlTXpiWEk5Y3Fod3JqSDZ2NXQ2Qnc="
                                    };
                var seralizedobj = new StringContent(JsonConvert.SerializeObject(keyobject), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(URL, seralizedobj);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<AuthTokenResponse>(data);
                    if (obj is not null)
                        if (obj.Token is not null)
                            return obj.Token;
                    return "error message";
                }
                return "error";

            }
            catch (Exception ex)
            {
                return ex.Message;


            }

        }

        public async Task<string> OrderRegistation(string token)
        {
            try
            {
                string URL = "https://accept.paymob.com/api/ecommerce/orders";
                List<OrderItem> items = new();
                items.Add(new OrderItem
                {
                    Name = "consultation",
                    AmountCents = "35000",
                    Description = "consultatoion",
                    Quantity = 1
                });

                var RequestedData = new OrderRegistrationitem
                {
                    AmountCents = 35000,
                    AuthToken = token,
                    DeliveryNeeded = false,
                    Currency = "EGP",
                    Items = items
                };
                var SerializedRequestedObj = new StringContent(JsonConvert.SerializeObject(RequestedData), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(URL, SerializedRequestedObj);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<OrderRegistrationResponse>(data);
                    if (obj is not null)
                        if (obj.Id is not null)
                            return obj.Id;
                    return "error";
                }
                return "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PaymentKey(string token, string orderId)
        {
            try
            {
                var URL = "https://accept.paymob.com/api/acceptance/payment_keys";
                var RequestedData = new PaymentKeyRequestData
                {
                    AuthToken = token,
                    AmountContent = 35000,
                    Expiration = 4000,
                    OrderId = orderId,
                    BillingData = new BillingData
                    {
                        Email = "abdelrhmanyounis7979@gmail.com",
                        FirstName = "Abdelrhman",
                        LastName = "Gamal",
                        Country = "Egypt",
                        City = "cairo",
                        Street = "street",
                        Building = "25",
                        Floor = "6",
                        Apartment = "2",
                        PostalCode = "d",
                        ShippingMethod = "shiping",
                        PhoneNumber = "01555555555",
                        State = "state"
                    },
                    Currency = "EGP",
                    IntegrationId =2176892
                };
                var SerializedRequestedObj = new StringContent(JsonConvert.SerializeObject(RequestedData), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(URL, SerializedRequestedObj);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<PaymentKeyRequestResopns>(data);
                    if (obj != null)
                    {
                        if (obj.Token is not null)
                            return obj.Token;
                    }
                    else
                    {
                        return "error";
                    }
                }
                return "error";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}