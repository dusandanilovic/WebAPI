using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Providers.Models;

namespace WebAPI.Providers.Services
{
    public interface IExchangeRatesApiService
    {
        public Task<ExchangeRate> GetDailyExchangeRate(DateTime day, string baseCurrency, string targetCurrency);
    }
}
