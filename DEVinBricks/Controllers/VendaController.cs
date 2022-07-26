using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using DEVinBricks.DTO;

namespace DEVinBricks.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase {
        private readonly IVendaService _service;
        public VendaController(IVendaService service) {
            _service = service;
        }

        /// <summary>
        /// Cadastra uma nova venda
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="201">Venda cadastrada com sucesso.</response>
        /// <response code="400">Venda não cadastrada.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("/cadastrarVenda")]
        public IActionResult CadastrarVenda([FromBody] int idProduto, int quantidadeProduto, int idComprador, int idVendedor) {
            if (!EhVendaValida(idProduto, quantidadeProduto, idComprador, idVendedor))
                return BadRequest();

            else {
                CadastraVenda(idProduto, quantidadeProduto, idComprador, idVendedor);
            }
        }
        private bool EhVendaValida(int idProduto, int quantidadeProduto, int idComprador, int idVendedor) {
            var produtoExiste = idProduto.exists();
            var compradorExiste = idComprador.exists();
            var vendedorExiste = idVendedor.exists();

            if ((produtoExiste == false || compradorExiste == false || vendedorExiste == false) && quantidadeProduto < 1) {
                return false;
            } else {
                return true;
            }
        }
        private void CadastraVenda(int idProduto, int quantidadeProduto, int idComprador, int idVendedor) {

        }
    }
}
