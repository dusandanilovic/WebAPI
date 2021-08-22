using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWebAPI.Controllers.Base
{
    /// <summary>
    /// API controller base
    /// </summary>
    /// <seealso cref="Controller" />
    public class ControllerBase : Controller
    {
        /// <summary>
        /// The service provider
        /// </summary>
        protected readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ControllerBase(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
