using CurrencyWebAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Services;

namespace CurrencyWebAPI.Controllers
{
    /// <summary>
    /// The cuurency controller
    /// </summary>
    /// <seealso cref="CurrencyWebAPI.Controllers.Base.CurrencyControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : CurrencyControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="currencyService">The currency service.</param>
        public CurrencyController(ICurrencyService currencyService) : base(currencyService) { }

        /// <summary>
        /// Get exchange rate data
        /// </summary>
        /// <param name="days">Set of dates separated by comma. [yyyy-MM-dd]</param>
        /// <param name="baseCurrency">The base currency.</param>
        /// <param name="targetCurrency">The target currency.</param>
        /// <returns>
        /// The currency.
        /// </returns>
        public async override Task<IActionResult> GetExchangeRateData(string days, string baseCurrency, string targetCurrency)
        {
            try
            {
                var exchangeRateData = await this.currencyService.GetExchangeRateData(days, baseCurrency, targetCurrency);
                if(exchangeRateData != null)
                {
                    return this.Ok(exchangeRateData);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
