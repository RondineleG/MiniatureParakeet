using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Infrastructure.DataAccess
{
    public class TerminalDataAccess : ITerminalRepository
    {
        private readonly RegisterDataContext _context;

        public TerminalDataAccess(RegisterDataContext context)
        {
            _context = context;
        }

        public List<Terminal> GetAll()
        {
            // List<Terminal> data = _context.Terminals.ToList();
            //foreach (Terminal terminal in data)
            //{
            //    terminal.City = _context.Cities.FirstOrDefault(c => c.IdCity == terminal.CityIdCity);
            //    terminal.City.State = _context.States.FirstOrDefault(s => s.IdState == terminal.City.StateIdState);
            //    terminal.City.State.Country = _context.Countries.FirstOrDefault(c => c.IdCountry == terminal.City.State.CountryIdCountry);
            //}
            return _context.Terminals.ToList(); ;
        }

        public bool Add(Terminal terminal)
        {
            try
            {
                _context.Terminals.Add(terminal);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Terminal Update(Terminal terminal)
        {
            _context.Terminals.Update(terminal);
            _context.SaveChanges();

            return terminal;
        }

        public Terminal Find(int idTerminal)
        {
            Terminal model = _context.Terminals.FirstOrDefault(v => v.IdTerminal == idTerminal);
            return model;
        }

        public bool Delete(Terminal teminal)
        {
            try
            {
                _context.Terminals.Remove(teminal);
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
