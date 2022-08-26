using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Repositories
{
    public interface ICityRepository
    {
        List<City> GetAll();

        bool Add(City city);

        City Update(City city);

        City Find(int idCity);

        bool Delete(City city);

        List<City> GetAllByState(int idState);
    }
}
