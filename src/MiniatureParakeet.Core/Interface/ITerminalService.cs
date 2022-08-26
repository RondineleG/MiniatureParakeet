using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Interface
{
    public interface ITerminalService
    {
        List<Terminal> GetAllTerminals();

        Terminal FindTerminal(int idTerminal);

        bool AddTerminal(Terminal terminal);

        Terminal UpdateTerminal(Terminal terminal);

        bool DeleteTerminal(Terminal terminal);
    }
}
