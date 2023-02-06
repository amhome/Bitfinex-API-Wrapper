using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexWithdrawResponse
    {
        public BitfinexWithdrawModel Model { get; set; }

        public BitfinexWithdrawResponse(BitfinexWithdrawModel model)
        {
            this.Model = model;
        }


        public static BitfinexWithdrawResponse FromJSON(string response)
        {
            List<BitfinexWithdrawModel> model = JsonConvert.DeserializeObject<List<BitfinexWithdrawModel>>(response);
            return new BitfinexWithdrawResponse(model.First());
        }
    }




    public class BitfinexWithdrawModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public int withdrawal_id { get; set; }
    }
}
