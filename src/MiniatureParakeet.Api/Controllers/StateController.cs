using Microsoft.AspNetCore.Mvc;
using MiniatureParakeet.Api.Configurations;
using MiniatureParakeet.Core.Entities;
using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;
using MiniatureParakeet.Core.Service;
using System.Net;

namespace Resilire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {

        private readonly IStateService _stateService;

        public StateController(ILogger<StateController> logger, IStateRepository stateRepository)
        {
            _stateService = new StateService(stateRepository);
        }

        /// <summary>
        /// Service to get all states
        /// </summary>
        /// <returns>List of State (Json)</returns>
        [HttpGet]
        public List<State> GetAll()
        {
            try
            {
                return _stateService.GetAllStates();
            }
            catch
            {
                throw new HttpResponseException("Failed to get state data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get just one state
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns>State object (Json)</returns>
        [HttpGet("{id}")]
        public State Get(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _stateService.FindState(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get state data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get states filtered by country
        /// </summary>
        /// <param name="id">Country identificator</param>
        /// <returns>List of State (Json)</returns>
        [HttpGet("StatesByCountry/{id}")]
        public List<State> GetAllByCountry(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _stateService.GetAllStatesByCountry(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get state data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save a new state
        /// </summary>
        /// <param name="state">State object (Json)</param>
        /// <returns>State added object (Json)</returns>
        [HttpPost]
        public bool AddState(State state)
        {
            #region Validation Data
            if (state == null)
            {
                throw new HttpResponseException("Invalid State Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(state.NameState) || state.NameState.Length > 100)
            {
                throw new HttpResponseException("Name of state Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _stateService.AddState(state);
            }
            catch
            {
                throw new HttpResponseException("Invalid State Integration JSON", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update a state
        /// </summary>
        /// <param name="state">State object (Json)</param>
        /// <returns>State added object (Json)</returns>
        [HttpPut]
        public State UpdateState(State state)
        {
            #region Validation Data
            if (state == null)
            {
                throw new HttpResponseException("Invalid State Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(state.NameState) || state.NameState.Length > 100)
            {
                throw new HttpResponseException("Name of state Invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _stateService.UpdateState(state);
            }
            catch
            {
                throw new HttpResponseException("Failed to update state data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete a state
        /// </summary>
        /// <param name="state">State object (Json)</param>
        /// <returns>True or False</returns>
        [HttpDelete]
        public bool DeleteState(State state)
        {
            try
            {
                return _stateService.DeleteState(state);
            }
            catch
            {
                return false;
            }
        }

    }
}
