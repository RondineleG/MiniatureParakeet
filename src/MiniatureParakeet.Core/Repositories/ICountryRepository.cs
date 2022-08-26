using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetAll();

        bool Add(Country country);

        Country Update(Country country);

        Country Find(int idCountry);

        bool Delete(Country country);

    }
}
