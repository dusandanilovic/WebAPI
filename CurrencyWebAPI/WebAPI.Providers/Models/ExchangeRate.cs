using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Providers.Models
{
    public class ExchangeRate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
