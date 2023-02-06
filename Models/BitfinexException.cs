using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexException : WebException
    {

        public BitfinexException(WebException ex, string bitfinexMessage) :
            base(bitfinexMessage, ex)
        {
        }
    }
}
