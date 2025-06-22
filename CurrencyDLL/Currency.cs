using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDLL
{
    internal class Currency
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_date")]
        public string UpdatedDate { get; set; }

        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("base_currency_name")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, RateDetail> Rates { get; set; }
    }
}
