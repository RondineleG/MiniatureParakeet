using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Infrastructure.DataAccess
{
    public class StateDataAccess : IStateRepository
    {
        private readonly RegisterDataContext _context;

        public StateDataAccess(RegisterDataContext context)
        {
            _context = context;
        }

        public List<State> GetAll()
        {
            List<State> data = this._context.States.OrderBy(state => state.NameState).ToList();
            return data;
        }

        public bool Add(State state)
        {
            try
            {
                _context.States.Add(state);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public State Update(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();

            return state;
        }

        public State Find(int idState)
        {
            State model = _context.States.FirstOrDefault(v => v.IdState == idState);

            return model;
        }

        public bool Delete(State state)
        {
            try
            {
                _context.States.Remove(state);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        List<State> IStateRepository.GetAllByCountry(int idCountry)
        {
            List<State> data = this._context.States.Where(v => v.CountryIdCountry == idCountry).OrderBy(state => state.NameState).ToList();
            foreach (State state in data)
            {
                state.Country = _context.Countries.FirstOrDefault(v => v.IdCountry == state.CountryIdCountry);
            }
            return data;
        }
    }
}
