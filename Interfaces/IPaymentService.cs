namespace paymentWithPaymob.Interfaces
{
    public interface IPaymentService
    {
        public Task<string> GetToken();
        public Task<string> OrderRegistation(string token);
        public Task<string> PaymentKey(string token, string orderId);

    }
}