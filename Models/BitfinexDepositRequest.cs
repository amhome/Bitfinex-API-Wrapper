using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexDepositRequest : BitfinexGenericRequest
    {
        public string method { get; set; }
        public string wallet_name { get; set; } = "exchange"; //Wallet to deposit in (accepted: “trading”, “exchange”, “deposit”). Your wallet needs to already exist

        public BitfinexDepositRequest(string nonce, string method)
        {
            this.nonce = nonce;
            this.request = "/v1/deposit/new";

            this.method = method;
        }
    }
}
