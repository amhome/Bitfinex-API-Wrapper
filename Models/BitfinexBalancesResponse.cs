using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    
    public class BitfinexBalancesResponse
    {

        public List<BitfinexBalanceResponseItem> Items { get; set; }

        public static List<BitfinexBalanceResponseItem> FromJSON(string response)
        {
            return JsonConvert.DeserializeObject<List<BitfinexBalanceResponseItem>>(response);
        }

    }




    public class BitfinexBalanceResponseItem
    {
        public string type;
        public string currency;
        public string amount;
        public string available;
    }

}
