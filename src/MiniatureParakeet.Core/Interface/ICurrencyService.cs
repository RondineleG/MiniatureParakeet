using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Interface
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies();

        Currency FindCurrency(int IdCurrency);

        bool AddCurrency(Currency currency);

        Currency UpdateCurrency(Currency currency);

        bool DeleteCurrency(Currency currency);
    }
}
