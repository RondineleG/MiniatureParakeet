using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Core.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        /// <summary>
        /// Get all registered currencies
        /// </summary>
        /// <returns>List of currency object</returns>
        public List<Currency> GetAllCurrencies()
        {
            return _currencyRepository.GetAll();
        }

        /// <summary>
        /// Persist currency if valid
        /// </summary>
        /// <param name="currency">Currency Object</param>
        /// <returns>Success = true / Failure = false</returns>
        public bool AddCurrency(Currency currency)
        {
            try
            {
                if (currency.IdCurrency == null || currency.IdCurrency == 0)
                {
                    return _currencyRepository.Add(currency);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Persist Updating currency
        /// </summary>
        /// <param name="currency">Currency Object</param>
        /// <returns>Currency updated</returns>
        public Currency UpdateCurrency(Currency currency)
        {
            try
            {
                if (currency.IdCurrency > 0)
                {
                    var updatedCurrency = _currencyRepository.Update(currency);

                    return updatedCurrency;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Delete currency of database if valid
        /// </summary>
        /// <param name="currency">Currency object</param>
        /// <returns>Sucess = true / Fail = false </returns>
        public bool DeleteCurrency(Currency currency)
        {
            try
            {
                if (currency.IdCurrency > 0)
                {
                    bool success = _currencyRepository.Delete(currency);

                    return success;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Find only one currency Object by ID
        /// </summary>
        /// <param name="idcurrency">ID of Currency</param>
        /// <returns>currency object</returns>
        public Currency FindCurrency(int idCurrency)
        {
            try
            {
                if (idCurrency > 0)
                {
                    var currency = _currencyRepository.Find(idCurrency);

                    return currency;
                }
                else
                {
                    return new Currency();
                }
            }
            catch
            {
                return new Currency();
            }
        }

    }
}
