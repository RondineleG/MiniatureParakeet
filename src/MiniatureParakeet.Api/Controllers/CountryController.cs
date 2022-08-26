using Microsoft.AspNetCore.Mvc;
using MiniatureParakeet.Api.Configurations;
using MiniatureParakeet.Core.Service;
using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;
using System.Net;

namespace Resilire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository)
        {
            _countryService = new CountryService(countryRepository);
        }

        /// <summary>
        /// Service to get all Country
        /// </summary>
        /// <returns>List of Country (Json)</returns>
        [HttpGet]
        public List<Country> GetAll()
        {
            try
            {
                return _countryService.GetAllCountries();
            }
            catch
            {
                throw new HttpResponseException("Failed to get country data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get just one country
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns>Country object (Json)</returns>
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _countryService.FindCountry(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get country data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save a new country
        /// </summary>
        /// <param name="country">Country object (Json)</param>
        /// <returns>Country added object (Json)</returns>
        [HttpPost]
        public bool AddCountry(Country country)
        {
            #region Validation Data
            if (country == null)
            {
                throw new HttpResponseException("Invalid Country Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(country.NameCountry) || country.NameCountry.Length > 100)
            {
                throw new HttpResponseException("Name of Country Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _countryService.AddCountry(country);
            }
            catch
            {
                throw new HttpResponseException("Invalid Country Integration JSON", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update a country
        /// </summary>
        /// <param name="country">Country object (Json)</param>
        /// <returns>State added object (Json)</returns>
        [HttpPut]
        public Country UpdateCountry(Country country)
        {
            #region Validation Data
            if (country == null)
            {
                throw new HttpResponseException("Invalid Country Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(country.NameCountry) || country.NameCountry.Length > 100)
            {
                throw new HttpResponseException("Name of country Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _countryService.UpdateCountry(country);
            }
            catch
            {
                throw new HttpResponseException("Failed to update country data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete a country
        /// </summary>
        /// <param name="country">Country object (Json)</param>
        /// <returns>True or False</returns>
        [HttpDelete]
        public bool DeleteCountry(Country country)
        {
            try
            {
                return _countryService.DeleteCountry(country);
            }
            catch
            {
                return false;
            }
        }

    }
}