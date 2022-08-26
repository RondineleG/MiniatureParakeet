using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Interface
{
    public interface ICityService
    {
        List<City> GetAllCities();

        City FindCity(int IdCity);

        List<City> GetAllCitiesByState(int IdState);

        bool AddCity(City city);

        City UpdateCity(City city);

        bool DeleteCity(City city);
    }
}
