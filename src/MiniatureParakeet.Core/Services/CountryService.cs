using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Core.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Get all country
        /// </summary>
        /// <returns>List of country object</returns>
        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAll();
        }

        /// <summary>
        /// Persist country if valid
        /// </summary>
        /// <param name="country">Country Object</param>
        /// <returns>Success = true / Failure = false</returns>
        public bool AddCountry(Country country)
        {
            try
            {
                if (country.IdCountry == null || country.IdCountry == 0)
                {
                    return _countryRepository.Add(country);
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
        /// Persist Updating country
        /// </summary>
        /// <param name="country">Country Object</param>
        /// <returns>Country updated</returns>
        public Country UpdateCountry(Country country)
        {
            try
            {
                if (country.IdCountry > 0)
                {
                    var updatedCountry = _countryRepository.Update(country);

                    return updatedCountry;
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
        /// Delete country of database if valid
        /// </summary>
        /// <param name="country">Country object</param>
        /// <returns>Sucess = true / Fail = false </returns>
        public bool DeleteCountry(Country country)
        {
            try
            {
                if (country.IdCountry > 0)
                {
                    bool success = _countryRepository.Delete(country);

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
        /// Find only one country Object by ID
        /// </summary>
        /// <param name="idcountry">ID of Country</param>
        /// <returns>country object</returns>
        public Country FindCountry(int idCountry)
        {
            try
            {
                if (idCountry > 0)
                {
                    var country = _countryRepository.Find(idCountry);

                    return country;
                }
                else
                {
                    return new Country();
                }
            }
            catch
            {
                return new Country();
            }
        }
    }
}
