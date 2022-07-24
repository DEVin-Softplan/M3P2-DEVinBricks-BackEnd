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
        /// <returns>Comprador cadastrado com sucesso!</returns>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="404">Já existe Comprador com este E-mail ou CPF cadastrado.</response>
        [HttpPost(Name = "CriarComprador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarComprador([FromBody] CompradorDTO comprador)
        {
            if (_service.VerificaSeExisteEmailComprador(comprador.Email))
                return BadRequest($"O E-mail '{comprador.Email}' já está cadastrado");
            if (_service.VerificaSeExisteCPFComprador(comprador.CPF))
                return BadRequest($"O CPF '{comprador.CPF}' já está cadastrado");
            var resultado = await _service.CadastrarComprador(comprador);
            return Ok(new { message = "Comprador cadastrado com sucesso!", Id = resultado, NovoComprador = comprador });
        }
    }
}
