using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;

namespace MiniatureParakeet.Core.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository cStateRepository)
        {
            _stateRepository = cStateRepository;
        }

        /// <summary>
        /// Get all registered states
        /// </summary>
        /// <returns>List of state object</returns>
        public List<State> GetAllStates()
        {
            return _stateRepository.GetAll();
        }

        /// <summary>
        /// Persist state if valid
        /// </summary>
        /// <param name="state">State Object</param>
        /// <returns>Success = true / Failure = false</returns>
        public bool AddState(State state)
        {
            try
            {
                if (state.IdState == null || state.IdState == 0)
                {
                    return _stateRepository.Add(state);
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

        /// <summary>
        /// Persist Updating state
        /// </summary>
        /// <param name="state">State Object</param>
        /// <returns>State updated</returns>
        public State UpdateState(State state)
        {
            try
            {
                if (state.IdState > 0)
                {
                    var updatedState = _stateRepository.Update(state);

                    return updatedState;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Delete state of database if valid
        /// </summary>
        /// <param name="state">State object</param>
        /// <returns>Sucess = true / Fail = false </returns>
        public bool DeleteState(State state)
        {
            try
            {
                if (state.IdState > 0)
                {
                    bool success = _stateRepository.Delete(state);

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

        /// <summary>
        /// Find only one State Object by ID
        /// </summary>
        /// <param name="idState">ID of State</param>
        /// <returns>State object</returns>
        public State FindState(int idState)
        {
            try
            {
                if (idState > 0)
                {
                    var state = _stateRepository.Find(idState);

                    return state;
                }
                else
                {
                    return new State();
                }
            }
            catch
            {
                return new State();
            }
        }

        public List<State> GetAllStatesByCountry(int IdCountry)
        {
            return _stateRepository.GetAllByCountry(IdCountry);
        }
    }
}
