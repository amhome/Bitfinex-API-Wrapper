using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Bitfinex
{
    public class BitfinexLocal
    {
        private IHostingEnvironment _hostingEnvironment;
        public BitfinexLocal(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        private string LoadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, $"{fileName}.json")))
                return r.ReadToEnd();
        }

        public string GetMethod(string symbol)
        {
            symbol = symbol.ToUpper().Replace("USDT", "");
            List<List<object>> items = JsonConvert.DeserializeObject<List<List<object>>>(LoadJson("bitfinexMethods"));
            var methods = items.SelectMany(s => s).Where(s => s.GetType() == typeof(string));
            var symbols = items.SelectMany(s => s).Where(s => s.GetType() == typeof(JArray)).Cast<JArray>()
                .Select(s => s.First).ToList();
            return methods.ElementAtOrDefault(symbols.IndexOf(symbol)).ToString();
        }
    }
}
