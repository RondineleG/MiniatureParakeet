using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Interface
{
    public interface IStateService
    {
        List<State> GetAllStates();

        State FindState(int IdState);

        List<State> GetAllStatesByCountry(int IdCountry);

        bool AddState(State state);

        State UpdateState(State state);

        bool DeleteState(State state);
    }
}
