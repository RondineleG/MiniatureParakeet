using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Interface
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();

        Country FindCountry(int IdCountry);

        bool AddCountry(Country country);

        Country UpdateCountry(Country country);

        bool DeleteCountry(Country country);
    }
}
