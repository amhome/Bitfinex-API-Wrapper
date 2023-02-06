using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexDepositResponse
    {
        public BitfinexDepositModel Model { get; set; }

        public BitfinexDepositResponse(BitfinexDepositModel model)
        {
            Model = model;
        }

        public static BitfinexDepositResponse FromJSON(string response)
        {
            BitfinexDepositModel model = JsonConvert.DeserializeObject<BitfinexDepositModel>(response);
            return new BitfinexDepositResponse(model);
        }
    }



    public class BitfinexDepositModel
    {
        public string result { get; set; }
        public string method { get; set; }
        public string currency { get; set; }
        public string address { get; set; }
    }
}
