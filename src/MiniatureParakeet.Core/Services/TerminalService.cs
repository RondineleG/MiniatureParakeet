using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Core.Service
{
    public class TerminalService : ITerminalService
    {
        private readonly ITerminalRepository _terminalRepository;

        public TerminalService(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;
        }

        public List<Terminal> GetAllTerminals()
        {
            return _terminalRepository.GetAll();
        }

        public bool AddTerminal(Terminal terminal)
        {
            try
            {
                if (terminal.IdTerminal == 0)
                {

                    return _terminalRepository.Add(terminal);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public Terminal UpdateTerminal(Terminal terminal)
        {
            try
            {
                if (terminal.IdTerminal > 0)
                {
                    var updatedTerminal = _terminalRepository.Update(terminal);
                    return updatedTerminal;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public bool DeleteTerminal(Terminal terminal)
        {
            try
            {
                if (terminal.IdTerminal > 0)
                {
                    bool success = _terminalRepository.Delete(terminal);

                    return success;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public Terminal FindTerminal(int idTerminal)
        {
            try
            {
                if (idTerminal > 0)
                {
                    var terminal = _terminalRepository.Find(idTerminal);
                    return terminal;
                }
                else
                {
                    return new Terminal();
                }
            }
            catch
            {
                return new Terminal();
            }
        }
    }
}
