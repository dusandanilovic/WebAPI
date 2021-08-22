using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Models;
using WebAPI.Core.Services;
using WebAPI.Providers.Services;

namespace WebAPI.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IExchangeRatesApiService exchangeRatesApiService;

        public CurrencyService(IExchangeRatesApiService exchangeRatesApiService)
        {
            this.exchangeRatesApiService = exchangeRatesApiService ?? throw new ArgumentNullException("exchangeRatesApiService is null");
        }

        public async Task<ExchangeRateData> GetExchangeRateData(string days, string baseCurrency, string targetCurrency)
        {
            try
            {
                if (days != null)
                {
                    List<DateTime> listOfDays = days.Split(',').Select(d => DateTime.Parse(d)).ToList();
                    List<ExchangeRateDTO> exchangeRateDTOs = new List<ExchangeRateDTO>();
                    var tasks = listOfDays.Select(day => this.exchangeRatesApiService.GetDailyExchangeRate(day, baseCurrency, targetCurrency));
                    var exchangeRates = await Task.WhenAll(tasks);

                    foreach (var exchangeRate in exchangeRates)
                    {
                        exchangeRateDTOs.Add(new ExchangeRateDTO
                        {
                            Date = exchangeRate.Date,
                            BaseCurrency = exchangeRate.BaseCurrency,
                            Rate = exchangeRate.Rates.TryGetValue(targetCurrency, out decimal rate) == true ? rate : 0
                        });
                    }

                    if (exchangeRateDTOs != null)
                    {
                        var minValue = exchangeRateDTOs.OrderBy(e => e.Rate).First();
                        var maxValue = exchangeRateDTOs.OrderByDescending(e => e.Rate).First();
                        var average = exchangeRateDTOs.Average(e => e.Rate);

                        return new ExchangeRateData()
                        {
                            MinValue = new ExchangeRateValue()
                            {
                                Date = minValue.Date.ToString("yyyy-MM-dd"),
                                Value = minValue.Rate
                            },
                            MaxValue = new ExchangeRateValue()
                            {
                                Date = maxValue.Date.ToString("yyyy-MM-dd"),
                                Value = maxValue.Rate
                            },
                            AvgValue = average
                        };
                    }
                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
