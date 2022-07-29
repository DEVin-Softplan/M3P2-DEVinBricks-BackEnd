using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services;
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
        ///        "cpf": "012.345.678-90"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Cadastro realizado com sucesso.</response>
        /// <response code="400">Erro no pedido realizado.</response>
        [HttpPost(Name = "CriarComprador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarComprador([FromBody] CompradorPostDTO comprador)
        {
            string postCompradorCPF = comprador.CPF;
            comprador.CPF = Util.formataCPF(comprador.CPF);
            comprador.Telefone = Util.formataTelefone(comprador.Telefone);
            if (!Util.validaCPF(postCompradorCPF))
                return BadRequest($"O CPF '{postCompradorCPF}' não é válido.");
            if (!Util.validaEmail(comprador.Email))
                return BadRequest($"O E-mail '{comprador.Email}' não é valido.");
            if (_compradorRepository.VerificaSeExisteEmailComprador(comprador.Email))
                return BadRequest($"O E-mail '{comprador.Email}' já está cadastrado.");
            if (_compradorRepository.VerificaSeExisteCPFComprador(comprador.CPF))
                return BadRequest($"O CPF '{postCompradorCPF}' já está cadastrado.");
            int authUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var resultado = await _compradorRepository.CadastrarComprador(comprador, authUserId);
            return Created("Comprador cadastrado com sucesso!", new { Id = resultado, NovoComprador = comprador });
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
            if (comprador == null)
                return NotFound("Comprador não encontrado.");
            return Ok(comprador);
        }

        /// <summary>
        /// Retorna a lista de Comprador(es) conforme os parâmetros passados
        /// </summary>
        /// <returns>Lista de Comprador(es) conforme os parâmetros passados</returns>
        /// <param name="nome">Busca Nome do Comprador.</param>
        /// <param name="cpf">Busca CPF do Comprador.</param>
        /// <param name="pagina">Retorna a Página da Busca.</param>
        /// <param name="tamanhopagina">Retorna o Tamanho Página da Busca.</param>
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
        /// <response code="204">Comprador alterado.</response>
        /// <response code="400">Erro no pedido realizado.</response>
        /// <response code="404">Id não encontrado.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch]
        public IActionResult EditarComprador([FromBody] CompradorPatchDTO alteracao, int id)
        {
            int authUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            alteracao.Telefone = Util.formataTelefone(alteracao.Telefone);
            // verificar se o ID existe
            if (_compradorRepository.ObterPeloId(id) == null)
                return NotFound("Id não encontrado");
            if (!Util.validaEmail(alteracao.Email))
                return BadRequest($"O E-mail '{alteracao.Email}' não é valido.");
            if (_compradorRepository.VerificaSeExisteEmailComprador(alteracao.Email))
                return BadRequest($"O Email '{alteracao.Email}' já existe.");
            // sucesso editado 201
            var model = _compradorRepository.EditarComprador(alteracao, authUserId, id);
            return NoContent();
        }

    }
}
