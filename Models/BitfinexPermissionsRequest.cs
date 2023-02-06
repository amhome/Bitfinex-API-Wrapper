using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexPermissionsRequest: BitfinexGenericRequest
    {
        public BitfinexPermissionsRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/key_info";
        }
    }
}
