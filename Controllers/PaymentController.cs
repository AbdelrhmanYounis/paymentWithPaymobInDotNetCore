using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using paymentWithPaymob.DTOS;
using paymentWithPaymob.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace paymentWithPaymob.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var Tokenobj = await _service.GetToken();
            var objwithID = await _service.OrderRegistation(Tokenobj);
            var IframToken = await _service.PaymentKey(Tokenobj, objwithID);
            return Redirect("https://accept.paymob.com/api/acceptance/iframes/392179?payment_token=" + IframToken);

        }
        [HttpGet]
        public IActionResult PaymentCallBack (ResponseDto response)
        {
          string[]  HMACStringKeys = new string[20] { "amount_cents", "created_at", "currency", "error_occured", "has_parent_transaction"
              , "id","integration_id","is_3d_secure","is_auth","is_capture","is_refunded","is_standalone_payment","is_voided"
              ,"order","owner","pending","source_data_pan","source_data_sub_type","source_data_type","success" };

            string HMACStringconcatenates = "", HMAC_secret = "C052EACA1C43FDFCD23FA8D9BFE98113";

            foreach (var propertyName in HMACStringKeys)
            {
                try
                {
                    HMACStringconcatenates += response.GetType().GetProperty(propertyName).GetValue(response, null);
                }
                catch (Exception ex)
                {
                     Console.WriteLine(ex.Message);
                }
            }
            var HashedHMAC = SHA512_ComputeHash(HMACStringconcatenates,HMAC_secret);
            
            if (string.Equals(response.hmac, HashedHMAC))
            {
                return View();
            }
            return View("failed");

        }
        public static string SHA512_ComputeHash(string text, string secretKey)
        {
            var hash = new StringBuilder(); ;
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(secretKey);
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }
    }
}