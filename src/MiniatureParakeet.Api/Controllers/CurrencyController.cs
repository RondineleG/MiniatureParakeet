using Microsoft.AspNetCore.Mvc;
using MiniatureParakeet.Api.Configurations;
using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;
using MiniatureParakeet.Core.Service;
using System.Net;

namespace Resilire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;

        private readonly ICurrencyService _currencyService;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyRepository currencyRepository)
        {
            _logger = logger;

            _currencyService = new CurrencyService(currencyRepository);
        }

        /// <summary>
        /// Service to get all currencies
        /// </summary>
        /// <returns>List of Currency (Json)</returns>
        [HttpGet]
        public List<Currency> GetAll()
        {
            try
            {
                return _currencyService.GetAllCurrencies();
            }
            catch
            {
                throw new HttpResponseException("Failed to get currency data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get just one currency
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns>Currency object (Json)</returns>
        [HttpGet("{id}")]
        public Currency Get(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _currencyService.FindCurrency(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get currency data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save a new currency
        /// </summary>
        /// <param name="currency">Currency object (Json)</param>
        /// <returns>Currency added object (Json)</returns>
        [HttpPost]
        public bool AddCurrency(Currency currency)
        {
            #region Validation Data
            if (currency == null)
            {
                throw new HttpResponseException("Invalid Currency Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(currency.DescriptionCurrency) || currency.DescriptionCurrency.Length > 200)
            {
                throw new HttpResponseException("Description of currency Invalid", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(currency.AcronymCurrency) || currency.AcronymCurrency.Length > 3)
            {
                throw new HttpResponseException("Currency Acronym Invalid", HttpStatusCode.BadRequest);
            }

            if (!String.IsNullOrEmpty(currency.BacenCodeCurrency) && currency.BacenCodeCurrency.Length > 3)
            {
                throw new HttpResponseException("Bacen Code of currency Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                bool response = _currencyService.AddCurrency(currency);
                if (!response)
                {
                    throw new HttpResponseException("Invalid Currency. Acronym and Bacen code should be unique.", HttpStatusCode.BadRequest);
                }
                return response;
            }
            catch
            {
                throw new HttpResponseException("Invalid Currency Integration JSON", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update a currency
        /// </summary>
        /// <param name="currency">Currency object (Json)</param>
        /// <returns>State added object (Json)</returns>
        [HttpPut]
        public Currency UpdateCurrency(Currency currency)
        {
            #region Validation Data
            if (currency == null)
            {
                throw new HttpResponseException("Invalid Currency Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(currency.DescriptionCurrency) || currency.DescriptionCurrency.Length > 200)
            {
                throw new HttpResponseException("Description of currency Invalid", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(currency.AcronymCurrency) || currency.AcronymCurrency.Length > 3)
            {
                throw new HttpResponseException("Currency Acronym Invalid", HttpStatusCode.BadRequest);
            }

            if (currency.BacenCodeCurrency.Length > 3)
            {
                throw new HttpResponseException("Bacen Code of currency Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _currencyService.UpdateCurrency(currency);
            }
            catch
            {
                throw new HttpResponseException("Failed to update currency data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete a currency
        /// </summary>
        /// <param name="currency">Currency object (Json)</param>
        /// <returns>True or False</returns>
        [HttpDelete]
        public bool DeleteCurrency(Currency currency)
        {
            try
            {
                return _currencyService.DeleteCurrency(currency);
            }
            catch
            {
                return false;
            }
        }

    }
}
