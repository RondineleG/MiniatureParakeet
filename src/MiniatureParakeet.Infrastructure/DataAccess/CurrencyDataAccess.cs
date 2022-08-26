using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Infrastructure.DataAccess
{
    public class CurrencyDataAccess : ICurrencyRepository
    {
        private readonly RegisterDataContext _context;

        public CurrencyDataAccess(RegisterDataContext context)
        {
            _context = context;
        }

        public List<Currency> GetAll()
        {
            List<Currency> data = this._context.Currencies.ToList();
            return data;
        }

        public bool Add(Currency currency)
        {
            try
            {
                _context.Currencies.Add(currency);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Currency Update(Currency currency)
        {
            _context.Currencies.Update(currency);
            _context.SaveChanges();

            return currency;
        }

        public Currency Find(int idCurrency)
        {
            Currency model = _context.Currencies.FirstOrDefault(v => v.IdCurrency == idCurrency);

            return model;
        }

        public bool Delete(Currency currency)
        {
            try
            {
                _context.Currencies.Remove(currency);
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
