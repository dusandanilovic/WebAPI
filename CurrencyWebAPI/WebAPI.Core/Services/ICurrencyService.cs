using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Models;

namespace WebAPI.Core.Services
{
    public interface ICurrencyService
    {
        public Task<ExchangeRateData> GetExchangeRateData(string days, string baseCurrency, string targetCurrency);
    }
}
