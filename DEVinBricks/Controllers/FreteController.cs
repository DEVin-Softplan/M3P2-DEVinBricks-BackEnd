using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        private readonly IFreteRepository _freteRepository;

        public FreteController(IFreteRepository freteRepository)
        {
            _freteRepository = freteRepository;
        }

        /// <summary>
        /// Busca Frete pelo Id
        /// </summary>
        /// <param name="id">Filtra pelo Id do frete.</param>
        /// <returns>Dados do frete</returns>
        /// <response code="200">Frete encontrado.</response>
        /// <response code="401">Administrador não está autenticado no sistema.</response>
        /// <response code="403">Administrador não tem permissão para acessar essa informação.</response>
        /// <response code="404">Frete não encontrado.</response>
        [HttpGet("/Frete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "admin")]
        public async Task<ActionResult<IEnumerable<FreteModel>>> ObterFretePorId(int id)
        {
            var frete = _freteRepository.ObterFretePorId(id);
            if (frete == null) return NotFound("Frete não encontrado no sistema.");
            return Ok(frete);
        }
    }
}
