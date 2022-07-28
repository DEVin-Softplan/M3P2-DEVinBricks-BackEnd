using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class CompradorController : ControllerBase
    {
        private ICompradorRepository _compradorRepository;
    
        public CompradorController(ICompradorRepository compradorContext)
        {
            _compradorRepository = compradorContext;
        }

        /// <summary>
        /// Cadastra um Comprador
        /// </summary>
        /// <returns>Comprador cadastrado com sucesso!</returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /Comprador
        ///     {
        ///        "nome": "Nome Comprador",
        ///        "email": "exemplopost@email.com.br",
        ///        "telefone": "(12) 3456-7890",
        ///        "dataDeNascimento": "01/01/2000",
        ///        "cpf": "012.345.678-90",
        ///        "ativo": 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="400">Já existe Comprador com este E-mail ou CPF cadastrado.</response>
        [HttpPost(Name = "CriarComprador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarComprador([FromBody] CompradorPostDTO comprador)
        {
            int authUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (_compradorRepository.VerificaSeExisteEmailComprador(comprador.Email))
                return BadRequest($"O E-mail '{comprador.Email}' já está cadastrado");
            if (_compradorRepository.VerificaSeExisteCPFComprador(comprador.CPF))
                return BadRequest($"O CPF '{comprador.CPF}' já está cadastrado");
            var resultado = await _compradorRepository.CadastrarComprador(comprador, authUserId);
            return Ok(new { message = "Comprador cadastrado com sucesso!", Id = resultado, NovoComprador = comprador });
        }

        /// <summary>
        /// Busca Comprador pelo Id
        /// </summary>
        /// <param name="id">Busca Id do Comprador.</param>
        /// <returns>Dados do Comprador</returns>
        /// <response code="200">Comprador encontrado.</response>
        /// <response code="404">Comprador não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Comprador>>> ObterCompradorPeloId(int id)
        {
            var comprador = _compradorRepository.ObterPeloId(id);
            if (comprador == null) return NotFound("Comprador não encontrado");
            return Ok(comprador);
        }

        /// <summary>
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
        public ActionResult<Comprador> ObterListaCompradores(string? nome, string? cpf, int pagina = 0, int tamanhopagina = 10)
        {
            CompradorGetDTO comprador = CompradorGetDTO.ConverterParaEntidadeCompradorGetDTO(nome, cpf, pagina, tamanhopagina);
            var resultado = _compradorRepository.ListarGetComprador(comprador);
            if (resultado.Count() == 0)
                return NotFound("Nenhum resultado encontrado com os parâmetros passados.");
            return Ok(new { Pagina = pagina, TamanhoPagina = tamanhopagina, Resultados = resultado });
        }

        /// <summary>
        /// Altera dados do Comprador
        /// </summary>
        /// <param name="id">Busca Id do Comprador.</param>
        /// <returns>Alteração de dados do Comprador</returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     PATCH /Comprador
        ///     {
        ///        "email": "exemplopatch@email.com.br",
        ///        "telefone": "(12) 3456-7890"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Comprador alterado.</response>
        /// <response code="404">Nenhum Comprador encontrado.</response>
        /// <response code="400">Email já existente</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch]
        public IActionResult EditarComprador([FromBody] CompradorPatchDTO alteracao, int id)
        {
            int authUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            // verificar se o ID existe
            if (_compradorRepository.ObterPeloId(id) == null)
                return NotFound("Id não encontrado");
            if (_compradorRepository.VerificaSeExisteEmailComprador(alteracao.Email)) return BadRequest("O Email informado já existe.");
            // sucesso editado 201
            var model = _compradorRepository.EditarComprador(alteracao, authUserId, id);
            return Ok(new { message = "Comprador alterado.", Comprador = model });
        }

    }
}
