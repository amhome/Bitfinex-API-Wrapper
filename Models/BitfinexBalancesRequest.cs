using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexBalancesRequest : BitfinexGenericRequest
    {
        public BitfinexBalancesRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/balances";
        }
    }
}
