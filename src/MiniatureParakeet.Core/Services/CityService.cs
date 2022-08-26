using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Core.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        /// <summary>
        /// Get all registered cities
        /// </summary>
        /// <returns>List of city object</returns>
        public List<City> GetAllCities()
        {
            return _cityRepository.GetAll();
        }

        /// <summary>
        /// Persist city if valid
        /// </summary>
        /// <param name="city">City Object</param>
        /// <returns>Success = true / Failure = false</returns>
        public bool AddCity(City city)
        {
            try
            {
                if (city.IdCity == null || city.IdCity == 0)
                {
                    return _cityRepository.Add(city);
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
        /// Persist Updating city
        /// </summary>
        /// <param name="city">City Object</param>
        /// <returns>City updated</returns>
        public City UpdateCity(City city)
        {
            try
            {
                if (city.IdCity > 0)
                {
                    City updatedCity = _cityRepository.Update(city);

                    return updatedCity;
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
        /// Delete city of database if valid
        /// </summary>
        /// <param name="city">City object</param>
        /// <returns>Sucess = true / Fail = false </returns>
        public bool DeleteCity(City city)
        {
            try
            {
                if (city.IdCity > 0)
                {
                    bool success = _cityRepository.Delete(city);

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
        /// Find only one City Object by ID
        /// </summary>
        /// <param name="idCity">ID of City</param>
        /// <returns>City object</returns>
        public City FindCity(int idCity)
        {
            try
            {
                if (idCity > 0)
                {
                    City city = _cityRepository.Find(idCity);

                    return city;
                }
                else
                {
                    return new City();
                }
            }
            catch
            {
                return new City();
            }
        }

        public List<City> GetAllCitiesByState(int IdState)
        {
            return _cityRepository.GetAllByState(IdState);
        }
    }
}
