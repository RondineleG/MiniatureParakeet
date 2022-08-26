using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Infrastructure.DataAccess
{
    public class CountryDataAccess : ICountryRepository
    {
        private readonly RegisterDataContext _context;

        public CountryDataAccess(RegisterDataContext context)
        {
            _context = context;
        }

        public List<Country> GetAll()
        {
            List<Country> data = this._context.Countries.OrderBy(country => country.NameCountry).ToList();
            return data;
        }

        public bool Add(Country country)
        {
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Country Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();

            return country;
        }

        public Country Find(int idCountry)
        {
            Country model = _context.Countries.FirstOrDefault(v => v.IdCountry == idCountry);

            return model;
        }

        public bool Delete(Country country)
        {
            try
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
