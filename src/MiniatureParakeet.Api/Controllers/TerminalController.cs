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
    public class TerminalController : ControllerBase
    {
        private readonly ILogger<TerminalController> _logger;
        private readonly ITerminalService _terminalService;

        public TerminalController(ILogger<TerminalController> logger, ITerminalRepository terminalRepository)
        {
            _logger = logger;
            _terminalService = new TerminalService(terminalRepository);
        }

        /// <summary>
        /// Service to get all terminals
        /// </summary>
        /// <returns>List of terminals (Json)</returns>
        [HttpGet]
        public List<Terminal> GetAll()
        {
            try
            {
                return _terminalService.GetAllTerminals();
            }
            catch
            {
                throw new HttpResponseException("Failed to get terminal data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Service to get just one terminal
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns>Terminal object (Json)</returns>
        [HttpGet("{id}")]
        public Terminal Get(int id)
        {
            #region Validation Data
            if (id == 0)
            {
                throw new HttpResponseException("Invalid Id", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _terminalService.FindTerminal(id);
            }
            catch
            {
                throw new HttpResponseException("Failed to get terminal data", HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save a new terminal
        /// </summary>
        /// <param name="terminal">terminal object (Json)</param>
        /// <returns>terminal added object (Json)</returns>
        [HttpPost]
        public bool AddTerminal(Terminal terminal)
        {
            #region Validation Data
            if (terminal == null)
            {
                throw new HttpResponseException("Invalid terminal Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(terminal.NameTerminal) || terminal.NameTerminal.Length > 100)
            {
                throw new HttpResponseException("Name of terminal Invalid", HttpStatusCode.BadRequest);
            }

            if (terminal.CityIdCity <= 0)
            {
                throw new HttpResponseException("City of terminal is invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _terminalService.AddTerminal(terminal);
            }
            catch (HttpResponseException)
            {
                throw new HttpResponseException("Invalid Terminal Integration JSON", HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(e.Message, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Update a terminal
        /// </summary>
        /// <param name="terminal">Terminal object (Json)</param>
        /// <returns>terminal added object (Json)</returns>
        [HttpPut]
        public Terminal UpdateTerminal(Terminal terminal)
        {
            #region Validation Data
            if (terminal == null)
            {
                throw new HttpResponseException("Invalid terminal Integration JSON", HttpStatusCode.BadRequest);
            }

            if (String.IsNullOrEmpty(terminal.NameTerminal) || terminal.NameTerminal.Length > 100)
            {
                throw new HttpResponseException("Name of terminal Invalid", HttpStatusCode.BadRequest);
            }


            if (terminal.CityIdCity <= 0)
            {
                throw new HttpResponseException("City of terminal is invalid", HttpStatusCode.BadRequest);
            }
            #endregion

            try
            {
                return _terminalService.UpdateTerminal(terminal);
            }
            catch (HttpResponseException)
            {
                throw new HttpResponseException("Failed to update terminal data", HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(e.Message, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete a terminal
        /// </summary>
        /// <param name="terminal">Terminal object (Json)</param>
        /// <returns>True or False</returns>
        [HttpDelete]
        public bool DeleteTerminal(Terminal terminal)
        {
            try
            {
                return _terminalService.DeleteTerminal(terminal);
            }
            catch
            {
                return false;
            }
        }

    }
}
