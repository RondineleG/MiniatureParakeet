using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Core.Repositories
{
    public interface IStateRepository
    {
        List<State> GetAll();

        bool Add(State state);

        State Update(State state);

        State Find(int idState);

        bool Delete(State state);

        List<State> GetAllByCountry(int idCountry);
    }
}
