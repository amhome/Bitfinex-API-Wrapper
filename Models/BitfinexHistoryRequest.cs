using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexHistoryRequest : BitfinexGenericRequest
    {
        public string currency { get; set; } //required
        public string method { get; set; }
        public string since { get; set; }
        public string until { get; set; }


        public BitfinexHistoryRequest(string nonce, string currency, string method, string since, string until)
        {
            this.nonce = nonce;
            this.request = "/v1/history/movements";

            this.currency = currency;
            this.method = method;
            this.since = since;
            this.until = until;
        }
    }
}
