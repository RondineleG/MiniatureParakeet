using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Repositories
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAll();

        bool Add(Currency currency);

        Currency Update(Currency currency);

        Currency Find(int idCurrency);

        bool Delete(Currency currency);
    }
}
