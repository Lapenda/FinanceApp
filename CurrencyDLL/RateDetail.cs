using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDLL
{
    internal class RateDetail
    {
        [JsonProperty("currency_name")]
        public string CurrencyName { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("rate_for_amount")]
        public string RateForAmount { get; set; }
    }
}
