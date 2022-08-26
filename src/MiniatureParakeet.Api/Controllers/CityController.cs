using Microsoft.AspNetCore.Mvc;
using MiniatureParakeet.Api.Configurations;
using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;
using MiniatureParakeet.Core.Services;
using System.Net;

namespace Resilire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityRepository cityRepository)
        {
            _cityService = new CityService(cityRepository);
        }

        /// <summary>
        /// Service to get all cities
        /// </summary>
        /// <returns>List of City (Json)</returns>
        [HttpGet]
        public List<City> GetAll()
        {
            try
            {
                return _cityService.GetAllCities();
            }
            catch
            {
                throw new HttpResponseException("Failed to get city data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get just one city
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns>City object (Json)</returns>
        [HttpGet("{id}")]
        public City Get(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _cityService.FindCity(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get city data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get cities filtered by state
        /// </summary>
        /// <param name="id">State identificator</param>
        /// <returns>List of City (Json)</returns>
        [HttpGet("CitiesByState/{id}")]
        public List<City> GetAllByState(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _cityService.GetAllCitiesByState(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get city data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save a new city
        /// </summary>
        /// <param name="city">City object (Json)</param>
        /// <returns>City added object (Json)</returns>
        [HttpPost]
        public bool AddCity(City city)
        {
            #region Validation Data
            if (city == null)
            {
                throw new HttpResponseException("Invalid City Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(city.NameCity) || city.NameCity.Length > 100)
            {
                throw new HttpResponseException("Name of city Invalid", HttpStatusCode.BadRequest);
            }
            if (city.StateIdState is null)
            {
                throw new HttpResponseException("Name of state invalid", HttpStatusCode.Forbidden);
            }
            if (city.IbgeCodeCity.Length != 7)
            {
                throw new HttpResponseException("IBGE code invalid", HttpStatusCode.Forbidden);
            }
            #endregion

            try
            {
                return _cityService.AddCity(city);
            }
            catch
            {
                throw new HttpResponseException("Invalid City Integration JSON", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update a city
        /// </summary>
        /// <param name="city">City object (Json)</param>
        /// <returns>City added object (Json)</returns>
        [HttpPut]
        public City UpdateCity(City city)
        {
            #region Validation Data
            if (city == null)
            {
                throw new HttpResponseException("Invalid City Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(city.NameCity) || city.NameCity.Length > 100)
            {
                throw new HttpResponseException("Name of city Invalid", HttpStatusCode.BadRequest);
            }
            if (city.IbgeCodeCity.Length != 7)
            {
                throw new HttpResponseException("IBGE code invalid", HttpStatusCode.Forbidden);
            }
            #endregion

            try
            {
                return _cityService.UpdateCity(city);
            }
            catch
            {
                throw new HttpResponseException("Failed to update city data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete a city
        /// </summary>
        /// <param name="city">City object (Json)</param>
        /// <returns>True or False</returns>
        [HttpDelete]
        public bool DeleteCity(City city)
        {
            try
            {
                return _cityService.DeleteCity(city);
            }
            catch
            {
                return false;
            }
        }

    }
}
