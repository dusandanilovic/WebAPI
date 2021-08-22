using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWebAPI.Controllers.Base
{
    /// <summary>
    /// The Currency controller base
    /// </summary>
    public abstract class CurrencyControllerBase : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyControllerBase"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CurrencyControllerBase(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <summary>
        /// Get exchange rate data
        /// </summary>
        /// <param name="days">Set of dates separated by comma. [yyyy-MM-dd]</param>
        /// <param name="baseCurrency">The base currency.</param>
        /// <param name="targetCurrency">The target currency.</param>
        /// <returns>
        /// The currency.
        /// </returns>
        [HttpGet("exchangeRates")]
        [SwaggerOperation(OperationId = "Forecast", Summary = "Get forecast")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public abstract Task<IActionResult> GetExchangeRateData(string days, string baseCurrency, string targetCurrency);
    }
}
