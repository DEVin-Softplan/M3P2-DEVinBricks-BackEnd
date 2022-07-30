using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosService _service;

        public EstadosController(IEstadosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Consulta lista de Estados
        /// </summary>
        /// <returns>Lista de Estados.</returns>
        /// <response code="200">Lista de Estados cadastrados.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Estados não encontradoas.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IActionResult Consultar()
        {

            var resultado = _service.ConsultarEstados();

            return Ok(resultado);
        }
    }
}
