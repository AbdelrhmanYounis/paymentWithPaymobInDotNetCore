using Microsoft.AspNetCore.Mvc;

namespace paymentWithPaymob.DTOS
{
    public class ResponseDto
    {

        public int id { get; set; }
        public bool success { get; set; }
        public bool is_auth { get; set; }
        public bool is_3d_secure { get; set; }

        [BindProperty(Name = "source_data.type", SupportsGet = true)]
        public string source_data_type { get; set; }
        public string txn_response_code { get; set; }
        public int amount_cents { get; set; }
        public bool is_voided { get; set; }

        [BindProperty(Name = "data.message", SupportsGet = true)]
        public string data_message { get; set; }
        public bool is_refunded { get; set; }
        public bool has_parent_transaction { get; set; }

        [BindProperty(Name = "source_data.pan", SupportsGet = true)]
        public int source_data_pan { get; set; }
        public bool is_standalone_payment { get; set; }
        public int profile_id { get; set; }
        public int refunded_amount_cents { get; set; }
        public bool error_occured { get; set; }
        public int order { get; set; }
        public string hmac { get; set; }
        public string currency { get; set; }
        public bool is_capture { get; set; }
        public int captured_amount { get; set; }
        public int integration_id { get; set; }
        public DateTime created_at { get; set; }
        public bool is_refund { get; set; }
        public bool pending { get; set; }
        public int owner { get; set; }
        public int merchant_ccommission { get; set; }
        public bool is_void { get; set; }

        [BindProperty(Name = "source_data.sub_type", SupportsGet = true)]
        public string source_data_sub_type { get; set; }
       
    }
}