using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebAPI.Core.Models
{
    public class ExchangeRateData
    {
        public ExchangeRateValue MinValue { get; set; }

        public ExchangeRateValue MaxValue { get; set; }

        public decimal AvgValue { get; set; }
    }
}
