using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Models
{
    public class ExchangeRateDTO
    {
        public DateTime Date { get; set; }

        public string BaseCurrency { get; set; } 

        public decimal Rate { get; set; }
    }
}
