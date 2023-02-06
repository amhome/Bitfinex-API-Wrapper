using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexWithdrawRequest : BitfinexGenericRequest
    {
        public string withdraw_type { get; set; }
        public string walletselected { get; set; } = "exchange";
        public string amount { get; set; }
        public string address { get; set; }



        public BitfinexWithdrawRequest(string nonce, string method, string amount, string address)
        {
            this.nonce = nonce;
            this.request = "/v1/withdraw";

            this.withdraw_type = method.ToLower();
            this.amount = amount;
            this.address = address;
        }

    }

    
}
