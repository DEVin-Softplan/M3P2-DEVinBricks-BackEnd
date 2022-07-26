using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IObterProdutoService _service;

        public ProdutoController(IObterProdutoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna um Produto.
        /// </summary>
        /// <returns>Retorna Produto conforme o parâmetro passado</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
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
        [HttpPost]
        //[Authorize(Policy = "admin")]
        public IActionResult ObterListaProduto(string? nome, int pagina, int tamanhoPagina)
        {
            var response = _service.ObterListaProduto(nome, pagina, tamanhoPagina);

            if (response.Count == 0)
                return NotFound("Nenhum Produto Encontrado");

            return Ok(response);
        }
    }
}
