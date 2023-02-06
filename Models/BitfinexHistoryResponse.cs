using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexHistoryResponse
    {
        public int id { get; set; }
        public string txid { get; set; }
        public string currency { get; set; } // "BTC"
        public string method { get; set; } // "BITCOIN"
        public string type { get; set; } // "WITHDRAWAL"
        public string amount { get; set; } // ".01"
        public string description { get; set; }
        public string address { get; set; }
        public string status { get; set; } // "COMPLETED"
        public string timestamp { get; set; } // "1443833327.0"
        public float fee { get; set; } // 0.1





        public static IEnumerable<BitfinexHistoryResponse> FromJSON(string response)
        {
            return JsonConvert.DeserializeObject<IEnumerable<BitfinexHistoryResponse>>(response);
        }
    }
}
