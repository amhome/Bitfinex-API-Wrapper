using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexPermissionsResponse
    {
        public BitfinexAccountPermission account { get; set; }
        public BitfinexHistoryPermission history { get; set; }
        public BitfinexOrdersPermission orders { get; set; }
        public BitfinexPositionsPermission positions { get; set; }
        public BitfinexFundingPermission funding { get; set; }
        public BitfinexWalletsPermission wallets { get; set; }
        public BitfinexWithdrawPermission withdraw { get; set; }

        public static BitfinexPermissionsResponse FromJSON(string response)
        {
            return JsonConvert.DeserializeObject<BitfinexPermissionsResponse>(response);
        }
    }


    public class BitfinexAccountPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexHistoryPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexOrdersPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexPositionsPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexFundingPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexWalletsPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

    public class BitfinexWithdrawPermission
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }

   
}
