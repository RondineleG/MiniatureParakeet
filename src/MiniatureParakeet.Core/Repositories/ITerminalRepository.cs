using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Repositories
{
    public interface ITerminalRepository
    {
        List<Terminal> GetAll();

        bool Add(Terminal terminal);

        Terminal Update(Terminal terminal);

        Terminal Find(int idTerminal);

        bool Delete(Terminal terminal);
    }
}