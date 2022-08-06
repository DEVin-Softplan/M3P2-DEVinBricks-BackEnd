using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DEVinBricks.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase {
        const int maxPageSize = 20;
        private IVendaRepository _service;
        public VendaController(IVendaRepository context) {
            _service = context;
        }

        /// <summary>
        /// Cadastra uma Venda
        /// </summary>
        /// <returns>Venda cadastrada com sucesso!</returns>
        /// <response code="201">Cadastro realizado com sucesso.</response>
        [HttpPost(Name = "CadastrarVenda")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public async Task<IActionResult> CadastrarVenda([FromBody] VendaPostDTO Venda/*, VendaProdutoPostDTO VendaProduto*/) {
            var IdUsuarioInclusao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var resultado = await _service.CadastrarVenda(Venda, IdUsuarioInclusao);
            return Ok(new { message = "Venda cadastrada com sucesso!", Id = resultado, NovaVenda = Venda });
        }

        /// <summary>
        /// Busca Venda pelo Id
        /// </summary>
        /// <param name="id">Busca Id da Venda.</param>
        /// <returns>Dados da Venda</returns>
        /// <response code="200">Venda encontrada.</response>
        /// <response code="404">Venda não encontrada.</response>
        [HttpGet("/Venda/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Repositories.Models.VendaModel>>> ObterVendaPeloId(int id) {
            var Venda = _service.ObterPeloId(id);
            if (Venda == null) return NotFound("Venda não encontrada");
            return Ok(Venda);
        }

        /// <summary>
        /// Consulta lista de Vendas por comprador.
        /// </summary>
        /// <param name="nome">Filtra por nome do Comprador.</param>
        /// <param name="cpf">Filtra por nome CPF do Comprador.</param>
        /// <param name="page">Número da página.</param>
        /// <param name="size">Tamanho da página.</param>
        /// <returns>Vendas.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Venda não encontrada.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize]
        public IActionResult ConsultarVendaPorComprador(string? nome, string? cpf, int page = 1, int size = 10) {
            if (size > maxPageSize) {
                size = maxPageSize;
            }

            var resultado = _service.ConsultarVendaPorComprador(nome, cpf, page, size);

            return Ok(resultado);
        }
    }
}