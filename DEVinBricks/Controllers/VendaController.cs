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
    public class VendaController : ControllerBase
    {
        private IVendaRepository _service;
        public VendaController(IVendaRepository context)
        {
            _service = context;
        }

        /// <summary>
        /// Cadastra uma Venda
        /// </summary>
        /// <returns>Venda cadastrada com sucesso!</returns>
        /// <response code="201">Cadastro realizado com sucesso.</response>
//        /// <response code="400">Já existe Venda com este E-mail ou CPF cadastrado.</response>
        [HttpPost(Name = "CadastrarVenda")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize()]
        public async Task<IActionResult> CadastrarVenda([FromBody] VendaPostDTO Venda, VendaProdutoPostDTO VendaProduto)
        {
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

        public async Task<ActionResult<IEnumerable<Repositories.Models.VendaModel>>> ObterVendaPeloId(int id)
        {
            var Venda = _service.ObterPeloId(id);
            if (Venda == null) return NotFound("Venda não encontrada");
            return Ok(Venda);
        }

        /// <summary>
        /// Retorna a lista de Venda(s) conforme os parâmetros passados
        /// </summary>
        /// <returns>Lista de Venda(s) conforme os parâmetros passados</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        //[HttpGet(Name = "GetVenda")]
        [HttpGet("/Vendas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Policy = "admin")]
        public ActionResult<VendaModel> GetVenda(//string? nome, string? cpf, 
            int compradorId, int vendedorId, int pagina = 0, int tamanhopagina = 10)
        {
            VendaGetDTO Venda = VendaGetDTO.ConverterParaEntidadeVendaGetDTO(//nome, cpf, 
                compradorId, vendedorId, pagina, tamanhopagina);
            var resultado = _service.ListarGetVenda(Venda);
            if (resultado.Count() == 0)
                return NotFound("Nenhum resultado encontrado com os parâmetros passados.");
            return Ok(new { Pagina = pagina, TamanhoPagina = tamanhopagina, Resultados = resultado });
        }
    }
}