using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
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
        /// <response code="400">Já existe Comprador com este E-mail ou CPF cadastrado.</response>
        [HttpPost(Name = "CriarComprador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarComprador([FromBody] CompradorPostDTO comprador)
        {
            if (_service.VerificaSeExisteEmailComprador(comprador.Email))
                return BadRequest($"O E-mail '{comprador.Email}' já está cadastrado");
            if (_service.VerificaSeExisteCPFComprador(comprador.CPF))
                return BadRequest($"O CPF '{comprador.CPF}' já está cadastrado");
            var resultado = await _service.CadastrarComprador(comprador);
            return Ok(new { message = "Comprador cadastrado com sucesso!", Id = resultado, NovoComprador = comprador });
        }

        /// <summary>
        /// Busca Comprador pelo Id
        /// </summary>
        /// <param name="id">Busca Id do Comprador.</param>
        /// <returns>Dados do Comprador</returns>
        /// <response code="200">Comprador encontrado.</response>
        /// <response code="404">Comprador não encontrado.</response>
        [HttpGet("/Comprador/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
    
        public async Task<ActionResult<IEnumerable<Repositories.Models.Comprador>>> ObterCompradorPeloId(int id)
        {
            var comprador = _service.ObterPeloId(id);
            if (comprador == null) return NotFound("Comprador não encontrado");
            return Ok(comprador);
        }
        /// Retorna a lista de Comprador(es) conforme os parâmetros passados
        /// </summary>
        /// <returns>Lista de Comprador(es) conforme os parâmetros passados</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        [HttpGet(Name = "GetComprador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "admin")]
        public ActionResult<Comprador> GetComprador(string? nome, string? cpf, int pagina = 0, int tamanhopagina = 10)
        {
            CompradorGetDTO comprador = CompradorGetDTO.ConverterParaEntidadeCompradorGetDTO(nome, cpf, pagina, tamanhopagina);
            var resultado = _service.ListarGetComprador(comprador);
            if (resultado.Count() == 0)
                return NotFound("Nenhum resultado encontrado com os parâmetros passados.");
            return Ok(new { Pagina = pagina, TamanhoPagina = tamanhopagina, Resultados = resultado });
        }
    }
}
