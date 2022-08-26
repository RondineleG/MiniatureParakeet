using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Infrastructure.DataAccess
{
    public class CityDataAccess : ICityRepository
    {
        private readonly RegisterDataContext _context;

        public CityDataAccess(RegisterDataContext context)
        {
            _context = context;
        }

        public List<City> GetAll()
        {
            List<City> data = _context.Cities.OrderBy(city => city.NameCity).ToList();
            return data;
        }

        public bool Add(City city)
        {
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public City Update(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();

            return city;
        }

        public City Find(int idCity)
        {
            City model = _context.Cities.FirstOrDefault(v => v.IdCity == idCity);

            return model;
        }

        public bool Delete(City city)
        {
            try
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        List<City> ICityRepository.GetAllByState(int idState)
        {
            List<City> data = _context.Cities.Where(v => v.StateIdState == idState).OrderBy(city => city.NameCity).ToList();
            foreach (City city in data)
            {
                city.State = _context.States.FirstOrDefault(v => v.IdState == city.StateIdState);
            }
            return data;
        }
    }
}
