using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        private ICompradorRepository _service;
        public CompradorController(ICompradorRepository context)
        {
            _service = context;
        }

        /// <summary>
        /// Cadastra um Comprador
        /// </summary>
        /// <returns>Comprador Cadastrado</returns>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarComprador([FromBody] CompradorDTO comprador)
        {
            var resultado = await _service.CadastrarComprador(comprador);
            return Ok(new { message = "Comprador cadastrado com sucesso!", Id = resultado, NovoComprador = comprador });
            //return Ok();
        }
    }
}
