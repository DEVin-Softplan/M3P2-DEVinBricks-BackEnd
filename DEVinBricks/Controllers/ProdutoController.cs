using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly ICadastroDeProdutoRepository _context;


        public ProdutoController(IProdutoService service, ICadastroDeProdutoRepository context)
        {
            _service = service;
            _context = context;
        }

        /// <summary>
        /// Retorna um Produto.
        /// </summary>
        /// <returns>Retorna Produto conforme o parâmetro passado</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("ObterProduto"),HttpGet]
        public ActionResult ObterProduto(int id)
        {
            try
            {
                var response = _service.ObterProdutoPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("Produto Inexistente");
            }
        }

        /// <summary>
        /// Retorna Lista de Produtos.
        /// </summary>
        /// <returns>Lista de Produtos conforme os parâmetros passados</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("ListaProdutos"), HttpPost]
        //[Authorize(Policy = "admin")]
        public IActionResult ObterListaProduto(string? nome, int pagina, int tamanhoPagina)
        {
            var response = _service.ObterListaProduto(nome, pagina, tamanhoPagina);

            if (response.Count == 0)
                return NotFound("Nenhum Produto Encontrado");

            return Ok(response);
        }

        /// <summary>
        /// Edita um produto.
        /// </summary>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Parametro inválido.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Editar"), HttpPut]
       // [Authorize(Policy = "admin")]
        public IActionResult EditarProduto([FromBody] ObterProdutoPorIdDTO dto)
        {

            var IdUsuarioAlteracao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (dto.Valor == 0)
                return BadRequest("Valor deve ser maior que zero.");

            if (_service.VerificaNome(dto.Nome))
                return BadRequest("Produto com nome já existente.");

            var response = _service.EditarProduto(dto, IdUsuarioAlteracao);

            return Ok(response);
        }

        /// <summary>
        /// Cadastre um Produto
        /// </summary>
        /// <returns>Produto cadastrado com sucesso!</returns>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="400">Já existe Produto cadastrado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("api/Produto/CadastraProduto")]
        // [Authorize(Policy = "admin")]
        public async Task<ActionResult> CriarCadastroDeProduto([FromBody] CadastroDeProdutoDTO produtoDTO)
        {
            if (_context.VerificaSeExisteProduto(produtoDTO.Nome))
                return NotFound($"O Produto '{produtoDTO.Nome}' já existente");
            var cadastroInserido = await _context.CadastrarProduto(produtoDTO);
            return Ok(new
            {
                message = "Prosuto cadastrado com sucesso!",
                Id = cadastroInserido,
                NovoProduto = produtoDTO
            });
        }
    }
}
