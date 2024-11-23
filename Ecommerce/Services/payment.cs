using Razorpay.Api;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Services
{
    public interface IRazorpayService
    {
        public Order CreateOrder(int amount, string currency, string receipt);
        public Payment FetchPayment(string paymentId);
        public bool VerifyPaymentSignature(string paymentId, string orderId, string signature, string apiSecret);
    }



    public class RazorpayService : IRazorpayService
    {
        private readonly RazorpayClient _client;

        public RazorpayService(IConfiguration configuration)
        {
            var apiKey = configuration["Razorpay:ApiKey"];
            var apiSecret = configuration["Razorpay:ApiSecret"];

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                throw new ArgumentException("Razorpay API credentials are missing.");
            }

            _client = new RazorpayClient(apiKey, apiSecret);
        }

        public Order CreateOrder(int amount, string currency, string receipt)
        {
            var options = new Dictionary<string, object>
        {
            { "amount", amount * 100 }, // Amount in paise (1 INR = 100 paise)
            { "currency", currency },
            { "receipt", receipt },
            { "payment_capture", 1 } // Auto-capture payment
        };

            return _client.Order.Create(options);
        }

        public Payment FetchPayment(string paymentId)
        {
            return _client.Payment.Fetch(paymentId);
        }

        public bool VerifyPaymentSignature(string paymentId, string orderId, string signature, string apiSecret)
        {
            string payload = $"{orderId}|{paymentId}";

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                var generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return generatedSignature == signature;
            }
        }

        


    }


}
