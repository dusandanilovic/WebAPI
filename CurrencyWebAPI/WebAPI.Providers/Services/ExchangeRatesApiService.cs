using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Providers.Models;

namespace WebAPI.Providers.Services
{
    public class ExchangeRatesApiService : IExchangeRatesApiService
    {
        public Configuration Configuration { get; }
        public ExchangeRatesApiService()
        {
            this.Configuration = new Configuration
            {
                BaseUrl = "http://api.exchangeratesapi.io/v1",
                AccessKey = "4d26f302fa69323696bb66270f6bb33e"
            };
        }

        public async Task<ExchangeRate> GetDailyExchangeRate(DateTime day, string baseCurrency, string targetCurrency)
        {
            //// since exchange rates API free subscription does not allow base currency I had to omit this part of the url to make this service work
            //// string url = $"{this.Configuration.BaseUrl}/{day.ToString("yyyy-MM-dd")}?access_key={this.Configuration.AccessKey}&base={baseCurrency}&symbols={targetCurrency}";

            string url = $"{this.Configuration.BaseUrl}/{day.ToString("yyyy-MM-dd")}?access_key={this.Configuration.AccessKey}&symbols={targetCurrency}";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode == true)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ExchangeRate>(content);
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
