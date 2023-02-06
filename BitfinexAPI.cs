using Newtonsoft.Json;
using Project.Models.Bitfinex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{

    // The current rate limit is between 10 and 90 requests per minute depending on the specific REST API endpoint (i.e. /ticker).
    // If an IP address is rate limited, the IP is blocked for 60 seconds and cannot make any requests during that time.
    // If your IP address is rate limited, the API will return the JSON response {“error”: “ERR_RATE_LIMIT”}”. 

    public class BitfinexAPI
    {
        private DateTime epoch = new DateTime(1970, 1, 1);

        private HMACSHA384 hashMaker;
        private string Key;
        private int nonce = 0;
        private string Nonce
        {
            get
            {
                if (nonce == 0)
                {
                    nonce = (int)(DateTime.UtcNow - epoch).TotalSeconds;
                }
                return (nonce++).ToString();
            }
        }
        public BitfinexAPI(string key, string secret)
        {
            hashMaker = new HMACSHA384(Encoding.UTF8.GetBytes(secret));
            this.Key = key;
        }

        private String GetHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(String.Format("{0:x2}", b));
            }
            return sb.ToString();
        }




        public BitfinexDepositResponse GetDepositAddress(string method)
        {
            BitfinexDepositRequest req = new BitfinexDepositRequest(Nonce, method);
            string response = SendRequest(req, "POST");
            BitfinexDepositResponse resp = BitfinexDepositResponse.FromJSON(response);

            return resp;
        }
        

        public BitfinexWithdrawResponse ApplyWithdraw(string method, string amount, string address)
        {
            BitfinexWithdrawRequest req = new BitfinexWithdrawRequest(Nonce, method, amount, address);
            string response = SendRequest(req, "POST");
            BitfinexWithdrawResponse resp = BitfinexWithdrawResponse.FromJSON(response);

            return resp;
        }


        public IEnumerable<BitfinexHistoryResponse> GetHistories(string currency, string method, string since, string until)
        {
            BitfinexHistoryRequest req = new BitfinexHistoryRequest(Nonce, currency, method, since, until);
            string response = SendRequest(req, "POST");
            IEnumerable<BitfinexHistoryResponse> resp = BitfinexHistoryResponse.FromJSON(response);

            return resp;
        }


        public BitfinexBalancesResponse GetBalances()
        {
            BitfinexBalancesRequest req = new BitfinexBalancesRequest(Nonce);
            string response = SendRequest(req, "GET");
            return new BitfinexBalancesResponse { Items = BitfinexBalancesResponse.FromJSON(response) };
        }


        public BitfinexPermissionsResponse GetPermissions()
        {
            BitfinexPermissionsRequest req = new BitfinexPermissionsRequest(Nonce);
            string response = SendRequest(req, "POST");
            return BitfinexPermissionsResponse.FromJSON(response);
        }
        
        


        private string SendRequest(BitfinexGenericRequest request, string httpMethod)
        {
            string json = JsonConvert.SerializeObject(request);
            string json64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] data = Encoding.UTF8.GetBytes(json64);
            byte[] hash = hashMaker.ComputeHash(data);
            string signature = GetHexString(hash);

            HttpWebRequest wr = WebRequest.Create("https://api.bitfinex.com" + request.request) as HttpWebRequest;
            wr.Headers.Add("X-BFX-APIKEY", Key);
            wr.Headers.Add("X-BFX-PAYLOAD", json64);
            wr.Headers.Add("X-BFX-SIGNATURE", signature);
            wr.Method = httpMethod;

            string response = null;
            try
            {
                HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
                throw new BitfinexException(ex, response);
            }
            return response;
        }
    }
}
